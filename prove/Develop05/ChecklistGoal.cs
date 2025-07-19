public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    internal int _currentCount;

    public ChecklistGoal(string name, string desc, int points, int targetCount, int bonusPoints)
        : base(name, desc, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public override bool RecordEvent()
    {
        if (_completed) return false;
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _completed = true;
        }
        return true;
    }

    public override string GetStatus()
    {
        int barWidth = 20;
        double progress = (double)_currentCount / _targetCount;
        int filled = (int)(progress * barWidth);
        int empty = barWidth - filled;

        string bar = "[" + new string('█', filled) + new string('-', empty) + $"] {_currentCount}/{_targetCount}";
        string statusMark = _completed ? "X" : " ";

        return $"[{statusMark}] {bar}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_completed}|{_targetCount}|{_currentCount}|{_bonusPoints}";
    }

    public int GetBonus()
    {
        return _completed ? _bonusPoints : 0;
    }
}
