using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string expression = "{7+(8*5)-[(9-7)+(4+1)]}";
        bool isBalanced = IsBalanced(expression);
        Console.WriteLine($"La expresión está balanceada: {isBalanced}");
    }

    static bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in expression)
        {
            if (ch == '{' || ch == '(' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == '}' || ch == ')' || ch == ']')
            {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if (!IsMatchingPair(top, ch)) return false;
            }
        }
        return stack.Count == 0;
    }

    static bool IsMatchingPair(char open, char close)
    {
        return (open == '{' && close == '}') ||
               (open == '(' && close == ')') ||
               (open == '[' && close == ']');
    }
}
