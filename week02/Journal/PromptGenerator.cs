using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // List of possible prompts. This class is the only one responsible
    // for knowing where prompts come from (currently, a fixed in-memory
    // list). If this were changed to a web database in the future,
    // only this class would need to be updated.
    private List<string> _prompts;

    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I learned today?",
            "What am I most grateful for today?"
        };
    }

    // Behavior: returns a random prompt from the list.
    // The calling code does not need to know how prompts are
    // stored or selected internally.
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}