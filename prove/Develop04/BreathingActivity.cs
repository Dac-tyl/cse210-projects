using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        int cycleTime = 6; // 3 in + 3 out
        int cycles = _duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(3);
            Console.WriteLine();
        }
    }
}
