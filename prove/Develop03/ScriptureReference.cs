public class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerseStart()
    {
        return _verseStart;
    }

    public int GetVerseEnd()
    {
        return _verseEnd;
    }

    public override string ToString()
    {
        if (_verseStart == _verseEnd)
            return $"{_book} {_chapter}:{_verseStart}";
        else
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}
