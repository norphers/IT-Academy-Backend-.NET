using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp5
{
    class Program
    {
        static int[] serie1 = { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };
        static void Main(string[] args)
        {
            Stage1();
            Stage2();
            Stage3();
        }

        static void Stage1()
        {
            Console.WriteLine("Stage 1.");
            PrintArray(PairArrayConstructor(GetPairs(serie1)));
        }

        static void Stage2()
        {
            Console.WriteLine("Stage 2.");
            Console.WriteLine(CalculateAverage(serie1));
            Console.WriteLine(CalculateMaxScore(serie1));
            Console.WriteLine(CalculateMinScore(serie1));
        }

        static void Stage3()
        {
            Console.WriteLine("Stage 3.");
            Console.Write("Numbers bigger than 5: ");
            PrintArray(NumbersBiggerThan5(serie1));
            Console.Write("Numbers lower than 5: ");
            PrintArray(NumbersLowerThan5(serie1));
        }

        static IEnumerable<int> GetPairs(int[] array)
        {
            IEnumerable<int> pairNumberSerie = (from number in array where number % 2 == 0 orderby number select number);
            return pairNumberSerie;
        }

        static int[] PairArrayConstructor(IEnumerable<int> numberSerie)
        {
            int[] pairArray = new int[numberSerie.Count()];

            for (var i = 0; i < numberSerie.Count(); i++)
            {
                pairArray[i] = numberSerie.ElementAt(i);
            }
            return pairArray;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int i in array) Console.Write(i + " ");
            Console.WriteLine("");
        }

        static double CalculateAverage(int[] array)
        {
            double average = (from number in array select number).Average();
            return average;
        }

        static int CalculateMaxScore(int[] array)
        {
            int maxScore = (from number in array select number).Max();
            return maxScore;
        }

        static int CalculateMinScore(int[] array)
        {
            int minScore = (from number in array select number).Min();
            return minScore;
        }

        static int[] NumbersBiggerThan5(int[] array)
        {
            IEnumerable<int> biggerThan5Serie = (from number in array where number>5 select number);
            int[] biggerThan5Array = new int[biggerThan5Serie.Count()];

            for (var i = 0; i < biggerThan5Serie.Count(); i++)
            {
                biggerThan5Array[i] = biggerThan5Serie.ElementAt(i);
            }
            return biggerThan5Array;
        }

        static int[] NumbersLowerThan5(int[] array)
        {
            IEnumerable<int> lowerThan5Serie = (from number in array where number <= 5 select number);
            int[] lowerThan5Array = new int[lowerThan5Serie.Count()];

            for (var i = 0; i < lowerThan5Serie.Count(); i++)
            {
                lowerThan5Array[i] = lowerThan5Serie.ElementAt(i);
            }
            return lowerThan5Array;
        }


        /*
         * En aquesta fase farem servir un array amb noms: (David, Sergio, Maria, Laura, Oscar, Julia, Oriol)
            Creeu un array amb els noms de l’enunciat. (0,5 punts)
            Fent servir consultes linq mostreu per consola els noms que comencin amb la lletra “O”. (1 punt)
            Fent servir consultes linq mostreu per consola quins noms tenen més de 6 lletres. (1 punt)
            Fent servir consultes linq mostreu per consola els noms de l’array ordenats de manera descendent. 
        */
    }
}
