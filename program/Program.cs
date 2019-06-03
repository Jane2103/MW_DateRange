using System;

namespace program
{
    public class Program
    {
        const int FirstDayIndex = 0;
        const int FirstMonthIndex = 3;
        const int InsertSubstringDayIndex = 5;
        const int FirstRemoveIndex = 2;
        const int SecondRemoveIndex = 5;
        const string FormatString = "d";
        const string ExceptionMessage = "Invalid input format.Input shall be provided: dd.mm.yyyy dd.mm.yyyy. " +
                    "First input shall indicate earlier date than the second one. Example: 21.03.2019 31.05.2019";

        public static void Main(string[] args)
        {
            //var startDateAsString = args[0];
            //var endDateAsString = args[1];
            var startDateAsString = "29.02.2019";
            var endDateAsString = "21.03.2019";

            try
            {
                printRange(startDateAsString, endDateAsString);         
            }
            catch (FormatException)
            {
                Console.WriteLine(ExceptionMessage);
            }
        }

        public static void printRange(string startDateAsString, string endDateAsString)
        {
            if (!isNotText(startDateAsString) || !isNotText(endDateAsString)) throw new FormatException();

            startDateAsString = convertStringToValidForm(startDateAsString);            
            endDateAsString = convertStringToValidForm(endDateAsString);            

            var startDate = DateTime.ParseExact(startDateAsString, FormatString, System.Globalization.CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(endDateAsString, FormatString, System.Globalization.CultureInfo.InvariantCulture);
                        
            var datesComparisonResult = DateTime.Compare(endDate, startDate);            
            if (datesComparisonResult != 1) throw new FormatException();

            if ((startDate.Year == endDate.Year) && (startDate.Month == endDate.Month))
            {
                var firstDayAsString = AddZeroIfNeeded(startDate.Day);
                var secondDayAsString = AddZeroIfNeeded(endDate.Day);
                var monthAsString = AddZeroIfNeeded(startDate.Month);

                Console.WriteLine($"{firstDayAsString}-{secondDayAsString}.{monthAsString}.{startDate.Year}");
            }

            if ((startDate.Year == endDate.Year) && (startDate.Month != endDate.Month))
            {
                var firstDayAsString = AddZeroIfNeeded(startDate.Day);
                var secondDayAsString = AddZeroIfNeeded(endDate.Day);
                var firstMonthAsString = AddZeroIfNeeded(startDate.Month);
                var secondMonthAsString = AddZeroIfNeeded(endDate.Month);

                Console.WriteLine($"{firstDayAsString}.{firstMonthAsString}-{secondDayAsString}.{secondMonthAsString}.{startDate.Year}");
            }

            if (startDate.Year != endDate.Year)
            {
                var firstDayAsString = AddZeroIfNeeded(startDate.Day);
                var secondDayAsString = AddZeroIfNeeded(endDate.Day);
                var firstMonthAsString = AddZeroIfNeeded(startDate.Month);
                var secondMonthAsString = AddZeroIfNeeded(endDate.Month);
                
                Console.WriteLine($"{firstDayAsString}.{firstMonthAsString}.{startDate.Year}" +
                    $"-{secondDayAsString}.{secondMonthAsString}.{endDate.Year}");
            }
        }

        private static bool isNotText(string stringAsDate)
        {
            var resolution = true;
            if (stringAsDate.Length != 10) return false;
            for (int i = 0; i < stringAsDate.Length; i++)
            {
                if ((stringAsDate[i] >= '0' && stringAsDate[i] <= '9') || stringAsDate[i] == '.') resolution &= true;
                else resolution = false;
            }
            return resolution;
        }

        public static string convertStringToValidForm(string dateAsString)
        {
            var substringDay = dateAsString.Substring(FirstDayIndex, 2);
            var substringMonth = dateAsString.Substring(FirstMonthIndex, 2);
            var convertedDate = dateAsString.Insert(FirstDayIndex, substringMonth);

            convertedDate = convertedDate.Insert(InsertSubstringDayIndex, substringDay);
            convertedDate = convertedDate.Remove(FirstRemoveIndex, 2);
            convertedDate = convertedDate.Remove(SecondRemoveIndex, 2);

            convertedDate = convertedDate.Replace('.', '/');

            return convertedDate;
        }

        private static string AddZeroIfNeeded(int date)
        {
            string numberAsString;

            return date < 10 ? numberAsString = "0" + date : numberAsString = date.ToString();
        }
    }
}
