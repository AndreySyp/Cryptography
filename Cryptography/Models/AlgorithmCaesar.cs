using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Models
{
    internal class AlgorithmCasaer
    {
        private readonly string alphabet;

        private string Code(string text, int key)
        {
            string outText = "";

            for (int i = 0; i < text.Length; i++)
            {
                int index = alphabet.IndexOf(text[i]);
                if (index == -1) outText += text[i];
                else outText += alphabet[(alphabet.Length + index + key) % alphabet.Length];
            }

            return outText;
        }


        public AlgorithmCasaer(string alphabet)
        {
            this.alphabet = alphabet;
        }

        public string Encrypt(string text, int key)
        {
            return Code(text.ToLower(), key);
        }
        public string Decrypt(string text, int key)
        {
            return Code(text.ToLower(), -key);
        }
    }
}
