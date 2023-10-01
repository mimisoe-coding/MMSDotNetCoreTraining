using System.Xml.Linq;

namespace MDotNetCore.ApexChartApp.Models
{
    public class PyramidChartResponseModel
    {
        public string title;
        public List<SeriesData> series { get; set; }
    }
    public class SeriesData
    {
        public string name { get; set; }
        public List<object[]> data { get; set; }
    }
}
