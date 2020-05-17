using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FilmManagment.GUI.Commands
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> executeAction;
        private readonly Func<object, bool> canExecuteAction;

        public RelayCommand(Action<object> actionToExecute, Func<object, bool> canBeExecuted = null)
        {
            executeAction = actionToExecute;
            canExecuteAction = canBeExecuted;
        }

        public RelayCommand(Action actionToExecute, Func<bool> canBeExecuted = null) : this(parameter => actionToExecute(), parameter => canBeExecuted?.Invoke() ?? true)
        {
        }

        public RelayCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteAction?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            executeAction?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    class RelayCommand<Tmodel> : ICommand
    {
        private readonly Action<Tmodel> executeAction;
        private readonly Func<Tmodel, bool> canExecuteAction;

        public RelayCommand(Action<Tmodel> actionToExecute, Func<Tmodel, bool> canBeExecuted = null)
        {
            executeAction = actionToExecute;
            canExecuteAction = canBeExecuted;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is Tmodel typedParameter)
                return canExecuteAction?.Invoke(typedParameter) ?? true;
            return false;
        }

        public void Execute(object parameter)
        {
            if (parameter is Tmodel typedParameter)
                executeAction?.Invoke(typedParameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
