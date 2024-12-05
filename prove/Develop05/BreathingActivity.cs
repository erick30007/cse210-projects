using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity helps you relax by guiding you through slow breathing exercises. we recommend you to be in a place where there is silence and nothing to interrupt you. Clear your mind and focus on your breathing.") { }

    public void PerformBreathing()
    {
        DisplayStartingMessage();

        Console.WriteLine("Follow the instructions to breathe in and out.\n");

        int interval = Duration / 2; 
        for (int i = 0; i < interval; i++)
        {
            Console.Write("Breathe in...");
            ShowCountDown(3);
            Console.WriteLine(" Now breathe out...");
            ShowCountDown(3);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}

