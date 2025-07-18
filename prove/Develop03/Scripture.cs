using System;
using System.Collections.Generic;

public class Scripture
{
    private ScriptureReference Reference;
    private List<ScriptureWord> Words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = new List<ScriptureWord>();
        foreach (var word in text.Split(' '))
        {
            Words.Add(new ScriptureWord(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(Reference.ToString());
        foreach (var word in Words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count = 3)
    {
        Random rand = new Random();
        int hidden = 0;

        List<int> indexes = new List<int>();
        for (int i = 0; i < Words.Count; i++)
        {
            if (Words[i].IsVisible())
            {
                indexes.Add(i);
            }
        }

        if (indexes.Count == 0) return;

        for (int i = 0; i < count && indexes.Count > 0; i++)
        {
            int randomIndex = rand.Next(indexes.Count);
            Words[indexes[randomIndex]].Hide();
            indexes.RemoveAt(randomIndex);
            hidden++;
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var word in Words)
        {
            if (word.IsVisible())
                return false;
        }
        return true;
    }
}
