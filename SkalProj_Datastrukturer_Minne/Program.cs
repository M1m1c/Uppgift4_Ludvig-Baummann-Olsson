using System;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis" 
                    + "\n5. Recursive even"
                    + "\n6. Recursive Fibonacci" 
                    +"\n7. Iterative even"
                    +"\n8. Iterative Fibonacci"
                    + "\n0. Exit the application");

                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ParanthesisChecker.CheckParanthesis();
                        break;
                    case '5':
                        RecursionAndIteration.CheckFunction("Enter a number to get the Nth even number",
                        RecursionAndIteration.RecursiveEven);
                        break;
                    case '6':
                        RecursionAndIteration.CheckFunction("Enter a number to get the Nth number of the fibonacci sequence",
                        RecursionAndIteration.RecursiveFibonacci);
                        break;
                    case '7':
                        RecursionAndIteration.CheckFunction("Enter a number to get the Nth even number",
                        RecursionAndIteration.IterativeEven);
                        break;
                    case '8':
                        RecursionAndIteration.CheckFunction("Enter a number to get the Nth fibonacci number",
                        RecursionAndIteration.IterativeFibonacci);
                            break;

                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
          
            Console.Clear();
            List<string> theList = new List<string>();
            
            while (true)
            {
                
                Console.WriteLine("Enter '+Name' to add a name to the list.\n" +
                    "Enter '-Name' to remove name from list.\n" +
                    "Enter 0 to return to main menu.");

                WriteEachItemInCollection(theList);

                Console.WriteLine($"List count: {theList.Count}\n" +
                    $"List capacity {theList.Capacity}");

                string input = Console.ReadLine();
                char nav = input.Length > 0 ? input[0] : 'n';
                string value = input.Length > 1 ? input.Substring(1) : "fail";
                nav = value == "fail" && nav != '0' ? 'n' : nav;

                switch (nav)
                {
                    case '+':
                        Console.Clear();
                        theList.Add(value);
                        break;
                    case '-':
                        Console.Clear();
                        theList.Remove(value);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Use only + or - to add names.");
                        break;
                }

            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            
            Queue<string> theQueue = new Queue<string>();        
            List<String> names = new List<string> {"Kalle","Greta","Stina","Olle","Erik","Johan","Lena","Jenny" };
            Random rand = new Random();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Enter '+' to add a name to the queue.\n" +
                   "Enter '-' to dequeue the first nam in the queue.\n" +
                   "Enter 0 to return to main menu.");

                WriteEachItemInCollection(theQueue);

                string input = Console.ReadLine();
                char nav = input.Length > 0 ? input[0] : 'n';

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(names[rand.Next(0, names.Count)]);
                        break;
                    case '-':
                        if (theQueue.Count > 0) theQueue.Dequeue();
                        break;
                    case '0':
                        return;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            
            Stack<char> theStack = new Stack<char>();
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Enter a string to reverse it\n" +
                   "Enter 0 to return to main menu.");           

                string input = Console.ReadLine();
                char nav = input.Length > 0 ? input[0] : 'n';

                foreach (var item in input)
                {
                    theStack.Push(item);
                }

                switch (nav)
                {
                    default:
                        do
                        {
                            Console.Write(theStack.Pop());
                        } while (theStack.Count>0);
                        Console.Write("\n");
                        break;
                    case '0':
                        return;
                }
            }
        }
  
        private static void WriteEachItemInCollection<T>(IEnumerable<T> theCollection)
        {
            foreach (var item in theCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}

