using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMEF
{
    public interface IOperation<T>
    {
        string Name { get;}

        T Calculate(T obj1, T obj2);
    }

    public abstract class AbstractOperation<DT> : IOperation<DT> where DT : struct
    {
        private string myName;

        protected AbstractOperation(string name)
        {
            myName = name;            
        }

        protected abstract DT Evaluate(DT lOperand, DT rOperand);

        private bool IsDataTypeAllowed(DT data)
        {
            if(data.GetType() != typeof(int) || data.GetType() != typeof(float) || data.GetType() != typeof(long) || data.GetType() != typeof(double))
            {
                return false;
            }
            return true;
        }

        public string Name
        {
            get { return myName; }
        }

        public DT Calculate(DT lOperand, DT rOperand)
        {
            if (!IsDataTypeAllowed(lOperand) || !IsDataTypeAllowed(rOperand))
            {
                throw new ArgumentException(String.Format("Data type {0} is not allowed", typeof(DT)));
            }
            return Evaluate(lOperand, rOperand);
        }
    }
}
