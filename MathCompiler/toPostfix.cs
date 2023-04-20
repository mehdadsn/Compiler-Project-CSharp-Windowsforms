using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCompiler
{
    public class toPostfix
    {
        public static string Postfix(string txtFunction)
        {
            Stack<string> outPutStack = new Stack<string>();
            string output = "";
            Stack<string> tokenStack = new Stack<string>();

            string read = "";
            string function = txtFunction;
            for (int i = 0; i < function.Length; i++)
            {

                read += function[i];
                if (isNumber(read)) { }
                if (read == "x")
                {
                    output += read + " ";
                    //outPutStack.Push(read);
                    read = "";
                }
                else if (isNumber(read))
                {
                    for (int j = i + 1; j < function.Length && (isNumber(function[j].ToString()) || function[j] == '.'); j++)
                    {
                        read += function[j];
                        i++;
                    }

                    output += read + " ";
                    //outPutStack.Push(read);
                    read = "";
                }
                else if (read == " ")
                {
                    read = "";
                }
                else if (read == ")")
                {
                    while (tokenStack.First() != "(")
                    {
                        //outPutStack.Push(tokenStack.Pop());
                        output += tokenStack.Pop() + " ";
                    }
                    if (tokenStack.First() == "(") tokenStack.Pop();
                    //if(tokenStack.First() == "sin") outPutStack.Push(tokenStack.Pop());
                    int index = Reserved.keywords.IndexOf(tokenStack.First());
                    if (index >= 7 && index <= 12)
                    {
                        //outPutStack.Push(tokenStack.Pop());
                        output += tokenStack.Pop() + " ";
                    }
                    read = "";
                }else if(read == "|")
                {
                    read = "";
                    i++;
                    while(function[i] != '|' )
                    {
                        read += function[i];
                        i++;
                    }
                    output += Postfix(read) +" | ";
                }
                else
                {
                    if (Reserved.keywords.Contains(read))
                    {
                        int j = Reserved.keywords.IndexOf(read);
                        if (tokenStack.Count > 0 && j <= 6)
                        {
                            var test = tokenStack.ElementAt(0);
                            int b = Reserved.keywords.IndexOf(test);
                            if (Precedence(j, b))
                            {
                                //outPutStack.Push(tokenStack.Pop());
                                output += tokenStack.Pop() + " ";
                            }
                        }

                        tokenStack.Push(read);
                        read = "";
                    }
                }
            }
            if (tokenStack.Count > 0)
            {
                for (int i = 0; i <= tokenStack.Count; i++)
                {
                    output += tokenStack.Pop() + " ";
                    //outPutStack.Push(tokenStack.Pop());
                }
            }

            return output;
            
        }
        static bool isNumber(string s)
        {
            try
            {
                float.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
        static bool Precedence(int a, int b)
        {
            if (b > 6)
            {
                return false;
            }
            else if ((a / 2) <= (b / 2)) { return true; }
            else return false;
        }
    }
}
