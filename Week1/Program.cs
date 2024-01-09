namespace Week1
{
    internal class Program
    {
        static void GetNextDate(int day, int month, int year, bool isLeapYear)
        {
            Console.Write($"The next date of {day}/{month}/{year} ");
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    day = (day==31) ? 1 : day + 1;
                    month = (day == 1) ? month + 1 : month;
                    break;
                case 2:
                    day = (day == (isLeapYear ? 29 : 28)) ? 1 : day + 1;
                    month = (day==1) ? month + 1 : month;
                    break;
                default:
                    day = (day == 30) ? 1 : day + 1;
                    month = (day == 1) ? month + 1 : month;
                    break;
            }
            if (month == 13)
            {
                month = 1;
                year++;
            }
            else
                year = year;
            Console.WriteLine($"is: {day}/{month}/{year}");
        }
        static void GetPreviousDate(int day, int month, int year, bool isLeapYear)
        {
            Console.Write($"The previous date of {day}/{month}/{year} ");
            switch (month)
            {
                case 1:
                case 2:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    day = (day == 1) ? 31 : day - 1;
                    month = (day == 31) ? month - 1 : month;
                    break;
                case 3:
                    day = (day == 1) ? (isLeapYear ? 29 : 28) : day - 1;
                    month = (day == (isLeapYear ? 29 : 28)) ? month - 1 : month;
                    break;
                default:
                    day = (day == 1) ? 30 : day - 1;
                    month = (day == 30) ? month - 1 : month;
                    break;
            }
            if (month == 0)
            {
                month = 12;
                year--;
            }
            else
                year = year;
            Console.WriteLine($"is: {day}/{month}/{year}");
        }
        static int GetDaysFromMonth(int day, int month, bool isLeapYear)
        {
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return 31;
                case 2:
                    return isLeapYear ? 29 : 28;
                default:
                    return 30;
            }
        }
        static bool IsLeapYear(int year)
        {
            if (year % 4 == 0 || (year % 4 != 0 && year % 400 == 0))
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            int year, month, day;
            int maxdayofmonth;
            bool isLeapYear = false;
            //Check input:
            do
            {
                Console.Write("Input year:");
                year = Convert.ToInt32(Console.ReadLine());
            } while (year < 1900);
            do
            {
                Console.Write("Input month:");
                month = Convert.ToInt32(Console.ReadLine());
            } while (month < 1 || month > 12);
            isLeapYear = IsLeapYear(year);
            maxdayofmonth = GetDaysFromMonth(year, month, isLeapYear);
            do
            {
                Console.Write($"Input day(1 - {maxdayofmonth}):");
                day = Convert.ToInt32(Console.ReadLine());
            } while (day < 1 || day > maxdayofmonth);
            GetNextDate(day, month, year, isLeapYear);
            GetPreviousDate(day, month, year, isLeapYear);
        }
    }
}