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