using System;
using System.Windows.Controls;

namespace Cryptography.Infrastructure.Commands
{
    internal class VerificationGenerationKey
    {
        public delegate long RuleGenerateKeyNullParam();
        public delegate string RuleGenerateKeyNullParamStr();
        public delegate string[] RuleGenerateKeyNullParamStrArr();
        public delegate long RuleGenerateKeyOneParam(long num);
        public delegate void RuleGenerateKeyThreeParam(long num1,ref long num2, ref long num3);

        public delegate bool СonditionKeyOneParam(long num);
        public delegate bool СonditionKeyOneParamStr(string num);
        public delegate bool СonditionKeyOneParamStrArr(string[] num);
        public delegate bool СonditionKeyTwoParam(long num_1, long num_2);

        public static void GenerateKey(out long num, TextBox tb, RuleGenerateKeyNullParam rgk, СonditionKeyOneParam ck)
        {
            if (tb.Text.ToString() == "")
            {
                num = rgk();
                tb.Text = num.ToString();
            }
            else if (!ck(Convert.ToInt64(tb.Text.ToString())))
            {
                num = rgk();
                tb.Text = num.ToString();
            }
            else num = Convert.ToInt64(tb.Text.ToString());
        }
        public static void GenerateKey(out string str, TextBox tb, RuleGenerateKeyNullParamStr rgk, СonditionKeyOneParamStr ck)
        {
            if (tb.Text.ToString() == "")
            {
                str = rgk();
                tb.Text = str.ToString();
            }
            else if (!ck(tb.Text.ToString()))
            {
                str = rgk();
                tb.Text = str.ToString();
            }
            else str = tb.Text.ToString();
        }
        public static void GenerateKey(out string[] strs, TextBox tb, RuleGenerateKeyNullParamStrArr rgk, СonditionKeyOneParamStrArr ck)
        {
            if (tb.Text.ToString() == "")
            {
                strs = rgk();
                foreach (string item in strs)
                    tb.Text += item + "\n";
            }
            //else if (!ck(tb.Text.ToString())) //// Сделать проверку на длину ключа
            //{
            //    strs = rgk();
            //    foreach (string item in strs)
            //        tb.Text += item + "\n";
            //}
            else strs = tb.Text.Split('\n');
        }
        public static void GenerateKey(long m, out long d, out long e, TextBox tb1, TextBox tb2, RuleGenerateKeyThreeParam rgk)
        {
            d = 0; e = 0;
            if (tb1.Text.ToString() == "" || tb2.Text.ToString() == "")
            {
                rgk(m, ref d, ref e);
                tb1.Text = d.ToString();
                tb2.Text = e.ToString();
            }
            else
            {
                d = Convert.ToInt64(tb1.Text.ToString());
                e = Convert.ToInt64(tb2.Text.ToString());
            }
        }

        public static void GenerateKey(long p, out long num, TextBox tb, RuleGenerateKeyOneParam rgk, СonditionKeyTwoParam ck)
        {
            if (tb.Text.ToString() == "")
            {
                num = rgk(p);
                tb.Text = num.ToString();
            }
            else if (ck(Convert.ToInt64(tb.Text.ToString()), p))
            {
                num = rgk(p);
                tb.Text = num.ToString();
            }
            else num = Convert.ToInt64(tb.Text.ToString());
        }
    }
}