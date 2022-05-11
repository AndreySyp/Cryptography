using System;
using System.Linq;

namespace Cryptography.Models
{
    internal class AlgorithmElGamal
    {
        private readonly long p, g, x, y;
        public AlgorithmElGamal(long p, long g, long x, long y)
        {
            this.p = p;
            this.g = g;
            this.x = x;
            this.y = y;
        }

        public string Encrypt(string text, out long a)
        {
            int[] intArr = new int[text.Length];
            Random rnd = new();
            uint k;

            do
            {
                k = (uint)(rnd.NextDouble() * uint.MaxValue);
            } while (AdditionalFunctions.GCD(k, p - 1, out _, out _) != 1 && k > p - 1);

            a = AdditionalFunctions.PMC(g, k, p);
            for (int i = 0; i < text.Length; i++)
            {
                long t1 = AdditionalFunctions.PMC(y, k, p);
                long t2 = AdditionalFunctions.PMC(t1 * text[i], 1, p);
                intArr[i] = (char)t2;
            }

            return string.Join(" ", Array.ConvertAll(intArr, x => x.ToString()));
        }
        public string Decrypt(string text, long a)
        {
            int[] intArr;
            try { intArr = text.Split(' ').Select(x => int.Parse(x)).ToArray(); }
            catch (Exception) { return ""; }

            char[] charArr = new char[intArr.Length];

            for (int i = 0; i < intArr.Length; i++)
            {
                long t1 = AdditionalFunctions.PMC(a, p - 1 - x, p);
                long t2 = AdditionalFunctions.PMC(t1 * intArr[i], 1, p);
                charArr[i] = (char)t2;
            }

            return new string(charArr);
        }
        public static long GenerateKey(long max)
        {
            Random rnd = new();
            long t = (long)(rnd.NextDouble() * long.MaxValue);
            while (t > max)
                t = (t / 2) + rnd.Next(500);
            return t;
        }
    }
}