using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using LearnMEF.Annotations;
using LearnMEF.Commands;
using LearnMEF.Models;


namespace LearnMEF.ViewModel
{
    public class CalculateViewModel:INotifyPropertyChanged
    {
        
        private CalculateModel mod = CalculateModel.Instance;
        private int mynum1;

        public int FirstNumber
        {
            get { return mynum1; }
            set
            {
                mynum1 = value;
                mod.FirstNumber = mynum1;
            }
        }

        private int mynum2;

        public int Secondnumber
        {
            get { return mynum2; }
            set
            {
                mynum2 = value;
                mod.Secondnumber = mynum2;
            }
        }

        private int myresult;

        public int Result
        {
            get { return myresult; }
            set
            {
                myresult = value;
                mod.Result = myresult;
                OnPropertyChanged("Result");
            }
        }

        private ObservableCollection<string> myOperators;

        public ObservableCollection<string> Operators
        {
            get { return myOperators; }
            set
            {
                myOperators = value;
            }
        }

        public CalculateCommand mycommand;

        public ICommand Command
        {
            get { return mycommand; }
            
        }

        public CalculateViewModel()
        {
            mycommand = new CalculateCommand();
            CalculateModel.Instance.ModelUpdated += OnModelUpdated;
            Operators = new ObservableCollection<string>() { "Add", "Sub" };
        }

        private void OnModelUpdated(object sender, EventArgs e)
        {
            Result = CalculateModel.Instance.Result;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
