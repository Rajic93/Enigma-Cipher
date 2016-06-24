using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Algorithm
{
    public interface ICryptingAlgorithm
    {
        void SetProperties(bool crypt_decrypt, string keyRows, string keyColumns, string message);
        void SetProperties(byte[] Key, byte[] message);
        string Encrypt();
        string Decrypt();
    }
}
