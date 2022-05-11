using System;
using System.Linq;

namespace Cryptography.Models
{
    internal class AlgorithmShamir
    {
        private readonly int p, dA, cA, dB, cB;

        public static void Generate(ref int d, ref int c, int p)
        {
            Random rnd = new();

            d = 1;
            c = rnd.Next(p);
            while (d < p)
            {
                if (d * c % (p - 1) == 1) return;
                d++;
            }
            if (d == p) Generate(ref d, ref c, p);
        }

        public AlgorithmShamir(int p, int dA, int cA, int dB, int cB)
        {
            this.p = p;
            this.dA = dA;
            this.cA = cA;
            this.dB = dB;
            this.cB = cB;
        }

        public string X1(string text)
        {
            int[] intArr = new int[text.Length];
            Array.Copy(text.ToCharArray(), intArr, text.Length);
            return X(intArr, cA);

        }
        public string X2(string text)
        {
            return X(text.Split(' ').Select(x => int.Parse(x)).ToArray(), cB);
        }
        public string X3(string text)
        {
            return X(text.Split(' ').Select(x => int.Parse(x)).ToArray(), dA);
        }
        public string X4(string text)
        {
            int[] intArr = text.Split(' ').Select(x => int.Parse(x)).ToArray();
            char[] charArr = new char[intArr.Length];

            for (int i = 0; i < intArr.Length; i++)
                charArr[i] = (char)AdditionalFunctions.PMC(intArr[i], dB, p);

            return new string(charArr);
        }

        private string X(int[] intArr, int key)
        {
            for (int i = 0; i < intArr.Length; i++)
                intArr[i] = (int)AdditionalFunctions.PMC(intArr[i], key, p);
            return string.Join(" ", Array.ConvertAll(intArr, x => x.ToString()));
        }
    }
}