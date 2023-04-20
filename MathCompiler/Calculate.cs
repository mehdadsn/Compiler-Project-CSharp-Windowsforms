using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCompiler
{
    public class Calculate
    {
        public static float calculate(string postfix, double x)
        {
            Stack<string> stack = new Stack<string>();
            string input = "";
            float answer = 0;
            int i = 0;
            for (; i < postfix.Length; i++)
            {
                for (; postfix[i] != ' '; i++)
                {
                    input += postfix[i];
                }
                if (input == "x")
                {
                    stack.Push(x.ToString());
                }
                else if (input == "") { }
                else stack.Push(input);


                switch (input)
                {

                    case "+":
                        stack.Pop();
                        float b1 = float.Parse(stack.Pop());
                        float a1 = float.Parse(stack.Pop());
                        a1 = a1 + b1;
                        stack.Push(a1.ToString());
                        break;
                    case "-":
                        stack.Pop();
                        float b2 = float.Parse(stack.Pop());
                        float a2 = float.Parse(stack.Pop());
                        a2 = a2 - b2;
                        stack.Push(a2.ToString());
                        break;
                    case "*":
                        stack.Pop();
                        float b3 = float.Parse(stack.Pop());
                        float a3 = float.Parse(stack.Pop());
                        a3 = a3 * b3;
                        stack.Push(a3.ToString());
                        break;
                    case "/":
                        stack.Pop();
                        float b4 = float.Parse(stack.Pop());
                        float a4 = float.Parse(stack.Pop());
                        a4 = a4 / b4;
                        stack.Push(a4.ToString());
                        break;
                    case "^":
                        stack.Pop();
                        double b5 = float.Parse(stack.Pop());
                        double a5 = float.Parse(stack.Pop());
                        a5 = Math.Pow(a5, b5);
                        stack.Push(a5.ToString());
                        break;
                    case "sin":
                        stack.Pop();
                        double a6 = float.Parse(stack.Pop());
                        a6 = a6 * (Math.PI / 180);
                        a6 = Math.Sin(a6);
                        stack.Push(a6.ToString());
                        break;
                    case "cos":
                        stack.Pop();
                        double a7 = float.Parse(stack.Pop());
                        a7 = a7 * (Math.PI / 180);
                        a7 = Math.Cos(a7);
                        stack.Push(a7.ToString());
                        break;
                    case "tan":
                        stack.Pop();
                        double a8 = float.Parse(stack.Pop());
                        a8 = a8 * (Math.PI / 180);
                        a8 = Math.Tan(a8);
                        stack.Push(a8.ToString());
                        break;
                    case "cot":
                        stack.Pop();
                        double a9 = float.Parse(stack.Pop());
                        a9 = a9 * (Math.PI / 180);
                        a9 = 1 / Math.Tan(a9);
                        stack.Push(a9.ToString());
                        break;
                    case "arcsin":
                        stack.Pop();
                        double a10 = float.Parse(stack.Pop());
                        a10 = Math.Asin(a10);
                        a10 = a10 * (180 / Math.PI);
                        stack.Push(a10.ToString());
                        break;
                    case "arccos":
                        stack.Pop();
                        double a11 = float.Parse(stack.Pop());
                        a11 = Math.Asin(a11);
                        a11 = a11 * (180 / Math.PI);
                        stack.Push(a11.ToString());
                        break;
                    case "|":
                        stack.Pop();
                        double a12 = float.Parse(stack.Pop());
                        a12 = Math.Abs(a12);
                        stack.Push(a12.ToString());
                        break;
                }

                input = "";
            }

            answer = float.Parse(stack.Pop());
            return answer;
        }
    }
}
