using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1 : IUnitTest1
    {
        [TestMethod]
        public ArrayList TestMethod1()
        {
            ArrayList test = new ArrayList();
            test.Add("1");
            test.Add("2");
            test.Add("3");
            test.Add("4");
            test.Add("5");
            test.Add("6");
            test.Add("7");
            test.Add("8");
            test.Add("9");
            test.Add("10");

            return test;
        }
    }
}
