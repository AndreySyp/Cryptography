using Cryptography.ViewModels.Base;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.Windows.Controls;
using System.Windows.Input;
using Cryptography.Views.Windows;
using System.Windows;

namespace Cryptography.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Pages

        private readonly Page Caesar = new Caesar();
        private readonly Page PolybiusSquare = new PolybiusSquare();
        private readonly Page Vigenere = new Vigenere();

        public Page _CurrentPage;

        public Page CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }
        public ICommand MenuCaesar_Click => new RelayCommand(() => CurrentPage = Caesar);
        public ICommand MenuPolybiusSquare_Click => new RelayCommand(() => CurrentPage = PolybiusSquare);
        public ICommand Vigenere_Click => new RelayCommand(() => CurrentPage = Vigenere);

        #endregion

        public MainWindowViewModel()
        {
        }
    }
}
