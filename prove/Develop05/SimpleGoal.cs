public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string desc, int points) : base(name, desc, points) { }

    public override bool RecordEvent()
    {
        if (_completed) return false;
        _completed = true;
        return true;
    }

    public override string GetStatus()
    {
        return _completed ? "[X]" : "[ ]";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_completed}";
    }
}
