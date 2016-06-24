using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Algorithm
{
    public class TEA
    {
        protected byte[] _Key = new byte[16];
        protected byte[] _InitializationVector = new byte[8];
        protected const UInt32 _delta = 0x9e3779b9;
        protected byte[] _BlockLHalf = new byte[8];
        protected byte[] _BlockHHalf = new byte[8];
        protected byte[] _InputStream;
        protected byte[] _OutputStream;
        protected short _Mode;
        protected bool _cryptDecrypt = true;

        #region Constructors
        public TEA()
        {

        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Method that set all needed properties for encryption/decryption.
        /// </summary>
        /// <param name="key">Key for encryption/decryption.</param>
        /// <param name="initializationVector">Initialization vector.</param>
        /// <param name="message">Stream of bytes that represents original message or cripted message.</param>
        public void SetProperties(byte[] key, byte[] initializationVector, byte[] message, short mode)
        {
            if (key.Length != 16 && initializationVector.Length != 8)
            {
                throw new Exception("Invalid Key and Initialization vector.");
            }
            else if (key.Length != 16)
            {
                throw new Exception("Invalid Key.");
            }
            else if (initializationVector.Length != 8)
            {
                throw new Exception("Invalid Initialization vector.");
            }
            else
            {
                _Key = key;
                _InitializationVector = initializationVector;
                _InputStream = message;
                _OutputStream = new byte[_InputStream.Length];
                _Mode = mode;
            }
        }
        /// <summary>
        /// Function that starts encryption.
        /// </summary>
        public void Encrypt()
        {
            _cryptDecrypt = true;
            switch (_Mode)
            {
                case (short)BlockCipherMode.CBC:
                    {
                        CBCEncryption();
                        break;
                    }
                case (short)BlockCipherMode.CFB:
                    {
                        CFBEncryption();
                        break;
                    }
                case (short)BlockCipherMode.CRT:
                    {
                        CRTEncryption();
                        break;
                    }
                case (short)BlockCipherMode.OFB:
                    {
                        OFBEncryption();
                        break;
                    }
                case (short)BlockCipherMode.PCBC:
                    {
                        PCBCEncryption();
                        break;
                    }
            }

        }
        /// <summary>
        /// Function that starts decryption.
        /// </summary>
        public void Decrypt()
        {
            _cryptDecrypt = false;
            switch (_Mode)
            {
                case (short)BlockCipherMode.CBC:
                    {
                        CBCDecryption();
                        break;
                    }
                case (short)BlockCipherMode.CFB:
                    {
                        CFBDecryption();
                        break;
                    }
                case (short)BlockCipherMode.CRT:
                    {
                        CRTDecryption();
                        break;
                    }
                case (short)BlockCipherMode.OFB:
                    {
                        OFBDecryption();
                        break;
                    }
                case (short)BlockCipherMode.PCBC:
                    {
                        PCBCDecryption();
                        break;
                    }
            }
        }
        /// <summary>
        /// Returns crypted or decrypted message.
        /// </summary>
        /// <returns>Crypted or decrypted message</returns>
        public byte[] GetCryptedMessage()
        {
            return _OutputStream;
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// 
        /// </summary>
        private void CBCEncryption()
        {
            byte[] block = new byte[8];
            int numOfBlock;
            if (((float)_InputStream.Length / 8) - (int)(_InputStream.Length / 8) == 0)
            {
                numOfBlock = _InputStream.Length / 8;
            }
            else
            {
                numOfBlock = _InputStream.Length / 8 + 1;
            }
            _OutputStream = new byte[numOfBlock * 8];
            for (int i = 0; i < numOfBlock; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i * 8 + j < _InputStream.Length)
                    {
                        block[j] = _InputStream[i * 8 + j];
                    }
                    else
                    {
                        block[j] = 0;
                    }
                }

                byte[] result = new byte[8];
                for (int index = 0; index < 8; index++)
                {
                    result[index] = (byte)(block[index] ^ _InitializationVector[index]);
                }

                result = BlockCipherCryption(result);
                _InitializationVector = (byte[])result.Clone();

                for (int j = 0; j < 8; j++)
                {
                    _OutputStream[i * 8 + j] = result[j];
                }
            }
        }
        private void PCBCEncryption()
        {
            throw new NotImplementedException();
        }

        private void OFBEncryption()
        {
            throw new NotImplementedException();
        }

        private void CRTEncryption()
        {
            throw new NotImplementedException();
        }

        private void CFBEncryption()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        private void CBCDecryption()
        {
            byte[] block = new byte[8];
            int numOfBlock;
            if (((float)_InputStream.Length / 8) - (int)(_InputStream.Length / 8) == 0)
            {
                numOfBlock = _InputStream.Length / 8;
            }
            else
            {
                numOfBlock = _InputStream.Length / 8 + 1;
            }
            _OutputStream = new byte[numOfBlock * 8];
            for (int i = 0; i < numOfBlock; i++)
            {

                byte[] result = new byte[8];
                for (int index = 0; index < 8; index++)
                {
                    if (i * 8 + index < _InputStream.Length)
                    {
                        result[index] = _InputStream[i * 8 + index];
                    }
                    else
                    {
                        result[index] = 0;
                    }
                }
                byte[] newInitializationVector = (byte[])result.Clone();
                result = BlockCipherCryption(result);
                for (int index = 0; index < 8; index++)
                {
                    result[index] = (byte)(result[index] ^ _InitializationVector[index]);

                }
                //byte[] newInitializationVector = result;
                _InitializationVector = newInitializationVector;

                for (int j = 0; j < 8; j++)
                {
                    _OutputStream[i * 8 + j] = result[j];
                }
            }
        }
        private void PCBCDecryption()
        {
            throw new NotImplementedException();
        }

        private void OFBDecryption()
        {
            throw new NotImplementedException();
        }

        private void CRTDecryption()
        {
            throw new NotImplementedException();
        }

        private void CFBDecryption()
        {
            throw new NotImplementedException();
        }

        virtual protected byte[] BlockCipherCryption(byte[] result)
        {
            byte[] partialKey1 = new byte[4];
            byte[] partialKey2 = new byte[4];
            byte[] partialKey3 = new byte[4];
            byte[] partialKey4 = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                partialKey1[i] = _Key[i];
                partialKey2[i] = _Key[i + 4];
                partialKey3[i] = _Key[i + 8];
                partialKey4[i] = _Key[i + 12];
            }
            for (int i = 0; i < 4; i++)
            {
                _BlockHHalf[i] = result[i + 4];
            }
            for (int i = 0; i < 4; i++)
            {
                _BlockLHalf[i] = result[i];
            }
            UInt32 key1 = (uint)BitConverter.ToInt32(partialKey1, 0);
            UInt32 key2 = (uint)BitConverter.ToInt32(partialKey2, 0);
            UInt32 key3 = (uint)BitConverter.ToInt32(partialKey3, 0);
            UInt32 key4 = (uint)BitConverter.ToInt32(partialKey4, 0);
            UInt32 left = (uint)BitConverter.ToInt32(_BlockHHalf, 0);
            UInt32 right = (uint)BitConverter.ToInt32(_BlockLHalf, 0);
            if (_cryptDecrypt)
            {
                UInt32 sum = 0;
                for (int i = 0; i < 32; i++)
                {
                    sum += _delta;
                    left += ((right << 4) + key1) ^ (right + sum) ^ ((right >> 5) + key2);
                    right += ((left << 4) + key3) ^ (left + sum) ^ ((left >> 5) + key4);
                }
            }
            else
            {
                UInt32 sum = 0xC6EF3720 << 5;        //shl 5
                for (int i = 0; i < 32; i++)
                {
                    right -= ((left << 4) + key3) ^ (left + sum) ^ ((left >> 5) + key4);
                    left -= ((right << 4) + key1) ^ (right + sum) ^ ((right >> 5) + key2);
                    sum -= _delta;
                }
            }
            _BlockHHalf = BitConverter.GetBytes(left);
            _BlockLHalf = BitConverter.GetBytes(right);
                for (int j = 0; j < 4; j++)
                {
                    result[j] = _BlockLHalf[j];
                }
                for (int j = 0; j < 4; j++)
                {
                    result[j + 4] = _BlockHHalf[j];
                }
            return result;
        }
        #endregion
    }

    public enum BlockCipherMode
    {
        PCBC,
        OFB,
        CFB,
        CBC,
        CRT
    }

}
