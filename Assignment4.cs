using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment4
    {
        //Enums : Q1      
        enum DayOfWeek
        {
            Saturday,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        class Program
        {
            static void Main()
            {
                Console.Write("Enter a day number (0–6): ");
                int dayNumber = int.Parse(Console.ReadLine());

                if (dayNumber < 0 || dayNumber > 6)
                {
                    Console.WriteLine("Invalid number! Please enter a number between 0 and 6.");
                    return;
                }

                DayOfWeek day = (DayOfWeek)dayNumber;
                Console.WriteLine($"Day: {day}");

                switch (day)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        Console.WriteLine("Type: Weekend");
                        break;

                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        Console.WriteLine("Type: Workday");
                        break;
                }
            }
        }
        //Arrays : Q1
        class Array1
        {
            static void Main()
            {
                Console.Write("Enter array size: ");
                int size = int.Parse(Console.ReadLine());
                int[] arr = new int[size];
                // Read elements
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Enter element [{i}]: ");
                    arr[i] = int.Parse(Console.ReadLine());
                }
                // Initialize values
                int sum = 0;
                int max = arr[0];
                int min = arr[0];
                for (int i = 0; i < size; i++)
                {
                    sum += arr[i];
                    if (arr[i] > max)
                        max = arr[i];
                    if (arr[i] < min)
                        min = arr[i];
                }
                double average = (double)sum / size;

                Console.WriteLine("\nSum = " + sum);
                Console.WriteLine("Average = " + average);
                Console.WriteLine("Max = " + max);
                Console.WriteLine("Min = " + min);

                Console.Write("Reverse = ");
                for (int i = size - 1; i >= 0; i--)
                {
                    Console.Write(arr[i]);
                    if (i != 0)
                        Console.Write(", ");

                }
            }
        }
        //Arrays : Q2
        class Array2
        {
            static void Main()
            {
                int students = 3;
                int subjects = 4;
                double[,] grades = new double[students, subjects];
                double totalSum = 0;

                for (int i = 0; i < students; i++)
                {
                    Console.WriteLine($"\nEnter grades for Student {i + 1}:");
                    for (int j = 0; j < subjects; j++)
                    {
                        Console.Write($"Subject {j + 1}: ");
                        grades[i, j] = double.Parse(Console.ReadLine());
                        totalSum += grades[i, j];
                    }
                }

                Console.WriteLine("\nStudent Averages:");
                for (int i = 0; i < students; i++)
                {
                    double studentSum = 0;
                    for (int j = 0; j < subjects; j++)
                    {
                        studentSum += grades[i, j];
                    }
                    double studentAverage = studentSum / subjects;
                    Console.WriteLine($"Student {i + 1} Average = {studentAverage}");
                }

                double overallAverage = totalSum / (students * subjects);
                Console.WriteLine($"\nOverall Class Average = {overallAverage}");
            }
        }
        //Functions : Q1
        class Functions1
        {
            static double Add(double a, double b)
            {
                return a + b;
            }
            static double Subtract(double a, double b)
            {
                return a - b;
            }
            static double Multiply(double a, double b)
            {
                return a * b;
            }
            static double Divide(double a, double b)
            {
                if (b == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return 0;
                }
                return a / b;
            }
            static void Main()
            {
                Console.Write("Enter first number: ");
                double num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                double num2 = double.Parse(Console.ReadLine());
                Console.Write("Enter operation (+, -, *, /): ");
                char op = char.Parse(Console.ReadLine());
                double result = 0;
                switch (op)
                {
                    case '+':
                        result = Add(num1, num2);
                        break;
                    case '-':
                        result = Subtract(num1, num2);
                        break;
                    case '*':
                        result = Multiply(num1, num2);
                        break;
                    case '/':
                        result = Divide(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        return;
                }
                Console.WriteLine("Result = " + result);
            }
        }
        //Functions : Q2
        class Functions2
        {
            // Method with out parameters
            static void CalculateCircle(double radius, out double area, out double circumference)
            {
                area = Math.PI * radius * radius;
                circumference = 2 * Math.PI * radius;
            }
            static void Main()
            {
                Console.Write("Enter radius: ");
                double radius = double.Parse(Console.ReadLine());
                double area, circumference;
                CalculateCircle(radius, out area, out circumference);
                Console.WriteLine("Area = " + area);
                Console.WriteLine("Circumference = " + circumference);
            }
        }

        //Application 
        enum Grade
        {
            A, B, C, D, F
        }
        class Application
        {

            static Grade GetGrade(int score)
            {
                if (score >= 90)
                    return Grade.A;
                else if (score >= 80)
                    return Grade.B;
                else if (score >= 70)
                    return Grade.C;
                else if (score >= 60)
                    return Grade.D;
                else
                    return Grade.F;
            }

           
            static double CalculateAverage(int[] scores)
            {
                int sum = 0;
                for (int i = 0; i < scores.Length; i++)
                {
                    sum += scores[i];
                }
                return (double)sum / scores.Length;
            }
            
            static void GetMinMax(int[] scores, out int min, out int max)
            {
                min = scores[0];
                max = scores[0];
                for (int i = 1; i < scores.Length; i++)
                {
                    if (scores[i] < min)
                        min = scores[i];
                    if (scores[i] > max) max = scores[i];
                }
            }
            static void Main()
            {
                int[] scores = new int[5];
                for (int i = 0; i < scores.Length; i++)
                {
                    Console.Write($"Enter score for Student {i + 1}: ");
                    scores[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("\n--- Report ---");
                
                for (int i = 0; i < scores.Length; i++)
                {
                    Grade grade = GetGrade(scores[i]);
                    Console.WriteLine($"Student {i + 1}: {scores[i]} -> Grade: {grade}");
                }
                
                double average = CalculateAverage(scores);
                
                GetMinMax(scores, out int minScore, out int maxScore);
                
                Console.WriteLine($"\nAverage: {average:F1}");
                Console.WriteLine($"Highest Score: {maxScore}");
                Console.WriteLine($"Lowest Score: {minScore}");
            }
        }

    }
}