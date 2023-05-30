using System.ComponentModel.Design;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int num = random.Next(0, 100);

            bool win = false;

            do
            {
                Console.WriteLine("Guess a number between 1 and 100: ");
                string res = Console.ReadLine();
                int converted;
                bool success = int.TryParse(res, out converted);
                if (!success)
                {
                    Console.WriteLine("Please enter a number");
                }
                else if (converted > num)
                {
                    Console.WriteLine("Too high, try again.");
                } 
                else if (converted < num)
                {
                    Console.WriteLine("Too low, try again");
                }
                else
                {
                    Console.WriteLine("Correct! You Win!");
                    win = true;
                }

            }
            while (win == false);
        }
    }
}