using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Models
{
    internal class AlgorithmVigenere
    {
        readonly string alphabet;

        private string RepeatKey(string str, int N)
        {
            string outStr = str;
            while (outStr.Length < N)
                outStr += outStr;

            return outStr.Substring(0, N);
        }
        private string Code(string text, string password, int e_d)
        {
            string keyString = RepeatKey(password, text.Length);
            string outText = "";

            for (int i = 0; i < text.Length; i++)
            {
                int textIndex = alphabet.IndexOf(text[i]);
                int keyIndex = alphabet.IndexOf(keyString[i]);
                if (textIndex < 0)
                    outText += text[i].ToString();
                else
                {
                    int index = (alphabet.Length + textIndex + (e_d * keyIndex)) % alphabet.Length;
                    outText += alphabet[index].ToString();
                }
            }

            return outText;
        }


        public AlgorithmVigenere(string alphabet)
        {
            this.alphabet = alphabet;
        }

        public string Encrypt(string text, string key)
        {
            return Code(text, key, 1);
        }
        public string Decrypt(string text, string key)
        {
            return Code(text, key, -1);
        }
    }
}
