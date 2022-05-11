using System;

namespace Cryptography.Models
{
    internal class AdditionalFunctions
    {
        public static long GCD(long a, long b, out long x, out long y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return b;
            }
            long d = GCD(b % a, a, out long x1, out long y1);
            x = y1 - (b / a * x1);
            y = x1;
            return d;

        }//GreatestCommonDivisor
        public static long PMC(long @base, long exponen, long modulus)
        {
            long result = 1;

            while (exponen > 0)
            {
                if (exponen % 2 == 1)
                {
                    result = result * @base % modulus;
                    exponen--;
                }
                @base = @base * @base % modulus;
                exponen /= 2;
            }

            return result;
        }//PowerModCalculator

        public static int[,] StringArrToInt2dArr(int N, int M, string[] Inkeys)
        {
            int[,] keys = new int[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    keys[i, j] = Inkeys[i][j];
            return keys;
        }

        public static long GenerateSimpleNumber()
        {
            Random rnd = new();
            byte[] numberBytes = new byte[4];
            rnd.NextBytes(numberBytes);
            long number = BitConverter.ToUInt16(numberBytes, 0);

            while (!IsPrime(number))
                unchecked { number++; }
            return number;
        }

        public static bool IsPrime(long number)
        {
            if ((number & 1) == 0) return number == 2;

            long limit = (long)Math.Sqrt(number);
            for (long i = 3; i <= limit; i += 2)
                if ((number % i) == 0) return false;
            return true;
        }
        public static bool IsEven(long rounds)
        {
            return !(rounds % 2 == 0);
        }
    }
}