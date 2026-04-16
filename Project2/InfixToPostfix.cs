using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class InfixToPostfix
    {
        public static int precedence(char text)
        {
            if (text == '+' || text == '-')
            {
                return 1;
            }
            else if (text == '*' || text == '/')
            {
                return 2;
            }
            else if (text == '^')
            {
                return 3;
            }
            return -1;
        }
        public bool is_operator(char text)
        {
            if (text == '+' || text == '-' ||
                text == '*' || text == '/' || text == '^')
            {
                return true;
            }
            return false;
        }

        public static string infixToPostfix(String infix)
        {
            var result = "";
            // Get the size
            var size = infix.Length;
            // Create empty stack 
            var s = new MyStack();
            for (var i = 0; i < size; ++i)
            {
                if ((infix[i] >= '0' && infix[i] <= '9') ||
                    (infix[i] >= 'a' && infix[i] <= 'z') ||
                    (infix[i] >= 'A' && infix[i] <= 'Z'))
                {
                    // When getting a operands
                    result = result + infix[i].ToString();
                }
                else
                {
                    if (s.isEmpty() || infix[i] == '(')
                    {
                        // Base case
                        // When getting a open parenthesis
                        // Or stack is empty
                        s.push(infix[i]);
                    }
                    else if (infix[i] == ')')
                    {
                        // Need to remove stack element until the close bracket
                        while (s.isEmpty() == false && s.peek() != '(')
                        {
                            // Get top element
                            result += s.peek();
                            // Remove stack element
                            s.pop();
                        }
                        if (s.peek() == '(')
                        {
                            // Remove stack element
                            s.pop();
                        }
                    }
                    else
                    {
                        // Remove stack element until precedence of 
                        // top is greater than current infix operator
                        while (s.isEmpty() == false &&
                               precedence(infix[i]) <=
                               precedence(s.peek()))
                        {
                            // Get top element
                            result += s.peek();
                            // Remove stack element
                            s.pop();
                        }
                        // Add new operator
                        s.push(infix[i]);
                    }
                }
            }
            // Add remaining elements
            while (s.isEmpty() == false)
            {
                result += s.peek();
                s.pop();
            }
            return result;
        }

        public static List<string> infix2Postfix(List<string> infixes)
        {
            List<string> result = new List<string>();
            foreach (string infix in infixes)
                result.Add(infixToPostfix(infix));
            return result;
        }
    }
}
