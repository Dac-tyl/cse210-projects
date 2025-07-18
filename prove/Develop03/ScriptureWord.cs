public class ScriptureWord
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public ScriptureWord(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }

    public bool IsVisible()
    {
        return !IsHidden;
    }
}
