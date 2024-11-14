using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            _entries.Add(Entry.FromString(line));
        }
    }
}
