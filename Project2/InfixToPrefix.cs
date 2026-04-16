using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class InfixToPrefix
    {
        public static List<string> infix2Prefix(List<string> infixes)
        {
            List<string> result = new List<string>();
            foreach (string infix in infixes)
            {
                result.Add(infixToPrefix(infix));
            }
            return result;
        }
        // Function to check if
        // given character is
        // an operator or not.
        static bool isOperator(char c)
        {
            return (!(c >= 'a' && c <= 'z') &&
                    !(c >= '0' && c <= '9') &&
                    !(c >= 'A' && c <= 'Z'));
        }

        // Function to find priority
        // of given operator.
        static int getPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            else if (C == '^')
                return 3;
            return 0;
        }

        // Function that converts infix
        // expression to prefix expression.
        static String infixToPrefix(String infix)
        {
            // stack for operators.
            Stack<char> operators = new Stack<char>();

            // stack for operands.
            Stack<String> operands = new Stack<String>();

            for (int i = 0; i < infix.Length; i++)
            {

                // If current character is an
                // opening bracket, then
                // push into the operators stack.
                if (infix[i] == '(')
                {
                    operators.Push(infix[i]);
                }

                // If current character is a
                // closing bracket, then pop from
                // both stacks and push result
                // in operands stack until
                // matching opening bracket is
                // not found.
                else if (infix[i] == ')')
                {
                    while (operators.Count != 0 &&
                        operators.Peek() != '(')
                    {

                        // operand 1
                        String op1 = operands.Peek();
                        operands.Pop();

                        // operand 2
                        String op2 = operands.Peek();
                        operands.Pop();

                        // operator
                        char op = operators.Peek();
                        operators.Pop();

                        // Add operands and operator
                        // in form operator +
                        // operand1 + operand2.
                        String tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    // Pop opening bracket
                    // from stack.
                    operators.Pop();
                }

                // If current character is an
                // operand then push it into
                // operands stack.
                else if (!isOperator(infix[i]))
                {
                    operands.Push(infix[i] + "");
                }

                // If current character is an
                // operator, then push it into
                // operators stack after popping
                // high priority operators from
                // operators stack and pushing
                // result in operands stack.
                else
                {
                    while (operators.Count != 0 &&
                        getPriority(infix[i]) <=
                            getPriority(operators.Peek()))
                    {

                        String op1 = operands.Peek();
                        operands.Pop();

                        String op2 = operands.Peek();
                        operands.Pop();

                        char op = operators.Peek();
                        operators.Pop();

                        String tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    operators.Push(infix[i]);
                }
            }

            // Pop operators from operators
            // stack until it is empty and
            // operation in add result of
            // each pop operands stack.
            while (operators.Count != 0)
            {
                String op1 = operands.Peek();
                operands.Pop();

                String op2 = operands.Peek();
                operands.Pop();

                char op = operators.Peek();
                operators.Pop();

                String tmp = op + op2 + op1;
                operands.Push(tmp);
            }

            // Final prefix expression is
            // present in operands stack.
            return operands.Peek();
        }
    }
}
