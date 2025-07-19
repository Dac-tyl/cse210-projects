using System;
using System.Collections.Generic;

public class Scripture
{
    private ScriptureReference _reference;
    private List<ScriptureWord> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = new List<ScriptureWord>();
        foreach (var word in text.Split(' '))
        {
            _words.Add(new ScriptureWord(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        foreach (var word in _words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count = 3)
    {
        Random rand = new Random();
        List<int> indexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsVisible())
            {
                indexes.Add(i);
            }
        }

        if (indexes.Count == 0) return;

        for (int i = 0; i < count && indexes.Count > 0; i++)
        {
            int randomIndex = rand.Next(indexes.Count);
            _words[indexes[randomIndex]].Hide();
            indexes.RemoveAt(randomIndex);
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var word in _words)
        {
            if (word.IsVisible())
                return false;
        }
        return true;
    }
}
