using MDotNetCore.ApexChartApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDotNetCore.ApexChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult ColumnChart()
        {
			CanvasJsBarAndColumnResponseModel model = new CanvasJsBarAndColumnResponseModel()
			{
				Title = "Column Chart",
				Data = new List<CanvasJsBarAndColumnModel>
				{
					new CanvasJsBarAndColumnModel(300878, "Venezuela"),
					new CanvasJsBarAndColumnModel(266455, "Saudi"),
					new CanvasJsBarAndColumnModel(169709, "Canada"),
					new CanvasJsBarAndColumnModel(158400, "Iran"),
					new CanvasJsBarAndColumnModel(101500, "Kuwait"),
					new CanvasJsBarAndColumnModel(97800, "UAE"),
					new CanvasJsBarAndColumnModel(80000, "Russia")
				}
			};
			return View(model);
		}

		public IActionResult BarChart()
		{
			CanvasJsBarAndColumnResponseModel model = new CanvasJsBarAndColumnResponseModel()
			{
				Title = "Bar Chart",
				Data = new List<CanvasJsBarAndColumnModel>
				{
					new CanvasJsBarAndColumnModel(3, "Sweden"),
					new CanvasJsBarAndColumnModel(7, "Taiwan"),
					new CanvasJsBarAndColumnModel(5, "Russia"),
					new CanvasJsBarAndColumnModel(9, "Spain"),
					new CanvasJsBarAndColumnModel(7, "Brazil"),
					new CanvasJsBarAndColumnModel(7, "India"),
					new CanvasJsBarAndColumnModel(9, "Italy"),
					new CanvasJsBarAndColumnModel(8, "Australia"),
					new CanvasJsBarAndColumnModel(11, "Canada"),
					new CanvasJsBarAndColumnModel(15, "South Korea"),
					new CanvasJsBarAndColumnModel(12, "Netherlands"),
					new CanvasJsBarAndColumnModel(15, "Switzerland"),
					new CanvasJsBarAndColumnModel(25, "Britain"),
					new CanvasJsBarAndColumnModel(28, "Germany"),
					new CanvasJsBarAndColumnModel(29, "France"),
					new CanvasJsBarAndColumnModel(52, "Japan"),
					new CanvasJsBarAndColumnModel(103, "China"),
					new CanvasJsBarAndColumnModel(134, "US")
				}
			};
			return View(model);
		}
    }
}
