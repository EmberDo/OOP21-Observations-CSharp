namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Dummy version of javafx PieChart.
/// The chart content is populated by pie slices based oon data set opn the PieChart.
/// </summary>
public class DummyPieChart
{
    public List<DummyData> Data { get; }

    /// <summary>
    /// Construct a new dummy PieChart, using a list of its nested class to store data.
    /// </summary>
    /// <param name="data">a list containing DummyData.</param>
    public DummyPieChart(List<DummyData> data)
    {
        Data = new List<DummyData>();
        SetData(data);
    }
    
    private void SetData(List<DummyData> values)
    {
        values.ForEach(v => Data.Add(v));
    }

    /// <summary>
    /// Dummy version of javafx PieChart.Data.
    /// PieChart Data Item, represents one slice in the PieChart.
    /// </summary>
    public class DummyData
    {
        public string Name { get; }
        public double Value { get; }

        public DummyData(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}