using System.Collections.Generic;

namespace MDotNetCore.ApexChartApp
{
    public class HighChartsPieChartResponseModel
    {
        public string Title { get; set; }
        public List<HighChartsPieChartModel> Data { get; set; }
    }

    public class HighChartsPieChartModel
    {
        public HighChartsPieChartModel(string name, double y, bool sliced = false, bool selected = false)
        {
            this.name = name;
            this.y = y;
            this.sliced = sliced;
            this.selected = selected;
        }

        public string name { get; set; }
        public double y { get; set; }
        public bool sliced { get; set; }
        public bool selected { get; set; }
    }
}
