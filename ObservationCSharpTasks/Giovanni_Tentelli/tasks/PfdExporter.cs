using System.Collections.Immutable;

namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Class with a single method to export all locally saved data of students, moments, dates and observations into a legible pdf file.
/// </summary>
public class PdfExporter
{
    private static readonly char Sep = Path.DirectorySeparatorChar;
    private static readonly string Root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private const string NameApp = "Observations";
    private static readonly string ExportPath = Root + Sep + NameApp + Sep;
    private const string PdfName = "Observations.txt";

    private const float FontSize = 1;


    private readonly DummyPDDocument _document;
    private DummyPDPageContentStream _stream = null!;
    private int _currentLineYValue;

    /// <summary>
    /// Initialize the class and creates an empty document.
    /// </summary>
    public PdfExporter()
    {
        _document = new DummyPDDocument();
        SetNewPage();
    }

    /// <summary>
    /// Export all data saved into a user legible pdf file.
    /// </summary>
    /// <param name="data">dictionary containing all students, a dictionary of their saved moments, each containing a dictionary of saved dates, every date having a dictionary of observations and relative counters.</param>
    public void ExportPdf(Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>> data)
    {
        AddSingleLineText("Observations", 0, FontSize);
        AddSingleLineText(CreateSubTitle(), 0, FontSize);

        foreach (var student in data.Keys.ToImmutableSortedSet())
        {
            AddSingleLineText(" ", 0, FontSize);
            AddSingleLineText(student, 1, FontSize);

            foreach (var moment in data[student].Keys.ToImmutableSortedSet())
            {
                AddSingleLineText(" ", 0, FontSize);
                AddSingleLineText(moment, 2, FontSize);

                foreach (var date in data[student][moment].Keys.ToImmutableSortedSet())
                {
                    AddSingleLineText(" ", 0, FontSize);
                    AddSingleLineText(date, 2, FontSize);

                    List<String> observationsList = new List<string>();
                    foreach (var observation in data[student][moment][date].Keys.ToImmutableSortedSet())
                    {
                        observationsList.Add(observation + ": " + data[student][moment][date][observation]);
                    }

                    AddMultiLineText(observationsList, 3, FontSize);
                }
            }           
        }
        _document.Save(ExportPath + PdfName);
    }

    /// <summary>
    /// Create a string containing the date of creation.
    /// </summary>
    /// <returns>a string.</returns>
    private String CreateSubTitle()
    {
        return "PDF creato il " + DateTime.Today.ToString("U");
    }

    /// <summary>
    /// Add a single line of text to the current document and page.
    /// </summary>
    /// <param name="text">string of text to add.</param>
    /// <param name="xOffset">horizontal position on page.</param>
    /// <param name="fontSize">font size.</param>
    void AddSingleLineText(string text, int xOffset, float fontSize)
    {
        var indentation = "";
        for (int i = 0; i < xOffset; i++)
        {
            indentation += "\t";
        }

        if (IsEndOfPage(fontSize))
        {
            SetNewPage();
        }

        _stream.ShowText(indentation + text);
        _currentLineYValue -= (int) fontSize;
    }

    /// <summary>
    /// Add multiple lines of text to the current page.
    /// </summary>
    /// <param name="textList">list of strings to add.</param>
    /// <param name="xOffset">text indentation.</param>
    /// <param name="fontSize">font size.</param>
    void AddMultiLineText(List<string> textList, int xOffset, float fontSize)
    {
        var indentation = "";
        for (int i = 0; i < xOffset; i++)
        {
            indentation = indentation + "\t";
        }

        foreach (var textLine in textList)
        {
            if (IsEndOfPage(fontSize))
            {
                SetNewPage();
            }

            _stream.ShowText(indentation + textLine);
            //_stream.NewLine();
            _currentLineYValue -= (int) fontSize;
        }
    }

    /// <summary>
    /// Set a new page for the current document.
    /// </summary>
    void SetNewPage()
    {
        var page = new DummyPDPage();
        _document.AddPage(page);
        _stream = new DummyPDPageContentStream(page);
        var pageHeight = DummyPDPage.Height;
        _currentLineYValue = pageHeight;
    }

    /// <summary>
    /// Valuates if the current y offset has reached the bottom of the page.
    /// </summary>
    /// <param name="offset">additional offset regarding the height of a text line to evaluate if there still space fo a new line</param>
    /// <returns>return true if has been reached the bottom of page, false if not.</returns>
    private bool IsEndOfPage(float offset)
    {
        return _currentLineYValue - offset < 0;
    }
}