using System;
using System.Collections;
using System.Security.Cryptography;
using NUnit.Framework;
using Polynomial;
using System.Collections.Generic;

namespace Polynomial.NUnitTests
{
    [TestFixture]
    public class PolynomialTests
    {

        #region Plus
        public IEnumerable<TestCaseData> TestPlusData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(0, 1), null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Polynomial(1, 2, 3), new Polynomial(2, 3, 4)).Returns(new Polynomial(3, 5, 7));
                yield return new TestCaseData(new Polynomial(-4, -2, 0), new Polynomial(2, 3, 4, 5)).Returns(new Polynomial(-2, 1, 4, 5));
                //yield return new TestCaseData(new Polynomial(Double.MaxValue), new Polynomial(1)).Throws(typeof(OverflowException));
            }
        }

        [Test, TestCaseSource(nameof(TestPlusData))]
        public Polynomial PlusOperator_AddTwoPolynomialsWithYield(Polynomial pol1, Polynomial pol2)
        {
            return pol1 + pol2;
        }

        #endregion

        #region Multiplication

        public IEnumerable<TestCaseData> TestMultiplyData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(0, 1), null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Polynomial(1, 2), new Polynomial(1)).Returns(new Polynomial(1, 2));
                yield return new TestCaseData(new Polynomial(-4, -2, 0), new Polynomial(2, 3, 4, 5)).Returns(new Polynomial(-8, -16, -22, -28, -10));
                //yield return new TestCaseData(new Polynomial(Double.MaxValue), new Polynomial(2)).Throws(typeof(OverflowException));
            }
        }

        [Test, TestCaseSource(nameof(TestMultiplyData))]
        public Polynomial MultiplyOperator_MultiplyPolynomailsWithYield(Polynomial pol1, Polynomial pol2)
        {
            return pol1 * pol2;
        }

        public IEnumerable<TestCaseData> TestMultiplyOnDoubleData
        {
            get
            {
                yield return new TestCaseData(null, 2).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Polynomial(1, 2), 2).Returns(new Polynomial(2, 4));
                yield return new TestCaseData(new Polynomial(-4, -2, 3, 0), -2).Returns(new Polynomial(8, 4, -6));
                //yield return new TestCaseData(new Polynomial(Double.MaxValue), 2).Throws(typeof(OverflowException));
            }
        }

        [Test, TestCaseSource(nameof(TestMultiplyOnDoubleData))]
        public Polynomial MultiplyOperator_MultiplyPolynomailOnDoubleWithYield(Polynomial pol, double x)
        {
            return pol*x;
        }
        #endregion

        #region Equals
        public IEnumerable<TestCaseData> TestEqualsData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 2, 3)).Returns(true);
                yield return new TestCaseData(new Polynomial(1, 2, 3, 0, 0, 0)).Returns(true);
                yield return new TestCaseData(new Polynomial(1, 2)).Returns(false);
                yield return new TestCaseData(null).Returns(false);
                // yield return new TestCaseData(new object()).Returns(false);
            }
        }

        [Test, TestCaseSource(nameof(TestEqualsData))]
        public bool Equals_CompareTwoPolynomialsWithYield(Polynomial pol)
        {
            Polynomial pol1 = new Polynomial(1, 2, 3);
            return pol1.Equals(pol);
        }
        #endregion



    }
}
