using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Algorithm
{
    public class Knapsack
    {
        private uint[] _privateKey;
        private uint[] _publicKey;
        private uint[] _packedData;
        private uint[] _outputData;
        private uint _multiplier;

        private uint _inverseMultiplier;
        private uint _modulus;
        private uint _TC;
        private short _mode;
        private byte[] _inputStream;
        private byte[] _outputStream;

        #region Constructors
        public Knapsack()
        {

        }

        public Knapsack(uint[] key, byte[] message, uint multiplier, uint modulus, short mode)
        {
            _privateKey = key;
            _inputStream = message;
            _multiplier = multiplier;
            _modulus = modulus;
            _mode = mode;
            PackData();
        }
        #endregion

        #region PublicMethods
        public void SetProperties(uint[] key, byte[] message, uint multiplier, uint modulus, short mode)
        {
            _privateKey = key;
            _inputStream = message;
            _multiplier = multiplier;
            _modulus = modulus;
            _mode = mode;
            PackData();
            GenerateInverseMultiplier();
        }

        public void Encrypt()
        {
            GeneratePublicKey();
            _outputData = new uint[_packedData.Length];
            for (int i = 0; i < _packedData.Length; i++)
            {
                BitArray binaryValue = new BitArray(BitConverter.GetBytes(_packedData[i]));
                Reverse(binaryValue);
                uint sum = 0;
                for (int j = 0; j < _publicKey.Length; j++)
                {
                    if (binaryValue.Get(j))
                    {
                        sum += _publicKey[j];
                    }
                }
                _outputData[i] = sum;
            }
        }

        public void Decrypt()
        {
            _outputData = new uint[_packedData.Length];
            for (int i = 0; i < _packedData.Length; i++)
            {
                GenerateTC(_packedData[i]);
                BitArray number = new BitArray(32, false);
                
                for (int j = _privateKey.Length; j > 0; j--)
                {
                    if (_privateKey[j - 1] <= _TC)
                    {
                        number.Set(32 - j, true);
                        _TC -= _privateKey[j - 1];
                    }
                    else
                    {
                        number.Set(32 - j, false);
                    }
                }

                if (_TC == 0)
                {
                    byte[] output = new byte[4];
                    number.CopyTo(output, 0);
                    _outputData[i] = BitConverter.ToUInt32(output, 0);
                }
                else
                {
                    _outputData[i] = uint.MaxValue;
                }
            }           
        }

        public byte[] GetCryptedMesssage()
        {
            UnpackData();
            return _outputStream;
        }
        #endregion

        #region PrivatMethods
        private void PackData()
        {
            int numOfBlock;
            if (((float)_inputStream.Length / 4) - (int)(_inputStream.Length / 4) == 0)
            {
                numOfBlock = _inputStream.Length / 4;
            }
            else
            {
                numOfBlock = _inputStream.Length / 4 + 1;
            }
            _packedData = new uint[numOfBlock];
            for (int i = 0; i < numOfBlock; i++)
            {
                byte[] number = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    if (i * 4 + j < _inputStream.Length)
                    {
                        number[j] = _inputStream[i * 4 + j];
                    }
                    else
                    {
                        number[j] = 0;
                    }
                }
                _packedData[i] = BitConverter.ToUInt32(number, 0);
            }
        }

        private void UnpackData()
        {
            _outputStream = new byte[_outputData.Length * 4];
            for (int i = 0; i < _outputData.Length; i++)
            {
                byte[] number = BitConverter.GetBytes(_outputData[i]);
                for (int j = 0; j < number.Length; j++)
                {
                    _outputStream[i * 4 + j] = number[j];
                }
            }
        }

        private void GeneratePublicKey()
        {
            _publicKey = new uint[_privateKey.Length];
            for (int i = 0; i < _privateKey.Length; i++)
            {
                _publicKey[i] = (_privateKey[i] * _multiplier) % _modulus;
            }
        }

        private void GenerateInverseMultiplier()
        {
            bool ctrl = true;
            int k = 0;
            while (ctrl)
            {
                int result = (int)((k * _modulus + 1) / _multiplier);
                float resultFloat = (float)(k * _modulus + 1) / (float)_multiplier;
                if (resultFloat - result == 0)
                {
                    _inverseMultiplier = (uint)((k * _modulus + 1) / _multiplier);
                    ctrl = false;
                }
                else
                {
                    k++;
                }
            }
        }

        private void GenerateTC(uint c)
        {
            _TC = (c * _inverseMultiplier) % _modulus;
        }

        private void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
        #endregion
    }

    public enum Mode
    {
        Simulation,
        Standard
    }



    ///***********************************************
    //
    ///***********************************************
    public class KnapsackSimulator
    {
        private int keyLength;
        private List<int> privateKey;
        private List<int> publicKey;
        private int m;
        private int n;
        private int im;

        public KnapsackSimulator()
        {
            privateKey = new List<int>();
            publicKey = new List<int>();
            n = 0; m = 0; im = 0;
        }
        public void setKeyLength()
        {
            keyLength = privateKey.Count;
        }
        public int returnKeyLength()
        {
            return keyLength;
        }
        public List<int> returnPrivateKey()
        {
            return privateKey;
        }
        public List<int> returnPublicKey()
        {
            return publicKey;
        }
        public void setLogicN()
        {
            Random r = new Random();
            foreach (int i in privateKey)
            {
                n += i;
            }
            n += r.Next(1, 4);
        }
        private bool isSimpleNumber(int k)
        {
            if ((Math.Pow(2, k - 1)) % k == 1)
                return true;
            else
                return false;
        }
        public void setMultiplicatiorM()
        {
            for (int i = n / 40; i < n; i++)
            {
                if (isSimpleNumber(i))
                {
                    m = i;
                    break;
                }
            }
        }
        public void setIM()
        {
            for (int k = 1; k < n; k++)
            {
                int pomIM = n * k + 1;
                if (pomIM % m == 0)
                {
                    im = pomIM / m;
                    break;
                }
            }
        }
        public void setPrivateKey(int startNumber, int length)
        {
            privateKey.Add(startNumber);
            int Sum = startNumber;
            Random r = new Random();
            for (int i = 1; i < length; i++)
            {
                privateKey.Add(Sum + r.Next(1, 4));
                Sum += privateKey[i];
            }
            setLogicN();
            setMultiplicatiorM();
            setIM();
            setKeyLength();
            setPublicKey();
        }
        public void setPublicKey()
        {
            foreach (int i in privateKey)
            {
                publicKey.Add((i * m) % n);
            }
        }
        public void changeKeysLength(int length)
        {
            if (length == n)
            {

            }
            else if (length < privateKey.Count)
            {
                for (int i = 0; i < privateKey.Count - length; i++)
                {
                    privateKey.RemoveAt(privateKey.Count - 1);
                    publicKey.RemoveAt(publicKey.Count - 1);
                }
                setLogicN();
                setMultiplicatiorM();
                setIM();
            }
            else
            {
                int start = privateKey[0];
                privateKey.Clear();
                publicKey.Clear();
                setPrivateKey(start, length);
                setPublicKey();
            }
        }
        public void changeKeyValue(int index, int value) //
        {
            privateKey[index] = value;
            reCountKeys(index + 1);
            publicKey.Clear();
            setPublicKey();
        }
        public void reCountKeys(int startIndex)
        {
            int Sum = 0;
            for (int i = 0; i < startIndex; i++)
            {
                Sum += privateKey[i];
            }
            for (int i = startIndex; i < privateKey.Count; i++)
            {
                privateKey[i] = Sum + 1;
                Sum += privateKey[i];
            }
        }
        public string returnPrivateKeyString()
        {
            string s = "";
            foreach (int i in privateKey)
            {
                s += i.ToString() + " ";
            }
            return s;
        }
        public string returnPublicKeyString()
        {
            string s = "";
            foreach (int i in publicKey)
            {
                s += i.ToString() + " ";
            }
            return s;
        }
        public byte encrypte(byte encodeChar)
        {
            int code = encodeChar;
            BitArray bits = new BitArray(8);
            bits = returnBits(code);
            int C = 0;
            int j = 0;
            for (int i = 8; i > 0; i--)
            {
                if (bits[j++] == true)
                    C += publicKey[i - 1];
            }
            return (byte)C;
        }
        private BitArray returnBits(int code)
        {
            BitArray bits = new BitArray(8);
            int i = 0;
            while (code > 0)
            {
                if (code % 2 == 1)
                    bits.Set(i++, true);
                else
                    bits.Set(i++, false);
                code = code / 2;
            }
            return bits;
        }
        public byte decrypte(int decodeChar)
        {
            int TC = (decodeChar * im) % n;
            int P = 0; int k = 1;
            for (int i = privateKey.Count; i > 0; i--)
            {
                if (privateKey[i - 1] <= TC)
                {
                    P = P + k;
                    TC = TC - privateKey[i - 1];
                }
                k = k * 2;
            }
            return (byte)P;
        }
    }
}
