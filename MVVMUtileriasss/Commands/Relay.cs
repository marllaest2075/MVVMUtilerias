using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMUtilerias.Commands
{
    public class Relay : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;
        public event EventHandler CanExecuteChanged;
        public Relay(Action<object> action, Predicate<object> predicate)
        {
            _action = action;
            _predicate = predicate;           
        }
        public Relay(Action<object> action) :this(action,null)
        {

        }
        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate(parameter);
        }
        public void Execute(object parameter)
        {
            _action(parameter);
        }
        public void Raise()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
