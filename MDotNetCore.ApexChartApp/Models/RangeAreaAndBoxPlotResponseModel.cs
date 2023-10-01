namespace MDotNetCore.ApexChartApp.Models
{
	public class RangeAreaAndBoxPlotResponseModel
	{
		public List<DataSeries> Series { get; set; }
		public List<DataPoint> dataPoint { get; set; }
	}
	public class DataSeries
	{
		public string name { get; set; }
		public List<DataPoint> data { get; set; }
	}
	public class DataPoint
	{
		public string x { get; set; }
		public List<double> y { get; set; }
	}
}
