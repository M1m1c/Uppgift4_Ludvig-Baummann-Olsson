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

                var brackets = FindBrackets(input);
                if (brackets.Count == 0)
                {
                    Console.WriteLine("Found no opening bracket or found a closing bracket before an opening," +
                                      " string had incorrect formatting");
                    continue;
                }

                GoThroughBrackets(brackets);

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

        //Returns all brackets in the input string
        private static List<char> FindBrackets(string input)
        {
            List<char> temp = new List<char>();
            foreach (var item in input)
            {
                if (temp.Count == 0 && (item == ')' || item == ']' || item == '}'))
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

        //Loops through brackets list, restarts from the last index if FoundEnclosedBrackets succeeds
        private static void GoThroughBrackets(List<char> brackets)
        {
            int i = brackets.Count - 1;
            while (-1 < i)
            {
                if (FoundEnclosedBrackets(brackets, i))
                {
                    i = brackets.Count - 1;
                    continue;
                }
                i--;
            }
        }

        //Finds the last opening to appear in list and calls FoundClosing(), returns true if FoundClosing() Succeeds
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

        //Returns true if the elment behind index "i" contains the wanted symbol,
        //removes opening and closing brackets from list on succees.
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
    }
}
