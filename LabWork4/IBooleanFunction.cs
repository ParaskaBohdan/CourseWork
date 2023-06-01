using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork4
{
    public interface IBooleanFunction
    {
        bool Evaluate(bool input1, bool input2);
        bool IsLinear { get; }
        string GetName();
        bool IsSymmetric();
        bool IsMonotonic();
    }
}
