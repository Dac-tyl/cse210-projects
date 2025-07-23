using System;

class CatPet : Pet
{
    public CatPet(string name) : base(name) {}

    public override void ReactToFeed()
    {
        Console.WriteLine("The cat purrs softly while eating.");
    }

    public override void ReactToPlay()
    {
        Console.WriteLine("The cat chases a laser pointer playfully.");
    }

    public override void ReactToClean()
    {
        Console.WriteLine("The cat grooms itself after being cleaned.");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}
