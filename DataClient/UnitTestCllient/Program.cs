using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ServiceLibrary;
using System;

namespace UnitTestCllient
{
    [TestFixture]
    public class Program
    {
        [Test]
        public static void Main(string[] args)
        {
            Getter unitTestClient = new Getter();            
            Object[] o = new Object[10];
            o[0] = "1";
            o[1] = "2";
            o[2] = "3";
            o[3] = "4";
            o[4] = "5";
            o[5] = "6";
            o[6] = "7";
            o[7] = "8";
            o[8] = "9";
            o[9] = "10";

            try
            {
                Console.WriteLine("Output Array: \n");
                Console.WriteLine("Actual : Expected");
                Console.WriteLine("");

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(unitTestClient.GetTestList()[i] + " : " + o[i]);
                }

                NUnit.Framework.CollectionAssert.AreEqual(o, unitTestClient.GetTestList());


                Console.WriteLine("");
                Console.WriteLine("Unit Test has passed!!");
            }
            catch (AssertFailedException af)
            {
                Console.WriteLine("Unit Test has failed!!");
                Console.WriteLine(af.StackTrace);
            }

            Console.ReadLine();

        }
    }
}
