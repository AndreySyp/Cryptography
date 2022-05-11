using Cryptography.Infrastructure.Commands.Base;
using System;

namespace Cryptography.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentException(null, nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parametr) => _CanExecute?.Invoke(parametr) ?? true;

        public override void Execute(object parametr)
        {
            if (!CanExecute(parametr)) return;
            _Execute(parametr);
        }
    }
}