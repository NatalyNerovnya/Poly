using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial
    {
        private double[] coeff;
        private int dim;
        readonly char variable;

        public Polynomial()
        {
            dim = 1;
            coeff = new double[dim - 1];
            variable = 'x';
            coeff[0] = default(double);
        }

        public Polynomial(params double[] arr) : this()
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

        public Polynomial(char symbol, params double[] arr) : this(arr)
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
            Polynomial pol = (Polynomial)obj;
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

        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            return pol1.Equals(pol2);
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return pol1.Equals(pol2);
        }

        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null & pol2 == null)
                return null;
            if (pol1 == null)
                return pol2;
            if (pol2 == null)
                return pol1;
            if (pol1.variable != pol2.variable)//what exeption should I throw here?
                throw new NotImplementedException();

            int d = Math.Max(pol1.dim, pol2.dim);
            Polynomial result = new Polynomial(d, pol1.variable);
            for (int i = 0; i < d; i++)
            {
                result.coeff[i] = pol1.coeff[i] + pol2.coeff[i];
            }
            return result;
        }

    }
}
