using Cryptography.Infrastructure.Commands;
using Cryptography.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.Views.Windows
{
    public partial class PolybiusSquare : Page
    {
        private string alphabet;
        private bool isEncrypted;
        private int method;
        public PolybiusSquare()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            AlgorithmPolybiusSquare ps = new(alphabet, method);

            string text = InputText.Text.ToString();
            VerificationGenerationKey.GenerateKey(out string key, InputKey, ps.GenerateKey, (string num) => { return true; });

            OutputText.Text = isEncrypted ? ps.Encrypt(text, key) : ps.Decrypt(text, key);
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
        private void Method_Selected(object sender, RoutedEventArgs e)
        {
            switch (((ComboBoxItem)((ComboBox)sender).SelectedItem).Name)
            {
                case "One":
                    method = 1;
                    break;
                case "Two":
                    method = 2;
                    break;
            }
        }

        public void TextBox_NoSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
    }
}