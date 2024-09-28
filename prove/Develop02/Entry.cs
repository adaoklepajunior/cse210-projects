public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    public Entry() { }

    public Entry(string promptText, string entryText)
    {
        Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        PromptText = promptText;
        EntryText = entryText;
    }

    public override string ToString()
    {
        return $"{Date} - Prompt: {PromptText}\n{EntryText}";
    }

    //Showing Creativity and Exceeding Requirements - Saving to a CSV file
    public string ToCsv()
    {
        return $"\"{Date}\",\"{PromptText.Replace("\"", "\"\"")}\",\"{EntryText.Replace("\"", "\"\"")}\"";
    }

    public static Entry FromCsv(string csvLine)
    {
        var values = csvLine.Split(new[] { "\",\"" }, StringSplitOptions.None);
        var date = values[0].Trim('\"');
        var promptText = values[1].Trim('\"');
        var entryText = values[2].Trim('\"');
        return new Entry(promptText, entryText) { Date = date };
    }
}