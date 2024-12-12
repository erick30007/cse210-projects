using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetDetails();
    public abstract string SaveData();
}

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        _isComplete = false;
    }

    public override bool IsComplete() => _isComplete;

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} ({Description})";
    }

    public override string SaveData()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_isComplete}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public override bool IsComplete() => false;

    public override int RecordEvent() => Points;

    public override string GetDetails()
    {
        return $"[ ] {Name} ({Description})";
    }

    public override string SaveData()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }
}

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
    {
        Name = name;
        Description = description;
        Points = points;
        _targetCount = targetCount;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    public override bool IsComplete() => _timesCompleted >= _targetCount;

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _timesCompleted++;
            return _timesCompleted == _targetCount ? Points + _bonus : Points;
        }
        return 0;
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} ({Description}) -- Completed {_timesCompleted}/{_targetCount}";
    }

    public override string SaveData()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_timesCompleted},{_targetCount},{_bonus}";
    }
}

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        _score += _goals[goalIndex].RecordEvent();
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.SaveData());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])) { });
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[5])));
                    break;
            }
        }
    }

    public int GetScore()
    {
        return _score;
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Select Goal Type:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("Choice: ");
                    string goalType = Console.ReadLine();

                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter points for this goal: ");
                    int points = int.Parse(Console.ReadLine());

                    if (goalType == "1")
                    {
                        manager.AddGoal(new SimpleGoal(name, description, points));
                    }
                    else if (goalType == "2")
                    {
                        manager.AddGoal(new EternalGoal(name, description, points));
                    }
                    else if (goalType == "3")
                    {
                        Console.Write("Enter target count: ");
                        int targetCount = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonus));
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.DisplayGoals();
                    Console.Write("Select a goal to record: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(goalIndex);
                    break;

                case "4":
                    Console.WriteLine($"Your current score is: {manager.GetScore()}");
                    break;

                case "5":
                    Console.Write("Enter filename to save goals: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveToFile(saveFile);
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}

