using Cryptography.Infrastructure.Commands;
using Cryptography.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.Views.Windows
{
    public partial class Vigenere : Page
    {
        private string alphabet;
        private bool isEncrypted;

        public Vigenere()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            AlgorithmVigenere v = new(alphabet);

            string text = InputText.Text.ToString();
            VerificationGenerationKey.GenerateKey(out string key, InputKey, v.GenerateKey, (string num) => { return true; });

            OutputText.Text = isEncrypted ? v.Encrypt(text, key) : v.Decrypt(text, key);
        }

        private void Language_Selected(object sender, RoutedEventArgs e)
        {
            switch (((ComboBoxItem)((ComboBox)sender).SelectedItem).Name)
            {
                case "Eng":
                    alphabet = "abcdefghijklmnopqrstuvwxyz";
                    break;
                case "Ru":
                    alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                    break;
            }
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

        public void TextBox_NoSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
    }
}