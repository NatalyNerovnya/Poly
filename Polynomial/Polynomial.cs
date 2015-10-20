using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial <T> where T : IComparable<T>
    {
        private T[] coeff;
        private int dim;
        readonly char variable;

        public Polynomial()
        {
            dim = 1;
            coeff = new T [dim - 1];
            variable = 'x';
            coeff[0] = default(T);
        }

        public Polynomial(params T[] arr) : this()
        {
            dim = arr.Length;
            coeff = arr;
        }

        public Polynomial(int d) : this()
        {
            if (d > 0)
                dim = d;
            else
                throw new ArgumentOutOfRangeException("The dimension must be greater than 0.");
        }

        public Polynomial(char symbol, params T[] arr) : this(arr)
        {
            variable = symbol;
        }

        public Polynomial(int d, char symbol) : this(d)
        {
            variable = symbol;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Polynomial<T> pol = (Polynomial<T>)obj;
            if (pol.dim != this.dim)
                return false;

            for (int i = 0; i < dim; i++)
                if (coeff[i].CompareTo(pol.coeff[i]) == 0)
                    continue;
                else
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
