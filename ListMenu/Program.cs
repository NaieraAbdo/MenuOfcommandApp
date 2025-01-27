using System.Collections.Specialized;
using System.Collections.Generic;
using System.Xml.Linq;


namespace ListMenu
{
    internal class Program
    {
        static void DisplayMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    ------------");
            Console.WriteLine("    | Main Menu |");
            Console.WriteLine("    ------------");
            Console.WriteLine("P - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display Mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("C - Clear the whole list");
            Console.WriteLine("W - Swap two numbers");
            Console.WriteLine("Q - Quit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your choice: ");
        }
        static char EnterChoice()
        {
            DisplayMainMenu();
            int trial = 1;
            bool flag = false;
            char choice;
            do
            {
                if (trial > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unknown Selection , Please try again.");
                    DisplayMainMenu();
                }
                else if (trial == 1)
                {
                    trial++;
                }
                flag = char.TryParse(Console.ReadLine(), out choice);

            } while (!flag || !(choice == 'P' || choice == 'p' || choice == 'A' || choice == 'A' || choice == 'a' 
               || choice == 'M' || choice == 'm'|| choice == 'S'|| choice == 's'|| choice == 'L'|| choice == 'l' ||choice == 'F' 
               || choice == 'f' ||choice == 'C' || choice == 'c' || choice == 'W' || choice == 'w' || choice == 'Q'|| choice == 'q'));
            char loweredChar = char.ToLower(choice);

            return loweredChar;
        }

        static void PrintElements(List<int> list)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (list.Count == 0)
            Console.WriteLine("[] -the list is empty");
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int i = 0;
                while ( i < list.Count)
                {
                    if(i ==0 )
                        Console.Write("[ ");
                    Console.Write($"{list[i]} ");
                    if(i == list.Count- 1)
                        Console.WriteLine("]");
                    
                    i++;

                }
            }
        }

        static void AddElement(List<int> list )
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the number to add: ");
            int number = Convert.ToInt32(Console.ReadLine());
            //No Duplication
            bool isexist = false;
            for(int i=0;i<list.Count; i++)
            {
                if(number == list[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This element already exist , please enter another one.");
                    isexist = true;
                    //Add another one
                    AddElement(list);
                    break;
                }
            }
            if (!isexist)
            {
                list.Add(number);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{number} added");
                Console.WriteLine("----------------------------");
            }
        }


        static void FindSmallest(List<int> list)
        {   int smallest = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            if (list.Count == 0)
                Console.WriteLine("Unable to determine the smallest number - the list is empty");
            else
            {
                smallest = list[0];
                for (int i = 0; i < list.Count; i++)
                {
                    int I = list[i];
                    if (I < smallest)
                        smallest = I;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"The smallest numer is {smallest}");

            }
            
        }

        static int FindLargest(List<int> list)
        {
            int largest = 0;
            if (list.Count == 0)
                largest = 0;
            else
            {
                largest = list[0];
                for (int i = 0; i < list.Count; i++)
                {
                    int I = list[i];
                    if (I > largest)
                        largest = I;
                }
            }
            return largest;

        }

        static void FindMean(List<int> list)
        {
            double mean = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            if (list.Count == 0)
                Console.WriteLine("Unable to calculate the mean - no data ");
            else
            {
                int sum = 0;
                for ( int i =0; i < list.Count; i++)
                {
                    sum += list[i];
                }
                mean = (double)sum / list.Count;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"The Mean of the list is {mean}");

            }
        }

        static void FindAnElement(List<int> list) 
        {
            if (list.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't Find elements - the list is empty");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the element you need to find: ");
                int element = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == element)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"The index of the element is {i + 1}");
                        break;
                    }
                }
            }
        }

        static void Swap(List<int> list)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (list.Count == 0)
                Console.WriteLine("No elements to swap.");
            else if (list.Count == 1)
                Console.WriteLine("Can't Swap with one element , Please add another one.");
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Current List : ");
                PrintElements(list);
                int firstNumber = list[1];
                int secondNumber = list[0];
                int firstIndex =0;
                int secondIndex =0;
                if (list.Count > 2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Choose the first number you want to swap : ");
                    firstNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Choose the second number you want to swap: ");
                    secondNumber = Convert.ToInt32(Console.ReadLine());
                }


                for(int i = 0;i<list.Count; i++)
                {
                    if (list[i] == firstNumber)
                        firstIndex = i;
                    
                    if (list[i] == secondNumber)
                        secondIndex = i;
                }

                int temp = list[firstIndex];
                list[firstIndex] = list[secondIndex];
                list[secondIndex] = temp;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ---------    ");
                Console.WriteLine("The list after swapping: ");
                PrintElements(list);


            }
        }

        static void ClearList(List<int> list)
        {
            list.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The list is cleared.");
        }


        static void Main(string[] args)
        {

            List<int> list = new List<int>();
        
            int istrue = 1;
            while (istrue == 1 )
            {
                char loweredChar =  EnterChoice();
                switch (loweredChar)
                {
                    case 'p':
                        PrintElements(list);
                        break;
                    case 'a':
                       
                        AddElement(list);
                        break;
                    case 'm':
                        FindMean(list);
                        break;
                    case 's':
                        FindSmallest(list);
                        break;
                    case 'l':
                        int largest = FindLargest(list);
                        if (largest == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unable to determine the largest number - the list is empty");
                        }
                        else{
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"The largest numer is {largest}");
                        }
                        break;
                    case 'q':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Goodbye.");
                        istrue = 0;
                        break;
                    case 'f':
                        FindAnElement(list);
                        break;
                    case 'c':
                        ClearList(list); 
                        break;
                    case 'w':
                        Swap(list);
                        break;
                }

            }



        }

    }
}