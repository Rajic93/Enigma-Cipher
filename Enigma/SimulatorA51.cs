using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption_Algorithm;
using System.Collections;

namespace Lab_1
{
    public class SimulatorA51 : A51
    {
        private MainForm _formRef;
        public SimulatorA51(MainForm formRef)
        {
            _formRef = formRef;
        }

        public override void SetProperties(byte[] inputStream, byte[] key)
        {
            _Key = key;
            _InputStream = inputStream;
            BitArray keyArray = new BitArray(_Key);
            BitArray x = new BitArray(19);
            BitArray y = new BitArray(22);
            BitArray z = new BitArray(23);
            for (int i = 0; i < 19; i++)
            {
                bool value = keyArray.Get(i);
                x.Set(i, keyArray.Get(i));
            }
            for (int i = 19; i < 40; i++)
            {
                bool value = keyArray.Get(i);
                y.Set(i - 19, value);
            }
            for (int i = 40; i < 63; i++)
            {
                bool value = keyArray.Get(i);
                z.Set(i - 40, value);
            }
            int[] xStep = { 12, 15, 16, 17 };
            int[] yStep = { 19, 20 };
            int[] zStep = { 6, 19, 20, 21 };
            _X = new Register(x, 7, xStep);
            _Y = new Register(y, 9, yStep);
            _Z = new Register(z, 9, zStep);

            _formRef.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                _formRef.ResetSimulator();
                _formRef.SetX(_X.ToString());
                _formRef.SetY(_Y.ToString());
                _formRef.SetZ(_Z.ToString());
                _formRef.SetKey(_X.ToString() + _Y.ToString() + _Z.ToString());
                _formRef.SetMajX((_X.MajorityVoteBit)?'1':'0');
                _formRef.SetMajY((_Y.MajorityVoteBit)?'1':'0');
                _formRef.SetMajZ((_Z.MajorityVoteBit) ? '1' : '0');
                _formRef.RefreshPanel();
            });
        }

        protected override void _Crypt()
        {
            byte[] keyStreamBytes = GenerateKeyStream();
            _OutputStream = new byte[_InputStream.Length];
            for (int index = 0; index < keyStreamBytes.Length; index++)
            {
                _OutputStream[index] = (byte)(keyStreamBytes[index] ^ _InputStream[index]);
            }
            //string msg = System.Text.Encoding.ASCII.GetString(_OutputStream);
        }

        protected override byte[] GenerateKeyStream()
        {
            bool[] keyStream = new bool[_InputStream.Length * 8];
            //creating bool array of key stream that needs to be packed to byte array
            for (int i = 0; i < _InputStream.Length * 8; i++)
            {
                keyStream[i] = Round();
                if (_formRef.simulation)
                {
                    _formRef.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        _formRef.SetX(_X.ToString());
                        _formRef.SetY(_Y.ToString());
                        _formRef.SetZ(_Z.ToString());
                        _formRef.SetMajBit((Majority(_X.MajorityVoteBit, _Y.MajorityVoteBit, _Z.MajorityVoteBit)) ? "1" : "0");
                        _formRef.SetMajX((_X.MajorityVoteBit) ? '1' : '0');
                        _formRef.SetMajY((_Y.MajorityVoteBit) ? '1' : '0');
                        _formRef.SetMajZ((_Z.MajorityVoteBit) ? '1' : '0');

                        _formRef.SetStreamBit(keyStream[i]);
                        _formRef.RefreshPanel();
                    });
                }
                System.Threading.Thread.Sleep(100);
            }
            //packing to bytes
            byte[] keyStreamBytes = new byte[keyStream.Length / 8];
            for (int i = 0; i < keyStreamBytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    keyStreamBytes[i] = (byte)((byte)((keyStream[i * 8 + j]) ? 0x01 : 0x00) | keyStreamBytes[i]);
                    keyStreamBytes[i] = (byte)(keyStreamBytes[i] << 1);
                }
            }
            return keyStreamBytes;
        }

        protected override bool Round()
        {
            bool m = Majority(_X.MajorityVoteBit, _Y.MajorityVoteBit, _Z.MajorityVoteBit);
            if (m == _X.MajorityVoteBit)
            {
                _X.ShiftLeft();
            }
            if (m == _Y.MajorityVoteBit)
            {
                _Y.ShiftLeft();
            }
            if (m == _Z.MajorityVoteBit)
            {
                _Z.ShiftLeft();
            }
            bool x = _X.Value[_X.Length - 1];
            bool y = _Y.Value[_Y.Length - 1];
            bool z = _Z.Value[_Z.Length - 1];
            bool s = x ^ y ^ z;
            return s;
            if (_formRef.simulation)
            {
                _formRef.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    _formRef.SetX(_X.ToString());
                    _formRef.SetY(_Y.ToString());
                    _formRef.SetZ(_Z.ToString());
                    _formRef.SetMajBit((m) ? "1" : "0");
                    _formRef.SetMajX(Convert.ToChar(_X.MajorityVoteBit));
                    _formRef.SetMajY(Convert.ToChar(_Y.MajorityVoteBit));
                    _formRef.SetMajZ(Convert.ToChar(_Z.MajorityVoteBit));
                    _formRef.RefreshPanel();
                });
            }
        }

        protected override bool Majority(bool p1, bool p2, bool p3)
        {
            int one = 0;
            int zero = 0;
            if (p1)
            {
                one++;
            }
            else
            {
                zero++;
            }
            if (p2)
            {
                one++;
            }
            else
            {
                zero++;
            }
            if (p3)
            {
                one++;
            }
            else
            {
                zero++;
            }
            return zero < one;
        }

        public void Start(bool _cryptDecrypt)
        {
            _formRef.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                _formRef.SetMessage(System.Text.Encoding.ASCII.GetString(_InputStream));
                _formRef.RefreshPanel();
            });
            if (_cryptDecrypt)
            {
                byte[] keyStreamBytes = GenerateKeyStream();
                byte[] cryptedMessageBytes = new byte[_InputStream.Length];
                for (int index = 0; index < keyStreamBytes.Length; index++)
                {
                    cryptedMessageBytes[index] = (byte)(keyStreamBytes[index] ^ _InputStream[index]);
                }
                if (_formRef != null && _formRef.simulation)
                {
                    string msg = System.Text.Encoding.ASCII.GetString(cryptedMessageBytes);
                    _formRef.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        _formRef.SetMessageCrypted(msg);
                        _formRef.RefreshPanel();
                    });
                }
            }
            else
            {

            }
        }
    }
}
