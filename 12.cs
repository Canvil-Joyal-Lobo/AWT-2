//1) write a program to demonstrate command line arguments processing for the following 
//a) to find the square root of given number 
//b)to find sum and avg of 3 numbers 

(Add the number to the command line argument properties>Debug>Command line arguments any number 3)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prg1
{
    class Program
    {
        
         static void Main(string[] args)
        {
            double n1 = double.Parse(args[0]);
            double n2 = double.Parse(args[1]);
            double n3 = double.Parse(args[2]);
            Console.WriteLine("The numbers are {0},{1},{2}", n1, n2, n3);
            Console.WriteLine("The square root of {0} is {1:0.00}", n1, Math.Sqrt(n1));
            double sum = n1 + n2 + n3;
            double avg = sum / 3.0;
            Console.WriteLine("The sum of {0},{1},{2} is {3:0.00}",n1,n2,n3,sum);
            Console.WriteLine("The Average of {0},{1},{2} is {3:0.00}", n1, n2, n3, avg);
        }
    }
}
//////////////////////////////////////


//2) Write a program in c sharp to demonstrate the following
//a) Boxing and unBoxing
//b)Invalid unboxing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a Number:");
            int x = int.Parse(Console.ReadLine());
            object o = x;
            Console.WriteLine("Integer value is boxed!:" +o);
            int y = (int)o;
            Console.WriteLine("Integer value is unboxed:" +y);
            try
            {
                float z = (float)o;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}




