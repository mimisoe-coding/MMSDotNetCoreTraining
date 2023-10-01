using MDotNetCore.ApexChartApp.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace MDotNetCore.ApexChartApp.Controllers
{
    public class ApexChartController : Controller
    {
       // public IActionResult PieChart()
        //{
        //    PieChartResponseModel model = new PieChartResponseModel();
        //    model.Series = new List<int> { 44, 55, 13, 43, 22 };
        //    model.Labels = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E" };
        //    ViewBag.pieChart = model;
        //    return View();
        //}
        //public IActionResult ColumnChart()
        //{
        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model.Series = new List<DataModel> { new DataModel
        //{
        //    name = "Net Profit",
        //    data = new List<int> { 44, 55, 57, 56, 61, 58, 63, 60, 66 }
        //},
        //new DataModel
        //{
        //    name = "Revenue",
        //    data = new List<int> { 76, 85, 101, 98, 87, 105, 91, 114, 94 }
        //},
        //new DataModel
        //{
        //    name = "Free Cash Flow",
        //    data = new List<int> { 35, 41, 36, 26, 45, 48, 52, 53, 41 }
        //}};
        //    model.Categories = new List<string> { "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct" };
        //    ViewBag.columnChart = model;
        //    return View();
        //}

        //public IActionResult BarChart()
        //{
        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model.Data= new List<Data> { new Data
        //    {
        //    data = new List<int> { 400, 430, 448, 470, 540, 580, 690, 1100, 1200, 1380 }
        //    }};
        //    model.Categories = new List<string> {
        //        "South Korea", "Canada", "United Kingdom", "Netherlands", "Italy", "France", "Japan",
        //            "United States", "China", "Germany"
        //         };
        //    ViewBag.barChart = model;
        //    return View();
        //}

        //public IActionResult AreaChart()
        //{
        //    return View();
        //}

        //public IActionResult FunnelChart()
        //{
        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model.Series = new List<DataModel> { new DataModel
        //{
        //    name="Funnel Series",
        //    data=new List<int> {1380, 1100, 990, 880, 740, 548, 330, 200 }

        //} };
        //    model.Categories = new List<string> {   
        //    "Sourced",
        //    "Screened",
        //    "Assessed",
        //    "HR Interview",
        //    "Technical",
        //    "Verify",
        //    "Offered",
        //    "Hired",
        //   };
        //    ViewBag.funnelChart = model;
        //    return View();
        //}

        //public IActionResult LineChart()
        //{

        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model.Series = new List<DataModel> { new DataModel
        //{
        //    name= "Desktops",
        //    data=new List<int> {10, 41, 35, 51, 49, 62, 69, 91, 148 }

        //} };
        //    model.Categories = new List<string> {
        //    "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep"
        //   };
        //    ViewBag.lineChart = model;
        //    return View();
        //}

        //public IActionResult MixedChart()
        //{
        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model.MixedChart = new List<MixedChartResponseModel> { new MixedChartResponseModel
        //{
        //    name= "Website Blog",
        //    type= "column",
        //    data=new List<int> {440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160 }
        //},
        //new MixedChartResponseModel
        //{
        //    name= "Social Media",
        //  type="line",
        //  data=new List<int> {23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16 }
        //}};
        //    model.Labels = new List<string> { "01 Jan 2001", "02 Jan 2001", "03 Jan 2001", "04 Jan 2001", "05 Jan 2001", "06 Jan 2001", "07 Jan 2001", "08 Jan 2001", "09 Jan 2001", "10 Jan 2001", "11 Jan 2001", "12 Jan 2001" };
        //    ViewBag.mixedChart = model;
        //    return View();
        //}

        //public IActionResult PolarArea()
        //{
        //    ApexChartResponseModel model=new ApexChartResponseModel();
        //    model.value = new List<int> { 14, 23, 21, 17, 15, 10, 12, 17, 21 };
        //    ViewBag.polarArea=model;
        //    return View();
        //}

        //public IActionResult Rador()
        //{
        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model.Series = new List<DataModel> { new DataModel
        //{
        //    name= "Series 1",
        //  data=new List<int> {20, 100, 40, 30, 50, 80, 33 }

        //} };
        //    model.Categories = new List<string> {
        //    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        //   };
        //    ViewBag.rador = model;
        //    return View();
        //}

        public IActionResult RangeArea()
        {
            RangeAreaAndBoxPlotResponseModel model = new RangeAreaAndBoxPlotResponseModel();
            model.Series = new List<DataSeries>  {
                new DataSeries
                {
                    name="New York Temperature",
                    data=new List<DataPoint> { new DataPoint{ x="Jan", y=new List<double> { -2, 4 } },
                                               new DataPoint{ x="Feb", y=new List<double> { -1, 6 } },
                                               new DataPoint{ x="Mar", y=new List<double> { 3, 10 } },
                                               new DataPoint{ x="Apr", y=new List<double> { 8, 16 } },
                                               new DataPoint{ x="May", y=new List<double> { 13, 22 } },
                                               new DataPoint{ x="Jun", y=new List<double> { 18, 26 } },
                                               new DataPoint{ x="Jul", y=new List<double> { 21, 29} } ,
                                               new DataPoint{ x="Aug", y=new List<double> { 21, 28 } },
                                               new DataPoint{ x="Sep", y=new List<double> { 17, 24 } },
                                               new DataPoint{ x="Oct", y=new List<double> { 11, 18 } } ,
                                               new DataPoint{ x="Nov", y=new List<double> { 6, 12  } },
                                               new DataPoint{ x="Dec", y=new List<double> { 1, 7} }
                    }
                }
            };
            ViewBag.rangeArea = model;
            return View();
        }

        //public IActionResult MiscChart()
        //{
        //    ApexChartResponseModel model = new ApexChartResponseModel();
        //    model= new List<DataModel>{ new DataModel { name= "Series Column", type= "column", data=new List<int> {23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30 }},
        //                                           new DataModel { name= "Series Area",   type= "area", data=new List<int> {44, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43} },
        //                                           new DataModel { name= "Series Line", type= "line", data=new List<int> {30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39 }} };

        //    model.Labels = new List<string> { "01/01/2003", "02/01/2003", "03/01/2003", "04/01/2003", "05/01/2003", "06/01/2003", "07/01/2003", "08/01/2003", "09/01/2003", "10/01/2003", "11/01/2003" };
        //    ViewBag.miscChart = model;
        //    return View();
        //}

        public IActionResult BoxPlot()
        {
            RangeAreaAndBoxPlotResponseModel model=new RangeAreaAndBoxPlotResponseModel();
            model.dataPoint = new List<DataPoint>
            {
                                               new DataPoint{ x="Jan 2015", y=new List<double> { 54, 66, 69, 75, 88 } } ,
                                               new DataPoint{ x="Jan 2016", y=new List<double> { 43, 65, 69, 76, 81 } },
                                               new DataPoint{ x="Jan 2017", y=new List<double> { 31, 39, 45, 51, 59 } },
                                               new DataPoint{ x="Jan 2018", y=new List<double> { 39, 46, 55, 65, 71 } },
                                               new DataPoint{ x="Jan 2019", y=new List<double> { 29, 31, 35, 39, 44 } } ,
                                               new DataPoint{ x="Jan 2020", y=new List<double> { 41, 49, 58, 61, 67 } },
                                               new DataPoint{ x="Jan 2021", y=new List<double> { 54, 59, 66, 71, 88 } }
            };
            ViewBag.data = model;
            return View();
        }

    
    }
}
