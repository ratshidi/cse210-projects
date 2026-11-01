using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magicnumber = randomGenerator.Next(1, 101);

        int guess = -1;
        
        while (guess != magicnumber)
        {
            Console.WriteLine("What is the magic number? ");   
            guess = int.Parse(Console.ReadLine());

            if (guess < magicnumber)
            {
                Console.WriteLine("Your guess is too low.");
            }
            else if (guess > magicnumber)
            {
                Console.WriteLine("Your guess is too high.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number!");
            }
        }  
    }
}