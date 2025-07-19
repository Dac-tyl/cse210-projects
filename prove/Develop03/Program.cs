using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = LoadScriptures();
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            ClearConsole();
            scripture.Display();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "quit")
                break;

            scripture.HideRandomWords();
        }

        ClearConsole();
        Console.WriteLine("All words are hidden. Program has ended.");
    }

    static void ClearConsole()
    {
        for (int i = 0; i < 40; i++)
        {
            Console.WriteLine();
        }
    }

    static List<Scripture> LoadScriptures()
    {
        return new List<Scripture>
        {
            new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding"
            ),
            new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
            ),
            new Scripture(
                new ScriptureReference("2 Nephi", 2, 25),
                "Adam fell that men might be and men are that they might have joy"
            ),
            new Scripture(
                new ScriptureReference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God"
            ),
            new Scripture(
                new ScriptureReference("Alma", 37, 6),
                "By small and simple things are great things brought to pass"
            )
        };
    }
}

//I added multiple scriptures that the program can choose from to help you learn