using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial : ICloneable, IEquatable<Polynomial>// изменить опертаоры -,+
    {//Провеерять элементы  на нулевые
        private readonly double[] coeff;
        private int dim;

        public Polynomial() { }

        public Polynomial(params double[] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            dim = arr.Length;
            coeff = new double[dim];
            Array.Copy(arr, coeff, dim);
        }

        public double this[int i]
        {
            get
            {
                if(i < dim)
                    return coeff[i];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if(i < dim)
                    coeff[i] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }



        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            DeleteZerosInTheEnd();
            other.DeleteZerosInTheEnd();
            if (other.dim != this.dim) return false;

            for (int i = 0; i < dim; i++)
                if (this[i].CompareTo(other[i]) != 0)
                    return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Polynomial) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((coeff != null ? coeff.GetHashCode() : 0)*397) ^ dim;
            }
        }

#region operators
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals(pol1, pol2)) return true;
            if (ReferenceEquals(pol1, null)) return false;
            return pol1.Equals(pol2);
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals(pol1, pol2)) return true;
            if (ReferenceEquals(pol1, null)) return false;
            return !pol1.Equals(pol2);
        }

        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null || pol2 == null)
                throw new ArgumentNullException();

            pol1.DeleteZerosInTheEnd();
            pol2.DeleteZerosInTheEnd();
            int d = Math.Min(pol1.dim, pol2.dim);
            var result = pol1.dim >= pol2.dim ? pol1 : pol2;
            for (int i = 0; i < d; i++)
            {
                checked
                {
                    result[i] = pol1[i] + pol2[i];
                }
            }
            return result;
        }

        public static Polynomial operator -(Polynomial pol)
        {
            if (pol == null )
                throw new ArgumentNullException();
            return pol * (-1);
        }

        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null|| pol2 == null)
                throw new ArgumentNullException();
            return pol1 + (-pol2);
        }

        public static Polynomial operator *(Polynomial pol, double x)
        {
            if (pol == null)
                throw new ArgumentNullException();
            Polynomial result = new Polynomial(pol.dim);
            for (int i = 0; i < result.dim; i++)
            {
                result[i] = pol[i] * x;
            }
            return result;

        }

        public static Polynomial operator *(double x, Polynomial pol)
        {
            return pol * x;
        }

        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null || pol2 == null)
                throw new ArgumentNullException();


            int n = pol1.dim + pol2.dim - 1;
            double[] prod = new double[n];
            for (int i = 0; i < pol1.dim; i++)
            {
                for (int j = 0; j < pol2.dim; j++)
                {
                    prod[i + j] += pol1[i] * pol2[j];
                }
            }
            return new Polynomial(prod);
        }

        public static Polynomial Add (Polynomial pol1, Polynomial pol2)
        {
            return pol1 + pol2;
        }

        public static Polynomial Subtract (Polynomial pol1, Polynomial pol2)
        {
            return pol1 - pol2;
        }

        public static Polynomial Multiply(Polynomial pol1, Polynomial pol2)
        {
            return pol1 * pol2;
        }

        public static Polynomial Multiply(Polynomial pol, double x)
        {
            return pol * x;
        }

        public static Polynomial Multiply(double x, Polynomial pol)
        {
            return pol * x;
        }

        #endregion

        public Polynomial Clone()
        {
            return new Polynomial(this.coeff);
        }

        object ICloneable.Clone()
        {
            return Clone();
         }

        private void DeleteZerosInTheEnd()
        {
            for (int i = dim - 1; i >= 0; i--)
            {
                if (this[i] == 0)
                {
                    dim--;
                }
            }
        }
    }
}
