namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Dummy version of javafx XYChart.
/// </summary>
public abstract class DummyXYChart
{
    public class DummyData<TX, TY>
    {
        public TX XValue { set; get; }
        public TY YValue { set; get; }

        public DummyData(TX xValue, TY yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }
    }

    public class DummySeries<TX, TY>
    {
        public List<DummyData<TX, TY>> DisplayedData { get; } = new();
    }
}