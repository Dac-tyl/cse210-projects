using System;

class HealthSystem
{
    private Pet pet;

    public HealthSystem(Pet petInstance)
    {
        pet = petInstance;
    }

    public void CheckHealth()
    {
        if (pet.GetIsSick())
            Console.WriteLine($"{pet.GetName()} is sick! Please take care of it.");
        else
            Console.WriteLine($"{pet.GetName()} is healthy and happy!");
    }
}
