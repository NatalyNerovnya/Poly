using System;
using System.Security.Cryptography;
using NUnit.Framework;
using Polynomial;
using System.Collections.Generic;

namespace Polynomial.NUnitTests
{
    [TestFixture]
    public class PolynomialTests
    {

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

        //public IEnumerable<TestCaseData> TestData
        //{
        //    get
        //    {
        //        yield return new TestCaseData(new Polynomial(1,2,3), new Polynomial(2,3,4)).Returns(new Polynomial(3,5,7));
        //    }
        //}

        //[Test, TestCaseSource(nameof(TestData))]
        //public Polynomial PlusOperator_AddTwoPolynomialsWithYield(Polynomial pol1, Polynomial pol2)
        //{
        //    return pol1 + pol2;
        //}




    }
}
