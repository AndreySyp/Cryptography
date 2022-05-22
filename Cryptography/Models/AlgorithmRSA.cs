using System;
using System.Linq;

namespace Cryptography.Models
{
    internal class AlgorithmRSA
    {
        private readonly long p, q;
        public long n, m;
        public long d, e;
        public static void GenerateKey(long m,ref long d,ref long e)
        {
            for (int j = 3; j < m; j += 1331)
            {
                long gcd = AdditionalFunctions.GCD(j, m, out d, out _);
                if (gcd == 1 && d > 0)
                {
                    e = j;
                    break;
                }
            }
        }
        public AlgorithmRSA(long p, long q, long d, long e)
        {
            this.p = p;
            this.q = q;
            this.d = d;
            this.e = e;
            n = p * q;
            m = (p - 1) * (q - 1);
        }

        public string Encrypt(string text)
        {
            long[] intArr = new long[text.Length];

            for (int i = 0; i < text.Length; i++)
                intArr[i] = AdditionalFunctions.PMC(text[i], e, n);

            return string.Join(" ", Array.ConvertAll(intArr, x => x.ToString()));
        }
        public string Decrypt(string text)
        {
            long[] intArr;
            try { intArr = text.Split(" ").Select(x => long.Parse(x)).ToArray(); }
            catch (Exception) { return ""; }

            char[] charArr = new char[intArr.Length];

            for (int i = 0; i < intArr.Length; i++)
                charArr[i] = (char)AdditionalFunctions.PMC(intArr[i], d, n);

            return new string(charArr);
        }
    }
}