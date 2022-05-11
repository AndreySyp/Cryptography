using Cryptography.Infrastructure.Commands.Base;
using System.Windows;

namespace Cryptography.Infrastructure.Commands
{
    public class CloseWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object p)
        {
            Application.Current.Shutdown();
        }
    }
}