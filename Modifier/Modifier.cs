using System;

public abstract class Modifier : IPriority
{
    public string Label { get; }
    private int PriorityLevel { get; }
    
    public Modifier() : this("", 0){}
    
    public Modifier(int priorityLevel) : this("", priorityLevel){}
    
    public Modifier(string label, int priorityLevel)
    {
        Label = label;
        PriorityLevel = priorityLevel;
    }

    public int GetPriority()
    {
        return PriorityLevel;
    }

    public abstract float Compute(float input);
}