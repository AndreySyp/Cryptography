using System;
using System.Text;

namespace Cryptography.Models
{
    internal class AlgorithmFeistel
    {
        private readonly int round;
        private readonly int size;

        public AlgorithmFeistel(int round, int sizeText)
        {
            if (sizeText % 2 != 0) sizeText++;

            this.round = round;
            this.size = sizeText;
        }

        public string Encrypt(string text, string[] strKey)
        {
            if (text.Length % 2 != 0) text += " ";
            int[,] key = AdditionalFunctions.StringArrToInt2dArr(round, size, strKey);

            byte[] binText = Encoding.Unicode.GetBytes(text);
            byte[] textL = new byte[size], textR = new byte[size];
            Array.Copy(binText, 0, textL, 0, size);
            Array.Copy(binText, size, textR, 0, size);

            for (int j = 0; j < round; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    textL[i] = (byte)(textR[i] ^ key[j, i] ^ textL[i]);
                    (textL[i], textR[i]) = (textR[i], textL[i]);
                }
            }

            Array.Copy(textL, 0, binText, 0, size);
            Array.Copy(textR, 0, binText, size, size);
            return Encoding.Unicode.GetString(binText);
        }
        public string Decrypt(string text, string[] strKey)
        {
            if (text.Length % 2 != 0) text += " ";
            int[,] key = AdditionalFunctions.StringArrToInt2dArr(round, size, strKey);

            byte[] binText = Encoding.Unicode.GetBytes(text);
            byte[] textL = new byte[size];
            byte[] textR = new byte[size];
            Array.Copy(binText, 0, textR, 0, size);
            Array.Copy(binText, size, textL, 0, size);

            for (int j = round - 1; j >= 0; j--)
            {
                for (int i = 0; i < size; i++)
                {
                    textL[i] = (byte)(textR[i] ^ key[j, i] ^ textL[i]);
                    (textL[i], textR[i]) = (textR[i], textL[i]);
                }
            }

            Array.Copy(textR, 0, binText, 0, size);
            Array.Copy(textL, 0, binText, size, size);
            return Encoding.Unicode.GetString(binText);
        }
        public string[] GenerateKey()
        {
            Random rnd = new();
            string[] keys = new string[round];
            for (int i = 0; i < round; i++)
            {
                StringBuilder sb = new();
                for (int j = 0; j < size; j++)
                    sb.Append(rnd.Next(0, 3) + " ");
                keys[i] = sb.ToString();
            }
            return keys;
        }
        public static long GenerateRounds()
        {
            Random rnd = new();
            int rounds;
            do
            {
                rounds = rnd.Next(17);
            } while (AdditionalFunctions.IsEven(rounds));
            return rounds;
        }
    }
}