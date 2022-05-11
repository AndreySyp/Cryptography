using Cryptography.Models;
using Cryptography.Infrastructure.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.Views.Windows
{
    public partial class ElGamal : Page
    {
        private bool isEncrypted;

        public ElGamal()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            VerificationGenerationKey.GenerateKey(out long p, InputP, AdditionalFunctions.GenerateSimpleNumber, AdditionalFunctions.IsPrime);
            VerificationGenerationKey.GenerateKey(p, out long g, InputG, AlgorithmElGamal.GenerateKey, (long num, long p) => { return num > p; });
            VerificationGenerationKey.GenerateKey(p, out long x, InputX, AlgorithmElGamal.GenerateKey, (long num, long p) => { return num > p; });
            long.TryParse(InputA.Text.ToString(), out long a);
            long y = AdditionalFunctions.PMC(g, x, p);

            AlgorithmElGamal f = new(p, g, x, y);

            string text = InputText.Text.ToString();
            OutputText.Text = isEncrypted ? f.Encrypt(text, out a) : f.Decrypt(text, a);

            InputY.Text = y.ToString();
            InputA.Text = a.ToString();
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