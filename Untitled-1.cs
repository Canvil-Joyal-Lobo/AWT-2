//Program 9: Write a program to Set & Get the Name & Age of a person using Properties of C# to illustrate the use of different properties in C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Person {

        string name;
        int age;

        public string NAME {
            get {return name;}
            set { name = value; }
         }
        public int AGE{
            get { return age; }
            set { age = value; }
       }


               
        public static void display(Person[] p,int age)
        {
            Console.WriteLine("Name  Age");
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].AGE > age)
                {

                    Console.WriteLine(p[i].NAME+ " "+ p[i].AGE);
                   
                }
               
            }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] p = new Person[3];
          
            for (int i = 0; i < p.Length; i++)
            {
                p[i] =new Person();
                Console.Write("Enter the name:");
                p[i].NAME = Console.ReadLine();
                Console.Write("Enter the age:");
                p[i].AGE = int.Parse(Console.ReadLine());


            }
   
                int age = 16;
                Person.display(p, age);
        }
    }
}


///////////////////

//9-//Write a program to Set & Get the Name & Age of a person using Properties of C# to illustrate
using System;

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public static void Display(Person[] persons)
    {
        bool recordFound = false;  

        Console.WriteLine("{0,-20} {1,-5}", "Name", "Age");  // Table header
        Console.WriteLine(new string('-', 25));  

        foreach (var person in persons)
        {
            if (person.Age >= 16 && person.Age <= 60)  
            {
                Console.WriteLine("{0,-20} {1,-5}", person.Name, person.Age); 
                recordFound = true;  
            }
        }

      
        if (!recordFound)
        {
            Console.WriteLine("No records found with age between 16 and 60.");
        }
    }

    public static Person[] InputDetails(int count)
    {
        Person[] persons = new Person[count];

        for (int i = 0; i < count; i++)
        {
            persons[i] = new Person();

            Console.WriteLine(string.Format("Enter details for person {0}:", i + 1));

            Console.Write("Enter Name: ");
            persons[i].Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            persons[i].Age = int.Parse(Console.ReadLine());
        }

        return persons;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("How many persons do you want to enter? ");
        int count = int.Parse(Console.ReadLine());

        Person[] persons = Person.InputDetails(count);

        Console.WriteLine("People with Age between 16 and 60:");
        Person.Display(persons);
    }
}


/////////////////////////////////////////

//10. Write a Program in C# Demonstrate arrays of interface types (for runtime polymorphism).
using System;
namespace Lab10
{
    interface shape
    {
        double cal_area();
    }
    class circle:shape
    {
        public double cal_area()
        {
            Console.WriteLine("Enter the radius of a circle");
            double radius = double.Parse(Console.ReadLine());
            double area= 3.14 * radius * radius;
            return area;
        }
    }
    class square:shape
    {
        public double cal_area()
        {
            Console.WriteLine("Enter the side of a square");
            double side = double.Parse(Console.ReadLine());
            double area = side * side;
            return area;

        }
    }
    class rectangle:shape
    {
        public double cal_area()
        {
            Console.WriteLine("Enter the length and breadth of a rectangle");
            double length = double.Parse(Console.ReadLine());
            double breadth = double.Parse(Console.ReadLine());
            double area = length * breadth;
            return area;

        }
    }
    class triangle:shape
    {
        public double cal_area()
        {
            Console.WriteLine("Enter three sides of a triangle");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double s = (a + b + c) / 2.0 ;
            double s1 = (s * (s - a) * (s - b) * (s - c));
            double area = Math.Sqrt(s1);
            return area;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            shape[] s = new shape[4];
            s[0] = new circle();
            s[1] = new triangle();
            s[2] = new square();
            s[3] = new rectangle();
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("The area is {0:0.00}", s[i].cal_area());
            }
        }
    }
}
