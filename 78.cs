//7. Write a Program in C# to create and implement a Delegate for any two arithmetic operations


using System;

namespace DelegateExample
{   
    public delegate void CalculatorDelegate(float a, float b);
    class Calculator
    {       
        public void Add(float a, float b)
        {
            Console.WriteLine("Addition: " + (a + b));
        }

        
        public void Sub(float a, float b)
        {
            Console.WriteLine("Subtraction: " + (a - b));
        }

      
        public void Mul(float a, float b)
        {
            Console.WriteLine("Multiplication: " + (a * b));
        }

      
        public void Quo(float a, float b)
        {
            if (b != 0)
                Console.WriteLine("Division: " + (a / b));
            else
                Console.WriteLine("Division by zero is not allowed.");
        }

        public void Mod(float a, float b)
        {
            if (b != 0)
                Console.WriteLine("Modulo: " + (a % b));
            else
                Console.WriteLine("Modulo by zero is not allowed.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {           
            Calculator c = new Calculator();
            CalculatorDelegate cd = new CalculatorDelegate(c.Add);
            cd(10, 20);
            Console.Write("Enter first number: ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            float b = float.Parse(Console.ReadLine());
            cd += c.Sub;
            cd += c.Mul;
            cd += c.Quo;
            cd += c.Mod;
            cd(a, b);
        }
    }
}


///////////////////////

//8. Write a Program in C# to demonstrate abstract class and abstract methods in C#.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    abstract class Calculate
    {
        public abstract float add(float a, float b);
        public abstract float sub(float a, float b);
        public abstract float mul(float a, float b);
        public abstract float div(float a, float b);
        public abstract float mod(float a, float b);
    }
    class Calculator : Calculate
    {
        public override float add(float a, float b)
        {
            return a + b;
        }
        public override float sub(float a, float b)
        {
            return a - b;
        }
        public override float mul(float a, float b)
        {
            return a * b;
        }
        public override float div(float a, float b)
        {
            return a / b;
        }
        public override float mod(float a, float b)
        {
            return a % b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Console.Write("Enter the first number:");
            float a = float.Parse(Console.ReadLine());
            Console.Write("Enter the Second number:");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("The sum of two numbers {0} and {1} is :{2}", a, b, c.add(a, b));
            Console.WriteLine("The difference of two numbers {0} and {1} is :{2}", a, b, c.sub(a, b));
            Console.WriteLine("The product of two numbers {0} and {1} is :{2}", a, b, c.mul(a, b));
            Console.WriteLine("The quotient of two numbers {0} and {1} is :{2}", a, b, c.div(a, b));
            Console.WriteLine("The remainder of two numbers {0} and {1} is :{2}", a, b, c.mod(a, b));
        }
    }
}
