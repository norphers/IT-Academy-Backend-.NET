using System;

namespace ConsoleApp3
{
    class Program
    {
        static string city1;
        static string city2;
        static string city3;
        static string city4;
        static string city5;
        static string city6;
        static readonly string city7 = "test"; //for testing try/catch error
        static readonly string[] cities = new string[6];
        static readonly string[] citiesModified = new string[6];

        static void Main(string[] args)
        {
            Console.WriteLine("Stage1");
            Stage1();

            Console.WriteLine("\nStage2");
            Stage2();

            Console.WriteLine("\nStage3");
            Stage3();

            Console.WriteLine("\nStage4");
            Stage4();
        }

        static void Stage1()
        {
            city1 = SetCity(); //Barcelona
            city2 = SetCity(); //Madrid
            city3 = SetCity(); //Valencia
            city4 = SetCity(); //Málaga
            city5 = SetCity(); //Cádiz
            city6 = SetCity(); //Santander
            Console.WriteLine("\nCities: " + city1 + ", " + city2 + ", " + city3 + ", " + city4 + ", " + city5 + ", and " + city6 + ".");
        }

        static void Stage2()
        {
            try
            {
                CitiesArrayGen(city1);
                CitiesArrayGen(city2);
                CitiesArrayGen(city3);
                CitiesArrayGen(city4);
                CitiesArrayGen(city5);
                CitiesArrayGen(city6);
                CitiesArrayGen(city7);
            }
            catch (Exception e)
            {
                Console.WriteLine("Array is full. \nError: " + e + "\n");
            }
            PrintArray(cities);
        }

        static void Stage3()
        {
            CitiesCharModifier(cities);
            PrintArray(citiesModified);
        }

        static void Stage4()
        {
            char[] cityArray1 = new char[city1.Length];
            char[] cityArray2 = new char[city2.Length];
            char[] cityArray3 = new char[city3.Length];
            char[] cityArray4 = new char[city4.Length];
            char[] cityArray5 = new char[city5.Length];
            char[] cityArray6 = new char[city6.Length];

            PrintSortReverseArray(CityArrayGen(cityArray1, city1));
            PrintSortReverseArray(CityArrayGen(cityArray2, city2));
            PrintSortReverseArray(CityArrayGen(cityArray3, city3));
            PrintSortReverseArray(CityArrayGen(cityArray4, city4));
            PrintSortReverseArray(CityArrayGen(cityArray5, city5));
            PrintSortReverseArray(CityArrayGen(cityArray6, city6));
        }

        static string SetCity()
        {
            Console.Write("Enter a city name: ");
            string city = Console.ReadLine();
            return city;
        }

        static string[] CitiesArrayGen(string city)
        {
            if (cities != null)
            {
                for (int i = 0; i <= cities.Length;)
                {
                    if (cities[i] == null || cities[i] == "")
                    {
                        cities[i] = city;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
                return cities;
            }
            else
            {
                throw new Exception();
            }
	    }

        static string[] CitiesCharModifier(string[] cities)
        {
            for (int i = 0; i < citiesModified.Length;)
            {
                for (int j = 0; j < cities.Length; j++)
                {
                    citiesModified[i] = cities[j].Replace('a', '4');
                    i++;
                }
            }
            return citiesModified;
        }

        static void PrintArray(string[] stringArray)
        {
            Array.Sort(stringArray);
            Console.Write("Cities: ");
            for (int i=0; i<stringArray.Length; i++)
            {
                if(i< stringArray.Length-1)
                {
                    Console.Write(stringArray[i] + ", ");
                } 
                else
                {
                    Console.WriteLine("and " + stringArray[i] + ".");
                }
                
            }
        }

        static char[] CityArrayGen(char[] cityArray, String city)
        {
            for (int i = 0; i < city.Length; i++)
            {
                cityArray[i] = city[i];
            }
            return cityArray;
        }

        static void PrintSortReverseArray(char[] cityArray)
        {
            for (int i = cityArray.Length - 1; i < cityArray.Length && i > -1; i--)
            {
                Console.Write(cityArray[i]);
            }
            Console.WriteLine();
        }

    }
}
