namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Dummy version of Apache Pdfbox PDDocument.
/// This is the in-memory representation of the PDF document.
/// </summary>
public class DummyPDDocument
{
    private readonly List<DummyPDPage> _pages = new();

    /// <summary>
    /// Will add a page to the document.
    /// </summary>
    /// <param name="page">the page to add to the document.</param>
    public void AddPage(DummyPDPage page)
    {
        _pages.Add(page);
    }

    /// <summary>
    /// Save the document to a file.
    /// </summary>
    /// <param name="exportPath">the file to save as.</param>
    public void Save(string exportPath)
    {
        //wrap all the document pages in a list of strings
        var text = _pages.SelectMany(page => page.Lines).ToList();

        foreach (var s in text)
        {
            //View export output on the console
            Console.WriteLine(s);
        }

        try
        {
            string directoryName = Path.GetDirectoryName(exportPath) ?? throw new InvalidOperationException();
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Error finding directory path: " + e);
        }

        try
        {
            File.WriteAllLinesAsync(exportPath, text);
            Console.WriteLine("File successfully saved in: " + exportPath);
        }
        catch (IOException e)
        {
            Console.WriteLine("Impossible create file: " + e);
        }
    }
}