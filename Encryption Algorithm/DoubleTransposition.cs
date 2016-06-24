using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Algorithm
{
    public class DoubleTransposition : ICryptingAlgorithm
    {
        private static DoubleTransposition _doubleTransposition;
        private bool _crypt_decrypt;
        private string _KeyRows { get; set; }
        private string _KeyColumns { get; set; }
        private string _OriginalMessage { get; set; }
        private string _CryptedMessage { get; set; }
        private char[,] _PermutationMatrix { get; set; }
        private int _RowSize { get; set; }
        private int _ColumnSize { get; set; }

        protected DoubleTransposition()
        {

        }

        public static DoubleTransposition GetInstance()
        {
            if (_doubleTransposition == null)
            {
                return new DoubleTransposition();
            }
            else
                return _doubleTransposition;
        }

        public void SetProperties(bool crypt_decrypt, string keyRows, string keyColumns, string message)
        {
            _RowSize = keyRows.Split(',').Length;
            _ColumnSize = keyColumns.Split(',').Length;
            if (_RowSize != _ColumnSize)
            {
                throw new Exception("Key not valid!");
            }
            if (crypt_decrypt)
            {
                _KeyRows = keyRows;
                _KeyColumns = keyColumns;
                _OriginalMessage = message;
            }
            else
            {
                _KeyRows = keyRows;
                _KeyColumns = keyColumns;
                _CryptedMessage = message;
            }
            _PermutationMatrix = new char[_RowSize, _ColumnSize];
        }

        private void SetValuesMatrix(string newMessage)
        {
            for (int i = 0; i < _RowSize; i++)
            {
                for (int j = 0; j < _ColumnSize; j++)
                {
                    if (i * _ColumnSize + j < newMessage.Length)
                    {
                        _PermutationMatrix[i, j] = newMessage[i * _ColumnSize + j];
                    }
                    else
                    {
                        _PermutationMatrix[i, j] = '\0';
                    }
                }
            }
        }

        public string Encrypt()
        {
            string[] rowIndexes = _KeyRows.Split(',');
            string[] columnIndexes = _KeyColumns.Split(',');
            if (rowIndexes.Length > _RowSize || columnIndexes.Length > _ColumnSize)
            {
                throw new Exception("Index out of bounds. Please enter valid indexes, from 0 to " + (_RowSize - 1).ToString()
                    + " for row and from 0 to " + (_ColumnSize - 1).ToString() + " for column.");
            }
            else
            {
                string message = _OriginalMessage;
                char[,] AfterX = new char[_RowSize, _ColumnSize];
                char[,] AfterY = new char[_RowSize, _ColumnSize];
                do
                {
                    string partialMessage;
                    if (_RowSize * _ColumnSize <= message.Length)
                    {
                        partialMessage = message.Substring(0, _RowSize * _ColumnSize);
                        message = message.Substring(_RowSize * _ColumnSize);
                    }
                    else
                    {
                        partialMessage = message;
                        for (int index = 0; index < _ColumnSize * _RowSize - message.Length; index++)
                        {
                            partialMessage += " ";
                        }
                        message = "";
                    }
                    SetValuesMatrix(partialMessage);
                    //row permutations
                    for (int i = 0; i < rowIndexes.Length; i++)
                    {
                        int row = Convert.ToInt32(rowIndexes[i]);
                        for (int j = 0; j < _ColumnSize; j++)
                        {
                            AfterX[i, j] = _PermutationMatrix[row, j];
                        }
                    }
                    //column permutations
                    for (int i = 0; i < columnIndexes.Length; i++)
                    {
                        int column = Convert.ToInt32(columnIndexes[i]);
                        for (int j = 0; j < _RowSize; j++)
                        {
                            AfterY[j, i] = AfterX[j, column];
                        }
                    }                    
                } while (message.Length != 0);
                _CryptedMessage = "";
                for (int i = 0; i < _RowSize; i++)
                {
                    for (int j = 0; j < _ColumnSize; j++)
                    {
                        _CryptedMessage += AfterY[i, j];
                    }
                }
            }
            return _CryptedMessage;
        }

        public string Decrypt()
        {
            for (int i = 0; i < _RowSize; i++)
            {
                for (int j = 0; j < _ColumnSize; j++)
                {
                    _PermutationMatrix[i, j] = _CryptedMessage[i * _ColumnSize + j];
                }
            }
            string[] rowIndexes = _KeyRows.Split(',');
            string[] columnIndexes = _KeyColumns.Split(',');
            if (rowIndexes.Length != _RowSize || columnIndexes.Length != _ColumnSize)
            {
                throw new Exception("Index out of bounds. Please enter valid indexes, from 0 to " + (_RowSize - 1).ToString() + " for row and from 0 to " + (_ColumnSize - 1).ToString() + " for column.");
            }
            else
            {
                string partialMessage;
                _OriginalMessage = "";
                string message = _CryptedMessage;
                char[,] AfterX = new char[_RowSize, _ColumnSize];
                char[,] AfterY = new char[_RowSize, _ColumnSize];
                do
                {
                    if (message.Length >= _RowSize * _ColumnSize)
                    {
                        partialMessage = message.Substring(0, _RowSize * _ColumnSize);
                        message = message.Substring(_RowSize * _ColumnSize);
                    }
                    else
                    {
                        for (int i = 0; i < _RowSize * _ColumnSize - message.Length; i++)
                        {
                            message += " ";
                        }
                        partialMessage = message;
                        message = "";
                    }
                    SetValuesMatrix(partialMessage);
                    //column permutations
                    for (int i = 0; i < columnIndexes.Length; i++)
                    {
                        int column = Convert.ToInt32(columnIndexes[i]);
                        for (int j = 0; j < _RowSize; j++)
                        {
                            AfterY[j, column] = _PermutationMatrix[j, i];
                        }
                    }
                    //row permutations
                    for (int i = 0; i < rowIndexes.Length; i++)
                    {
                        int row = Convert.ToInt32(rowIndexes[i]);
                        for (int j = 0; j < _ColumnSize; j++)
                        {
                            AfterX[row, j] = AfterY[i, j];
                        }
                    }
                    for (int i = 0; i < _RowSize; i++)
                    {
                        for (int j = 0; j < _ColumnSize; j++)
                        {
                            _OriginalMessage += AfterX[i, j];
                        }
                    }
                } while (message.Length != 0);
            }
            return _OriginalMessage;
        }

        //
        public void SetProperties(byte[] Key, byte[] message)
        {
            throw new Exception("Currently in use is Double Transposition Algorithm. Please use proper version of this function."
                + "\nSetProperties(bool _crypt_decrypt, string rowKey, string columnKey, string message)");
        }
    }
}
