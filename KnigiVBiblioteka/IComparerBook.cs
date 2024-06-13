using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnigiVBiblioteka
{
    public class IComparerBook:IComparer<BeleziNaKniga>
    {
        public int Compare(BeleziNaKniga x, BeleziNaKniga y)
        {
            int result;
            result = x.Avtor.CompareTo(y.Avtor);
            if (result == 0)
            {
                result = x.Nomer.CompareTo(y.Nomer);
            }
            return result;
        }
    }
}
