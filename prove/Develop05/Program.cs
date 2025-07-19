using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n=== Goal Tracker ===");
            Console.WriteLine($"Current Score: {manager.GetScore()}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    RecordEvent(manager);
                    break;
                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    manager.Save(saveFile);
                    break;
                case "5":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    manager.Load(loadFile);
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter points per completion: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.Write("Please enter a valid non-negative number for points: ");
        }

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                int target;
                Console.Write("Enter how many times to complete goal: ");
                while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                {
                    Console.Write("Please enter a valid positive number: ");
                }
                int bonus;
                Console.Write("Enter bonus points upon completion: ");
                while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
                {
                    Console.Write("Please enter a valid non-negative number: ");
                }
                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        manager.ListGoals();
        Console.Write("Enter goal number to record event: ");
        if (int.TryParse(Console.ReadLine(), out int goalNum))
        {
            manager.RecordEvent(goalNum - 1);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
//I added progress bars for the checklist goals.