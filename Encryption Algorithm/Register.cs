using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Encryption_Algorithm
{
    public class Register
    {
        public BitArray Value;
        public bool MajorityVoteBit = false;
        public int MajorityVoteBiteNumber;
        public bool[] StepBits;
        public int[] StepBitsNumbers;
        public int Length;

        #region Constructors
        public Register(BitArray bits, int majorityVoteBit, int[] stepBitsNumbers)
        {
            Value = bits;
            MajorityVoteBiteNumber = majorityVoteBit;
            StepBitsNumbers = stepBitsNumbers;
            MajorityVoteBit = Value.Get(MajorityVoteBiteNumber);
            StepBits = new bool[stepBitsNumbers.Length];
            for (int i = 0; i < StepBitsNumbers.Length; i++)
            {
                StepBits[i] = Value.Get(StepBitsNumbers[i]);
            }
            Length = Value.Length;
        }

        public Register(byte[] bytes, int majorityVoteBit, int[] stepBitsNumbers)
        {
            Value = new BitArray(bytes);
            MajorityVoteBiteNumber = majorityVoteBit;
            StepBitsNumbers = stepBitsNumbers;
            MajorityVoteBit = Value.Get(MajorityVoteBiteNumber);
            for (int i = 0; i < StepBitsNumbers.Length; i++)
            {
                StepBits[i] = Value.Get(StepBitsNumbers[i]);
            }
            Length = Value.Length;
        }

        public Register(int length, int majorityVoteBit, int[] stepBitsNumbers)
        {
            Value = new BitArray(length, false);
            MajorityVoteBiteNumber = majorityVoteBit;
            StepBitsNumbers = stepBitsNumbers;
            MajorityVoteBit = Value.Get(MajorityVoteBiteNumber);
            for (int i = 0; i < StepBitsNumbers.Length; i++)
            {
                StepBits[i] = Value.Get(StepBitsNumbers[i]);
            }
            Length = length;
        }
        #endregion

        #region Methods
        //public void ShiftRight()
        //{
        //    for (int i = Length - 1; i > 0; i--)
        //    {
        //        Value.Set(i, Value.Get(i - 1));
        //    }
        //    Value.Set(0, false);
        //    MajorityVoteBit = Value[MajorityVoteBiteNumber];
        //}

        public void ShiftLeft()
        {
            for (int i = Length - 1; i > 0; i--)
            {
                Value.Set(i, Value.Get(i - 1));
            }
            bool t = false;
            foreach (var item in StepBitsNumbers)
            {
                t = t ^ Value.Get(item);
            }
            Value.Set(0, t);
            MajorityVoteBit = Value[MajorityVoteBiteNumber];
        }
        /// <summary>
        /// Nije dobro
        /// </summary>
        //public void RotateRight()
        //{
        //    bool firstBit = Value.Get(Length - 1);
        //    for (int i = 0; i < Length - 1; i++)
        //    {
        //        Value.Set(i, Value.Get(i + 1));
        //    }
        //    Value.Set(Length - 1, firstBit);
        //}
        /// <summary>
        /// Nije dobro
        /// </summary>
        //public void RotateLeft()
        //{
        //    bool lastBit = Value.Get(0);
        //    for (int i = Length; i > 1; i++)
        //    {
        //        Value.Set(i, Value.Get(i - 1));
        //    }
        //    Value.Set(0, lastBit);
        //}

        public string ToString()
        {
            string value = "";
            foreach (bool bit in Value)
            {
                if (bit)
                {
                    value = "1" + value;
                }
                else
                {
                    value = "0" + value;
                }
            }
            return value;
        }
        #endregion
    }
}
