using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            string status = g.GetStatus();
            Console.WriteLine($"{i + 1}. {status} {g.GetName()} ({g.GetDescription()})");
        }
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        var goal = _goals[index];
        bool wasRecorded = goal.RecordEvent();

        if (!wasRecorded)
        {
            Console.WriteLine("Goal already completed or cannot be recorded.");
            return;
        }

        if (goal is ChecklistGoal checklist)
        {
            _score += checklist.GetPoints();
            if (checklist.IsCompleted())
            {
                int bonus = checklist.GetBonus();
                _score += bonus;
                Console.WriteLine($"Congrats! You completed the checklist and earned a bonus of {bonus} points!");
            }
            else
            {
                Console.WriteLine($"You earned {checklist.GetPoints()} points!");
            }
        }
        else if (goal is EternalGoal)
        {
            _score += goal.GetPoints();
            Console.WriteLine($"You earned {goal.GetPoints()} points!");
        }
        else if (goal is SimpleGoal)
        {
            if (goal.IsCompleted())
            {
                _score += goal.GetPoints();
                Console.WriteLine($"Congrats! You completed the goal and earned {goal.GetPoints()} points!");
            }
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals and score saved.");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string scoreLine = reader.ReadLine();
            _score = int.Parse(scoreLine);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Goal g = Goal.Deserialize(line);
                _goals.Add(g);
            }
        }
        Console.WriteLine("Goals and score loaded.");
    }
}
