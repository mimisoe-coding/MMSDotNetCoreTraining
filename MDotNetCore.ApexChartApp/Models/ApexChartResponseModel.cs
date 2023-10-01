namespace MDotNetCore.ApexChartApp.Models
{
	public class Data
	{
		public List<int> data { get; set; }
	}
	public class DataModel
	{
		public string name { get; set; }
		public List<int> data { get; set; }
	}
	public class ApexChartResponseModel
	{
		// public List<int> data { get; set; }
		public List<string> Labels { get; set; }
		public List<int> value { get; set; }
		public List<DataModel> Series { get; set; }
		public List<string> Categories { get; set; }
		public List<Data> Data { get; set; }
		public List<MixedChartResponseModel> MixedChart { get; set; }
	}

	public class MixedChartResponseModel
	{
		public string name { get; set; }
		public string type { get; set; }
		public List<int> data { get; set; }
	}

}
