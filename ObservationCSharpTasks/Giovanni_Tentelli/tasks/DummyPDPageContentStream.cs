namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Dummy version of Apache Pdfbox PDPageContentStream.
/// provides ability to write to a page content stream.
/// </summary>
public class DummyPDPageContentStream
{
    private readonly DummyPDPage _page;
    
    /// <summary>
    /// Create a new p
    /// </summary>
    /// <param name="page"></param>
    public DummyPDPageContentStream(DummyPDPage page)
    {
        _page = page;
    }

    /// <summary>
    /// Shows the given text at the location specified by the current text matrix.
    /// </summary>
    /// <param name="text">The Unicode text to show.</param>
    public void ShowText(string text)
    {
        _page.Lines.Add(text);
    }
}