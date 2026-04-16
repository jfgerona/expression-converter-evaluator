using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class CompareExpressions : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            double a = Convert.ToDouble(x);
            double b = Convert.ToDouble(y);
            if(a>b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }
    }
}
