using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completed;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = false;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public bool IsCompleted()
    {
        return _completed;
    }

    public abstract bool RecordEvent();

    public abstract string GetStatus();

    public abstract string Serialize();

    public static Goal Deserialize(string data)
    {
        // Format: Type|Name|Description|Points|Completed|ExtraFields...
        var parts = data.Split('|');
        string type = parts[0];
        string name = parts[1];
        string desc = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);

        switch (type)
        {
            case "SimpleGoal":
                var sg = new SimpleGoal(name, desc, points);
                sg._completed = completed;
                return sg;

            case "EternalGoal":
                var eg = new EternalGoal(name, desc, points);
                eg._completed = false; // Eternal goals never complete
                return eg;

            case "ChecklistGoal":
                int target = int.Parse(parts[5]);
                int current = int.Parse(parts[6]);
                int bonus = int.Parse(parts[7]);
                var cg = new ChecklistGoal(name, desc, points, target, bonus);
                cg._currentCount = current;
                cg._completed = completed;
                return cg;

            default:
                throw new Exception("Unknown goal type in file.");
        }
    }
}
