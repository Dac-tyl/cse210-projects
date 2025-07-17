using System;

class Program
{
    static void Main()
    {
        Scripture[] scriptures = new Scripture[5];
        scriptures[0] = new Scripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding.");
        scriptures[1] = new Scripture(new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        scriptures[2] = new Scripture(new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy.");
        scriptures[3] = new Scripture(new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God.");
        scriptures[4] = new Scripture(new Reference("Ether", 12, 27),
            "And if men come unto me I will show unto them their weakness.");

        Random rand = new Random();
        int index = rand.Next(scriptures.Length);
        Scripture scripture = scriptures[index];

        while (!scripture.AllWordsHidden())
        {
            SafeClear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        SafeClear();
        Console.WriteLine("Final Scripture:\n");
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden or program ended.");
    }

    static void SafeClear()
    {
        try
        {
            Console.Clear();
        }
        catch
        {
            for (int i = 0; i < 30; i++) Console.WriteLine();
        }
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return _startVerse == _endVerse
            ? $"{_book} {_chapter}:{_startVerse}"
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

class Scripture
{
    private Reference _reference;
    private Word[] _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] parts = text.Split(' ');
        _words = new Word[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            _words[i] = new Word(parts[i]);
        }
    }

    public void HideRandomWords(int count)
    {
        int tries = 0;
        int maxTries = count * 5;

        while (count > 0 && tries < maxTries)
        {
            int index = _random.Next(_words.Length);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                count--;
            }
            tries++;
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " - ";
        for (int i = 0; i < _words.Length; i++)
        {
            result += _words[i].GetDisplayText() + " ";
        }
        return result.Trim();
    }

    public bool AllWordsHidden()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            if (!_words[i].IsHidden())
                return false;
        }
        return true;
    }
}
//To exceed the requirements I added multiple scriptures that can be picked at random to use from a library in the file.