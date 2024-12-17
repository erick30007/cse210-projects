using System;

public abstract class Activity
{
    private string _date;
    private int _length; 

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string Date => _date;
    public int Length => _length;

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();     

    public virtual string GetSummary()
    {
        return $"{_date} ({_length} min): Distance {GetDistance():F1} km, Speed {GetSpeed():F1} kph, Pace {GetPace():F1} min per km";
    }
}
