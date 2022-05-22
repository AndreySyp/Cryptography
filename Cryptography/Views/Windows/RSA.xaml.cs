using Cryptography.Infrastructure.Commands;
using Cryptography.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.Views.Windows
{
    public partial class RSA : Page
    {
        private bool isEncrypted;

        public RSA()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            VerificationGenerationKey.GenerateKey(out long p, InputP, AdditionalFunctions.GenerateSimpleNumber, AdditionalFunctions.IsPrime);
            VerificationGenerationKey.GenerateKey(out long q, InputQ, AdditionalFunctions.GenerateSimpleNumber, AdditionalFunctions.IsPrime);
            VerificationGenerationKey.GenerateKey((p - 1) * (q - 1), out long d, out long ee, InputD, InputE, AlgorithmRSA.GenerateKey);

            AlgorithmRSA rsa = new(p, q, d ,ee);

            string text = InputText.Text.ToString();
            OutputText.Text = isEncrypted ? rsa.Encrypt(text) : rsa.Decrypt(text);

            OutputM.Text = rsa.m.ToString();
            OutputN.Text = rsa.n.ToString();
        }

        private void Code_Checked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "Encrypt":
                    isEncrypted = true;
                    break;
                case "Decrypt":
                    isEncrypted = false;
                    break;
            }
        }

        public void TextBox_OnlyNumber(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _)) e.Handled = true;
        }
        public void TextBox_NoSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
    }
}
