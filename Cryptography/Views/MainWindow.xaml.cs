using Cryptography.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Cryptography
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            App.LanguageChanged += LanguageChanged;
            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (CultureInfo lang in App.Languages)
            {
                MenuItem menuLang = new()
                {
                    Header = lang.DisplayName,
                    Tag = lang,
                    IsChecked = lang.Equals(currLang)
                };
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }
        }

        private void LanguageChanged(object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
                i.IsChecked = i.Tag is CultureInfo ci && ci.Equals(currLang);
        }

        private void ChangeLanguageClick(object sender, EventArgs e)
        {
            if (sender is MenuItem mi)
                if (mi.Tag is CultureInfo lang) App.Language = lang;
        }
    }
}