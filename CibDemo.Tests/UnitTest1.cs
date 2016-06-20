using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CibDemo.Models;

namespace CibDemo.Tests
{
    [TestClass]
    public class BigNumberTest
    {
        [TestMethod]
        public void TestIsZero()
        {
            var x = new BigNumber(10);
            Assert.AreEqual("0,0000000000", x.AsPrintableString());
        }
    }
}
