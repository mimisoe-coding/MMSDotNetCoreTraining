namespace MDotNetCore.ApexChartApp.Models
{
    public class PercentageAreaModel
    {
        public PercentageAreaModel(string name, List<double> data) { 
            this.name = name;
            this.data = data;
        }
        public string name { get; set; }
        public List<double> data { get; set; }
    }
    public class HighChartsPercentageAreaResponseModel
    {
        public string title {  get; set; }
        public List<PercentageAreaModel> series { get; set; }
    }

}
