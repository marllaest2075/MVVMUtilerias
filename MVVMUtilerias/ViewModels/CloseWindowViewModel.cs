using MVVMUtilerias.Commands;
using MVVMUtilerias.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMUtilerias.ViewModels
{
    public class CloseWindowViewModel : BaseViewModel, ICloseWindow
    {

        private Relay _closeCommand;

        public Relay CloseCCommand => _closeCommand;

        public CloseWindowViewModel()
        {
            _closeCommand = new Relay(CloseWindow);
        }

        private void CloseWindow(object obj)
        {
            Close?.Invoke();
        }

        public Action Close { get ; set; }

        public bool CanClose()
        {
            return false;
        }
    }
}
