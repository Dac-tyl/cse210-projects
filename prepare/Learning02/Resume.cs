// Resume.cs
using System;
using System.Collections.Generic;

public class Resume
{
    // Member variable for person's name
    private string _name;
    
    // Member variable for list of jobs (List<Job>)
    private List<Job> _jobs;

    // Constructor to initialize Resume with a name
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Method to display the resume details
    public void Display()
    {
        // Display person's name
        Console.WriteLine($"Name: {_name}");

        // Display job list
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display(); // Call the Display method for each job in the list
        }
    }

    // Getter for name (optional)
    public string Name { get { return _name; } }
    public List<Job> Jobs { get { return _jobs; } }
}
