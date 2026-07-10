using System;

public class Entry
{
    // Private member variables (encapsulation): only the Entry class
    // knows how these are stored internally.
    private string _date;
    private string _promptText;
    private string _entryText;

    // Separator symbol used when saving/loading to a file.
    // Chosen to be unlikely to appear in the actual content.
    private const string Separator = "~|~";

    // Constructor used when the user writes a brand new entry.
    // The date is automatically set to the current date.
    public Entry(string promptText, string entryText)
    {
        _promptText = promptText;
        _entryText = entryText;
        _date = DateTime.Now.ToShortDateString();
    }

    // Constructor used when rebuilding an entry from a line that was
    // loaded from a file (it already has its own saved date).
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Behavior: the Entry knows how to display itself.
    // The Journal class does not need to know an entry's internal format.
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    // Converts the entry into a single line of text ready to be
    // saved to a file, using the defined separator.
    public string ToFileString()
    {
        return $"{_date}{Separator}{_promptText}{Separator}{_entryText}";
    }

    // Static method that rebuilds an Entry object from a line
    // read from a saved file.
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);

        // Basic validation to avoid errors if the line is malformed.
        if (parts.Length != 3)
        {
            return null;
        }

        string date = parts[0];
        string promptText = parts[1];
        string entryText = parts[2];

        return new Entry(date, promptText, entryText);
    }
}