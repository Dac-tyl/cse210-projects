using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter;

        if (grade >= 90)
       {
            letter = "A";
       }
        else if (grade >= 80)
        {   
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        if (grade >= 70)
        {
            Console.WriteLine ($"You passed with a {letter}. Congratulations!");
        }
        else 
        {
            Console.WriteLine($"You failed with a {letter}. Better luck next time!");
        }
    }
}