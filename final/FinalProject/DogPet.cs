using System;

class DogPet : Pet
{
    public DogPet(string name) : base(name) {}

    public override void ReactToFeed()
    {
        Console.WriteLine("The dog wags its tail happily after eating.");
    }

    public override void ReactToPlay()
    {
        Console.WriteLine("The dog barks excitedly and runs around.");
    }

    public override void ReactToClean()
    {
        Console.WriteLine("The dog shakes off the water happily.");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}
