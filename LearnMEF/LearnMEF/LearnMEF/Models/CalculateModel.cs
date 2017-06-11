using System;

namespace LearnMEF.Models
{
    // Animesh: Cann't say if this class is required
    public class CalculateModel
    {
        private static CalculateModel myInstance;
        public static readonly Object obj = new Object();

        public event EventHandler ModelUpdated;
        private CalculateModel()
        {
                
        }
        private int mynum1;

        public int FirstNumber
        {
            get { return mynum1; }
            set { mynum1 = value; }
        }

        private int mynum2;

        public int Secondnumber
        {
            get { return mynum2; }
            set { mynum2 = value; }
        }

        private int myresult;

        public int Result
        {
            get { return myresult; }
            set
            {
                myresult = value;
                if (ModelUpdated != null)
                {
                    ModelUpdated(this, EventArgs.Empty);
                }
            }
        }

        public static CalculateModel Instance
        {
            get
            {
                lock(obj)
                {
                    if(myInstance==null)
                    {
                        myInstance = new CalculateModel();
                    }
                    return myInstance;
                }
            }
        }
    }
}
