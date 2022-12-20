using System;
using System.Windows.Input;
using WPF_IMS.ViewModel;

namespace WPF_IMS.Command
{
    public class GetInstrumentsComamand : ICommand
    {
        public MainVM get_vm;
        public GetInstrumentsComamand(MainVM vm)
        {
            get_vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            get_vm.Display_Instruments();
        }
    }
}
