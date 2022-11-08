namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Simple factory class which creates instances of PieCharts or BarCharts.
/// </summary>
public abstract class ChartFactory
{
    /// <summary>
    /// Create a pie chart.
    /// </summary>
    /// <param name="pcd">a list containing data for the chart.</param>
    /// <returns>a new PieChart.</returns>
    public static DummyPieChart CreatePieChart(List<DummyPieChart.DummyData> pcd)
    {
        return new DummyPieChart(pcd);
    }

    /// <summary>
    /// Create a new bar chart.
    /// </summary>
    /// <param name="dummySeries">a series containing data for the chart.</param>
    /// <returns>a new BarChart.</returns>
    public static DummyBarChart<string, double> CreateBarChart(DummyXYChart.DummySeries<string, double> dummySeries)
    {
        var chart = new DummyBarChart<string, double>();
        chart.DisplayedSeries.Add(dummySeries);
        return chart;
    }
}