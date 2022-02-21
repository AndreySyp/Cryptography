using Cryptography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptography.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Vigenere.xaml
    /// </summary>
    public partial class Vigenere : Page
    {
        string alphabet;
        bool isEncrypted;

        public Vigenere()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            AlgorithmVigenere v = new(alphabet);

            OutputText.Text = isEncrypted
                ? v.Encrypt(InputText.Text.ToString(), InputKey.Text.ToString())
                : v.Decrypt(InputText.Text.ToString(), InputKey.Text.ToString());
        }
        private void Language_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            switch (selectedItem.Name)
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
            RadioButton pressed = (RadioButton)sender;
            switch (pressed.Name)
            {
                case "Encrypt":
                    isEncrypted = true;
                    break;
                case "Decrypt":
                    isEncrypted = false;
                    break;
            }
        }
        private void TextBox_OnlyNumber(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int val))
            {
                e.Handled = true;
            }
        }
        private void TextBox_NoSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}