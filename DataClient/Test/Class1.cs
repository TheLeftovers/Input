using NUnit.Framework;
using ServiceLibrary;
using System;

namespace Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
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

                CollectionAssert.AreEqual(o, unitTestClient.GetTestList());
                Assert.Pass();


                Console.WriteLine("");
                Console.WriteLine("Unit Test has passed!!");
            }
            catch (NUnit.Framework.AssertionException af)
            {
                Console.WriteLine("Unit Test has failed!!");
                Assert.Fail();
                Console.WriteLine(af.StackTrace);
                throw;
            }

            Console.ReadLine();

        }
    }
}
