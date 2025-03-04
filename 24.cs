//3-write a program in c sharp to add complex numbers using operator overloading 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prg3
{
    class complex
    {


        float real, img;
        public complex(float real, float img)
        {
            this.real = real;
            this.img = img;
        }
        public complex()
        {
            real = 0.0f;
            img = 0.0f;
        }

        public static complex operator +(complex c1, complex c2)
        {
            complex c3 = new complex();
            c3.real = c1.real + c2.real;
            c3.img = c1.img + c2.img;
            return c3;
        }
        public void display()
        {
            if (img > 0)
            {
                Console.WriteLine("{0}+{1}i", real, img);
            }
            else
            {
                Console.WriteLine("{0}{1}i", real, img);
            }
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            complex c1 = new complex(2, -3);
            complex c2 = new complex(5, 7);
            complex c3 = new complex();
            c3 = c1 + c2;
            Console.WriteLine("Complex number 1: ");
            c1.display();
            Console.WriteLine("Complex number 2: ");
            c2.display();
            Console.WriteLine("Sum is: ");
            c3.display();
        }
    }
}

//////////////////////////////////////

//4- Write a program in c# sum of each row of given jagged array of three inner arrays

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace prg4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[3][];
            a[0] = new int[2];
            a[1] = new int[2];
            a[2] = new int[3];
            Console.WriteLine("Enter the array elements:");
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < a[i].Length; j++)
                    a[i][j] = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("The jagged array is:");
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.WriteLine(a[i][j] + "");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                int sum = 0;
                for (int j = 0; j < a[i].Length; j++)
                {
                    sum = sum + a[i][j];
                }
                Console.WriteLine("The sum of {0} row elements is {1}", i, sum);
            }
        }
    }
}
