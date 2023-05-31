﻿using CalculatorLibrary;

namespace CalculatorProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while(!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.WriteLine("Type your first number, then press Enter");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("This is not a valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.WriteLine("Type your second number, then press Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.WriteLine("This is not a valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n"); ;
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0}\n", result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + ex.Message);
                }
                Console.WriteLine("------------------------\n");
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}