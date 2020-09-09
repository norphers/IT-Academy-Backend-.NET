using System;
using System.Net.NetworkInformation;

namespace ConsoleApp1
{
    class Program
    {
        static string name = "John";
        static string surname = "Doe";
        static int day = 25;
        static int month = 10;
        static int year = 1954;
        static int leapYear = 1948;
        static bool isLeapYear;

        static void Main(string[] args)
        {
            Console.WriteLine("Stage 1:");
            printSolutionStage1();
            Console.WriteLine("\nStage 2:");
            printSolutionStage2();
            Console.WriteLine("\nStage 3:");
            printSolutionStage3();
            Console.WriteLine();
        }

        public static void printSolutionStage1()
        {
            Console.WriteLine(name + ", " + surname);
            Console.WriteLine(year + "/" + month + "/" + day);
        }
        public static void printSolutionStage2()
        {
            calculLeapYearsBetweenTwoYears(year,leapYear);
        }
        public static void printSolutionStage3()
        {
            Console.WriteLine(name + ", " + surname);
            Console.WriteLine(year + "/" + month + "/" + day);
            Console.WriteLine(checkLeapYear(year));
            printLeapYears(year, leapYear);
        }
        public static void printLeapYears(int year, int leapYear)
        {
            Console.Write("List of leap years between " + leapYear + " and " + year + ": ");
            for (int i=leapYear; i<=year; i+=4)
            {
                if (i <= year - 4)
                {
                    Console.Write(leapYear + ", ");
                    leapYear += 4;
                }
                else
                {
                    Console.Write(leapYear + ".");
                    leapYear += 4;
                }
            }
        }

        public static void calculLeapYearsBetweenTwoYears(int newestYear, int oldestYear)
        {
            int result = (newestYear - oldestYear) / 4;
            Console.WriteLine("Leap years between " + oldestYear + " and " + newestYear + ": " +result);
        }

        public static string checkLeapYear(int year)
        {
            if(year % 4 == 0 || year % 100 == 0 || year % 400 == 0)
            {
                isLeapYear = true;
            } 
            else
            {
                isLeapYear = false;
            }

            if (isLeapYear)
            {
                string messageLeapYear = year + " is a leap year";
                return messageLeapYear;
            }
            else
            {
                string messageNoLeapYear = year + " is not a leap year";
                return messageNoLeapYear;
            }
        }
    }
}
