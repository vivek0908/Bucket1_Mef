using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using LearnMEF.Annotations;
using LearnMEF.Commands;
using LearnMEF.Models;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace LearnMEF.ViewModel
{
    //public class CalculateViewModel:INotifyPropertyChanged
    //{
        
    //    private CalculateModel mod = CalculateModel.Instance;
    //    private int mynum1;

    //    public int FirstNumber
    //    {
    //        get { return mynum1; }
    //        set
    //        {
    //            mynum1 = value;
    //            mod.FirstNumber = mynum1;
    //        }
    //    }

    //    private int mynum2;

    //    public int Secondnumber
    //    {
    //        get { return mynum2; }
    //        set
    //        {
    //            mynum2 = value;
    //            mod.Secondnumber = mynum2;
    //        }
    //    }

    //    private int myresult;

    //    public int Result
    //    {
    //        get { return myresult; }
    //        set
    //        {
    //            myresult = value;
    //            OnPropertyChanged("Result");
    //        }
    //    }

    //    private ObservableCollection<string> myOperators;

    //    public ObservableCollection<string> Operators
    //    {
    //        get { return myOperators; }
    //        private set
    //        {
    //            myOperators = value;
    //        }
    //    }

    //    public CalculateCommand mycommand;

    //    public ICommand CalculateCommand
    //    {
    //        get { return mycommand; }
            
    //    }

    //    public CalculateViewModel()
    //    {
    //        Operators = new ObservableCollection<string>() { "Add", "Sub" };
    //        mycommand = new CalculateCommand();
    //        CalculateModel.Instance.ModelUpdated += OnModelUpdated;
    //    }

    //    private void OnModelUpdated(object sender, EventArgs e)
    //    {
    //        Result = CalculateModel.Instance.Result;
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;


    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChangedEventHandler handler = PropertyChanged;
    //        if (handler != null)
    //        {
    //            handler(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}

    public class CalculateViewModel : IPartImportsSatisfiedNotification
    {
        private CompositionContainer mefContainer;

        [ImportMany]
        private List<IOperation<int>> Operations { get; set; }

        public CalculateViewModel()
        {
            myOperators = new ObservableCollection<string>();

            //MEF Composition
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            mefContainer = new CompositionContainer(catalog);
            mefContainer.ComposeParts(this);
        }

        private ObservableCollection<string> myOperators;

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
    }
}
