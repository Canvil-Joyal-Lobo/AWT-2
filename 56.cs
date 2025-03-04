//Program 5: Write a Program in C# to demonstrate Array Out of Bound Exception using Try, Catch and Finally blocks.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the dimensions of the matrix");
                int r = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());

                int[,] a = new int[r,c];
                int k = 0;

                Console.WriteLine("CommandLine Arguments: ");
                for (int i = 0; i < args.Length;i++ )
                   Console.Write(args[i]+"\t");

                Console.WriteLine();
                Console.WriteLine("Matrix form:");
                Console.WriteLine();

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        a[i, j] = int.Parse(args[k++]);

                    }
                }

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        Console.Write(a[i,j] + " ");
                    }
                    Console.WriteLine();
                }
               

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();


            }
            finally {

                Console.WriteLine("The exception handled successfully!");
                Console.WriteLine();
            
            }
        }
    }
}
//////////////////////////////////////

//5-//Write a program in c# to demonstrate array out of bound Exception using try catch finally block

using System;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide the number of rows and columns as arguments.");
            return;
        }
        int rows = int.Parse(args[0]);
        int columns = int.Parse(args[1]);

        if (args.Length < 2 + rows * columns)
        {
            Console.WriteLine("Please provide all the elements for the 2D array.");
            return;
        }
        int[,] numbers = new int[rows, columns];
        int index = 2;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                numbers[i, j] = int.Parse(args[index]);
                index++;
            }
        }
        Console.WriteLine("\nCommand-Line Arguments:");
        for (int i = 0; i < args.Length; i++)
        {
            Console.Write(args[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("\nThe 2D Array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(numbers[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nEnter the row index to access (0 to " + (rows - 1) + "):");
        int rowIndex = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the column index to access (0 to " + (columns - 1) + "):");
        int colIndex = int.Parse(Console.ReadLine());
        try
        {
            Console.WriteLine("Element at [" + rowIndex + ", " + colIndex + "]: " + numbers[rowIndex, colIndex]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Finally block executed.");
        }
    }
}

//////////////////////////////////////


//6.Write a Program to Demonstrate Use of Virtual and override key words in C# with a simple program.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Employee Details");

        Console.Write("Enter Employee No: ");
        string empno = Console.ReadLine();

        Console.Write("Enter Employee Name: ");
        string empname = Console.ReadLine();

        Console.Write("Enter Employee Address: ");
        string empaddress = Console.ReadLine();

        Salary salaryEmployee = new Salary(empno, empname, empaddress);

        Console.Write("Enter Basic Salary: ");
        double basicSalary = Convert.ToDouble(Console.ReadLine());

        salaryEmployee.Salary_Calculate(basicSalary);  // Calculate DA, HRA, and Gross Salary

        Console.WriteLine("\nEmployee and Salary Details:");
        salaryEmployee.Display();
    }
}

//  class:Employee.cs

using System;

public class Employee
{
    protected string empno, empname, empaddress;

    public Employee() { }

    public Employee(string empno, string empname, string empaddress)
    {
        this.empno = empno;
        this.empname = empname;
        this.empaddress = empaddress;
    }

    public virtual void Display()
    {
        Console.WriteLine("Employee No: " + empno);
        Console.WriteLine("Employee Name: " + empname);
        Console.WriteLine("Employee Address: " + empaddress);
    }
}


//  class:Salary.cs

using System;

public class Salary : Employee
{
    private double basicSalary;
    private double da;
    private double hra;
    private double grossSalary;

    public Salary(string empno, string empname, string empaddress)
        : base(empno, empname, empaddress)
    {
    }

    public void Salary_Calculate(double basicSalary)
    {
        this.basicSalary = basicSalary;

        
        if (basicSalary < 20000)
        {
            da = 0.50 * basicSalary; 
            hra = 0.25 * basicSalary; 
        }
        else if (basicSalary >= 20000 && basicSalary < 30000)
        {
            da = 0.40 * basicSalary;  
            hra = 0.20 * basicSalary; 
        }
        else
        {
            da = 0.50 * basicSalary;  
            hra = 0.20 * basicSalary; 
        }

        grossSalary = basicSalary + da + hra; 
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Basic Salary: " + basicSalary);
        Console.WriteLine("Dearness Allowance (DA): " + da);
        Console.WriteLine("House Rent Allowance (HRA): " + hra);
        Console.WriteLine("Gross Salary: " + grossSalary);
    }
}


///////////////////