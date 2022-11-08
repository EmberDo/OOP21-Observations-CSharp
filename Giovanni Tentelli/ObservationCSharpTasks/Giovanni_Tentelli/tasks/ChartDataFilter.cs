namespace ObservationCSharpTasks.Giovanni_Tentelli.tasks;

/// <summary>
/// Utility class used for filter data received and/or reorganize it in a compatible format for a PieChart or a BarChart.
/// </summary>
public static class ChartDataFilter
{
    private const string All = "Tutti";

    /// <summary>
    /// Return filtered data in an ObservableList containing PieChart.Data from raw data
    /// </summary>
    /// <param name="data">Map containing all or a single student and all their relative moments and observations.</param>
    /// <param name="student">Name of student to search content of.</param>
    /// <param name="moment">Name of moment to search content of or to search all moments available.</param>
    /// <returns> a List of PieChart.Data containing all the observations found and the relative number of observations.</returns>
    public static List<DummyPieChart.DummyData> GetPieData(
        Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>? data,
        string student,
        string moment)
    {
        var pieData = new List<DummyPieChart.DummyData>();

        if (!string.IsNullOrEmpty(student) && !string.IsNullOrEmpty(moment))
        {
            Dictionary<string, int> filteredData;
            if (moment.Equals(All))
            {
                filteredData = FilterDataByStudent(data, student);
            }
            else
            {
                filteredData = FilterDataByStudentAndMoment(data, student, moment);
            }

            foreach (var key in filteredData.Keys)
            {
                pieData.Add(new DummyPieChart.DummyData(key, filteredData[key]));
            }
        }

        return pieData;
    }

    /// <summary>
    /// Return filtered data in XYChart.Series from raw dataReturn filtered data in XYChart.Series from raw data
    /// </summary>
    /// <param name="data">Map containing all or a single student and all their relative moments and observations.</param>
    /// <param name="student">Name of student to search content of.</param>
    /// <param name="moment">Name of moment to search content of or to search all moments available.</param>
    /// <returns>an XYChart.Series containing all the observations found and the relative number of observations.</returns>
    public static DummyXYChart.DummySeries<string, int> GetBarData(
        Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>? data,
        String student,
        String moment)
    {
        var barData = new DummyXYChart.DummySeries<string, int>();

        if (!string.IsNullOrEmpty(student) && !string.IsNullOrEmpty(moment))
        {
            Dictionary<string, int> filteredData;
            if (moment.Equals(All))
            {
                filteredData = FilterDataByStudent(data, student);
            }
            else
            {
                filteredData = FilterDataByStudentAndMoment(data, student, moment);
            }

            foreach (string key in filteredData.Keys)
            {
                barData.DisplayedData.Add(new DummyXYChart.DummyData<string, int>(key, filteredData[key]));
            }
        }

        return barData;
    }

    /// <summary>
    /// Search all the observations and their counts of a specific student
    /// </summary>
    /// <param name="data">Map containing all or a single student and all their relative moments and observations.</param>
    /// <param name="studentFilter">Student to search content of.</param>
    /// <returns>A Dictionary containing all observations found and their counts.</returns>
    public static Dictionary<string, int> FilterDataByStudent(
        Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>? data,
        String studentFilter)
    {
        if (data != null && data.TryGetValue(data.Keys.First(), out _))
        {
            return new Dictionary<string, int>();
        }

        Dictionary<string, int> observations = new Dictionary<string, int>();

        var studentData = data[studentFilter];
        foreach (string moment in data[studentFilter].Keys)
        {
            var momentData = studentData[moment];
            foreach (string date in studentData.Keys)
            {
                var dateData = momentData[date];
                foreach (string observation in dateData.Keys)
                {
                    if (observations.ContainsKey(observation))
                    {
                        observations.Add(observation, dateData[observation] += observations[observation]);
                    }
                    else
                    {
                        observations.Add(observation, dateData[observation]);
                    }
                }
            }
        }

        return observations;
    }

    /// <summary>
    /// Search all the observations and their counts of a specific student
    /// </summary>
    /// <param name="data">Map containing all or a single student and all their relative moments and observations.</param>
    /// <param name="studentFilter">Student to search content of.</param>
    /// <param name="momentFilter">Moment to search content of.</param>
    /// <returns>A map of all observations found and their counts.</returns>
    public static Dictionary<string, int> FilterDataByStudentAndMoment(
        Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>? data,
        String studentFilter,
        String momentFilter)
    {
        if (data != null && data.TryGetValue(data.Keys.First(), out _))
        {
            return new Dictionary<string, int>();
        }

        Dictionary<string, int> observations = new Dictionary<string, int>();

        var studentData = data[studentFilter];
        var momentData = studentData[momentFilter];
        foreach (string date in momentData.Keys)
        {
            var dateData = momentData[date];
            foreach (string observation in dateData.Keys)
            {
                if (observations.ContainsKey(observation))
                {
                    observations.Add(observation, dateData[observation] += observations[observation]);
                }
                else
                {
                    observations.Add(observation, dateData[observation]);
                }
            }
        }

        return observations;
    }
}