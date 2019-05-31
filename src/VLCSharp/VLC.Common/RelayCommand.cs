using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VLC.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Func<object, object> execute;
        private readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;


        public RelayCommand(Func<object, object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Func<object, object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
