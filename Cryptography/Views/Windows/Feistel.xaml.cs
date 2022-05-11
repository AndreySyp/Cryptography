using Cryptography.Infrastructure.Commands;
using Cryptography.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.Views.Windows
{
    public partial class Feistel : Page
    {
        private bool isEncrypted;

        public Feistel()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            string text = InputText.Text.ToString();
            VerificationGenerationKey.GenerateKey(out long rounds, InputRounds, AlgorithmFeistel.GenerateRounds, (long num) => { return num % 2 == 0 && num > 0; });
            AlgorithmFeistel f = new((int)rounds, text.Length);
            VerificationGenerationKey.GenerateKey(out string[] key, InputKey, f.GenerateKey, (string[] strs) => { return false; });

            OutputText.Text = isEncrypted ? f.Encrypt(text, key) : f.Decrypt(text, key);
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