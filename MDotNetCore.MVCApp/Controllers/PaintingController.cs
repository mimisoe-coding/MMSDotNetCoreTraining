using MDotNetCore.MVCApp.Models;
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

        public async Task<IActionResult> Create()
        {
            for (int i = 1; i <= 1000; i++)
            {
                await _context.Painting.AddAsync(new Models.PaintingModel
                {
                    PaintingName = i.ToString(),
                    PaintingType = i.ToString(),
                    PaintingPrice = i,
                });
                await _context.SaveChangesAsync();
            }
            return Redirect("/Painting");
        }

        [ActionName("Index")]  //For browser end point
        public async Task<IActionResult> PaintingIndex(int pageNo = 1, int pageSize = 3)  //rename Index to Painting Index For Searching (For server Name)
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

            ViewBag.pageCount = pageCount;
            ViewBag.paintings = lst;
            ViewBag.pageNo = pageNo;
            ViewBag.pageSize = pageSize;
            return View("PaintingIndex");
        }

        [HttpGet]
        [ActionName("Create")]
        public IActionResult PaintingCreate()
        {
            return View("PaintingCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> PaintingSave(PaintingModel paintingModel)
        {
            await _context.AddAsync(paintingModel);
            var result = await _context.SaveChangesAsync();
            var message = result > 0 ? "Saving successful " : "Saving failed";
            TempData["isSuccess"] = result > 0;
            TempData["message"] = message;
            return Redirect("/Painting");

        }
    }
}
