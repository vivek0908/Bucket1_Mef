using LearnMEF.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace LearnMEF.ViewModel
{
    public class CalculateViewModel : IPartImportsSatisfiedNotification, INotifyPropertyChanged
    {
        private CompositionContainer mefContainer;
        private int result;

        [ImportMany]
        private List<IOperation<int>> Operations { get; set; }

        public CalculateViewModel()
        {
            myOperators = new ObservableCollection<string>();

            //MEF Composition
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            mefContainer = new CompositionContainer(catalog);
            mefContainer.ComposeParts(this);

            CalculateCommand = new CalculateCommand(Calculte, CanCalculate);
        }

        private bool CanCalculate()
        {
            return true;
        }

        private void Calculte(object parameter)
        {
            string requestedOperation = (string)parameter;
            foreach (var operation in mefContainer.GetExports<IOperation<int>>())
            {
                if(operation.Value.Name == requestedOperation)
                {
                     Result = operation.Value.Calculate(FirstNumber, Secondnumber);
                }
            }
        }

        private ObservableCollection<string> myOperators;

        public event PropertyChangedEventHandler PropertyChanged;

        public CalculateCommand CalculateCommand { get; private set; }

        public int FirstNumber
        {
            get;
            set;
        }

        public int Secondnumber
        {
            get;
            set;
        }

        public int Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                RaisePropertyChanged("Result");
            }

        }

        public ObservableCollection<string> Operators
        {
            get { return myOperators; }
            set { myOperators = value; }
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            foreach (var operation in mefContainer.GetExports<IOperation<int>>())
            {
                Operators.Add(operation.Value.Name);
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
