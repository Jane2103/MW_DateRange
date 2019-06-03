using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace programTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string ExceptionMessage = "Invalid input format. Input shall be provided: dd.mm.yyyy dd.mm.yyyy. " +
                    "First input shall indicate earlier date than the second one. Example: 21.03.2019 31.05.2019";
    
        //[TestMethod]
        //public void convertStringToValidForm_Test()
        //{
        //    var input = "02.03.2017";
        //    var expected = "03/02/2017";
        //    var result = program.Program.convertStringToValidForm(input);
        //    Assert.AreEqual(expected, result);
        //}

        [TestMethod]
        public void printRange_Test1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "01.01.2017";
                var input2 = "05.01.2017";
                var expected = "01-05.01.2017";

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }            
        }

        [TestMethod]
        public void printRange_Test2()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "01.01.2017";
                var input2 = "05.02.2017";
                var expected = "01.01-05.02.2017";

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test3()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "01.01.2016";
                var input2 = "05.01.2017";
                var expected = "01.01.2016-05.01.2017";

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test4()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "29.02.2019";
                var input2 = "21.03.2019";
                var expected = ExceptionMessage;

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test5()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "21.03.2019";
                var input2 = "28.02.2019";
                var expected = ExceptionMessage;

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test6()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "21.03.2019";
                var input2 = "21.03.2019";
                var expected = ExceptionMessage;

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test7()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "32.03.12-3";
                var input2 = "05.01.2017";
                var expected = ExceptionMessage;

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test8()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "--.03.1999";
                var input2 = "01.01.01";
                var expected = ExceptionMessage;

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void printRange_Test9()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "abcabcabca";
                var input2 = "abcabcabcb";
                var expected = ExceptionMessage;

                program.Program.printRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }
    }
}
