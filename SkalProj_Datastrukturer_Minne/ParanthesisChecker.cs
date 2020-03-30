using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class ParanthesisChecker
    {
        public static void CheckParanthesis()
        {
            Console.Clear();
            Console.WriteLine("Type a sentence with enclosed brackets");

            while (true)
            {
                string input = Console.ReadLine();
                char nav = input.Length > 0 ? input[0] : 'n';

                if (nav == '0' && input.Length < 2) return;
               
                Stack<char> openings = new Stack<char>();             
                bool correctFormatting = true;

                foreach (var item in input)
                {
                    if (correctFormatting == false) { break; }

                    switch (item)
                    {
                        case '(':
                            openings.Push('(');
                            break;
                        case '[':
                            openings.Push('[');
                            break;
                        case '{':
                            openings.Push('{');
                            break;
                        case ')':
                            correctFormatting = openings.Count > 0 ? (openings.Peek()=='(') : false;
                            if (correctFormatting) { openings.Pop(); }                       
                            break;
                        case ']':
                            correctFormatting = openings.Count > 0 ? (openings.Peek() == '[') : false;
                            if (correctFormatting) { openings.Pop(); }
                            break;
                        case '}':
                            correctFormatting = openings.Count > 0 ? (openings.Peek() == '{') : false;
                            if (correctFormatting) { openings.Pop(); }
                            break;
                    }
                }

                if (correctFormatting)
                {
                    Console.WriteLine("Correct formatting, all brackets were enclosed");
                }
                else
                {
                    Console.WriteLine("Incorrect formatting, string has one or more unenclosed brackets");
                }
            }
        }
    }
}
