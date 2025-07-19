using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts = new List<string>
    {
        "Think of someone who has made your life better.",
        "Think of something small that made you smile recently.",
        "Reflect on a challenge that helped you grow.",
        "Think of a gift you’ve received that meant a lot.",
        "Think of a place that brings you peace."
    };

    public GratitudeActivity()
        : base("Gratitude Activity", "This activity helps you reflect on the blessings in your life and strengthen your sense of gratitude.")
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = _gratitudePrompts[rand.Next(_gratitudePrompts.Count)];

        Console.WriteLine("\n" + prompt);
        Console.WriteLine("Take this time to reflect quietly...");
        ShowSpinner(_duration);
    }
}
