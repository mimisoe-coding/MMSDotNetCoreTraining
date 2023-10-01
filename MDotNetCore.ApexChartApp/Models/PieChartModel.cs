using System.Collections.Generic;

namespace MDotNetCore.ApexChartApp.Models
{
    public class PieChartResponseModel
    {
        public List<string> Labels { get; set; }
        public List<int> Series { get; set; }
    }
}
