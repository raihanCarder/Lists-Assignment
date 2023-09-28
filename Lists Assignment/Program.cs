using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {   // Raihan Carder

            Random generator = new Random();
            List<int> numbers = new List<int>();
            int randomValue, selection, newValue = 0, amountNumbers = 25;
            string punctuation, changeDescription = "Here are your list of integers";
            bool quit = false;

            Console.Title = "Lists";

            // create static method for this code

            for (int i = 0; i < 25; i++)
            {
                randomValue = generator.Next(10, 21);
                numbers.Add(randomValue);
            }

            while (!quit)
            {
                Console.WriteLine(changeDescription);
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                for (int i = 0; i < amountNumbers; i++)
                {
                    if (i < amountNumbers - 1)
                    {
                        punctuation = ", ";
                    }
                    else
                    {
                        punctuation = ".";
                    }

                    Console.Write(numbers[i] + punctuation);
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Enter what you'd like to do:");
                Console.WriteLine("1.  Sort the List");
                Console.WriteLine("2.  Make a New List ");
                Console.WriteLine("3.  Remove a Value");
                Console.WriteLine("4.  Add a Value to the List");
                Console.WriteLine("5.  The number of times a numbers in the list");
                Console.WriteLine("6.  The Largest Value");
                Console.WriteLine("7.  The Smallest Value");
                Console.WriteLine("8.  Quit");
                Console.WriteLine("9.  The Sum and Average of this List");
                Console.WriteLine("10. Most Frequent Value");
                Console.WriteLine("11. How many times is ___ in this list?");
                Console.Write("Enter the integer corresponding with your decision: ");

                if (int.TryParse(Console.ReadLine(), out selection))
                {
                    if (selection == 1)
                    {
                        numbers.Sort();
                        changeDescription = "Here's your new Sorted list: ";
                    }
                    else if (selection == 2)
                    {
                        numbers.Clear();
                        amountNumbers = 25;

                        for (int i = 0; i < amountNumbers; i++)
                        {
                            randomValue = generator.Next(10, 21);
                            numbers.Add(randomValue);
                        }
                        changeDescription = "Here's your new List: ";
                    }
                    else if (selection == 3)
                    {

                    }
                    else if (selection == 4)
                    {
                        Console.WriteLine();
                        Console.Write("Add an integer Value to the list: ");
                        if (int.TryParse(Console.ReadLine(), out newValue))
                        {
                            numbers.Add(newValue);
                        }
                        amountNumbers += 1;
                    }
                    else if (selection == 5)
                    {

                    }
                    else if (selection == 6)
                    {

                    }
                    else if (selection == 7)
                    {

                    }
                    else if (selection == 8)
                    {
                        quit = true;
                    }
                    else if (selection == 9)
                    {

                    }
                    else if (selection == 10)
                    {

                    }
                    else if (selection == 11)
                    {

                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else
                {

                }            
                Console.Clear();

            }
            Console.ReadLine();
        }


    }
}
