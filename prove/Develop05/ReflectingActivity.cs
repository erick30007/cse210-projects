using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting", "This activity helps you reflect on past experiences and learn from them.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you overcame a big challenge.",
            "Reflect on a moment when you felt truly at peace.",
            "Recall a time when you achieved something you're proud of."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel during the experience?",
            "What did you learn from the experience?",
            "How can you apply what you learned in the future?"
        };
    }

    public void PerformReflection()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Take a moment to reflect on this prompt...\n");
        ShowSpinner(5);

        Console.WriteLine("Now, consider the following questions:");
        foreach (string question in _questions)
        {
            Console.WriteLine($"- {question}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}

