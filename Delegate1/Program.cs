using System;
using System.Collections.Generic;

namespace Delegate1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Starting point
            Console.WriteLine("Starting point");
            int[] numbers = new int[20];
            string[] cities = new string[20];

            //Random Initialization
            var rnd = new Random();
            var names = "Stockholm, Copenhagen, Oslo, Helsinki, Berlin, Madrid, Lissabon".Split(',');
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(100, 1000 + 1);
                cities[i] = names[rnd.Next(0, names.Length)].Trim();
            }

            //WriteLists(numbers, cities);
            #endregion

            #region Exercises 1-4
            Console.WriteLine("Delegates I Exercises");
            Array.ForEach<int>(numbers, Write<int>);
            Array.ForEach<string>(cities, Write<string>);


            #endregion
            
            #region Exercises 5-6
            Console.WriteLine("\nDelegates II Exercises\n");

            var evenNumbers = Array.FindAll(numbers, FindEven);
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine($"{evenNumber, -15}");
            }

            //Array.FindAll(cities, FindCityLength);
            string[] longCities = Array.FindAll(cities, FindCityLength);
            Console.WriteLine("Cities with more than 6 letters:  \n");
            foreach (string sixLetters in cities) 
            {
                Console.WriteLine(sixLetters);
            }
            //Array.ForEach<string>(longCities, Write<string>);
            


            #endregion

            #region Exercises 7-8
            Console.WriteLine("\nDelegates III Exercises\n");

            Array.FindAll(numbers, FindNumberOver500);
            Console.WriteLine("Numbers over 500: ");
            int[] overFiveHundred = Array.FindAll(numbers, FindNumberOver500);
            foreach (var largeNumbers in overFiveHundred) 
            {
                Console.WriteLine($"{largeNumbers, -20}");
            }

            Console.WriteLine("The last city with eight letters:\n ");
            string lastCity = Array.FindLast(cities, FindLastCity);
            Console.WriteLine(lastCity);
           
            #endregion
        }

        #region Starting point
        static void WriteLists(int[] _numbers, string[] _cities)
        {

            Console.WriteLine($"{nameof(_numbers)}:");
            foreach (var item in _numbers)
                Console.WriteLine(item);

            Console.WriteLine($"\n{nameof(_cities)}:");
            foreach (var item in _cities)
                Console.WriteLine(item);

        }
        #endregion

        #region Exercises 1-4
        //static void WriteInt(int i)
        //{
        //    Console.Write($"{i,-8}");
        //}
        //static void WriteString(string s) 
        //{
        //    Console.Write($"{s, -20}");
        //}

        static void Write<T>(T i)
        {
            Console.Write($"{i, -20}");
        }
        #endregion

        #region Exercises 5-6

        static bool FindEven(int i) 
        {
            if (i % 2 == 0) 
            {
                return true;
            }
            return false;
        }
        static bool FindCityLength(string city) => city.Length > 6;


        #endregion

        #region Exercises 7-8
        static bool FindNumberOver500(int number) => number > 500;

        static bool FindLastCity(string city) => city.Length > 8;
        #endregion

    }
}
//Exercises

//Delegates I
//1.  Explore Array.ForEach and write a delegate that prints numbers to the console using Array.ForEach()
//2.  Explore Array.ForEach and write a delegate that prints cities to the console using Array.ForEach()
//3.  Use Generics <T> to write one delegate that prints T[] to the console using Array.ForEach()
//4.  Print out both lists using the Method from 6.

//Delegates II
//5.  Explore Array.FindAll() and write a delegate returns an int[] of all even numbers.
//    Print out the new array using the pattern from 4 - 6
//6.  Explore Array.FindAll() and write a delegate returns an string[] of all cities with a name with more than 6 letters.
//    Print out the new array using the pattern from 4 - 6

//Delegates III
//7. Explore Array.Find() and write a delegate that finds the first number in numbers > 500. Print out the number
//8. Explore Array.FindLast() and write a delegate that finds the last city in the cities with a name longer than 8 letters


