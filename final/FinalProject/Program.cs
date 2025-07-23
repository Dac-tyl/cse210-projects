using System;

class Program
{
    static void Main(string[] args)
    {
        PetManager petManager = new PetManager();
        PetUI ui = new PetUI(petManager);
        ui.Run();
    }
}
