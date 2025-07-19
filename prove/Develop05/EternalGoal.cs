public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points) : base(name, desc, points) { }

    public override bool RecordEvent()
    {
        // Always true because eternal goals never complete
        return true;
    }

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}|false";
    }
}
