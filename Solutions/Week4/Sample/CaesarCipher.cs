using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class CaesarCipher
    {
		private int cipherKey;

		public int CipherKey
		{
			get => cipherKey;
			set => cipherKey = value != 0 ? value : 3;
		}

        public CaesarCipher(int key) => CipherKey = key;

		public string Encrypt(string plainText)
		{
			char[] plainTextChars = plainText.ToCharArray();
			char[] cipherTextChars = new char[plainTextChars.Length];

			for (int i = 0; i < plainTextChars.Length; i++)
			{
				cipherTextChars[i] = (char)('A' + (plainTextChars[i] - 'A' + cipherKey + 26) % 26);
			}

			return new string(cipherTextChars);
		}

		public string Decrypt(string cipherText)
		{
            char[] cipherTextChars = cipherText.ToCharArray(); 
            char[] plainTextChars = new char[cipherTextChars.Length];

            for (int i = 0; i < cipherTextChars.Length; i++)
            {
                plainTextChars[i] = (char)('A' + (cipherTextChars[i] - 'A' - cipherKey + 26) % 26);
            }

            return new string(plainTextChars);
		}

    }
}
