using System;
using System.Windows.Input;
using WPF_IMS.ViewModel;

namespace WPF_IMS.Command
{
    public class AddCommand : ICommand
    {
        public AddVM _add_vm { get; set; }

        public AddCommand(AddVM vm)
        {
            _add_vm = vm;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _add_vm.Add_Instrument(parameter);
        }
    }
}
