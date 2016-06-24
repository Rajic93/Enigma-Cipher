using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Encryption_Algorithm;
using System.IO;
using System.Collections.Concurrent;

namespace Lab_1
{
    public partial class MainForm : Form
    {
        private ICryptingAlgorithm _cypherDT;
        private ICryptingAlgorithm _cypherA51;
        private Knapsack _knapsack;
        private KnapsackSimulator _simulatorKnap;
        private string _invalidKey = "";
        private DateTime _watcherLastActive;
        private ConcurrentQueue<string> _queue;
        private bool _readFromQueue;
        private byte[] _binaryKey;
        private uint[] _knapsackPrivateKey;
        private byte[] _initializationVector;
        private bool _cancel = false;
        public bool simulation = false;
        private SimulatorA51 _simulator;
        private bool _tea_xtea;

        public MainForm()
        {
            _simulator = new SimulatorA51(this);
            _cypherDT = DoubleTransposition.GetInstance();
            _queue = new ConcurrentQueue<string>();
            _readFromQueue = true;
            _knapsack = new Knapsack();
            _simulatorKnap = new KnapsackSimulator();
            _simulatorKnap.setPrivateKey(2, 8);
            InitializeComponent();
        }

        private string _dest;

        private void btnChooseKey_Click(object sender, EventArgs e)
        {
            ChooseKey();
        }

