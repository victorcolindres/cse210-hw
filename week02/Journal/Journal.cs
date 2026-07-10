using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Journal only knows that it stores a list of Entry objects.
    // Outside code never accesses _entries directly.
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Instead of exposing _entries directly, we offer an AddEntry
    // method. This means that if we ever change how entries are
    // stored internally (e.g., to an array or a database), the
    // code that calls AddEntry does not have to change.
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Behavior: iterates through every entry and asks it to
    // display itself (Journal does not know an Entry's internal
    // format).
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal has no entries yet.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all current entries to a text file.
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }

        Console.WriteLine($"Journal saved to {filename}.\n");
    }

    // Loads entries from a file, replacing any entries currently
    // stored in the journal.
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.\n");
            return;
        }

        // Replace the current entries.
        _entries = new List<Entry>();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);

            if (entry != null)
            {
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from {filename}.\n");
    }
}