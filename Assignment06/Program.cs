﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment06
{
    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    [Flags]
    public enum Permissions
    { Read = 1, Write = 2, Delete = 4, Execute = 8 }

    public struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point otherPoint)
        {
            double deltaX = X - otherPoint.X;
            double deltaY = Y - otherPoint.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Question1()
        {
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }
        }

        static void Question2()
        {
            Person[] people = new Person[3];

            people[0] = new Person("Mahmoud", 21);
            people[1] = new Person("Khaled", 29);
            people[2] = new Person("Ahmed", 29);

            Console.WriteLine("Details of Persons:");
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

        }

        static void Question3()
        {
            string input;
            Season season;
            do
            {
                Console.WriteLine("Enter a season (Spring, Summer, Autumn, Winter):");
                input = Console.ReadLine();
            }
            while (!Enum.TryParse(input, true, out season));


            string monthRange = season switch
            {
                Season.Spring => "March to May",
                Season.Summer => "June to August",
                Season.Autumn => "September to November",
                Season.Winter => "December to February",
                _ => "Unknown"
            };

            // Display the month range
            Console.WriteLine($"Month range for {season}: {monthRange}");
        }

        static void Question4()
        {
            Permissions permissions = Permissions.Read | Permissions.Write;

            permissions &= ~Permissions.Write;
            permissions |= Permissions.Delete;

            bool executeBool = (permissions & Permissions.Execute) == Permissions.Execute;
            Console.WriteLine("has Execute Permission: " + executeBool);
        }

        static void Question5()
        {
            string input;
            Color clr;
            do
            {
                Console.WriteLine("Enter a Color:");
                input = Console.ReadLine();
            }
            while (!Enum.TryParse(input, true, out clr));

            string clrString = clr switch
            {
                Color.Red or Color.Green or Color.Blue => "Primary color",
                _ => "not primary"
            };
        }

        static void Question6()
        {
            Point[] pts = new Point[2];
            for (int i = 0; i < pts.Length; i++)
            {
                string x;
                int xVal;
                string y;
                int yVal;
                do
                {
                    Console.WriteLine($"Enter Point{i} x:");
                    x = Console.ReadLine();
                    Console.WriteLine($"Enter Point{i} y:");
                    y = Console.ReadLine();
                } while (!int.TryParse(x, out xVal) || !int.TryParse(y, out yVal));

                pts[i] = new Point(xVal, yVal);
            }

            Console.WriteLine($"distance: {pts[0].DistanceTo(pts[1])}");
        }

        static void Question7()
        {
            Person[] people = new Person[3];
            int oldestIndex = 0; //make first person the oldest to start comparisons

            for (int i = 0; i < people.Length; i++)
            {
                string name;
                int age;
                string ageInput;
                do
                {
                    Console.WriteLine($"Enter Name for person{i}:");
                    name = Console.ReadLine();
                    Console.WriteLine($"Enter Age for person{i}:");
                    ageInput = Console.ReadLine();
                } while (!int.TryParse(ageInput, out age));

                people[i] = new Person(name, age);

                if (i > 0 && people[i - 1].Age < people[i].Age)
                {
                    oldestIndex = i;
                }
            }

            Console.WriteLine($"Oldest Person:\n{people[oldestIndex]}");
        }
    }
}