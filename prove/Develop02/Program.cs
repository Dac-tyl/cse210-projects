using System;

class Entry
{
    public string Prompt;
    public string Response;
    public string Date;

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public string ToLine()
    {
        return Date + "|" + Prompt + "|" + Response;
    }

    public void Display()
    {
        Console.WriteLine("Date: " + Date);
        Console.WriteLine("Prompt: " + Prompt);
        Console.WriteLine("Response: " + Response);
        Console.WriteLine();
    }

    public static Entry FromLine(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 3)
        {
            Entry e = new Entry(parts[1], parts[2]);
            e.Date = parts[0];
            return e;
        }
        return null;
    }
}

class Journal
{
    public Entry[] Entries = new Entry[100];
    public int Count = 0;

    public void Add(Entry entry)
    {
        if (Count < Entries.Length)
        {
            Entries[Count] = entry;
            Count++;
        }
        else
        {
            Console.WriteLine("Journal is full.");
        }
    }

    public void Display()
    {
        if (Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }

        for (int i = 0; i < Count; i++)
        {
            Entries[i].Display();
        }
    }

    public void Save(string filename)
    {
        string[] lines = new string[Count];
        for (int i = 0; i < Count; i++)
        {
            lines[i] = Entries[i].ToLine();
        }

        System.IO.File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal saved.\n");
    }

    public void Load(string filename)
    {
        if (!System.IO.File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(filename);
        Count = 0;
        foreach (string line in lines)
        {
            Entry e = Entry.FromLine(line);
            if (e != null)
            {
                Entries[Count] = e;
                Count++;
            }
        }

        Console.WriteLine("Journal loaded.\n");
    }
}

class Program
{
    static string[] Prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Filename to save: ");
                    string saveName = Console.ReadLine();
                    journal.Save(saveName);
                    break;
                case "4":
                    Console.Write("Filename to load: ");
                    string loadName = Console.ReadLine();
                    journal.Load(loadName);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.\n");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal)
    {
        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Length)];
        Console.WriteLine("\n" + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, response);
        journal.Add(entry);
        Console.WriteLine("Entry added.\n");
    }
}
