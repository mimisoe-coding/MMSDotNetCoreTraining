using MDotNetCore.ApexChartApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDotNetCore.ApexChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            HighChartsPieChartResponseModel model = new HighChartsPieChartResponseModel
            {
                Title = "Browser market shares in May, 2020",
                Data = new List<HighChartsPieChartModel>
                {
                    new HighChartsPieChartModel("Chrome", 70.67, true, true),
                    new HighChartsPieChartModel("Edge", 14.77)
                }
            };
            return View(model);
        }

        public IActionResult PercentageArea()
        {
            HighChartsPercentageAreaResponseModel model = new HighChartsPercentageAreaResponseModel
            {
                title = "Countries/regions with highest Gt CO<sub>2</sub>-emissions",
                series = new List<PercentageAreaModel> { new PercentageAreaModel("China",new List<double> { 2.5, 2.6, 2.7, 2.9, 3.1, 3.4, 3.5, 3.5, 3.4, 3.4, 3.4, 3.5, 3.9, 4.5, 5.2, 5.9, 6.5, 7, 7.5, 7.9, 8.6, 9.5, 9.8, 10, 10, 9.8, 9.7, 9.9, 10.3, 10.5, 10.7, 10.9 }),
                                                         new PercentageAreaModel("USA", new List<double>  { 5.1, 5.1, 5.2, 5.3, 5.4, 5.4, 5.6, 5.7, 5.7, 5.8, 6, 5.9, 5.9, 6, 6.1, 6.1, 6.1, 6.1, 5.9, 5.5, 5.7, 5.5, 5.3, 5.5, 5.5, 5.4, 5.2, 5.2, 5.4, 5.3, 4.7, 5 }),
                                                         new PercentageAreaModel("EU" , new List<double> { 3.9, 3.8, 3.7, 3.6, 3.6, 3.6, 3.7, 3.7, 3.6, 3.6, 3.6, 3.7,3.7, 3.7, 3.8, 3.7, 3.7, 3.7, 3.6, 3.3, 3.4, 3.3, 3.3, 3.2, 3, 3.1, 3.1, 3.1, 3, 2.9, 2.6, 2.7 }),
                                                         new PercentageAreaModel("India" , new List<double> {0.6, 0.6, 0.7, 0.7, 0.7, 0.8, 0.8, 0.9, 0.9, 1, 1, 1, 1, 1.1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 2, 2, 2.2, 2.3, 2.4, 2.4, 2.6, 2.6, 2.4, 2.7})
                }
            };
            return View(model);
        }

        public IActionResult ThreeDBubbleChart()
        {
            ThreeDBubbleChartResponseModel model = new ThreeDBubbleChartResponseModel
            {
                title = "Highcharts bubbles with radial gradient fill",
                dataOne = new List<List<int>> { new List<int>{ 9, 81, 63 },
                                                new List<int>{98, 5, 89},
                                                new List<int>{51, 50, 73},
                                                new List<int>{41, 22, 14},
                                                new List<int>{58, 24, 20},
                                                new List<int>{78, 37, 34},
                                                new List<int>{55, 56, 53},
                                                new List<int>{18, 45, 70},
                                                new List<int>{42, 44, 28},
                                                new List<int>{3, 52, 59},
                                                new List<int>{31, 18, 97},
                                                new List<int>{79, 91, 63},
                                                new List<int>{93, 23, 23 },
                                                new List<int>{44, 83, 22} },

                dataTwo = new List<List<int>> { new List<int>{ 42, 38, 20 },
                                                 new List<int>{6, 18, 1},
                                                 new List<int>{1, 93, 55},
                                                 new List<int>{57, 2, 90},
                                                 new List<int>{80, 76, 22},
                                                 new List<int>{11, 74, 96},
                                                 new List<int>{88, 56, 10},
                                                 new List<int>{30, 47, 49},
                                                 new List<int>{57, 62, 98},
                                                 new List<int>{4, 16, 16},
                                                 new List<int>{46, 10, 11},
                                                 new List<int>{22, 87, 89},
                                                 new List<int>{57, 91, 82 },
                                                 new List<int>{45, 15, 98} }

            };
            return View(model);
        }

        public  IActionResult SplineChart()
        {
            return View(model);
        }
    }
}
