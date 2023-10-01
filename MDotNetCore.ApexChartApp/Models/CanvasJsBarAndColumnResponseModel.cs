namespace MDotNetCore.ApexChartApp.Models
{
    public class CanvasJsBarAndColumnResponseModel
    {
        public string Title { get; set; }
        public List<CanvasJsBarAndColumnModel> Data { get; set; }
    }
    public class CanvasJsBarAndColumnModel
    {
        public CanvasJsBarAndColumnModel(double y, string label)
        {
            this.y = y;
            this.label = label;
        }

        public double y { get; set; }
        public string label { get; set; }
    }
}
