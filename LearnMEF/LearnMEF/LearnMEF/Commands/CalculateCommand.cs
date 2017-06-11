using System;
using System.Windows.Input;


namespace LearnMEF.Commands
{
    public class CalculateCommand:ICommand
    {
        private Action<object> myExecute;
        Func<bool> myCanExecute;

        public CalculateCommand(Action<object> execute, Func<bool> canExecute)
        {
            myExecute = execute;
            myCanExecute = canExecute;
        }

        public delegate bool canExecuteHandler();

        bool ICommand.CanExecute(object parameter)
        {
            if(myCanExecute != null)
            {
                return myCanExecute();
            }
            if(myExecute != null)
            {
                return true;
            }
            return false;
        }

        // Do not know when this can be needed
        public event EventHandler CanExecuteChanged;

        void ICommand.Execute(object parameter)
        {
            myExecute?.Invoke(parameter);
        }         
    }
}
