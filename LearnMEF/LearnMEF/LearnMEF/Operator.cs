using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LearnMEF;

namespace LearnMEF
{
    [Export(typeof(IOperation<int>))]
    class AddOperator: AbstractOperation<int>
    {
        [ImportingConstructor]
        public AddOperator() : base("ADD")
        {
        }

        protected override int Evaluate(int lOperand, int rOperand)
        {
            return lOperand + rOperand;
        }
    }

    [Export(typeof(IOperation<int>))]
    class SubOperator : AbstractOperation<int>
    {
        [ImportingConstructor]
        public SubOperator() : base("SUB")
        {
        }

        protected override int Evaluate(int lOperand, int rOperand)
        {
            return lOperand - rOperand;
        }
    }
}
