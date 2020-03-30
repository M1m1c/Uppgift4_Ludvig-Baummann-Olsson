using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class RecursionAndIteration
    {
        public static void CheckFunction(string Instruction, Func<int, int> functionToRun)
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

        public static int RecursiveEven(int n)
        {
            if (n == 0) return 0;
            return (RecursiveEven(n - 1) + 2);
        }

        //Måste vara ärlig, jag var tvungen att kolla up det här på nätet, har inte precis hållit på med reccursion tidigare.
        //Hade hört tallas om fibonaccisekvensen, men visste egentligen ingenting om det.
        public static int RecursiveFibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
            }
        }

        public static int IterativeEven(int n)
        {
            if (n == 0) return 0;

            int result = 0;

            for (int i = 1; i <= n; i++)
            {
                result += 2;
            }
            return result;
        }

        public static int IterativeFibonacci(int n)
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
