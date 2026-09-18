using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class RouteCipher
    {
        public int Key { get; set; }

        #region Constructor
        public RouteCipher(int key)
        {
            Key = key;
        }
        #endregion

        #region Methods
        public string Encrypt(string plainText)
        {
            // Declaration of local variables
            int rows = (int)Math.Ceiling((double)plainText.Length / Key);
            char[,] encryptionMatrix = new char[rows, Key];
            var plainTextChars = plainText.ToCharArray();
            var cipherTextChars = new char[encryptionMatrix.Length]; // rpows * cipherKey

            // Write to matrix
            int index = 0;
            for (int i = 0; i < encryptionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encryptionMatrix.GetLength(1); j++)
                {
                    if (index < plainTextChars.Length)
                    {
                        encryptionMatrix[i, j] = plainTextChars[index++];
                    }
                    else
                    {
                        encryptionMatrix[i, j] = 'X';
                    }
                }
            }

            // variable update and declaration
            index = 0;
            bool toEncrypt = true; // encrypt process - read characters from the matrix
            int matrixRows = encryptionMatrix.GetLength(0); // rows of matrix
            int matrixCols = encryptionMatrix.GetLength(1); // cols of matrix
            
            // Read matrix in spiral and save result in cipherTextChars
            if (Key > 0)
            {
                // if key is positive start from top left corner and read down
                readBottomLeft(toEncrypt, cipherTextChars, index, encryptionMatrix,
                    0, 0, matrixRows - 1, matrixCols - 1);
            }
            else
            {
                // if key is negative start from bottom right corner and read up
                readTopRight(toEncrypt, cipherTextChars, index, encryptionMatrix,
                    0, 0, matrixRows - 1, matrixCols - 1);
            }


            return new string(cipherTextChars);
        }

        public string Decrypt(string cipherText)
        {
            // Declaration of local variables
            int rows = (int)Math.Ceiling((double)cipherText.Length / Key);

            char[,] encryptionMatrix = new char[rows, Key];
            var cipherTextChars = cipherText.ToCharArray();
            var plainTextChars = new char[encryptionMatrix.Length]; // rows * cipherKey

            // variable declaration
            int index = 0;
            bool toEncrypt = false; // decrypt process - write character to the matrix
            int matrixRows = encryptionMatrix.GetLength(0); // rows of matrix
            int matrixCols = encryptionMatrix.GetLength(1); // cols of matrix


            // Read cipherTextChars and save the characters to the matrix in a spiral order
            if (Key > 0)
            {
                // if key is positive start from top left corner and read down
                readBottomLeft(toEncrypt, cipherTextChars, index, encryptionMatrix,
                    0, 0, matrixRows - 1, matrixCols - 1);
            }
            else
            {
                // if key is negative start from bottom right corner and read up
                readTopRight(toEncrypt, cipherTextChars, index, encryptionMatrix,
                    0, 0, matrixRows - 1, matrixCols - 1);
            }

            // Read from matrix
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

        // function to read the bottom-left peel of the matrix
        // and recursively call the top-right on the submatrix.
        private void readBottomLeft(bool toEncrypt, char[] chars, int index, char[,] matrix, int r1, int c1, int r2, int c2)
        {
            // read values in the column
            for (int i = r1; i <= r2; i++)
            {
                if (toEncrypt)
                {
                    chars[index++] = matrix[i, c1];
                }
                else
                {
                    matrix[i, c1] = chars[index++];
                }
            }

            // read values in the row.
            for (int j = c1 + 1; j <= c2; j++)
            {
                if (toEncrypt)
                {
                    chars[index++] = matrix[r2, j];
                }
                else
                {
                    matrix[r2, j] = chars[index++];
                }
            }

            // see if more layers need to be read.
            if (index < chars.Length)
            {
                // if yes recursively call the function to 
                // read the top right of the sub matrix.
                readTopRight(toEncrypt, chars, index, matrix, r1, c1 + 1, r2 - 1, c2);
            }
        }

        // function to print the bottom-left peel of the matrix and 
        // recursively call the print top-right on the submatrix.
        private void readTopRight(bool toEncrypt, char[] chars, int index, char[,] matrix, int r1, int c1, int r2, int c2)
        {

            // read the values in the column in reverse order.
            for (int i = r2; i >= r1; i--)
            {
                if (toEncrypt)
                {
                    chars[index++] = matrix[i,c2];
                }
                else
                {
                    matrix[i,c2] = chars[index++];
                }
            }

            // read the values in the row in reverse order.
            for (int j = c2 - 1; j >= c1; j--)
            {
                if (toEncrypt)
                {
                    chars[index++] = matrix[r1,j];
                }
                else
                {
                    matrix[r1,j] = chars[index++];
                }
            }

            // see if more layers need to be read.
            if (index < chars.Length)
            {
                // if yes recursively call the function to 
                // print the bottom left of the sub matrix.
                readBottomLeft(toEncrypt, chars, index, matrix, r1 + 1, c1, r2, c2 - 1);
            }
        }

        // toString method for the RouteCipher class
        override public string ToString()
         => $"Route cipher with key = {Key}";
        #endregion
    }
}
