using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Models
{
    internal class AlgorithmPolybiusSquare
    {
        private readonly int method;
        private readonly string alphabet;
        private int size;

        private char[,] GetSquare(string key)
        {
            string newAlphabet = alphabet;
            int index = 0;

            for (int i = 0; i < key.Length; i++)
                newAlphabet = newAlphabet.Replace(key[i].ToString(), "");

            newAlphabet = key + newAlphabet + " 0123456789?!,.";
            size = (int)Math.Ceiling(Math.Sqrt(alphabet.Length));
            char[,] square = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    square[i, j] = newAlphabet[index];
                    index++;
                }
            }

            return square;
        }
        private bool FindSymbol(char[,] symbolsTable, char symbol, ref int column, ref int row)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (symbolsTable[i, j] == symbol)
                    {
                        row = i;
                        column = j;
                        return true;
                    }
                }
            }

            row = -1;
            column = -1;
            return false;
        }


        public AlgorithmPolybiusSquare(string alphabet, int method)
        {
            this.alphabet = alphabet;
            this.method = method;
        }

        public string Encrypt(string text, string key)
        {
            text = text.ToLower();
            string outText = "";
            char[,] square = GetSquare(key);

            switch (method)
            {
                case 1:
                    for (int i = 0; i < text.Length; i++)
                    {
                        int columnIndex = 0, rowIndex = 0;
                        int newRowIndex;

                        if (FindSymbol(square, text[i], ref columnIndex, ref rowIndex))
                        {
                            if (rowIndex == size - 1) newRowIndex = 0;
                            else newRowIndex = rowIndex + 1;

                            outText += square[newRowIndex, columnIndex].ToString();
                        }
                    }
                    break;
                case 2:
                    int[] coordinates = new int[text.Length * 2];

                    for (int i = 0; i < text.Length; i++)
                    {
                        int columnIndex = 0, rowIndex = 0;

                        if (FindSymbol(square, text[i], ref columnIndex, ref rowIndex))
                        {
                            coordinates[i] = columnIndex;
                            coordinates[i + text.Length] = rowIndex;
                        }
                    }
                    for (int i = 0; i < text.Length * 2; i += 2)
                        outText += square[coordinates[i + 1], coordinates[i]];
                    break;
            }


            return outText;
        }
        public string Decrypt(string text, string key)
        {
            text = text.ToLower();
            string outText = "";
            char[,] square = GetSquare(key);

            switch (method)
            {
                case 1:
                    for (int i = 0; i < text.Length; i++)
                    {
                        int columnIndex = 0, rowIndex = 0;
                        int newRowIndex;

                        if (FindSymbol(square, text[i], ref columnIndex, ref rowIndex))
                        {
                            if (rowIndex == 0) newRowIndex = size - 1;
                            else newRowIndex = rowIndex - 1;

                            outText += square[newRowIndex, columnIndex].ToString();
                        }
                    }
                    break;
                case 2:
                    int[] coordinates = new int[text.Length * 2];
                    int j = 0;

                    for (int i = 0; i < text.Length; i++)
                    {
                        int columnIndex = 0, rowIndex = 0;
                        if (FindSymbol(square, text[i], ref columnIndex, ref rowIndex))
                        {
                            coordinates[j] = columnIndex;
                            coordinates[j + 1] = rowIndex;
                            j += 2;
                        }
                    }
                    for (int i = 0; i < text.Length; i++)
                        outText += square[coordinates[i + text.Length], coordinates[i]];
                    break;
            }

            return outText;
        }
    }
}

