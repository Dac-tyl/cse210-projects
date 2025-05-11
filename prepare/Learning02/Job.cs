// Job.cs
using System;

public class Job
{
    private string _jobTitle;
    private string _companyName;
    private int _yearStarted;
    private int _yearEnded;

    public Job(string jobTitle, string companyName, int yearStarted, int yearEnded)
    {
        _jobTitle = jobTitle;
        _companyName = companyName;
        _yearStarted = yearStarted;
        _yearEnded = yearEnded;
    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_yearStarted}-{_yearEnded}");
    }

}
