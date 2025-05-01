using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, enter 0 when finished.");
        
        int numberEntered;

        do
        {
        Console.WriteLine("Enter a number.");
        numberEntered = int.Parse(Console.ReadLine());
        numbers.Add(numberEntered);


        }while(numberEntered != 0);
        
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if(number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}