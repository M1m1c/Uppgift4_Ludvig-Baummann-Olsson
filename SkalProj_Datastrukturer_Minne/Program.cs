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
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            //TODO add list, queue or stack
            List<char> parenthisisCollection = new List<char>();
            while (true)
            {
                string input = Console.ReadLine();
                char nav = input.Length > 0 ? input[0] : 'n';
                if (nav == 0) return;

                //TODO turn this for each switch case into a function that takes a list and a func
                //RunFunctionBasedOnParentheis(input,parenthisisCollection, AddToCollection);
                RunFunctionBasedOnParentheis<IEnumerable<char>>(input, parenthisisCollection, AddToCollection);
                //TODO go trhough collection


            }


        }
        private static void WriteEachItemInCollection<T>(IEnumerable<T> theCollection)
        {
            foreach (var item in theCollection)
            {
                Console.WriteLine(item);
            }
        }
        static void RunFunctionBasedOnParentheis<T>(IEnumerable<char> collectionToGoThrough, 
            IEnumerable<char> collectionToAffect,
            Action<T,char> functionToRun)
        {
            foreach (var item in collectionToGoThrough)
            {
                switch (item)
                {
                    case '(':
                        //TODO add to collection
                        break;
                    case ')':
                        //TODO add to collection
                        break;
                    case '{':
                        //TODO add to collection
                        break;
                    case '}':
                        //TODO add to collection
                        break;
                    case '[':
                        //TODO add to collection
                        break;
                    case ']':
                        //TODO add to collection
                        break;
                }
            }
        }
        static void AddToCollection(IEnumerable<char> collection,char symbol)
        {

        }

    }
}

