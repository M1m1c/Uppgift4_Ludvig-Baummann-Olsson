using System;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// Teori och fakta.
        /// -------------------------
        /// 1: Stacken kan ses som systemet som hanterar metoder och dess lokala variablar.
        ///    När ett program körs så kan det bara utföra en sak åt gången,
        ///    och stacken ser till att hålla koll på vilka metoder och variablar som kommer behöva minne och hur länge.
        ///    Stacken körs via en LIFO ordning därför om vi har ett exempel som "DoManyThings(DoOneThing())".
        ///    Så kommer DoOneThing() köras först för att den var sist in och när den körts klart,
        ///    så kommer allt minne allokerat till den och dess variablar frigöras.
        ///  
        ///    Om man kollar på klass exemplet nedan. Så kommer alla variablar deklarerade bara inom klassen
        ///    hamna i heapen. Programet kan inte veta när heap värden ska sluta ha allokerat minne,
        ///    då deras värden kan komma att användas närsomhelst av vilken metod som helst inom klassen.
        ///    Vilket gör att man själv måste hålla koll på när man ska sluta allokera minne till heap variablar,
        ///    och skicka dem för garabage collection.
        ///  
        ///    Om man använder exemplet nedan igen, Så kan man se att variablen "z" finns bara inom metoden. 
        ///    Tack vare stacken så kommer "z" bara ha allokerat minne så länge som metoden "d" körs,
        ///    när den är klar kommer stacken att frigöra dess minne och allokera det igen om metoden körs senare.
        ///  
        /// class Rand
        /// {
        ///     int g;
        ///     
        ///     void d()
        ///     {
        ///         int z;
        ///     }
        /// }
        /// 
        /// 2: Value Types inehåller bara värden och ingen referens till minnet.
        ///    Om man tar exemplet nedan så kommer "z" bli värt 3 när det blir tilldelat "g" värde.
        ///    "z" värde kommer inte förändras när vi förändrar "g" värde igen,
        ///    då värdes typen "int" bara håller i en siffra och inte någon referens till någon plats i minnet.
        ///     
        ///     int g=3;
        ///     int z=g;
        ///         g=4;
        /// 
        ///     Reference types håller däremot referenser till platser i minnet.
        ///     Vilket gör att om vi skulle ta samma exempel som ovan fast med "string",
        ///     så skulle "z" värde förändras när "g" förändras.
        ///     Då man inte tilldelar värden med reference types, utan man tilldelar minnes platser/adresser.
        ///     
        /// 3:  I den första metoden så är alla variablar value types, därav när man assignar "y" till "x",
        ///     Så får "y" bara "x" värde.
        ///     Medans i den andra metoden så är varaiblarna refernce types. När man assignar "y" til "x",
        ///     Så ger man "y" samma adress som "x" och om man då ändrar värdet på någon av dem så ändras då bådas värde.
        /// ------------------------
        /// 
        /// Datastrukturer och minneseffektivitet
        /// -----------------------
        /// övning 1
        /// 
        /// 2. Listans kapacitet ökar när man överskrider den nuvarande kapaciteten.
        /// 
        /// 3. Kapaciteten fördubblas.
        /// 
        /// 4. För att när en lista utökar sin kapacitet så skapar den en ny lista som den lägger alla element i,
        ///    och om den gjorde det i takt med att man la till elment så skulle det inte vara mineseffektivt.
        ///    Därför fördubblas listans kapacitet så att det finns lite extra utrymme,
        ///    så att den inte behöver utföra operationen direkt igen.
        ///    
        /// 5. Nej kapacitetn minskar inte.
        /// 
        /// 6. När man inte vill att listan ska överskrida en särskilld längd,
        ///    då kan man förhindra att listan behöver utöka sin kapacitet.
        ///    Eller om man vet hur många element som listan kommer inehålla,
        ///    och att elementen inte kommer minska eller öka i mängd.
        ///--------------
        /// 
        /// övning 2
        /// 1. Stina blir expedierad och lämnar kön. Olle blir expedierad och lämnar kön
        /// 
        /// övning 3
        /// 1. För då får den som ställde sig sist i kön bli expedierad först.
        /// -------------
        /// rekursion och iteration
        /// sista fågan:
        /// Jag tror att itteration är mer effektivt, då en itterativ metod bara behöver anropas en gång och gå igenom sin loop,
        /// medans en rekursiv metod anropar sig själv vid varje steg tills den nåt sitt mål.
        /// 
        /// </summary>

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
                        CheckParanthesis();
                        break;
                    case '5':
                        CheckFunction("Enter a number to get the Nth even number", RecursiveEven);
                        break;
                    case '6':
                        CheckFunction("Enter a number to get the Nth number of the fibonacci sequence", RecursiveFibonacci);
                        break;
                    case '7':
                        CheckFunction("Enter a number to get the Nth even number", IterativeEven);
                        break;
                    case '8':
                        CheckFunction("Enter a number to get the Nth fibonacci number", IterativeFibonacci);
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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            
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
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

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

       static void CheckParanthesis()
        {
            Console.Clear();
            Console.WriteLine("Type sentence with enclosed brackets");

            while (true)
            {
                string input = Console.ReadLine();
                char nav = input.Length > 0 ? input[0] : 'n';

                if (nav == '0' && input.Length < 2) return;


                var brackets = FindBrackets(input);
                if (brackets.Count == 0)
                {
                    Console.WriteLine("Found no opening bracket or a closing bracket before an opening," +
                                      " string had incorrect formating");
                    continue;
                }

                //reverse foor loop find the first opening we come across, save that index
                //go from saved index forward using a normal for loop til we find teh correct closing ande remove both elements.
                // if we find any closings that are not correct inbetween, return incorrect formatting.
                //repeat
                int i = brackets.Count() - 1;
                while (-1 < i)
                {
                    if (FoundEnclosedBrackets(brackets, i))
                    {
                        i = brackets.Count() - 1;
                        continue;
                    }

                    i--;
                }

                if (brackets.Count == 0)
                {
                    Console.WriteLine("Correct formatting, all brackets were enclosed");
                }
                else
                {
                    Console.WriteLine("Incorrect formatting, string has one or more unenclosed brackets");
                }          
            }
        }

        private static bool FoundEnclosedBrackets(List<char> brackets, int i)
        {
            bool retFlag = false;
            switch (brackets[i])
            {
                case '(':
                    if (FoundClosing(brackets, i, ')'))
                    {
                        retFlag = true;
                    }
                    break;
                case '[':
                    if (FoundClosing(brackets, i, ']'))
                    {
                        retFlag = true;
                    }
                    break;
                case '{':
                    if (FoundClosing(brackets, i, '}'))
                    {
                        retFlag = true;
                    }
                    break;
            }
            return retFlag;

        }

        private static bool FoundClosing(List<char> brackets, int i, char wantedClosing)
        {
            bool retFlag = false;
            if (i + 1 < brackets.Count)
            {
                if (brackets[i+1] == wantedClosing)
                {
                    brackets.RemoveAt(i+1);
                    brackets.RemoveAt(i);
                    retFlag = true;
                }
            }           
            return retFlag;
        }

        private static List<char> FindBrackets(string input)
        {
            List<char> temp = new List<char>();
            foreach (var item in input)
            {
                if (temp.Count==0 && (item == ')' || item == ']' || item == '}'))
                {
                    break;
                }
                else if (item == '(' || item == '[' || item == '{' || item == ')' || item == ']' || item == '}')
                {
                    temp.Add(item);
                }
            }
            return temp;
        }
        
        private static void WriteEachItemInCollection<T>(IEnumerable<T> theCollection)
        {
            foreach (var item in theCollection)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckFunction(string Instruction, Func<int, int> functionToRun)
        {
            Console.WriteLine(Instruction);
            while (true)
            {
                string input = Console.ReadLine();
                int n = 0;
                int.TryParse(input, out n);
                char nav = input.Length > 0 ? input[0] : 'n';
                if (nav == '0' && input.Length < 2) return;

                Console.WriteLine(functionToRun(n));
            }
        }

        private static int RecursiveEven(int n)
        {
            if (n == 0) return 0;
            return (RecursiveEven(n - 1) + 2);
        }
        
        //Måste vara ärlig, jag var tvungen att kolla up det här på nätet, har inte precis hållit på med reccursion tidigare.
        //Hade hört tallas om fibonaccisekvensen, men visste egentligen ingenting om det.
        private static int RecursiveFibonacci(int n)
        {
            if ( n < 2)
            {
                return n;
            }
            else
            {
                return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
            }          
        }
      
        private static int IterativeEven(int n)
        {
            if (n == 0) return 0;

            int result = 0;

            for (int i = 1; i <= n; i++)
            {
                result +=2;
            }
            return result;
        }

        private static int IterativeFibonacci(int n)
        {
            int result = 0;
            int a = 1;
            for (int i = 0; i < n; i++)
            {
                int b = result;
                result = a;
                a = b + a;
            }
            return result;
        }
    }
}

