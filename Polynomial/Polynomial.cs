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

        public override string ToString()
        {
            string result = "" + coeff[0];
            for (int i = 1; i < dim; i++)
            {
                if (coeff[i] > 0)
                    result += " + " + coeff[i] + variable + "^" + i;
                else if (coeff[i] < 0)
                    result += " " + coeff[i] + variable + "^" + i;
                else
                    continue;
            }
            result += " = 0";
            return result;
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

        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
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
                result.coeff[i] = pol1.coeff[i] - pol2.coeff[i];
            }
            return result;
        }

        public static Polynomial operator *(Polynomial pol, double x)
        {
            if (pol == null)
                return null;
            if (x == 0)
                return null;
            Polynomial result = new Polynomial(pol.variable, pol.dim);
            for (int i = 0; i < result.dim; i++)
            {
                result.coeff[i] = pol.coeff[i] * x;
            }
            return result;

        }

        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null || pol2 == null)
                throw new ArgumentNullException();

            if (pol1.variable != pol2.variable)//what exeption should I throw here?
                throw new NotImplementedException();

            int n = pol1.dim + pol2.dim - 1;
            double[] prod = new double[n];
            for (int i = 0; i < pol1.dim; i++)
            {
                for (int j = 0; j < pol2.dim; j++)
                {
                    prod[i + j] += pol1.coeff[i] * pol2.coeff[j];
                }
            }
            return new Polynomial(pol1.variable, prod);
        }



        private Polynomial Clone(Polynomial pol)
        {
            if (pol == null)
                return null;

            return new Polynomial(pol.variable, pol.coeff);
        }

    }
}
