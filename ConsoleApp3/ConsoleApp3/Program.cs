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
            citiesCharModifier(cities);
            PrintArray(citiesModified);
        }

        static void Stage4()
        {

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

        static string[] citiesCharModifier(string[] cities)
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

    }
}
