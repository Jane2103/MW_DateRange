using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateRange.UnitTests
{
    [TestClass]
    public class ProgramTests
    {              
        [DataRow("01.01.2017", "05.01.2017", "01-05.01.2017")]
        [DataRow("01.01.2017", "05.02.2017", "01.01-05.02.2017")]
        [DataRow("01.01.2016", "05.01.2017", "01.01.2016-05.01.2017")]
        [DataRow("21.01.2016", "31.01.2016", "21-31.01.2016")]
        [DataRow("21.01.2016", "22.02.2016", "21.01-22.02.2016")]
        [DataRow("24.07.2018", "24.03.2019", "24.07.2018-24.03.2019")]
        [DataTestMethod]
        public void PrintRange_WithCorrectInput_ShouldReturnDateRange(string input1, string input2, string expected)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);                

                DateRange.Program.PrintRange(input1, input2);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }            
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PrintRange_WithIncorrectDateType_ShouldThrowException()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "29.02.2019";
                var input2 = "05.04.2019";

                DateRange.Program.PrintRange(input1, input2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PrintRange_WithEqualDateValues_ShouldThrowException()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "21.03.2019";
                var input2 = "21.03.2019";

                DateRange.Program.PrintRange(input1, input2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PrintRange_WithStartDateLaterThanEndDate_ShouldThrowException()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "21.03.2019";
                var input2 = "21.02.2019";          

                DateRange.Program.PrintRange(input1, input2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PrintRange_WithInvalidInput_ShouldThrowException()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "32.03.12-3";
                var input2 = "21.02";

                DateRange.Program.PrintRange(input1, input2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PrintRange_WithTextInput_ShouldThrowException()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "making";
                var input2 = "waves";

                DateRange.Program.PrintRange(input1, input2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PrintRange_WithEmptyInput_ShouldThrowException()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var input1 = "";
                var input2 = "";

                DateRange.Program.PrintRange(input1, input2);
            }
        }

        [DataRow(2, "02")]
        [DataRow(5, "05")]
        [DataRow(9, "09")]        
        [DataTestMethod]
        public void AddZeroIfNeeded_WithNumberLessThanTen_ShouldAddZeroPrefix(int input, string expected)
        {
            var result = DateRange.Program.AddZeroIfNeeded(input);

            Assert.AreEqual(expected, result);
        }

        [DataRow(20, "20")]
        [DataRow(15, "15")]
        [DataRow(10, "10")]
        [DataTestMethod]
        public void AddZeroIfNeeded_WithNumberGreaterOrEqualToTen_ShouldParseIntToString(int input, string expected)
        {
            var result = DateRange.Program.AddZeroIfNeeded(input);

            Assert.AreEqual(expected, result);
        }


    }
}
