using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservationCSharpTasks.Giovanni_Tentelli.tasks;

namespace TestProject1.Giovanni_Tentelli_Tests;

[TestClass]
public class TestCharts
{
    private readonly Dictionary<string, double> _dictionary = new();
    private const int Elements = 1000;
    private Random _rnd = new();

    [TestMethod]
    public void TestPieCHartData()
    {
        //Arrange
        for (int i = 0; i < Elements; i++)
        {
            _dictionary.Add("activity " + i, _rnd.Next());
        }

        //Act
        List<DummyPieChart.DummyData> list = new List<DummyPieChart.DummyData>();
        foreach (var pair in _dictionary)
        {
            list.Add(new DummyPieChart.DummyData(pair.Key, pair.Value));
        }

        //Assert
        foreach (var data in list)
        {
            Assert.IsTrue(data.Value.Equals(_dictionary[data.Name]));
        }
    }

    [TestMethod]
    public void TestPieChart()
    {
        //Arrange
        for (int i = 0; i < Elements; i++)
        {
            _dictionary.Add("activity " + i, _rnd.Next());
        }

        //Act
        List<DummyPieChart.DummyData> list = new List<DummyPieChart.DummyData>();
        foreach (var pair in _dictionary)
        {
            list.Add(new DummyPieChart.DummyData(pair.Key, pair.Value));
        }

        DummyPieChart pieChart = new DummyPieChart(list);

        //Assert
        List<DummyPieChart.DummyData> dataFromPieChart = pieChart.Data;
        foreach (var data in dataFromPieChart)
        {
            Assert.IsTrue(data.Value.Equals(_dictionary[data.Name]));
        }
    }

    [TestMethod]
    public void TestXYChartSeries()
    {
        //Arrange
        for (int i = 0; i < Elements; i++)
        {
            _dictionary.Add("activity " + i, _rnd.Next());
        }

        //Act
        List<DummyXYChart.DummyData<string, double>> list = new();
        foreach (var pair in _dictionary)
        {
            list.Add(new DummyXYChart.DummyData<string, double>(pair.Key, pair.Value));
        }

        //Assert
        foreach (var data in list)
        {
            Assert.IsTrue(data.YValue.Equals(_dictionary[data.XValue]));
        }
    }

    [TestMethod]
    public void TestBarCHart()
    {
        //Arrange
        for (int i = 0; i < Elements; i++)
        {
            _dictionary.Add("activity " + i, _rnd.Next());
        }

        //Act
        DummyXYChart.DummySeries<string, double> list = new();
        foreach (var pair in _dictionary)
        {
            list.DisplayedData.Add(new DummyXYChart.DummyData<string, double>(pair.Key, _dictionary[pair.Key]));
        }

        DummyBarChart<string, double> chart = new();
        chart.DisplayedSeries.Add(list);

        //Assert
        foreach (var series in chart.DisplayedSeries)
        {
            foreach (var data in series.DisplayedData)
            {
                Assert.IsTrue(data.YValue.Equals(_dictionary[data.XValue]));
            }
        }
    }

    [TestMethod]
    public void TestChartFactory()
    {
        //Arrange
        for (int i = 0; i < Elements; i++)
        {
            _dictionary.Add("activity " + i, _rnd.Next());
        }

        //Act
        List<DummyPieChart.DummyData> pieChartData = new List<DummyPieChart.DummyData>();
        foreach (var pair in _dictionary)
        {
            pieChartData.Add(new DummyPieChart.DummyData(pair.Key, pair.Value));
        }

        DummyPieChart pieChart = ChartFactory.CreatePieChart(pieChartData);

        DummyXYChart.DummySeries<string, double> dummySeriesData = new();
        foreach (var pair in _dictionary)
        {
            dummySeriesData.DisplayedData.Add(
                new DummyXYChart.DummyData<string, double>(pair.Key, _dictionary[pair.Key]));
        }

        DummyBarChart<string, double> chart = ChartFactory.CreateBarChart(dummySeriesData);

        //Assert
        List<DummyPieChart.DummyData> dataFromPieChart = pieChart.Data;
        foreach (var data in dataFromPieChart)
        {
            Assert.IsTrue(data.Value.Equals(_dictionary[data.Name]));
        }

        foreach (var series in chart.DisplayedSeries)
        {
            foreach (var data in series.DisplayedData)
            {
                Assert.IsTrue(data.YValue.Equals(_dictionary[data.XValue]));
            }
        }
    }

