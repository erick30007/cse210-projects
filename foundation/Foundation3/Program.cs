using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        var activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 5.0),   
            new Cycling("03 Nov 2022", 60, 20.0), 
            new Swimming("03 Nov 2022", 45, 30)  
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
