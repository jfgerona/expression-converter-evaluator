using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class ExpressionEvaluation
    {
        public static double evaluatePostfix(string v)
        //evaluation method
        {
            Stack i = new Stack();
            double a, b;
            for (int j = 0; j < v.Length; j++)
            //'v.Length' means length of the string
            {
                String c = v.Substring(j, 1);
                if(c.Equals("+")|| c.Equals("-")|| c.Equals("*") || c.Equals("/"))
                {
                    b = Convert.ToDouble(i.Pop());
                    a = Convert.ToDouble(i.Pop());
                    i.Push(evaluateExpression(a, b, c));
                }
                else
                {
                    i.Push(v.Substring(j, 1));
                }
            }
            return Convert.ToDouble(i.Pop());
        }

        static Boolean isOperand(char c)
        {
            // If the character is a digit
            // then it must be an operand
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        public static double evaluatePrefix(String exprsn)
        {
            Stack<Double> Stack = new Stack<Double>();

            for (int j = exprsn.Length - 1; j >= 0; j--)
            {

                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn[j]))
                    Stack.Push((double)(exprsn[j] - 48));

                else
                {
                    // Operator encountered
                    // Pop two elements from Stack
                    double o1 = Stack.Peek();
                    Stack.Pop();
                    double o2 = Stack.Peek();
                    Stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 O o2.
                    Stack.Push(Convert.ToDouble(evaluateExpression(o1, o2, exprsn[j].ToString())));
                }
            }

            return Stack.Peek();
        }

        //Expression tree
        public static string evaluateExpression(double a, double b, string c)
        {
            string result = "";
            var l = Expression.Constant(a);
            var r = Expression.Constant(b);
            switch (c)
            {
                case "+":
                    var Add = Expression.Add(l, r);
                    result = Expression.Lambda<Func<double>>(Add).Compile()().ToString();
                    break;
                case "-":
                    var Subtract = Expression.Subtract(l, r);
                    result = Expression.Lambda<Func<double>>(Subtract).Compile()().ToString();
                    break;
                case "*":
                    var Multiply = Expression.Multiply(l, r);
                    result = Expression.Lambda<Func<double>>(Multiply).Compile()().ToString();
                    break;
                case "/":
                    var Divide = Expression.Divide(l, r);
                    result = Expression.Lambda<Func<double>>(Divide).Compile()().ToString();
                    break;
            }

            return result;
        }
    }
}
