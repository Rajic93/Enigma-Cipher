using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Encryption_Algorithm
{
    public class A51
    {
        protected Register _X;
        protected Register _Y;
        protected Register _Z;
        protected byte[] _Key;
        protected byte[] _InputStream;
        protected byte[] _OutputStream;

        #region Constructors
        public A51()
        {
            
        }
        #endregion

        #region Public Methods
        public virtual void SetProperties(byte[] inputStream, byte[] key)
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
        }

        public byte[] GetCryptedMessage()
        {
            return _OutputStream;
        }

        public void Encrypt()
        {
            _Crypt();
        }

        public void Decrypt()
        {
            _Crypt();
        }
        #endregion

        #region Protected Methods
        protected virtual void _Crypt()
        {
            byte[] keyStreamBytes = GenerateKeyStream();
            _OutputStream = new byte[_InputStream.Length];
            for (int index = 0; index < keyStreamBytes.Length; index++)
            {
                _OutputStream[index] = (byte)(keyStreamBytes[index] ^ _InputStream[index]);
            }
            //string msg = System.Text.Encoding.ASCII.GetString(_OutputStream);
        }

        protected virtual byte[] GenerateKeyStream()
        {
            bool[] keyStream = new bool[_InputStream.Length * 8];
            //creating bool array of key stream that needs to be packed to byte array
            for (int i = 0; i < _InputStream.Length * 8; i++)
            {
                keyStream[i] = Round();
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

        protected virtual bool Round()
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
        }

        protected virtual bool Majority(bool p1, bool p2, bool p3)
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
        #endregion
    }
}
