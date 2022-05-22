using Cryptography.ViewModels.Base;
using Cryptography.Views.Windows;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Pages

        public Page _CurrentPage;
        public Page CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }

        private readonly Page PolybiusSquare = new PolybiusSquare();
        private readonly Page Vigenere = new Vigenere();
        private readonly Page Feistel = new Feistel();
        private readonly Page ElGamal = new ElGamal();
        private readonly Page Caesar = new Caesar();
        private readonly Page Shamir = new Shamir();
        private readonly Page RSA = new RSA();

        public ICommand MenuPolybiusSquare_Click => new RelayCommand(() => CurrentPage = PolybiusSquare);
        public ICommand MenuCaesar_Click => new RelayCommand(() => CurrentPage = Caesar);
        public ICommand Vigenere_Click => new RelayCommand(() => CurrentPage = Vigenere);
        public ICommand Feistel_Click => new RelayCommand(() => CurrentPage = Feistel);
        public ICommand ElGamal_Click => new RelayCommand(() => CurrentPage = ElGamal);
        public ICommand Shamir_Click => new RelayCommand(() => CurrentPage = Shamir);
        public ICommand RSA_Click => new RelayCommand(() => CurrentPage = RSA);

        #endregion

        public MainWindowViewModel()
        {
        }
    }
}