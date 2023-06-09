using System;
using System.Windows.Input;

namespace WPFToDolist.VievModel
{
    public class ViewModelCommand : ICommand
    {
        //Fields
        private readonly Action<object?> _executeAction;
        private readonly Func<object? , bool> _canExcuteAction;

        //Constuctors
        public ViewModelCommand(Action<object?> executeAction , Func<object? , bool> _canExcuteAction = null)
        {
            _executeAction = executeAction;
            this._canExcuteAction = _canExcuteAction;

        }
        public bool CanExecute(object? parameter)
        {
            if(_canExcuteAction == null) return true;
            else return _canExcuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }

        //Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}