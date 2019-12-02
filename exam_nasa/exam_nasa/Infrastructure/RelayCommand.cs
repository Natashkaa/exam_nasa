using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace exam_nasa.Infrastructure
{
    class RelayCommand : ICommand
    {
        readonly Action<object> action;
        readonly Predicate<object> predicate;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object> act, Predicate<object> pred = null)
        {
            action = act;
            predicate = pred;
        }

        public bool CanExecute(object parameter)
        {
            return predicate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
