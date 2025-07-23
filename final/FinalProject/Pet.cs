using System;

abstract class Pet
{
    private string name;
    private int hunger;      // 0 (full) to 100 (starving)
    private int happiness;   // 0 (sad) to 100 (happy)
    private int cleanliness; // 0 (dirty) to 100 (clean)
    private bool isSick;

    public Pet(string petName)
    {
        name = petName;
        hunger = 50;
        happiness = 50;
        cleanliness = 50;
        isSick = false;
    }

    // Encapsulated fields accessed by methods only
    public string GetName() { return name; }
    public bool GetIsSick() { return isSick; }

    public void Feed()
    {
        hunger -= 20;
        if (hunger < 0) hunger = 0;
        Console.WriteLine($"{name} has been fed.");
        UpdateHealth();
    }

    public void Play()
    {
        happiness += 20;
        if (happiness > 100) happiness = 100;
        hunger += 10; // playing makes hungry
        cleanliness -= 10;
        Console.WriteLine($"{name} played and feels happier!");
        UpdateHealth();
    }

    public void Clean()
    {
        cleanliness = 100;
        Console.WriteLine($"{name} is now clean.");
        UpdateHealth();
    }

    // Called to reduce stats over time
    public void PassTime()
    {
        hunger += 5;
        happiness -= 5;
        cleanliness -= 5;
        if (hunger > 100) hunger = 100;
        if (happiness < 0) happiness = 0;
        if (cleanliness < 0) cleanliness = 0;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        // If pet is too hungry or dirty or unhappy, it becomes sick
        if (hunger > 80 || cleanliness < 20 || happiness < 20)
            isSick = true;
        else
            isSick = false;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Hunger: {hunger}/100");
        Console.WriteLine($"Happiness: {happiness}/100");
        Console.WriteLine($"Cleanliness: {cleanliness}/100");
        Console.WriteLine($"Sick: {(isSick ? "Yes" : "No")}");
    }

    // Polymorphic methods that can be overridden
    public abstract void ReactToFeed();
    public abstract void ReactToPlay();
    public abstract void ReactToClean();
    public abstract void MakeSound();
}
