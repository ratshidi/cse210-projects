using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string gradepercentage = Console.ReadLine();
        int percentage = int.Parse(gradepercentage);

        string letter = "";

        
        if (percentage >= 97 && percentage <= 100)
        {
            letter = "A+";
        }
        else if (percentage >= 90 && percentage <= 96)
        {
            letter = "A";
        }
        else if (percentage >= 87 && percentage <= 89)
        {
            letter = "B+";
        }
        else if (percentage >= 84 && percentage <= 86)
        {
            letter = "B";
        }
        else if (percentage >= 80 && percentage <= 83)
        {
            letter = "B-";
        }
        else if (percentage >= 77 && percentage <= 79)
        {
            letter = "C+";
        }
        else if (percentage >= 74 && percentage <= 76)
        {
            letter = "C";
        }
        else if (percentage >= 70 && percentage <= 73)
        {
            letter = "C-";
        }
        else if (percentage >= 67 && percentage <= 69)
        {
            letter = "D+";
        }
        else if (percentage >= 64 && percentage <= 66)
        {
            letter = "D";
        }
        else if (percentage >= 60 && percentage <= 63)
        {
            letter = "D-";
        }
        else
        {
            letter = "F";
        } 
        
        Console.WriteLine($"Your Grade is {letter}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, try again next time...");
        }
    }
}