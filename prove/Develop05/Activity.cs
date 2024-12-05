using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected string Name { get { return _name; } }
    protected string Description { get { return _description; } }
    protected int Duration { get { return _duration; } }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {Name} activity.");
        Console.WriteLine($"{Description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed {Duration} seconds of the {Name} activity.");
    }

    public void ShowSpinner(int durationInSeconds)
    {
        for (int i = 0; i < durationInSeconds * 10; i++)
        {
            Console.Write("|");
            Thread.Sleep(100);
            Console.Write("\b/");
            Thread.Sleep(100);
            Console.Write("\b-");
            Thread.Sleep(100);
            Console.Write("\b\\");
            Thread.Sleep(100);
            Console.Write("\b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

