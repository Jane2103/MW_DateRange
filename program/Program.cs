using System;

namespace DateRange
{
    public class Program
    {
        const string FormatString = "dd.MM.yyyy";
        const string ExceptionMessage = "Invalid input format.Input shall be provided: dd.mm.yyyy dd.mm.yyyy. " +
                    "First input shall indicate earlier date than the second one. Example: 21.03.2019 31.05.2019";

        public static void Main(string[] args)
        {
            var startDateAsString = args[0];
            var endDateAsString = args[1];            

            try
            {
                PrintRange(startDateAsString, endDateAsString);         
            }
            catch (FormatException)
            {
                Console.WriteLine(ExceptionMessage);
            }
        }

        public static void PrintRange(string startDateAsString, string endDateAsString)
        {
            var startDate = DateTime.ParseExact(startDateAsString, FormatString, System.Globalization.CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(endDateAsString, FormatString, System.Globalization.CultureInfo.InvariantCulture);
                        
            var datesComparisonResult = DateTime.Compare(endDate, startDate);            
            if (datesComparisonResult != 1) throw new FormatException();

            var firstDayAsString = AddZeroIfNeeded(startDate.Day);
            var secondDayAsString = AddZeroIfNeeded(endDate.Day);
            var firstMonthAsString = AddZeroIfNeeded(startDate.Month);
            var secondMonthAsString = AddZeroIfNeeded(endDate.Month);

            if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
                Console.WriteLine($"{firstDayAsString}-{secondDayAsString}.{firstMonthAsString}.{startDate.Year}");                       

            if (startDate.Year == endDate.Year && startDate.Month != endDate.Month)
                Console.WriteLine($"{firstDayAsString}.{firstMonthAsString}-{secondDayAsString}.{secondMonthAsString}.{startDate.Year}");            

            if (startDate.Year != endDate.Year)                         
                Console.WriteLine($"{firstDayAsString}.{firstMonthAsString}.{startDate.Year}" +
                    $"-{secondDayAsString}.{secondMonthAsString}.{endDate.Year}");            
        }

        public static string AddZeroIfNeeded(int date) => date < 10 ? "0" + date : date.ToString();
    }
}
