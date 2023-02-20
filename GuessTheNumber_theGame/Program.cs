namespace GuessTheNumber_theGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            bool valid = false; ;
            int i = 0;
            bool[] array = new bool[10];

            Random rnd = new Random();
            int random = rnd.Next(1, 11);

            Console.Title = "Guess random number";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Guess number between 1 and 10\n");
            Console.ResetColor();

            // main loop - repeats itself until userInput == random
            do
            {

                //cheks if userInput is a valid number and if not displays error message
                do
                {
                    Console.Write("Write your number: ");
                    valid = int.TryParse(Console.ReadLine(), out userInput );

                    // checks if userInput is a number
                    if (!valid)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That's not a number!");
                        Console.ResetColor();
                    }
                } while (!valid);

                // checks if userInput is within range
                if(userInput < 1 || userInput > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose number between 1 and 10!");
                    Console.ResetColor();
                    continue;
                }

                // cheks if userInput is not repeating numbers
                if (array[userInput - 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You used this number before!");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    array[userInput - 1] = true;
                }

                // guides the user towards the correct number
                if(random < userInput)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Try lower!");
                    Console.ResetColor();
                }
                else if (random > userInput)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Try higher!");
                    Console.ResetColor();
                }
                i++;
            } while (userInput != random);

            // victory message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations, you won!");
            Console.WriteLine($"It took you {i} tries.");
            Console.ResetColor();
        }
    }
}