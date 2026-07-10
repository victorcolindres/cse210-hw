using System;

// Program.cs
//
// This program meets the core requirements:
// - Write a new entry (with a random prompt and automatic date)
// - Display the full journal
// - Save the journal to a file
// - Load the journal from a file
// - Menu with the above options
//
// To exceed requirements:
// - Saving in .csv or JSON format, properly handling commas and quotes
// - Storing additional information in each entry (e.g., mood)
// - Saving/loading from a database

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("That is not a valid option. Please try again.\n");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    // Helper method that groups the logic for writing a new entry,
    // keeping the Main method simpler and easier to read.
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.Write("> ");
        string response = Console.ReadLine();
        Console.WriteLine();

        Entry newEntry = new Entry(prompt, response);
        journal.AddEntry(newEntry);
    }
}