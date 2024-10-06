using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // This Constructor initializes the scripture with reference and text.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
{
    Random random = new Random();
    int numberToHide = random.Next(2, 5);
    int hiddenWordCount = 0;

    while (hiddenWordCount < numberToHide)
    {
        int index = random.Next(_words.Count);
        if (!_words[index].IsHidden())
        {
            _words[index].Hide();
            hiddenWordCount++;
        }

        if (IsCompletelyHidden())
        {
            break;
        }
    }
}

    public string GetDisplayText()
    {
        string scripText = "";
        foreach (Word word in _words)
        {
            scripText += word.GetDisplayText() + " ";
        }
        return _reference.GetDisplayText() + "\n" + scripText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}