        private void ChooseKey()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = openFileDialog.OpenFile();
                try
                {
                    if (radioButtonA51.Checked)
                    {
                        try
                        {
                            byte[] key = File.ReadAllBytes(openFileDialog.FileName);
                            txtA51.Text = System.Text.Encoding.ASCII.GetString(key);
                            _binaryKey = key;
                            _cancel = false;
                            if (MessageBox.Show("Do you want to crypt all files?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                CryptAllFiles();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (radioButtonDoubleTransposition.Checked)
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string rowKey = reader.ReadLine();
                            string columnKey = reader.ReadLine();
                            if ((rowKey != null && columnKey != null) &&IsValidKey(rowKey, columnKey))
                            {
                                txtRowKey.Text = rowKey;
                                txtColumnKey.Text = columnKey;
                                _cancel = false;
                                if (MessageBox.Show("Do you want to crypt all files?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    CryptAllFiles();
                                }
                            }
                            else
                            {
                                if (rowKey == null && columnKey == null)
                                {
                                    _invalidKey = "Invalid row and column keys.";
                                }
                                else if (rowKey == null)
                                {
                                    _invalidKey = "Invalid row key.";
                                    txtColumnKey.Text = columnKey;
                                }
                                else if (columnKey == null)
                                {
                                    _invalidKey = "Invalid column key.";
                                    txtRowKey.Text = rowKey;
                                }
                                MessageBox.Show(_invalidKey);
                            }
                        }
                    }
                    else if (radioButtonTEA.Checked)
                    {
                        try
                        {
                            byte[] key = File.ReadAllBytes(openFileDialog.FileName);
                            if (key.Length != 16)
                            {
                                throw new Exception("Invalid key. Length of key must be 128b.");
                            }
                            txtA51.Text = System.Text.Encoding.ASCII.GetString(key);
                            _binaryKey = key;
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                byte[] initVector = File.ReadAllBytes(openFileDialog.FileName);
                                if (initVector.Length != 8)
                                {
                                    throw new Exception("Invalid initialization vector. Length of initialization vector must be 64b.");
                                }
                                _initializationVector = initVector;
                                _cancel = false;
                                if (MessageBox.Show("Do you want to crypt all files?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    CryptAllFiles();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (radioButtonKnapsack.Checked)
                    {
                        byte[] key = File.ReadAllBytes(openFileDialog.FileName);
                        string text = System.Text.Encoding.ASCII.GetString(key);
                        txtA51.Text = text;
                        string[] nums = text.Split(' ');
                        _knapsackPrivateKey = new uint[32];
                        uint sum = 0;
                        for (int i = 0; i < nums.Length; i++)
                        {
                            _knapsackPrivateKey[i] = Convert.ToUInt32(nums[i]);
                            sum += _knapsackPrivateKey[i];
                        }
                        if (nums.Length < 32)
                        {
                            for (int j = nums.Length; j < 32; j++)
                            {
                                Random rand = new Random();
                                _knapsackPrivateKey[j] = sum + (uint)rand.Next(1, j);
                                sum += _knapsackPrivateKey[j];
                            }
                        }
                        _cancel = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to read from file. Please choose again.");
                    ChooseKey();
                }
            }
            _cancel = true;
        }

        private bool IsValidKey(string rowKey, string columnKey)
        {
            string[] rowIndexes = rowKey.Split(',');
            int counter = 0;
            for (int index = 0; index < rowIndexes.Length; index++)
            {
                if (rowIndexes.Contains(index.ToString()))
                {
                    counter++;
                }
            }
            if (counter != rowIndexes.Length)
            {
                _invalidKey = "Row key is not valid.";
            }
            string[] columnIndexes = columnKey.Split(',');
            counter = 0;
            for (int index = 0; index < columnIndexes.Length; index++)
            {
                if (columnIndexes.Contains(index.ToString()))
                {
                    counter++;
                }
            }
            if (counter != columnIndexes.Length)
            {
                if (!_invalidKey.Equals(""))
                {
                    _invalidKey = " Row and column keys are not valid.";
                }
                else
                {
                    _invalidKey = "Column key is not valid.";
                }
            }
            if (!_invalidKey.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (listBoxOriginalFiles.SelectedItem != null)
            {
                if (radioButtonTEA.Checked)
                {
                    if (_binaryKey == null)
                    {
                        MessageBox.Show("Key not set. Please choose key.");
                        ChooseKey();
                    }
                }
                else if (radioButtonKnapsack.Checked)
                {
                    if (_knapsackPrivateKey == null)
                    {
                        MessageBox.Show("Key not set. Please choose key.");
                        ChooseKey();
                    }
                }
                string[] parts = listBoxOriginalFiles.SelectedItem.ToString().Split('\\');
                string fileName = parts[parts.Length - 1].ToString().Split('.')[0];
                string message = null;
                if (radioButtonDoubleTransposition.Checked)
                {
                    string path = destinationFolderBrowserDialog.SelectedPath.ToString() + "\\" + fileName + ".cip";
                    if (!listBoxCryptedFiles.Items.Contains(path))
                    {
                        using (StreamReader reader = new StreamReader(listBoxOriginalFiles.SelectedItem.ToString()))
                        {
                            message = reader.ReadToEnd();
                        }
                        _cypherDT.SetProperties(true, txtRowKey.Text, txtColumnKey.Text, message);
                        message = _cypherDT.Encrypt();
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            writer.WriteLine(message);
                        }
                        listBoxCryptedFiles.Items.Add(path);
                    }
                }
                else if (radioButtonA51.Checked || radioButtonTEA.Checked || radioButtonKnapsack.Checked)
                {
                    string pathBinary = destinationFolderBrowserDialog.SelectedPath.ToString() + "\\" + parts[parts.Length - 1].ToString() + ".cip";
                    if (!listBoxCryptedFiles.Items.Contains(pathBinary))
                    {
                        string source = listBoxOriginalFiles.SelectedItem.ToString();
                        ThreadStart threadStart = delegate { EncryptFile(pathBinary, source); };
                        Thread t = new Thread(threadStart);
                        t.IsBackground = true;
                        t.Start();
                    }
                }
                listBoxCryptedFiles.SelectedItem = null;
                richTextBoxCryptedMessage.Text = message;
            }
        }

        private void EncryptFile(string path, string source)
        {
            if (radioButtonA51.Checked)
            {
                byte[] binaryMessage = File.ReadAllBytes(source);
                A51 cypher = new A51();
                cypher.SetProperties(binaryMessage, _binaryKey);
                cypher.Encrypt();
                byte[] cryptedMessage = cypher.GetCryptedMessage();
                File.WriteAllBytes(path, cryptedMessage);
                this.Invoke((MethodInvoker)delegate
                {
                    listBoxCryptedFiles.Items.Add(path);
                });
            }
            else if (radioButtonTEA.Checked)
            {
                byte[] binaryMessage = File.ReadAllBytes(source);
                if (checkBoxBMP.Checked)
                {
                    _dest = source;
                    if (_tea_xtea)
                    {
                        TEA tea = new TEA();
                        path = EncryptBMPFile(path, source, binaryMessage, tea);
                    }
                    else
                    {
                        XTEA tea = new XTEA(32);
                        path = EncryptBMPFile(path, source, binaryMessage, tea);
                    }
                }
                else
                {
                    if (_tea_xtea)
                    {
                        TEA tea = new TEA();
                        tea.SetProperties(_binaryKey, _initializationVector, binaryMessage, (short)BlockCipherMode.CBC);
                        tea.Encrypt();
                        byte[] cryptedMessage = tea.GetCryptedMessage();
                        File.WriteAllBytes(path, cryptedMessage);
                        this.Invoke((MethodInvoker)delegate
                        {
                            listBoxCryptedFiles.Items.Add(path);
                        });
                    }
                    else
                    {
                        XTEA tea = new XTEA(32);
                        tea.SetProperties(_binaryKey, _initializationVector, binaryMessage, (short)BlockCipherMode.CBC);
                        tea.Encrypt();
                        byte[] cryptedMessage = tea.GetCryptedMessage();
                        File.WriteAllBytes(path, cryptedMessage);
                        this.Invoke((MethodInvoker)delegate
                        {
                            listBoxCryptedFiles.Items.Add(path);
                        });
                    }
                }
            }
            else if (radioButtonKnapsack.Checked)
            {
                byte[] binaryMessage = File.ReadAllBytes(source);
                _knapsack.SetProperties(_knapsackPrivateKey, binaryMessage, 41, 491, (short)Mode.Standard);
                _knapsack.Encrypt();
                byte[] output = _knapsack.GetCryptedMesssage();
                /*byte[] output = new byte[binaryMessage.Length];
                for (int i = 0; i < binaryMessage.Length; i++)
                {
                    output[i] = _knapsack.encrypte(binaryMessage[i]);
                }*/
                File.WriteAllBytes(path, output);
                this.Invoke((MethodInvoker)delegate
                {
                    listBoxCryptedFiles.Items.Add(path);
                });
            }
        }

        private string EncryptBMPFile(string path, string source, byte[] binaryMessage, TEA tea)
        {
            long pos = binaryMessage[10] + 256 * (binaryMessage[11] + 256 * (binaryMessage[12] + 256 * binaryMessage[13]));
            byte[] pixels = new byte[binaryMessage.Length - pos];
            for (long i = pos; i < binaryMessage.Length; i++)
            {
                pixels[i - pos] = binaryMessage[i];
            }
            tea.SetProperties(_binaryKey, _initializationVector, binaryMessage, (short)BlockCipherMode.CBC);
            tea.Encrypt();
            byte[] cryptedMessage = (byte[])binaryMessage.Clone();
            pixels = tea.GetCryptedMessage();
            for (long i = pos; i < binaryMessage.Length; i++)
            {
                cryptedMessage[i] = pixels[i - pos];
            }
            string[] parts = path.Split('\\');
            path = path.Substring(0, path.Length - parts[parts.Length - 1].Length) + parts[parts.Length - 1].Split('.')[0]
                + "-cip." + parts[parts.Length - 1].Split('.')[1];
            {
                File.WriteAllBytes(path, cryptedMessage);
            }
            MemoryStream stream = new MemoryStream(cryptedMessage);
            Image bmp = Image.FromStream(stream);
            this.Invoke((MethodInvoker)delegate
            {
                pictureBoxOriginal.Image = Image.FromFile(source);
                listBoxCryptedFiles.Items.Add(path);
                pictureBoxCrypted.Image = bmp;

            });
            return path;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (listBoxCryptedFiles.SelectedItem != null)
            {
                string message = null; ;
                if (radioButtonA51.Checked || radioButtonTEA.Checked || radioButtonKnapsack.Checked)
                {
                    string source = listBoxCryptedFiles.SelectedItem.ToString();
                    ThreadStart thStart = delegate
                    {
                        DecryptFile(source);
                    };
                    Thread t = new Thread(thStart);
                    t.IsBackground = true;
                    t.Start();
                }
                else if (radioButtonDoubleTransposition.Checked)
                {
                    using (StreamReader reader = new StreamReader(listBoxCryptedFiles.SelectedItem.ToString()))
                    {
                        message = reader.ReadToEnd();
                    }
                    _cypherDT.SetProperties(false, txtRowKey.Text, txtColumnKey.Text, message);
                    message = _cypherDT.Decrypt();
                    listBoxOriginalFiles.SelectedItem = null;
                    richTextBoxOriginalMessage.Text = message;
                }
            }
        }

        private void DecryptFile(string source)
        {
            if (radioButtonA51.Checked)
            {
                byte[] binaryMessage = File.ReadAllBytes(source);
                A51 cypher = new A51();
                cypher.SetProperties(binaryMessage, _binaryKey);
                cypher.Decrypt();
                byte[] originalMessage = cypher.GetCryptedMessage();
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("File " + source + " decrypted");
                    listBoxOriginalFiles.SelectedItem = null;
                    richTextBoxOriginalMessage.Text = System.Text.Encoding.ASCII.GetString(originalMessage);
                });
            }
            else if (radioButtonTEA.Checked)
            {
                byte[] binaryMessage = File.ReadAllBytes(source);
                if (checkBoxBMP.Checked)
                {
                    if (_tea_xtea)
                    {
                        TEA tea = new TEA();
                        DecryptBMPFile(source, binaryMessage, tea);
                    }
                    else
                    {
                        XTEA tea = new XTEA(32);
                        DecryptBMPFile(source, binaryMessage, tea);
                    }
                }
                else
                {
                    if (_tea_xtea)
                    {
                        TEA tea = new TEA();
                        tea.SetProperties(_binaryKey, _initializationVector, binaryMessage, (short)BlockCipherMode.CBC);
                        tea.Decrypt();
                        byte[] originalMessage = tea.GetCryptedMessage();
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("File " + source + " decrypted");
                            listBoxOriginalFiles.SelectedItem = null;
                            richTextBoxOriginalMessage.Text = System.Text.Encoding.ASCII.GetString(originalMessage);
                        });
                    }
                    else
                    {
                        XTEA tea = new XTEA(32);
                        tea.SetProperties(_binaryKey, _initializationVector, binaryMessage, (short)BlockCipherMode.CBC);
                        tea.Decrypt();
                        byte[] originalMessage = tea.GetCryptedMessage();
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("File " + source + " decrypted");
                            listBoxOriginalFiles.SelectedItem = null;
                            richTextBoxOriginalMessage.Text = System.Text.Encoding.ASCII.GetString(originalMessage);
                        });
                    }
                }
            }
            else if (radioButtonKnapsack.Checked)
            {
                byte[] binaryMessage = File.ReadAllBytes(source);
                Knapsack _knapsack = new Knapsack();
                _knapsack.SetProperties(_knapsackPrivateKey, binaryMessage, 41, 491, (short)Mode.Standard);
                _knapsack.Decrypt();
                byte[] output = _knapsack.GetCryptedMesssage();
                /*
                byte[] output = new byte[binaryMessage.Length];
                for (int i = 0; i < binaryMessage.Length; i++)
                {
                    output[i] = _knapsack.decrypte(binaryMessage[i]);
                }*/
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("File " + source + " decrypted");
                    listBoxOriginalFiles.SelectedItem = null;
                    richTextBoxOriginalMessage.Text = System.Text.Encoding.ASCII.GetString(output);
                });
            }
        }

        private void DecryptBMPFile(string source, byte[] binaryMessage, TEA tea)
        {
            long pos = binaryMessage[10] + 256 * (binaryMessage[11] + 256 * (binaryMessage[12] + 256 * binaryMessage[13]));
            byte[] pixels = new byte[binaryMessage.Length - pos + 1];
            for (long i = pos; i < binaryMessage.Length; i++)
            {
                pixels[i - pos] = binaryMessage[i];
            }
            tea.SetProperties(_binaryKey, _initializationVector, binaryMessage, (short)BlockCipherMode.CBC);
            tea.Decrypt();
            pixels = (byte[])tea.GetCryptedMessage().Clone();
            byte[] originalMessage = (byte[])binaryMessage.Clone();
            for (long i = pos; i < binaryMessage.Length; i++)
            {
                originalMessage[i] = pixels[i - pos];
            }
            string[] parts = source.Split('\\');
            string dest = source.Substring(0, source.Length - parts[parts.Length - 1].Length) + parts[parts.Length - 1].Split('.')[0]
                + "-uncip." + parts[parts.Length - 1].Split('.')[1];

            File.WriteAllBytes(dest, originalMessage);
            this.Invoke((MethodInvoker)delegate
            {
                pictureBoxOriginal.Image = Image.FromFile(_dest);
            });
        }

        private void btnChooseSourceFolder_Click(object sender, EventArgs e)
        {
            if (sourceFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                AddToOriginalList(sourceFolderBrowserDialog.SelectedPath);
                if (destinationFolderBrowserDialog.SelectedPath.Equals(sourceFolderBrowserDialog.SelectedPath))
                {
                    if (MessageBox.Show("Source and destination paths are the same. Do you want to continue?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        ChooseDestinationFolder();
                    }
                }
                if (MessageBox.Show("Do you want to crypt all files?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CryptAllFiles();
                }
            }            
        }

        private void AddToOriginalList(string path)
        {
            string[] files = null;
            if (radioButtonDoubleTransposition.Checked)
            {
                files =  Directory.GetFiles(path, "*.*");
            }
            else if (radioButtonA51.Checked)
            {
                files = Directory.GetFiles(path);
            }
            if (files != null)
            {
                listBoxOriginalFiles.Items.Clear();
                for (int index = 0; index < files.Length; index++)
                {
                    if (!listBoxOriginalFiles.Items.Contains(files[index]))
                    {
                        listBoxOriginalFiles.Items.Add(files[index]);
                    }
                }
            }
        }

        private void CryptAllFiles()
        {
            if (AllParametersSet())
            {
                foreach (var file in listBoxOriginalFiles.Items)
                {
                    string[] parts = file.ToString().Split('\\');
                    string fileName = parts[parts.Length - 1].ToString().Split('.')[0];
                    string path = destinationFolderBrowserDialog.SelectedPath.ToString() + "\\" + fileName + ".cip";
                    if (!listBoxCryptedFiles.Items.Contains(path))
                    {
                        FileInfo info = new FileInfo(file.ToString());
                        if (DateTime.Compare(info.CreationTime, _watcherLastActive) < 0)
                        {
                            _queue.Enqueue(file.ToString());
                        }
                    }
                }
            }
            else
            {
                if (txtColumnKey.Text.Equals("") || txtRowKey.Text.Equals(""))
                {
                    MessageBox.Show("Encryption failed. Key is not set. Please choose valid key.");
                    ChooseKey();
                }
                if (destinationFolderBrowserDialog.SelectedPath.Equals(""))
                {
                    MessageBox.Show("Destination folder not set. Please choose it.");
                    ChooseDestinationFolder();
                }
                if (!_cancel)
                {
                    CryptAllFiles();
                }
            }
        }

        private bool AllParametersSet()
        {
            if (radioButtonDoubleTransposition.Checked)
            {
                return (!txtColumnKey.Text.Equals("") && !txtRowKey.Text.Equals("")) && destinationFolderBrowserDialog.SelectedPath != null;
            }
            else if (radioButtonA51.Checked || radioButtonTEA.Checked)
            {
                return !txtA51.Text.Equals("") && destinationFolderBrowserDialog.SelectedPath != null;
            }
            return false;
        }

        private void btnChooseDestinationFolder_Click(object sender, EventArgs e)
        {
            ChooseDestinationFolder();
        }

        private void ChooseDestinationFolder()
        {
            if (destinationFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (destinationFolderBrowserDialog.SelectedPath.Equals(sourceFolderBrowserDialog.SelectedPath))
                {
                    if (MessageBox.Show("Source and destination paths are the same. Do you want to continue?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        ChooseDestinationFolder();
                    }
                    else
                    {
                        AddToCryptedList(destinationFolderBrowserDialog.SelectedPath);
                    }
                }
                else
                {
                    AddToCryptedList(destinationFolderBrowserDialog.SelectedPath);
                }
            } 
        }

        private void AddToCryptedList(string path)
        {
            string[] files = Directory.GetFiles(path, "*.*");
            listBoxCryptedFiles.Items.Clear();
            for (int index = 0; index < files.Length; index++)
            {
                if (!listBoxCryptedFiles.Items.Contains(files[index]))
                {
                    listBoxCryptedFiles.Items.Add(files[index]);
                }
            }
        }

        private void listBoxOriginalFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxOriginalFiles.SelectedItem != null)
            {
                pictureBoxOriginal.Image = null;
                try
                {
                    if (listBoxOriginalFiles.SelectedItem.ToString().Contains(".bmp"))
                    {
                        checkBoxBMP.Checked = true;
                        panelText.Visible = false;
                        panelBMP.Visible = true;
                        string file = listBoxOriginalFiles.SelectedItem.ToString();
                        pictureBoxOriginal.Image = Image.FromFile(file);
                    }
                    else
                    {
                        checkBoxBMP.Checked = false;
                        panelText.Visible = true;
                        panelBMP.Visible = false;
                        string file = listBoxOriginalFiles.SelectedItem.ToString();
                        using (StreamReader reader = new StreamReader(file))
                        {
                            richTextBoxOriginalMessage.Text = reader.ReadToEnd();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void listBoxCryptedFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxCryptedFiles.SelectedItem != null)
                {
                    if (listBoxCryptedFiles.SelectedItem.ToString().Contains(".bmp"))
                    {
                        checkBoxBMP.Checked = true;
                        panelText.Visible = false;
                        panelBMP.Visible = true;
                        string file = listBoxCryptedFiles.SelectedItem.ToString();
                        pictureBoxCrypted.Image = Image.FromFile(file);
                    }
                    else
                    {
                        checkBoxBMP.Checked = false;
                        panelText.Visible = true;
                        panelBMP.Visible = false;
                        string file = listBoxCryptedFiles.SelectedItem.ToString();
                        using (StreamReader reader = new StreamReader(file))
                        {
                            richTextBoxCryptedMessage.Text = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                fileSystemWatcher.EnableRaisingEvents = true;
                fileSystemWatcherDestination.EnableRaisingEvents = true;
                if (!fileSystemWatcher.Path.Equals(""))
                {
                    CryptAllFiles();
                }
            }
            else
            {
                fileSystemWatcher.EnableRaisingEvents = false;
                fileSystemWatcherDestination.EnableRaisingEvents = false;
                _watcherLastActive = DateTime.Now;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                checkBoxBMP.Enabled = radioButtonTEA.Checked;
                using (StreamReader reader = new StreamReader("config.txt"))
                {
                    sourceFolderBrowserDialog.SelectedPath = reader.ReadLine();
                    fileSystemWatcher.Path = sourceFolderBrowserDialog.SelectedPath;
                    destinationFolderBrowserDialog.SelectedPath = reader.ReadLine();
                    fileSystemWatcherDestination.Path = destinationFolderBrowserDialog.SelectedPath;
                    string time = reader.ReadLine();
                    if (time.Equals(""))
                    {
                        _watcherLastActive = DateTime.Now;
                    }
                    else
                    {
                        _watcherLastActive = Convert.ToDateTime(time);
                    }
                    string teaXtea = reader.ReadLine();
                    if (teaXtea.Equals("TEA"))
                    {
                        _tea_xtea = true;
                    }
                    else if (teaXtea.Equals("XTEA"))
                    {
                        _tea_xtea = false;
                    }
                }
                ThreadStart threadStart = delegate { ReadFromQueue(); };
                new Thread(threadStart).Start();
            }
            catch (Exception ex)
            {
                _watcherLastActive = DateTime.Now;
            }
        }

        private void ReadFromQueue()
        {
            while (_readFromQueue)
            {
                if (fileSystemWatcher.EnableRaisingEvents && _queue.Count != 0)
                {
                    string path;
                    if (_queue.TryDequeue(out path))
                    {
                        string[] parts = path.Split('\\');
                        string destinationPath = destinationFolderBrowserDialog.SelectedPath + "\\" + parts[parts.Length - 1] + ".cip";
                        if (radioButtonA51.Checked)
                        {
                            string message;
                            byte[] bytes = File.ReadAllBytes(path);
                            A51 cypher = new A51();
                            cypher.SetProperties(bytes, _binaryKey);
                            cypher.Encrypt();
                            byte[] cryptedlMessage = cypher.GetCryptedMessage();
                            File.WriteAllBytes(destinationPath, cryptedlMessage);
                            this.Invoke((MethodInvoker)delegate
                            {
                                listBoxCryptedFiles.Items.Add(destinationPath);
                            });
                        }
                        else if (radioButtonDoubleTransposition.Checked)
                        {
                            string message;
                            using (StreamReader reader = new StreamReader(path))
                            {
                                message = reader.ReadToEnd();
                            }
                            _cypherDT.SetProperties(true, txtRowKey.Text, txtColumnKey.Text, message);
                            message = _cypherDT.Encrypt();
                            using (StreamWriter writer = new StreamWriter(destinationPath))
                            {
                                writer.WriteLine(message);
                            }
                            listBoxCryptedFiles.Items.Add(destinationPath);
                        }
                        else if (radioButtonTEA.Checked)
                        {
                            if (_tea_xtea)
                            {
                                byte[] bytes = File.ReadAllBytes(path);
                                TEA cypher = new TEA();
                                cypher.SetProperties(_binaryKey, _initializationVector, bytes, (short)BlockCipherMode.CBC);
                                cypher.Encrypt();
                                byte[] cryptedMessage = cypher.GetCryptedMessage();
                                File.WriteAllBytes(destinationPath, cryptedMessage);
                                this.Invoke((MethodInvoker)delegate
                                {
                                    listBoxCryptedFiles.Items.Add(destinationPath);
                                });
                            }
                            else
                            {
                                byte[] bytes = File.ReadAllBytes(path);
                                XTEA cypher = new XTEA(32);
                                cypher.SetProperties(_binaryKey, _initializationVector, bytes, (short)BlockCipherMode.CBC);
                                cypher.Encrypt();
                                byte[] cryptedMessage = cypher.GetCryptedMessage();
                                File.WriteAllBytes(destinationPath, cryptedMessage);
                                this.Invoke((MethodInvoker)delegate
                                {
                                    listBoxCryptedFiles.Items.Add(destinationPath);
                                });
                            }
                        }
                        else
                        {
                            byte[] binaryMessage = File.ReadAllBytes(path);
                            Knapsack _knapsack = new Knapsack();
                            _knapsack.SetProperties(_knapsackPrivateKey, binaryMessage, 41, 491, (short)Mode.Standard);
                            _knapsack.Encrypt();
                            byte[] output = _knapsack.GetCryptedMesssage();
                            /*byte[] output = new byte[binaryMessage.Length];
                            for (int i = 0; i < binaryMessage.Length; i++)
                            {
                                output[i] = (byte)_knapsack.encrypte(binaryMessage[i]);
                            }*/
                            File.WriteAllBytes(destinationPath, output);
                            this.Invoke((MethodInvoker)delegate
                            {
                                listBoxCryptedFiles.Items.Add(destinationPath);
                            });
                        }
                    }
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("config.txt"))
            {
                writer.WriteLine(sourceFolderBrowserDialog.SelectedPath);
                writer.WriteLine(destinationFolderBrowserDialog.SelectedPath);
                writer.WriteLine(DateTime.Now);
                if (_tea_xtea)
                {
                    writer.WriteLine("TEA");
                }
                else
                {
                    writer.WriteLine("XTEA");
                }
            }
            _readFromQueue = false;
            simulation = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBoxBMP.Checked = radioButtonTEA.Checked;
            if (!sourceFolderBrowserDialog.SelectedPath.Equals(""))
            {
                fileSystemWatcher.Path = sourceFolderBrowserDialog.SelectedPath;
                AddToOriginalList(sourceFolderBrowserDialog.SelectedPath);
                if (!destinationFolderBrowserDialog.SelectedPath.Equals(""))
                {
                    fileSystemWatcherDestination.Path = destinationFolderBrowserDialog.SelectedPath;
                    AddToCryptedList(destinationFolderBrowserDialog.SelectedPath);
                }
                if (MessageBox.Show("Do you want to encrypt all not encrypted files?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CryptAllFiles();
                }
            }
        }

        private void radioButtonA51_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSimulation.Enabled = radioButtonA51.Checked;
            panelSimulationKnapsack.Visible = false;
            panelSimulation.Visible = true;
            panelA51.Visible = true;
            panelDoubleTransposition.Visible = false;
        }

        private void radioButtonDoubleTransposition_CheckedChanged(object sender, EventArgs e)
        {
            panelA51.Visible = false;
            panelDoubleTransposition.Visible = true;
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            listBoxOriginalFiles.Items.Add(path);
            _queue.Enqueue(path);
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            if (listBoxOriginalFiles.Items.Contains(path))
            {
                listBoxOriginalFiles.Items.Remove(path);
            }
        }

        private void fileSystemWatcherDestination_Deleted(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            if (listBoxCryptedFiles.Items.Contains(path))
            {
                listBoxCryptedFiles.Items.Remove(path);
            }
        }

        #region Simulator
        private void btnSimulation_Click(object sender, EventArgs e)
        {
            if (simulation)
            {
                this.Width -= 300;
                simulation = false;
            }
            else
            {
                this.Width += 300;
                simulation = true;
            }
        }


        internal void SetX(string p)
        {
            lblX.Text = p;
        }

        private void buttonSimulateEncryption_Click(object sender, EventArgs e)
        {
            if (listBoxOriginalFiles.SelectedItem != null)
            {
                string path = listBoxOriginalFiles.SelectedItem.ToString();
                ThreadStart threadStart = delegate { Simulate(path); };
                Thread t = new Thread(threadStart);
                t.IsBackground = true;
                t.Start();
            }
        }

        private void Simulate(string path)
        {
            byte[] message = File.ReadAllBytes(path);
            _simulator.SetProperties(message, _binaryKey);
            _simulator.Start(true);
        }

        internal void ResetSimulator()
        {
            lblY.Text = "0000000000000000000000";
            lblX.Text = "0000000000000000000";
            lblZ.Text = "00000000000000000000000";
            richTextBoxInputStream.Text = "";
            richTextBoxKey.Text = "";
            richTextBoxKeyStream.Text = "";
            richTextBoxCM.Text = "";
            lblMajZ.Text = "0";
            lblMajX.Text = "0";
            lblMajY.Text = "0";
            lblMaj.Text = "0";
            lblS.Text = "0";
        }

        internal void SetY(string Y)
        {
            lblY.Text = Y;
        }

        internal void SetZ(string Z)
        {
            lblZ.Text = Z;
        }

        internal void SetKey(string KeyString)
        {
            richTextBoxKey.Text = KeyString;
        }

        internal void SetStreamBit(bool p)
        {
            string bit = (p) ? "1" : "0";
            lblS.Text = bit;
            richTextBoxKeyStream.Text += bit;
        }

        internal void SetKeyStream(string p)
        {
            richTextBoxKeyStream.Text += p;
        }

        internal void RefreshPanel()
        {
            panelSimulation.Refresh();
        }

        internal void SetMessage(string p)
        {
            richTextBoxInputStream.Text = p;
        }

        internal void SetMessageCrypted(string p)
        {
            richTextBoxCM.Text = p;
        }

        internal void SetMajZ(char MajorityBitValueZ)
        {
            lblMajZ.Text = MajorityBitValueZ.ToString();
        }

        internal void SetMajY(char MajorityBitValueY)
        {
            lblMajY.Text = MajorityBitValueY.ToString();
        }

        internal void SetMajX(char MajorityBitValueX)
        {
            lblMajX.Text = MajorityBitValueX.ToString();
        }

        internal void SetMajBit(string p)
        {
            lblMaj.Text = p;
        }

        private void checkBoxSimulation_CheckedChanged(object sender, EventArgs e)
        {
            btnSimulation.Enabled = checkBoxSimulation.Checked;
        }

        private void btnSimulation_EnabledChanged(object sender, EventArgs e)
        {
            if (!btnSimulation.Enabled)
            {
                if (this.Width > this.MinimumSize.Width)
                {
                    this.Width -= 280;
                    simulation = false;
                }
            }
        }
        #endregion

        private void radioButtonTEA_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxBMP.Checked = radioButtonTEA.Checked;
            checkBoxBMP.Enabled = radioButtonTEA.Checked;
            panelA51.Visible = true;
            panelDoubleTransposition.Visible = false;
        }
        
        private void checkBoxBMP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBMP.Checked)
            {
                panelText.Visible = false;
                panelBMP.Visible = true;
            }
            else
            {
                panelText.Visible = true;
                panelBMP.Visible = false;
            }
        }

        private void listBoxOriginalFiles_MouseEnter(object sender, EventArgs e)
        {
            listBoxOriginalFiles.Focus();
        }

        private void listBoxCryptedFiles_MouseEnter(object sender, EventArgs e)
        {
            listBoxCryptedFiles.Focus();
        }

        private void radioButtonKnapsack_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxBMP.Checked = radioButtonTEA.Checked;
            checkBoxBMP.Enabled = radioButtonTEA.Checked;
            panelA51.Visible = true;
            panelDoubleTransposition.Visible = false;
            checkBoxSimulation.Enabled = radioButtonKnapsack.Checked;
            panelSimulation.Visible = false;
            panelSimulationKnapsack.Visible = true;
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            string message = richTextBox1.Text;
            while (message.Length != 0)
            {
                byte character = (byte)message[0];
                if (message.Length > 1)
                {
                    message = message.Substring(1);
                }
                else
                {
                    message = "";
                }
                byte output = _simulatorKnap.encrypte(character);
                listBox1.Items.Add(Convert.ToInt32(output));
                richTextBox2.Text = richTextBox2.Text + Convert.ToInt32(output) + " ";
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            listBox1.ClearSelected();
            int start = richTextBox1.SelectionStart;
            if (richTextBox1.SelectionLength > 0)
            {
                int end = start + richTextBox1.SelectionLength;
                for (int i = start; i < end; i++)
                {
                    listBox1.SelectedIndex = i;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            string message = richTextBox2.Text;
            string[] parts = message.Split(' ');
            foreach (var item in parts)
            {
                if (item != "")
                {
                    byte output = _simulatorKnap.decrypte((byte)item[0]);
                    richTextBox1.Text += (char)Convert.ToInt32(output);
                }
            }
        }
    }
}