    [TestMethod]
    public void TestChartDataFilter()
    {
        //Arrange
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

        var student1 = new Dictionary<string, int>
        {
            {"activity 1", 15},
            {"activity 2", 1},
            {"activity 3", 2}
        };

        var student2 = new Dictionary<string, int>
        {
            {"activity 1", 14},
            {"activity 2", 2},
            {"activity 3", 7},
            {"activity 4", 5},
            {"activity 5", 3},
            {"activity 6", 2}
        };

        var student3 = new Dictionary<string, int>
        {
            {"activity 1", 18},
            {"activity 2", 17},
            {"activity 3", 11}
        };

        var student1Moment1 = new Dictionary<string, int>
        {
            {"activity 1", 6}
        };

        var student1Moment2 = new Dictionary<string, int>
        {
            {"activity 1", 4},
            {"activity 2", 1},
            {"activity 3", 2}
        };

        var student1Moment3 = new Dictionary<string, int>
        {
            {"activity 1", 8}
        };

        var student2Moment1 = new Dictionary<string, int>
        {
            {"activity 1", 3}
        };

        var student2Moment2 = new Dictionary<string, int>
        {
            {"activity 1", 11},
            {"activity 2", 2},
            {"activity 3", 7},
            {"activity 4", 5},
            {"activity 5", 3},
            {"activity 6", 2},
        };

        var student3Moment1 = new Dictionary<string, int>
        {
            {"activity 1", 6}
        };

        var student3Moment2 = new Dictionary<string, int>
        {
            {"activity 1", 1},
            {"activity 2", 3},
            {"activity 3", 5}
        };

        var student3Moment3 = new Dictionary<string, int>
        {
            {"activity 1", 2}
        };

        var student3Moment4 = new Dictionary<string, int>
        {
            {"activity 1", 5},
            {"activity 2", 9},
            {"activity 3", 6}
        };

        var student3Moment5 = new Dictionary<string, int>
        {
            {"activity 1", 4},
            {"activity 2", 5}
        };

        foreach (var student in data.Keys)
        {
            Debug.WriteLine("\n" + student);
            foreach (var moment in data[student].Keys)
            {
                Debug.WriteLine("\t" + moment);
                foreach (var date in data[student][moment].Keys)
                {
                    Debug.WriteLine("\t\t" + date);
                    foreach (var activity in data[student][moment][date].Keys)
                    {
                        Debug.WriteLine("\t\t\t" + activity + ": " + data[student][moment][date][activity]);
                    }
                }
            }
        }

        //Act & assert filter by student
        var filteredData = ChartDataFilter.FilterDataByStudent(data, "studente 1");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student1[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudent(data, "studente 2");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student2[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudent(data, "studente 3");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student3[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudent(data, "studente 4");
        Assert.IsTrue(filteredData.Count == 0);


        //Act & assert filter by student and moment
        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 1", "moment 1");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student1Moment1[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 1", "moment 2");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student1Moment2[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 1", "moment 3");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student1Moment3[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 2", "moment 1");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student2Moment1[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 2", "moment 2");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student2Moment2[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 3", "moment 1");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student3Moment1[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 3", "moment 2");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student3Moment2[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 3", "moment 3");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student3Moment3[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 3", "moment 4");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student3Moment4[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 3", "moment 4");
        foreach (var pair in filteredData)
        {
            Assert.IsTrue(pair.Value.Equals(student3Moment5[pair.Key]));
        }

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 4", "moment 1");
        Assert.IsTrue(filteredData.Count == 0);

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 4", "moment 2");
        Assert.IsTrue(filteredData.Count == 0);

        filteredData = ChartDataFilter.FilterDataByStudentAndMoment(data, "studente 4", "moment 3");
        Assert.IsTrue(filteredData.Count == 0);
    }
}