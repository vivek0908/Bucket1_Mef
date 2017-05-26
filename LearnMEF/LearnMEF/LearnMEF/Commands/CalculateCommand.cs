using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

using LearnMEF.Models;


namespace LearnMEF.Commands
{
    public class CalculateCommand:ICommand
    {
        public CalculateCommand(Func<> )
        {
              
        }
        public delegate bool canExecuteHandler();

        public bool CanExecute(object parameter)
        {
            canExecuteHandler objdel=new canExecuteHandler();
            objdel.Invoke();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var op=parameter.ToString();
            if (op.Equals("Add"))
            {
               CalculateModel.Instance.Result= CalculateModel.Instance.FirstNumber + CalculateModel.Instance.Secondnumber;
            }
            else if (op.Equals("Sub"))
            {
                CalculateModel.Instance.Result = CalculateModel.Instance.FirstNumber - CalculateModel.Instance.Secondnumber;
            }
        }

         
    }
}
