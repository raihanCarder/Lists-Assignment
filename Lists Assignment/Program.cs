using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {   // Raihan Carder
            Console.Title = "Lists";

            //ListOfIntegers();
            Vegetables();
            Console.ReadLine();
        }

        public static void ListOfIntegers()
        {
            Random generator = new Random();
            List<int> numbers = new List<int>();
            int randomValue, selection, newValue = 0, amountNumbers = 25, removeValue, amountRemoved = 0, fifteenOccurrences = 0, numberOccurences, selectedOccurence;
            string punctuation, changeDescription = "Here are your list of integers";
            bool quit = false;

            for (int i = 0; i < 25; i++)
            {
                randomValue = generator.Next(10, 21);
                numbers.Add(randomValue);
            }

            while (!quit)
            {
                amountRemoved = 0;
                fifteenOccurrences = 0;
                numberOccurences = 0;

                if (!numbers.Any())
                {
                    changeDescription = "Please press 2 to create a new list or Add some New Values";
                }


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

                if (int.TryParse(Console.ReadLine().Trim(), out selection))
                {
                    if (selection == 1)
                    {
                        numbers.Sort();
                        changeDescription = "Here's your Sorted list: ";
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
                        Console.WriteLine();
                        Console.Write("Enter a value you want removed: ");

                        if (int.TryParse(Console.ReadLine().Trim(), out removeValue) && removeValue >= 10 && removeValue < 21)
                        {
                            for (int i = 0; i < amountNumbers; i++)
                            {
                                if (numbers.Contains(removeValue))
                                {
                                    numbers.Remove(removeValue);
                                    amountRemoved += 1;
                                }
                            }
                            amountNumbers -= amountRemoved;
                            changeDescription = "Here's your new list: ";

                        }
                        else
                        {
                            changeDescription = "your value could not be removed, here's your list: ";
                        }


                    }
                    else if (selection == 4)
                    {
                        Console.WriteLine();
                        Console.Write("Add an integer Value to the list within the range 1-20: ");
                        if (int.TryParse(Console.ReadLine(), out newValue) && newValue >= 10 && newValue < 21)
                        {
                            numbers.Add(newValue);
                            amountNumbers += 1;
                            changeDescription = "Here's your new list: ";
                        }
                        else
                        {
                            changeDescription = "Value could not be added, here's your list: ";
                        }

                    }
                    else if (selection == 5)
                    {
                        for (int i = 0; i < amountNumbers; i++)
                        {
                            if (numbers[i] == 15)
                            {
                                fifteenOccurrences += 1;
                            }
                        }
                        changeDescription = $"The list contains fifteen; {fifteenOccurrences} times.";

                    }
                    else if (selection == 6)
                    {
                        changeDescription = $"The list's highest value is {numbers.Max()}";
                    }
                    else if (selection == 7)
                    {
                        changeDescription = $"The list's smallest value is {numbers.Min()}";
                    }
                    else if (selection == 8)
                    {
                        quit = true;
                    }
                    else if (selection == 9)
                    {
                        changeDescription = $"The list's sum value is {numbers.Sum()}, the lists average is {Math.Round(numbers.Average(), 2)}.";
                    }
                    else if (selection == 10)
                    {
                        Console.WriteLine();

                        var groupedNumbers = numbers.GroupBy(n => n);
                        var maxFrequency = groupedNumbers.Max(g => g.Count());
                        var modes = groupedNumbers.Where(g => g.Count() == maxFrequency).Select(g => g.Key);
                        Console.Write("The mode(s) are: ");
                        foreach (var mode in modes)
                        {
                            Console.Write(mode + " ");
                        }

                        Console.WriteLine();
                        Console.Write("Click Enter to Continue; ");
                        Console.ReadLine();
                    }
                    else if (selection == 11)
                    {
                        Console.WriteLine();
                        Console.Write("Enter a value that you'd like to know how many times its in the loop: ");
                        if (int.TryParse(Console.ReadLine().Trim(), out selectedOccurence))
                        {
                            for (int i = 0; i < amountNumbers; i++)
                            {
                                if (numbers[i] == selectedOccurence)
                                {
                                    numberOccurences += 1;
                                }
                            }
                        }
                        else
                        {

                        }
                        changeDescription = $"The value: {selectedOccurence} is in the list {numberOccurences} times.";


                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else
                {
                    // make a changedescription tellng them to enter valids election
                }
                Console.Clear();
            }
            Console.Write("Click enter to return to menu:");
            Console.ReadLine();




        }


        public static void Vegetables()
        {
            List<string> vegetables = new List<string>() { "CARROT", "BEET", "CELERY", "RADISH", "CABBAGE" };
            string error = "", addedVegetable;
            int numberVegetables = 5, selection = 0, removeByIndex;
            bool quit = false, cleared = false;

            while (!quit)
            {
                Console.WriteLine("Vegetables");
                Console.WriteLine(error);
                Console.WriteLine();
                error = "";

                if (!cleared)
                {
                    for (int i = 1; i < numberVegetables + 1; i++)
                    {
                      
                        Console.WriteLine($"{i} - {vegetables[i - 1]}");
                    }
                }
                else
                {
                    Console.WriteLine("Your list is empty. ");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Here's what you can do with this list:");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Remove a vegetable by Index");
                Console.WriteLine("2. Remove a vegetable by Value");
                Console.WriteLine("3. Search for a vegetable");
                Console.WriteLine("4. Add a vegetable");
                Console.WriteLine("5. Sort list");
                Console.WriteLine("6. Clear list");
                Console.WriteLine("-------------------------------");
                Console.Write("Type the number corresponding with your decision: ");

                if (int.TryParse(Console.ReadLine(), out selection) && selection > 0 && selection < 7)
                {
                    if (selection == 1)
                    {
                        if (!cleared)
                        {
                            Console.Write("By the index displayed on the screen, What vegetable would you like to remove: ");
                            if (int.TryParse(Console.ReadLine(), out removeByIndex) && removeByIndex > 0 && removeByIndex <= numberVegetables)
                            {
                                vegetables.Remove(vegetables[removeByIndex - 1]);
                                numberVegetables -= 1;
                            }
                        }
                        else
                        {
                            error = "Cannot remove values as list empty. Add new Item";
                        }
                    }
                    else if (selection == 2)
                    {

                    }
                    else if (selection == 3)
                    {

                    }
                    else if (selection == 4)
                    {
                        Console.Write("Type what vegetable you'd like to add:  ");
                        addedVegetable = Console.ReadLine().ToUpper().Trim();
                        numberVegetables += 1;
                        vegetables.Add(addedVegetable);
                        cleared = false;

                    }
                    else if (selection == 5)
                    {
                        vegetables.Sort();
                    }
                    else if (selection == 6)
                    {
                        vegetables.Clear();
                        numberVegetables = 0;
                        cleared = true;
                    }
                    else
                    {
                        error = "No valid Selection entered, reselect your option.";
                    }
                }
                else
                {
                    error = "No valid Selection entered, reselect your option.";
                }

                Console.Clear();
            }



        }



    }
}
