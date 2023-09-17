using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDotNetCore.MVCApp.Controllers
{
    public class PaintingController : Controller
    {
        private readonly AppDbContext _context;

        public PaintingController(AppDbContext context)
        {
            _context = context;
        }

        [ActionName("Index")]  //For broswer name
        public async Task<IActionResult> PaintingIndex(int pageNo=1,int pageSize=3)  //rename Index to Painting Index For Searching (For server Name)
        {
            var query = _context.Painting.OrderByDescending(x => x.PaintingId);
            var lst = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
       
            var pageCount = 0;
            var pageRowCount = await query.CountAsync();
            pageCount = pageRowCount / pageSize;
            if (pageRowCount % pageSize > 0)
                pageCount++;

            ViewBag.pageCount=pageCount;
            ViewBag.paintings=lst;
            ViewBag.pageNo = pageNo;
            ViewBag.pageSize=pageSize;

            return View("PaintingIndex");
        }
    }
}
