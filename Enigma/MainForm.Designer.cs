namespace Lab_1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.sourceFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.destinationFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonKnapsack = new System.Windows.Forms.RadioButton();
            this.checkBoxBMP = new System.Windows.Forms.CheckBox();
            this.radioButtonTEA = new System.Windows.Forms.RadioButton();
            this.radioButtonA51 = new System.Windows.Forms.RadioButton();
            this.radioButtonDoubleTransposition = new System.Windows.Forms.RadioButton();
            this.checkBoxSimulation = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChooseDestinationFolder = new System.Windows.Forms.Button();
            this.btnChooseSourceFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxOriginalMessage = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCryptedMessage = new System.Windows.Forms.RichTextBox();
            this.listBoxCryptedFiles = new System.Windows.Forms.ListBox();
            this.listBoxOriginalFiles = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnChooseKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColumnKey = new System.Windows.Forms.TextBox();
            this.txtRowKey = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelA51 = new System.Windows.Forms.Panel();
            this.txtA51 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelDoubleTransposition = new System.Windows.Forms.Panel();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.panelSimulation = new System.Windows.Forms.Panel();
            this.buttonSimulateDecryption = new System.Windows.Forms.Button();
            this.buttonSimulateEncryption = new System.Windows.Forms.Button();
            this.lblRound = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBoxCM = new System.Windows.Forms.RichTextBox();
            this.richTextBoxKeyStream = new System.Windows.Forms.RichTextBox();
            this.richTextBoxKey = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBoxInputStream = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblMaj = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblMajZ = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMajY = new System.Windows.Forms.Label();
            this.lblMajX = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fileSystemWatcherDestination = new System.IO.FileSystemWatcher();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelText = new System.Windows.Forms.Panel();
            this.panelBMP = new System.Windows.Forms.Panel();
            this.pictureBoxCrypted = new System.Windows.Forms.PictureBox();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSimulationKnapsack = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelA51.SuspendLayout();
            this.panelDoubleTransposition.SuspendLayout();
            this.panelSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherDestination)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelText.SuspendLayout();
            this.panelBMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrypted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.panelSimulationKnapsack.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonKnapsack);
            this.groupBox1.Controls.Add(this.checkBoxBMP);
            this.groupBox1.Controls.Add(this.radioButtonTEA);
            this.groupBox1.Controls.Add(this.radioButtonA51);
            this.groupBox1.Controls.Add(this.radioButtonDoubleTransposition);
            this.groupBox1.Controls.Add(this.checkBoxSimulation);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 29);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonKnapsack
            // 
            this.radioButtonKnapsack.AutoSize = true;
            this.radioButtonKnapsack.Location = new System.Drawing.Point(274, 10);
            this.radioButtonKnapsack.Name = "radioButtonKnapsack";
            this.radioButtonKnapsack.Size = new System.Drawing.Size(73, 17);
            this.radioButtonKnapsack.TabIndex = 60;
            this.radioButtonKnapsack.TabStop = true;
            this.radioButtonKnapsack.Text = "Knapsack";
            this.radioButtonKnapsack.UseVisualStyleBackColor = true;
            this.radioButtonKnapsack.CheckedChanged += new System.EventHandler(this.radioButtonKnapsack_CheckedChanged);
            // 
            // checkBoxBMP
            // 
            this.checkBoxBMP.AutoSize = true;
            this.checkBoxBMP.Location = new System.Drawing.Point(548, 10);
            this.checkBoxBMP.Name = "checkBoxBMP";
            this.checkBoxBMP.Size = new System.Drawing.Size(49, 17);
            this.checkBoxBMP.TabIndex = 59;
            this.checkBoxBMP.Text = "BMP";
            this.checkBoxBMP.UseVisualStyleBackColor = true;
            this.checkBoxBMP.CheckedChanged += new System.EventHandler(this.checkBoxBMP_CheckedChanged);
            // 
            // radioButtonTEA
            // 
            this.radioButtonTEA.AutoSize = true;
            this.radioButtonTEA.Location = new System.Drawing.Point(188, 10);
            this.radioButtonTEA.Name = "radioButtonTEA";
            this.radioButtonTEA.Size = new System.Drawing.Size(79, 17);
            this.radioButtonTEA.TabIndex = 58;
            this.radioButtonTEA.TabStop = true;
            this.radioButtonTEA.Text = "TEA/XTEA";
            this.radioButtonTEA.UseVisualStyleBackColor = true;
            this.radioButtonTEA.CheckedChanged += new System.EventHandler(this.radioButtonTEA_CheckedChanged);
            // 
            // radioButtonA51
            // 
            this.radioButtonA51.AutoSize = true;
            this.radioButtonA51.Location = new System.Drawing.Point(133, 10);
            this.radioButtonA51.Name = "radioButtonA51";
            this.radioButtonA51.Size = new System.Drawing.Size(49, 17);
            this.radioButtonA51.TabIndex = 57;
            this.radioButtonA51.TabStop = true;
            this.radioButtonA51.Text = "A5/1";
            this.radioButtonA51.UseVisualStyleBackColor = true;
            this.radioButtonA51.CheckedChanged += new System.EventHandler(this.radioButtonA51_CheckedChanged);
            // 
            // radioButtonDoubleTransposition
            // 
            this.radioButtonDoubleTransposition.AutoSize = true;
            this.radioButtonDoubleTransposition.Location = new System.Drawing.Point(6, 10);
            this.radioButtonDoubleTransposition.Name = "radioButtonDoubleTransposition";
            this.radioButtonDoubleTransposition.Size = new System.Drawing.Size(125, 17);
            this.radioButtonDoubleTransposition.TabIndex = 56;
            this.radioButtonDoubleTransposition.TabStop = true;
            this.radioButtonDoubleTransposition.Text = "Double Transposition";
            this.radioButtonDoubleTransposition.UseVisualStyleBackColor = true;
            this.radioButtonDoubleTransposition.CheckedChanged += new System.EventHandler(this.radioButtonDoubleTransposition_CheckedChanged);
            // 
            // checkBoxSimulation
            // 
            this.checkBoxSimulation.AutoSize = true;
            this.checkBoxSimulation.Enabled = false;
            this.checkBoxSimulation.Location = new System.Drawing.Point(603, 11);
            this.checkBoxSimulation.Name = "checkBoxSimulation";
            this.checkBoxSimulation.Size = new System.Drawing.Size(74, 17);
            this.checkBoxSimulation.TabIndex = 55;
            this.checkBoxSimulation.Text = "Simulation";
            this.checkBoxSimulation.UseVisualStyleBackColor = true;
            this.checkBoxSimulation.CheckedChanged += new System.EventHandler(this.checkBoxSimulation_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Crypted message:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Original message:";
            // 
            // btnChooseDestinationFolder
            // 
            this.btnChooseDestinationFolder.Location = new System.Drawing.Point(595, 81);
            this.btnChooseDestinationFolder.Name = "btnChooseDestinationFolder";
            this.btnChooseDestinationFolder.Size = new System.Drawing.Size(92, 23);
            this.btnChooseDestinationFolder.TabIndex = 52;
            this.btnChooseDestinationFolder.Text = "Choose folder";
            this.btnChooseDestinationFolder.UseVisualStyleBackColor = true;
            this.btnChooseDestinationFolder.Click += new System.EventHandler(this.btnChooseDestinationFolder_Click);
            // 
            // btnChooseSourceFolder
            // 
            this.btnChooseSourceFolder.Location = new System.Drawing.Point(251, 81);
            this.btnChooseSourceFolder.Name = "btnChooseSourceFolder";
            this.btnChooseSourceFolder.Size = new System.Drawing.Size(92, 23);
            this.btnChooseSourceFolder.TabIndex = 51;
            this.btnChooseSourceFolder.Text = "Choose folder";
            this.btnChooseSourceFolder.UseVisualStyleBackColor = true;
            this.btnChooseSourceFolder.Click += new System.EventHandler(this.btnChooseSourceFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Destination folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Source folder:";
            // 
            // richTextBoxOriginalMessage
            // 
            this.richTextBoxOriginalMessage.Location = new System.Drawing.Point(0, 18);
            this.richTextBoxOriginalMessage.Name = "richTextBoxOriginalMessage";
            this.richTextBoxOriginalMessage.ReadOnly = true;
            this.richTextBoxOriginalMessage.Size = new System.Drawing.Size(339, 228);
            this.richTextBoxOriginalMessage.TabIndex = 48;
            this.richTextBoxOriginalMessage.Text = "";
            // 
            // richTextBoxCryptedMessage
            // 
            this.richTextBoxCryptedMessage.Location = new System.Drawing.Point(344, 18);
            this.richTextBoxCryptedMessage.Name = "richTextBoxCryptedMessage";
            this.richTextBoxCryptedMessage.ReadOnly = true;
            this.richTextBoxCryptedMessage.Size = new System.Drawing.Size(339, 228);
            this.richTextBoxCryptedMessage.TabIndex = 47;
            this.richTextBoxCryptedMessage.Text = "";
            // 
            // listBoxCryptedFiles
            // 
            this.listBoxCryptedFiles.FormattingEnabled = true;
            this.listBoxCryptedFiles.Location = new System.Drawing.Point(348, 110);
            this.listBoxCryptedFiles.Name = "listBoxCryptedFiles";
            this.listBoxCryptedFiles.Size = new System.Drawing.Size(339, 186);
            this.listBoxCryptedFiles.TabIndex = 46;
            this.listBoxCryptedFiles.SelectedValueChanged += new System.EventHandler(this.listBoxCryptedFiles_SelectedValueChanged);
            this.listBoxCryptedFiles.MouseEnter += new System.EventHandler(this.listBoxCryptedFiles_MouseEnter);
            // 
            // listBoxOriginalFiles
            // 
            this.listBoxOriginalFiles.FormattingEnabled = true;
            this.listBoxOriginalFiles.Location = new System.Drawing.Point(4, 110);
            this.listBoxOriginalFiles.Name = "listBoxOriginalFiles";
            this.listBoxOriginalFiles.ScrollAlwaysVisible = true;
            this.listBoxOriginalFiles.Size = new System.Drawing.Size(339, 186);
            this.listBoxOriginalFiles.TabIndex = 45;
            this.listBoxOriginalFiles.SelectedValueChanged += new System.EventHandler(this.listBoxOriginalFiles_SelectedValueChanged);
            this.listBoxOriginalFiles.MouseEnter += new System.EventHandler(this.listBoxOriginalFiles_MouseEnter);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(348, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 17);
            this.checkBox1.TabIndex = 44;
            this.checkBox1.Text = "File system watcher";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(612, 43);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 43;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(531, 43);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 42;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnChooseKey
            // 
            this.btnChooseKey.Location = new System.Drawing.Point(270, 43);
            this.btnChooseKey.Name = "btnChooseKey";
            this.btnChooseKey.Size = new System.Drawing.Size(73, 25);
            this.btnChooseKey.TabIndex = 41;
            this.btnChooseKey.Text = "Choose key";
            this.btnChooseKey.UseVisualStyleBackColor = true;
            this.btnChooseKey.Click += new System.EventHandler(this.btnChooseKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Column key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Row key:";
            // 
            // txtColumnKey
            // 
            this.txtColumnKey.Location = new System.Drawing.Point(135, 16);
            this.txtColumnKey.Name = "txtColumnKey";
            this.txtColumnKey.Size = new System.Drawing.Size(127, 20);
            this.txtColumnKey.TabIndex = 38;
            // 
            // txtRowKey
            // 
            this.txtRowKey.Location = new System.Drawing.Point(2, 16);
            this.txtRowKey.Name = "txtRowKey";
            this.txtRowKey.Size = new System.Drawing.Size(127, 20);
            this.txtRowKey.TabIndex = 37;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelA51);
            this.flowLayoutPanel1.Controls.Add(this.panelDoubleTransposition);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 41);
            this.flowLayoutPanel1.TabIndex = 55;
            // 
            // panelA51
            // 
            this.panelA51.Controls.Add(this.txtA51);
            this.panelA51.Controls.Add(this.label7);
            this.panelA51.Location = new System.Drawing.Point(0, 0);
            this.panelA51.Margin = new System.Windows.Forms.Padding(0);
            this.panelA51.Name = "panelA51";
            this.panelA51.Size = new System.Drawing.Size(264, 41);
            this.panelA51.TabIndex = 0;
            // 
            // txtA51
            // 
            this.txtA51.Location = new System.Drawing.Point(2, 16);
            this.txtA51.Name = "txtA51";
            this.txtA51.Size = new System.Drawing.Size(260, 20);
            this.txtA51.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-1, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "64-bit binary key:";
            // 
            // panelDoubleTransposition
            // 
            this.panelDoubleTransposition.Controls.Add(this.txtRowKey);
            this.panelDoubleTransposition.Controls.Add(this.txtColumnKey);
            this.panelDoubleTransposition.Controls.Add(this.label1);
            this.panelDoubleTransposition.Controls.Add(this.label2);
            this.panelDoubleTransposition.Location = new System.Drawing.Point(0, 41);
            this.panelDoubleTransposition.Margin = new System.Windows.Forms.Padding(0);
            this.panelDoubleTransposition.Name = "panelDoubleTransposition";
            this.panelDoubleTransposition.Size = new System.Drawing.Size(264, 41);
            this.panelDoubleTransposition.TabIndex = 1;
            // 
            // btnSimulation
            // 
            this.btnSimulation.Enabled = false;
            this.btnSimulation.Location = new System.Drawing.Point(693, 202);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(20, 152);
            this.btnSimulation.TabIndex = 56;
            this.btnSimulation.Text = "Simu l at  i on";
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.EnabledChanged += new System.EventHandler(this.btnSimulation_EnabledChanged);
            this.btnSimulation.Click += new System.EventHandler(this.btnSimulation_Click);
            // 
            // panelSimulation
            // 
            this.panelSimulation.Controls.Add(this.buttonSimulateDecryption);
            this.panelSimulation.Controls.Add(this.buttonSimulateEncryption);
            this.panelSimulation.Controls.Add(this.lblRound);
            this.panelSimulation.Controls.Add(this.label18);
            this.panelSimulation.Controls.Add(this.label16);
            this.panelSimulation.Controls.Add(this.label14);
            this.panelSimulation.Controls.Add(this.richTextBoxCM);
            this.panelSimulation.Controls.Add(this.richTextBoxKeyStream);
            this.panelSimulation.Controls.Add(this.richTextBoxKey);
            this.panelSimulation.Controls.Add(this.label11);
            this.panelSimulation.Controls.Add(this.richTextBoxInputStream);
            this.panelSimulation.Controls.Add(this.label9);
            this.panelSimulation.Controls.Add(this.lblS);
            this.panelSimulation.Controls.Add(this.label17);
            this.panelSimulation.Controls.Add(this.lblMaj);
            this.panelSimulation.Controls.Add(this.label15);
            this.panelSimulation.Controls.Add(this.lblMajZ);
            this.panelSimulation.Controls.Add(this.label13);
            this.panelSimulation.Controls.Add(this.lblMajY);
            this.panelSimulation.Controls.Add(this.lblMajX);
            this.panelSimulation.Controls.Add(this.lblZ);
            this.panelSimulation.Controls.Add(this.label12);
            this.panelSimulation.Controls.Add(this.lblY);
            this.panelSimulation.Controls.Add(this.label10);
            this.panelSimulation.Controls.Add(this.lblX);
            this.panelSimulation.Controls.Add(this.label8);
            this.panelSimulation.Location = new System.Drawing.Point(3, 3);
            this.panelSimulation.Name = "panelSimulation";
            this.panelSimulation.Size = new System.Drawing.Size(290, 543);
            this.panelSimulation.TabIndex = 57;
            // 
            // buttonSimulateDecryption
            // 
            this.buttonSimulateDecryption.Location = new System.Drawing.Point(151, 5);
            this.buttonSimulateDecryption.Name = "buttonSimulateDecryption";
            this.buttonSimulateDecryption.Size = new System.Drawing.Size(119, 23);
            this.buttonSimulateDecryption.TabIndex = 61;
            this.buttonSimulateDecryption.Text = "Simulate Decryption";
            this.buttonSimulateDecryption.UseVisualStyleBackColor = true;
            this.buttonSimulateDecryption.Visible = false;
            // 
            // buttonSimulateEncryption
            // 
            this.buttonSimulateEncryption.Location = new System.Drawing.Point(101, 5);
            this.buttonSimulateEncryption.Name = "buttonSimulateEncryption";
            this.buttonSimulateEncryption.Size = new System.Drawing.Size(119, 23);
            this.buttonSimulateEncryption.TabIndex = 60;
            this.buttonSimulateEncryption.Text = "Simulate Encryption";
            this.buttonSimulateEncryption.UseVisualStyleBackColor = true;
            this.buttonSimulateEncryption.Click += new System.EventHandler(this.buttonSimulateEncryption_Click);
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(67, 174);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(16, 17);
            this.lblRound.TabIndex = 59;
            this.lblRound.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 17);
            this.label18.TabIndex = 58;
            this.label18.Text = "Round:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 382);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 17);
            this.label16.TabIndex = 21;
            this.label16.Text = "Key stream:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 458);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "Crypted message:";
            // 
            // richTextBoxCM
            // 
            this.richTextBoxCM.Location = new System.Drawing.Point(10, 474);
            this.richTextBoxCM.Name = "richTextBoxCM";
            this.richTextBoxCM.Size = new System.Drawing.Size(269, 57);
            this.richTextBoxCM.TabIndex = 19;
            this.richTextBoxCM.Text = "";
            // 
            // richTextBoxKeyStream
            // 
            this.richTextBoxKeyStream.Location = new System.Drawing.Point(10, 398);
            this.richTextBoxKeyStream.Name = "richTextBoxKeyStream";
            this.richTextBoxKeyStream.Size = new System.Drawing.Size(269, 57);
            this.richTextBoxKeyStream.TabIndex = 18;
            this.richTextBoxKeyStream.Text = "";
            // 
            // richTextBoxKey
            // 
            this.richTextBoxKey.Location = new System.Drawing.Point(10, 136);
            this.richTextBoxKey.Name = "richTextBoxKey";
            this.richTextBoxKey.ReadOnly = true;
            this.richTextBoxKey.Size = new System.Drawing.Size(269, 35);
            this.richTextBoxKey.TabIndex = 17;
            this.richTextBoxKey.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Key:";
            // 
            // richTextBoxInputStream
            // 
            this.richTextBoxInputStream.Location = new System.Drawing.Point(10, 56);
            this.richTextBoxInputStream.Name = "richTextBoxInputStream";
            this.richTextBoxInputStream.ReadOnly = true;
            this.richTextBoxInputStream.Size = new System.Drawing.Size(269, 57);
            this.richTextBoxInputStream.TabIndex = 15;
            this.richTextBoxInputStream.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Input stream:";
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS.Location = new System.Drawing.Point(128, 344);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(16, 17);
            this.lblS.TabIndex = 13;
            this.lblS.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(98, 344);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 17);
            this.label17.TabIndex = 12;
            this.label17.Text = "s = ";
            // 
            // lblMaj
            // 
            this.lblMaj.AutoSize = true;
            this.lblMaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaj.Location = new System.Drawing.Point(37, 344);
            this.lblMaj.Name = "lblMaj";
            this.lblMaj.Size = new System.Drawing.Size(16, 17);
            this.lblMaj.TabIndex = 11;
            this.lblMaj.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 344);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "m = ";
            // 
            // lblMajZ
            // 
            this.lblMajZ.AutoSize = true;
            this.lblMajZ.Location = new System.Drawing.Point(214, 309);
            this.lblMajZ.Name = "lblMajZ";
            this.lblMajZ.Size = new System.Drawing.Size(13, 13);
            this.lblMajZ.TabIndex = 9;
            this.lblMajZ.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(214, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Majority bits:";
            // 
            // lblMajY
            // 
            this.lblMajY.AutoSize = true;
            this.lblMajY.Location = new System.Drawing.Point(214, 263);
            this.lblMajY.Name = "lblMajY";
            this.lblMajY.Size = new System.Drawing.Size(13, 13);
            this.lblMajY.TabIndex = 7;
            this.lblMajY.Text = "0";
            // 
            // lblMajX
            // 
            this.lblMajX.AutoSize = true;
            this.lblMajX.Location = new System.Drawing.Point(214, 217);
            this.lblMajX.Name = "lblMajX";
            this.lblMajX.Size = new System.Drawing.Size(13, 13);
            this.lblMajX.TabIndex = 6;
            this.lblMajX.Text = "0";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.Location = new System.Drawing.Point(7, 307);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(192, 17);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "00000000000000000000000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Register Z:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(7, 261);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(184, 17);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "0000000000000000000000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Register Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(7, 215);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(160, 17);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "0000000000000000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Register X:";
            // 
            // fileSystemWatcherDestination
            // 
            this.fileSystemWatcherDestination.EnableRaisingEvents = true;
            this.fileSystemWatcherDestination.SynchronizingObject = this;
            this.fileSystemWatcherDestination.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcherDestination_Deleted);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panelText);
            this.flowLayoutPanel2.Controls.Add(this.panelBMP);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 298);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(685, 534);
            this.flowLayoutPanel2.TabIndex = 60;
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.richTextBoxOriginalMessage);
            this.panelText.Controls.Add(this.richTextBoxCryptedMessage);
            this.panelText.Controls.Add(this.label5);
            this.panelText.Controls.Add(this.label6);
            this.panelText.Location = new System.Drawing.Point(0, 0);
            this.panelText.Margin = new System.Windows.Forms.Padding(0);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(683, 249);
            this.panelText.TabIndex = 0;
            // 
            // panelBMP
            // 
            this.panelBMP.Controls.Add(this.pictureBoxCrypted);
            this.panelBMP.Controls.Add(this.pictureBoxOriginal);
            this.panelBMP.Controls.Add(this.label20);
            this.panelBMP.Controls.Add(this.label19);
            this.panelBMP.Location = new System.Drawing.Point(0, 249);
            this.panelBMP.Margin = new System.Windows.Forms.Padding(0);
            this.panelBMP.Name = "panelBMP";
            this.panelBMP.Size = new System.Drawing.Size(683, 249);
            this.panelBMP.TabIndex = 1;
            // 
            // pictureBoxCrypted
            // 
            this.pictureBoxCrypted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxCrypted.Location = new System.Drawing.Point(344, 16);
            this.pictureBoxCrypted.Name = "pictureBoxCrypted";
            this.pictureBoxCrypted.Size = new System.Drawing.Size(339, 228);
            this.pictureBoxCrypted.TabIndex = 3;
            this.pictureBoxCrypted.TabStop = false;
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(0, 16);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(339, 228);
            this.pictureBoxOriginal.TabIndex = 2;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(341, 2);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Cripted picture:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 2);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Original picture:";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.panelSimulation);
            this.flowLayoutPanel3.Controls.Add(this.panelSimulationKnapsack);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(721, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(298, 605);
            this.flowLayoutPanel3.TabIndex = 61;
            // 
            // panelSimulationKnapsack
            // 
            this.panelSimulationKnapsack.Controls.Add(this.richTextBox2);
            this.panelSimulationKnapsack.Controls.Add(this.btnSimulate);
            this.panelSimulationKnapsack.Controls.Add(this.label22);
            this.panelSimulationKnapsack.Controls.Add(this.listBox1);
            this.panelSimulationKnapsack.Controls.Add(this.label21);
            this.panelSimulationKnapsack.Controls.Add(this.richTextBox1);
            this.panelSimulationKnapsack.Location = new System.Drawing.Point(3, 552);
            this.panelSimulationKnapsack.Name = "panelSimulationKnapsack";
            this.panelSimulationKnapsack.Size = new System.Drawing.Size(290, 543);
            this.panelSimulationKnapsack.TabIndex = 58;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(63, 249);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(224, 225);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(78, 508);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(121, 23);
            this.btnSimulate.TabIndex = 4;
            this.btnSimulate.Text = "Simulate Encryption";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(0, 233);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "Output:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 249);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(54, 225);
            this.listBox1.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Input text:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(284, 211);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 547);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.btnSimulation);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnChooseDestinationFolder);
            this.Controls.Add(this.btnChooseSourceFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxCryptedFiles);
            this.Controls.Add(this.listBoxOriginalFiles);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnChooseKey);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(735, 586);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelA51.ResumeLayout(false);
            this.panelA51.PerformLayout();
            this.panelDoubleTransposition.ResumeLayout(false);
            this.panelDoubleTransposition.PerformLayout();
            this.panelSimulation.ResumeLayout(false);
            this.panelSimulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherDestination)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelText.ResumeLayout(false);
            this.panelText.PerformLayout();
            this.panelBMP.ResumeLayout(false);
            this.panelBMP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrypted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panelSimulationKnapsack.ResumeLayout(false);
            this.panelSimulationKnapsack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.FolderBrowserDialog sourceFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog destinationFolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChooseDestinationFolder;
        private System.Windows.Forms.Button btnChooseSourceFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxOriginalMessage;
        private System.Windows.Forms.RichTextBox richTextBoxCryptedMessage;
        private System.Windows.Forms.ListBox listBoxCryptedFiles;
        private System.Windows.Forms.ListBox listBoxOriginalFiles;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnChooseKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColumnKey;
        private System.Windows.Forms.TextBox txtRowKey;
        private System.Windows.Forms.CheckBox checkBoxSimulation;
        private System.Windows.Forms.RadioButton radioButtonA51;
        private System.Windows.Forms.RadioButton radioButtonDoubleTransposition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelA51;
        private System.Windows.Forms.TextBox txtA51;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelDoubleTransposition;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.Panel panelSimulation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBoxCM;
        private System.Windows.Forms.RichTextBox richTextBoxKeyStream;
        private System.Windows.Forms.RichTextBox richTextBoxKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox richTextBoxInputStream;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblMaj;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblMajZ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMajY;
        private System.Windows.Forms.Label lblMajX;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button buttonSimulateDecryption;
        private System.Windows.Forms.Button buttonSimulateEncryption;
        private System.IO.FileSystemWatcher fileSystemWatcherDestination;
        private System.Windows.Forms.CheckBox checkBoxBMP;
        private System.Windows.Forms.RadioButton radioButtonTEA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Panel panelBMP;
        private System.Windows.Forms.PictureBox pictureBoxCrypted;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton radioButtonKnapsack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panelSimulationKnapsack;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

