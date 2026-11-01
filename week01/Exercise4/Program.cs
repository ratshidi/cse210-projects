using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();

        int userInput = -1;
        
        while (userInput != 0)
        {
            Console.WriteLine("Enter number: ");
            Console.WriteLine("Enter 0 to quit");
            string input = Console.ReadLine();
            userInput = int.Parse(input);

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"Sum: {sum}");

        float average = (float)sum / numbers.Count;
        Console.WriteLine($"Average: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"Max: {max}");
    }
}