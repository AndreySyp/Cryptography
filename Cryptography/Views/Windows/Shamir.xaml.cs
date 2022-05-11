using Cryptography.Infrastructure.Commands;
using Cryptography.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.Views.Windows
{
    public partial class Shamir : Page
    {
        public Shamir()
        {
            InitializeComponent();
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Text == "") return;

            int dA = 0, cA = 0, dB = 0, cB = 0;

            VerificationGenerationKey.GenerateKey(out long p, InputP, AdditionalFunctions.GenerateSimpleNumber, AdditionalFunctions.IsPrime);
            AlgorithmShamir.Generate(ref dA, ref cA, (int)p);
            AlgorithmShamir.Generate(ref dB, ref cB, (int)p);

            AlgorithmShamir s = new((int)p, dA, cA, dB, cB);

            OutputTextX1.Text = s.X1(InputText.Text);
            OutputTextX2.Text = s.X2(OutputTextX1.Text);
            OutputTextX3.Text = s.X3(OutputTextX2.Text);
            OutputTextX4.Text = s.X4(OutputTextX3.Text);
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