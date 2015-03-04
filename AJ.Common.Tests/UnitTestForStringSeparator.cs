using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace AJ.Common.Tests
{
    /// <summary>
    /// Summary description for UnitTestForStringSeparator
    /// </summary>
    [TestClass]
    public class UnitTestForStringSeparator
    {
        public TestContext TestContext{get;set;}

        const string Filename = @"testinput.txt";

        static string GetTestString()
        {
            string fileContent = File.ReadAllText(Filename);
            return fileContent;
        }

        static void AssertEqual(string[] test1, string[] test2)
        {
            Assert.AreEqual(test1.Length, test2.Length, "count differs");
            for (int i = 0; i < test1.Length; ++i)
                Assert.AreEqual(test1[i], test2[i], "content differs");
        }

        static void DoTest(string[] sep, int count, StringSplitOptions options)
        {
            string text = GetTestString();

            var test1a = text.Split(sep, count, options);
            var test1b = text.SplitString(sep, count, options).ToArray();
            AssertEqual(test1a, test1b);
            Assert.IsTrue(test1b.Length <= count, "count to big");

            text = "";
            var test2a = text.Split(sep, count, options);
            var test2b = text.SplitString(sep, count, options).ToArray();
            AssertEqual(test2a, test2b);
            Assert.IsTrue(test2b.Length <= count, "count to big");
        }

        readonly string[] SEP_SINGLE_LAST = new string[] { "a" };       // last char in testinput.txt
        readonly string[] SEP_SINGLE_FIRST = new string[] { "==" };     // first chars in testinput.txt
        readonly string[] SEP_SINGLE_ANY = new string[] { "Test" };
        readonly string[] SEP_MULTI_LAST = new string[] { "a", "Test", "window" };
        readonly string[] SEP_MULTI_FIRST = new string[] { "==", "Test", "window" };
        readonly string[] SEP_MULTI_ANY = new string[] { "you", "Test", "window" };
        readonly string[] SEP_MULTI_COLLISION_A = new string[] { "Test", "Tester" };
        readonly string[] SEP_MULTI_COLLISION_B = new string[] { "Tester", "Test" };
        readonly string[] SEP_MULTI_COLLISION_C = new string[] { "Tester", "est" };
        readonly string[] SEP_MULTI_COLLISION_D = new string[] { "est", "Tester" };

        // SIMPLE

        [TestMethod]
        public void TestWithString_Simple_NoSep()
        {
            DoTest(null, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Simple_SingleLast()
        {
            DoTest(SEP_SINGLE_LAST, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Simple_SingleFIRST()
        {
            DoTest(SEP_SINGLE_FIRST, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Simple_SingleANY()
        {
            DoTest(SEP_SINGLE_ANY, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Simple_MultiLast()
        {
            DoTest(SEP_MULTI_LAST, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Simple_SEP_MULTI_FIRST()
        {
            DoTest(SEP_MULTI_FIRST, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Simple_MulitANY()
        {
            DoTest(SEP_MULTI_ANY, int.MaxValue, StringSplitOptions.None);
        }

        // COUNT

        [TestMethod]
        public void TestWithString_Count_NoSep()
        {
            DoTest(null, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SingleLast()
        {
            DoTest(SEP_SINGLE_LAST, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SEP_SINGLE_FIRST()
        {
            DoTest(SEP_SINGLE_FIRST, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SingleANY()
        {
            DoTest(SEP_SINGLE_ANY, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_MultiLast()
        {
            DoTest(SEP_MULTI_LAST, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SEP_MULTI_FIRST()
        {
            DoTest(SEP_MULTI_FIRST, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_MulitANY()
        {
            DoTest(SEP_MULTI_ANY, 100, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SEP_SINGLE_ANY_0()
        {
            DoTest(SEP_SINGLE_ANY, 0, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SEP_SINGLE_ANY_1()
        {
            DoTest(SEP_SINGLE_ANY, 1, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SEP_SINGLE_FIRST_0()
        {
            DoTest(SEP_SINGLE_FIRST, 0, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_Count_SEP_SINGLE_FIRST_1()
        {
            DoTest(SEP_SINGLE_FIRST, 1, StringSplitOptions.None);
        }

        // NoEmpty

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_NoSep()
        {
            DoTest(null, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_SingleLast()
        {
            DoTest(SEP_SINGLE_LAST, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_SingleFIRST()
        {
            DoTest(SEP_SINGLE_FIRST, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_SingleANY()
        {
            DoTest(SEP_SINGLE_ANY, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_MultiLast()
        {
            DoTest(SEP_MULTI_LAST, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_SEP_MULTI_FIRST()
        {
            DoTest(SEP_MULTI_FIRST, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Simple_MulitANY()
        {
            DoTest(SEP_MULTI_ANY, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
        }

        // COUNT + NoEmpty

        [TestMethod]
        public void TestWithString_NoEmpty_Count_NoSep()
        {
            DoTest(null, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SingleLast()
        {
            DoTest(SEP_SINGLE_LAST, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SEP_SINGLE_FIRST()
        {
            DoTest(SEP_SINGLE_FIRST, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SingleANY()
        {
            DoTest(SEP_SINGLE_ANY, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_MultiLast()
        {
            DoTest(SEP_MULTI_LAST, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SEP_MULTI_FIRST()
        {
            DoTest(SEP_MULTI_FIRST, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_MulitANY()
        {
            DoTest(SEP_MULTI_ANY, 100, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SEP_SINGLE_ANY_0()
        {
            DoTest(SEP_SINGLE_ANY, 0, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SEP_SINGLE_ANY_1()
        {
            DoTest(SEP_SINGLE_ANY, 1, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SEP_SINGLE_FIRST_0()
        {
            DoTest(SEP_SINGLE_FIRST, 0, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void TestWithString_NoEmpty_Count_SEP_SINGLE_FIRST_1()
        {
            DoTest(SEP_SINGLE_FIRST, 1, StringSplitOptions.RemoveEmptyEntries);
        }

        // collisions

        [TestMethod]
        public void TestWithString_SEP_MULTI_COLLISION_A()
        {
            DoTest(SEP_MULTI_COLLISION_A, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_SEP_MULTI_COLLISION_B()
        {
            DoTest(SEP_MULTI_COLLISION_B, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_SEP_MULTI_COLLISION_C()
        {
            DoTest(SEP_MULTI_COLLISION_C, int.MaxValue, StringSplitOptions.None);
        }

        [TestMethod]
        public void TestWithString_SEP_MULTI_COLLISION_D()
        {
            DoTest(SEP_MULTI_COLLISION_D, int.MaxValue, StringSplitOptions.None);
        }


    }
}
