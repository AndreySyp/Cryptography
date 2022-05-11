using System;

namespace Cryptography.Models
{
    internal class AlgorithmCasaer
    {
        private readonly string alphabet;

        public AlgorithmCasaer(string alphabet)
        {
            this.alphabet = alphabet;
        }

        private string Code(string text, int key)
        {
            System.Text.StringBuilder outText = new(text);
            for (int i = 0; i < text.Length; i++)
            {
                int index = alphabet.IndexOf(text[i]);
                if (index != -1) outText[i] = alphabet[(alphabet.Length + index + key) % alphabet.Length];
            }
            return outText.ToString();
        }

        public string Encrypt(string text, int key)
        {
            return Code(text.ToLower(), key);
        }
        public string Decrypt(string text, int key)
        {
            return Code(text.ToLower(), -key);
        }
        public long GenerateKey()
        {
            Random rnd = new();
            return rnd.Next(-alphabet.Length, alphabet.Length);
        }
    }
}