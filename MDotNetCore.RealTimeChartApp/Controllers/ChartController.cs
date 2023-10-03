using MDotNetCore.RealTimeChartApp.Models;
using MDotNetCore.RealTimeChartApp.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MDotNetCore.RealTimeChartApp.Controllers
{
    public class ChartController : Controller
    {
        private readonly AppDbContext _db;
        private IHubContext<NotificationHub> _hubContext;

        public ChartController(AppDbContext db, IHubContext<NotificationHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Save(PieChartRequestModel data)
        {
            PieChartModel item = new PieChartModel()
            {
                PieChartLabel = data.Label,
                PieChartSeries = data.Series,
            };
            await _db.AddAsync(item);
            var result = await _db.SaveChangesAsync();
            var message = result > 0 ? "Saving Successful." : "Saving Failed.";
            var isSuccess = result > 0;

            var lst = await _db.pieChart.ToListAsync();
            PieChartResponseModel model = new PieChartResponseModel()
            {
                Labels = lst.Select(x => x.PieChartLabel).ToArray(),
                Series = lst.Select(x => x.PieChartSeries).ToArray(),
            };
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", model);

            return Json(new { Message = message, IsSuccess = isSuccess });
        }
    }
}
