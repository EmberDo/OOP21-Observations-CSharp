namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Used to test PDFExporter.
/// If the export has been successful a new pdf file called Observation will be created in MyDocuments folder.
/// </summary>
public static class TestClass
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>> data = new();
        for (int i = 1; i <= 5; i++)
        {
            data.Add("studente " + i, new Dictionary<string, Dictionary<string, Dictionary<string, int>>>());
        }

        data["studente 1"].Add("momento 1", new Dictionary<string, Dictionary<string, int>>());
        data["studente 1"].Add("momento 2", new Dictionary<string, Dictionary<string, int>>());
        data["studente 1"].Add("momento 3", new Dictionary<string, Dictionary<string, int>>());

        data["studente 2"].Add("momento 1", new Dictionary<string, Dictionary<string, int>>());
        data["studente 2"].Add("momento 2", new Dictionary<string, Dictionary<string, int>>());

        data["studente 3"].Add("momento 1", new Dictionary<string, Dictionary<string, int>>());
        data["studente 3"].Add("momento 2", new Dictionary<string, Dictionary<string, int>>());
        data["studente 3"].Add("momento 3", new Dictionary<string, Dictionary<string, int>>());
        data["studente 3"].Add("momento 4", new Dictionary<string, Dictionary<string, int>>());
        data["studente 3"].Add("momento 5", new Dictionary<string, Dictionary<string, int>>());

        data["studente 4"].Add("momento 1", new Dictionary<string, Dictionary<string, int>>());

        data["studente 1"]["momento 1"].Add("data 1", new Dictionary<string, int>());
        data["studente 1"]["momento 1"].Add("data 2", new Dictionary<string, int>());
        data["studente 1"]["momento 2"].Add("data 1", new Dictionary<string, int>());
        data["studente 1"]["momento 3"].Add("data 1", new Dictionary<string, int>());

        data["studente 2"]["momento 1"].Add("data 1", new Dictionary<string, int>());
        data["studente 2"]["momento 1"].Add("data 2", new Dictionary<string, int>());
        data["studente 2"]["momento 2"].Add("data 1", new Dictionary<string, int>());
        data["studente 2"]["momento 2"].Add("data 2", new Dictionary<string, int>());

        data["studente 3"]["momento 1"].Add("data 1", new Dictionary<string, int>());
        data["studente 3"]["momento 1"].Add("data 2", new Dictionary<string, int>());
        data["studente 3"]["momento 2"].Add("data 1", new Dictionary<string, int>());
        data["studente 3"]["momento 3"].Add("data 1", new Dictionary<string, int>());
        data["studente 3"]["momento 4"].Add("data 1", new Dictionary<string, int>());
        data["studente 3"]["momento 4"].Add("data 2", new Dictionary<string, int>());
        data["studente 3"]["momento 4"].Add("data 3", new Dictionary<string, int>());
        data["studente 3"]["momento 5"].Add("data 1", new Dictionary<string, int>());

        data["studente 1"]["momento 1"]["data 1"].Add("attivita 1", 1);
        data["studente 1"]["momento 1"]["data 2"].Add("attivita 1", 2);
        data["studente 1"]["momento 2"]["data 1"].Add("attivita 1", 4);
        data["studente 1"]["momento 2"]["data 1"].Add("attivita 2", 1);
        data["studente 1"]["momento 2"]["data 1"].Add("attivita 3", 2);
        data["studente 1"]["momento 3"]["data 1"].Add("attivita 1", 8);

        data["studente 2"]["momento 2"]["data 1"].Add("attivita 1", 3);
        data["studente 2"]["momento 2"]["data 1"].Add("attivita 2", 2);
        data["studente 2"]["momento 2"]["data 1"].Add("attivita 3", 7);
        data["studente 2"]["momento 2"]["data 1"].Add("attivita 4", 5);
        data["studente 2"]["momento 2"]["data 1"].Add("attivita 5", 3);
        data["studente 2"]["momento 2"]["data 1"].Add("attivita 6", 2);
        data["studente 2"]["momento 2"]["data 2"].Add("attivita 1", 8);

        data["studente 3"]["momento 1"]["data 1"].Add("attivita 1", 3);
        data["studente 3"]["momento 1"]["data 2"].Add("attivita 1", 3);
        data["studente 3"]["momento 2"]["data 1"].Add("attivita 1", 1);
        data["studente 3"]["momento 2"]["data 1"].Add("attivita 2", 3);
        data["studente 3"]["momento 2"]["data 1"].Add("attivita 3", 5);
        data["studente 3"]["momento 3"]["data 1"].Add("attivita 1", 2);
        data["studente 3"]["momento 4"]["data 1"].Add("attivita 1", 1);
        data["studente 3"]["momento 4"]["data 1"].Add("attivita 2", 3);
        data["studente 3"]["momento 4"]["data 2"].Add("attivita 1", 4);
        data["studente 3"]["momento 4"]["data 2"].Add("attivita 2", 3);
        data["studente 3"]["momento 4"]["data 2"].Add("attivita 3", 6);
        data["studente 3"]["momento 4"]["data 3"].Add("attivita 2", 3);
        data["studente 3"]["momento 5"]["data 1"].Add("attivita 1", 4);
        data["studente 3"]["momento 5"]["data 1"].Add("attivita 2", 5);
        
        PdfExporter exporter = new PdfExporter();
        exporter.ExportPdf(data);
        
    }
}
