using System;

class PetManager
{
    private Pet pet;

    public void CreatePet(string type, string name)
    {
        if (type.ToLower() == "dog")
            pet = new DogPet(name);
        else if (type.ToLower() == "cat")
            pet = new CatPet(name);
        else
            throw new ArgumentException("Invalid pet type.");
    }

    public bool HasPet()
    {
        return pet != null;
    }

    public void FeedPet()
    {
        pet.Feed();
        pet.ReactToFeed();
    }

    public void PlayWithPet()
    {
        pet.Play();
        pet.ReactToPlay();
    }

    public void CleanPet()
    {
        pet.Clean();
        pet.ReactToClean();
    }

    public void ShowPetStatus()
    {
        pet.ShowStats();
        pet.MakeSound();
    }

    public void PassTime()
    {
        pet.PassTime();
    }
}
