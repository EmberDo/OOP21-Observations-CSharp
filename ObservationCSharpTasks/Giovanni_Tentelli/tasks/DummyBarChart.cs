namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Dummy version of javafx BarChart.
/// The chart content is populated by pie slices based oon data set opn the PieChart.
/// </summary>
public class DummyBarChart<TX, TY>
{
    public List<DummyXYChart.DummySeries<TX, TY>> DisplayedSeries { get; } = new();

    /// <summary>
    /// Construct a dummy BarChart.
    /// </summary>
    public DummyBarChart()
    {
    }
}