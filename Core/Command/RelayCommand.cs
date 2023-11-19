using Core.Command.Base;
using System;

namespace Core.Command
{
    public class RelayCommand : BaseCommand
    {
        readonly Action<object> execute;
        readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(Execute));
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
