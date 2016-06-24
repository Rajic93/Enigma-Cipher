using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Algorithm
{
    public class XTEA : TEA
    {
        private uint _numOfRounds;

        public XTEA(uint numOfRounds)
        {
            _numOfRounds = numOfRounds;
        }

        override protected byte[] BlockCipherCryption(byte[] result)
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
                for (int i = 0; i < _numOfRounds; i++)
                {
                    uint index = 0;
                    if ((sum & 3) == 0)
                    {
                        index = key1;
                    }
                    else if ((sum & 3) == 1)
                    {
                        index = key2;
                    }
                    else if ((sum & 3) == 2)
                    {
                        index = key3;
                    }
                    else if ((sum & 3) == 3)
                    {
                        index = key4;
                    }
                    left += ((right << 4) ^ (right >> 5) + right) ^ (sum + index);
                    sum += _delta; 
                    index = 0;
                    if (((sum >> 11) & 3) == 0)
                    {
                        index = key1;
                    }
                    else if (((sum >> 11) & 3) == 1)
                    {
                        index = key2;
                    }
                    else if (((sum >> 11) & 3) == 2)
                    {
                        index = key3;
                    }
                    else if (((sum >> 11) & 3) == 3)
                    {
                        index = key4;
                    }
                    right += ((left << 4) ^ (left >> 5) + left) ^ (sum + index);
                }
            }
            else
            {
                UInt32 sum = _delta * _numOfRounds;
                for (int i = 0; i < _numOfRounds; i++)
                {
                    uint index = 0;
                    if (((sum >> 11) & 3) == 0)
                    {
                        index = key1;
                    }
                    else if (((sum >> 11) & 3) == 1)
                    {
                        index = key2;
                    }
                    else if (((sum >> 11) & 3) == 2)
                    {
                        index = key3;
                    }
                    else if (((sum >> 11) & 3) == 3)
                    {
                        index = key4;
                    }
                    right -= ((left << 4) ^ (left >> 5) + left) ^ (sum + index);
                    sum -= _delta;
                    index = 0;
                    if ((sum & 3) == 0)
                    {
                        index = key1;
                    }
                    else if ((sum & 3) == 1)
                    {
                        index = key2;
                    }
                    else if ((sum & 3) == 2)
                    {
                        index = key3;
                    }
                    else if ((sum & 3) == 3)
                    {
                        index = key4;
                    }
                    left -= ((right << 4) ^ (right >> 5) + right) ^ (sum + index);
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
    }
}
