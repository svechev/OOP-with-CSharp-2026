using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Problem2
{
    class TranspositionCipher
    {
        int cipherKey;
        string stringCipher;
        public string StringCipher
        {
            get;
            set;
        }

        public TranspositionCipher(string key)
        => cipherKey = key != null ? key.Length : 3;

        public string Encrypt(string plainText)
        {
            // declaration of local vars
            int rows = (int)Math.Ceiling((double)plainText.Length / cipherKey);
            char[,] encryptionMatrix = new char[rows, cipherKey];
            var plainTextChars = plainText.ToCharArray();
            var cipherTextChars = new char[encryptionMatrix.Length]; // rows * cipherKey


            // write by row
            int index = 0;
            for (int i = 0; i < encryptionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encryptionMatrix.GetLength(1); j++)
                {
                    if (index < plainText.Length)
                    {
                        encryptionMatrix[i, j] = plainTextChars[index++];
                    }
                    else
                    {
                        encryptionMatrix[i, j] = ' ';
                    }
                }
            }

            // read by columns
            index = 0;
            for (int i = 0; i < encryptionMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < encryptionMatrix.GetLength(0); j++)
                {
                    cipherTextChars[index++] = encryptionMatrix[j, i];
                }
            }

            return new string(cipherTextChars);
        }

        public string Decrypt(string cipherText)
        {
            // declaration of local vars
            int rows = (int)Math.Ceiling((double)cipherText.Length / cipherKey);
            char[,] encryptionMatrix = new char[rows, cipherKey];
            var cipherTextChars = cipherText.ToCharArray();
            var plainTextChars = new char[encryptionMatrix.Length]; // rows * cipherKey


            // write by cols
            int index = 0;
            for (int i = 0; i < encryptionMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < encryptionMatrix.GetLength(0); j++)
                {
                    if (index < cipherText.Length)
                    {
                        encryptionMatrix[j, i] = cipherTextChars[index++];
                    }
                    else
                    {
                        encryptionMatrix[j, i] = ' ';
                    }
                }
            }

            // read by rows
            index = 0;
            for (int i = 0; i < encryptionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encryptionMatrix.GetLength(1); j++)
                {
                    plainTextChars[index++] = encryptionMatrix[i, j];
                }
            }

            return new string(plainTextChars);
        }

    }
}
