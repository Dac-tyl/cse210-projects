using System;

class PetUI
{
    private PetManager manager;

    public PetUI(PetManager petManager)
    {
        manager = petManager;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulator!");

        while (!manager.HasPet())
        {
            Console.Write("Choose your pet type (Dog or Cat): ");
            string type = Console.ReadLine();
            Console.Write("Name your pet: ");
            string name = Console.ReadLine();

            try
            {
                manager.CreatePet(type, name);
                Console.WriteLine($"You adopted a {type} named {name}!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Feed Pet");
            Console.WriteLine("2. Play with Pet");
            Console.WriteLine("3. Clean Pet");
            Console.WriteLine("4. Show Pet Status");
            Console.WriteLine("5. Wait (Pass Time)");
            Console.WriteLine("6. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.FeedPet();
                    break;
                case "2":
                    manager.PlayWithPet();
                    break;
                case "3":
                    manager.CleanPet();
                    break;
                case "4":
                    manager.ShowPetStatus();
                    break;
                case "5":
                    manager.PassTime();
                    Console.WriteLine("Time passes... The pet’s stats changed.");
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
