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

        [HttpGet]
        [ActionName("Generate")]
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

        [ActionName("Index")]
        public async Task<IActionResult> PaintingIndex(int pageNo = 1, int pageSize = 3)
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

        [ActionName("Edit")]
        public async Task<IActionResult> PaintingEdit(int id)
        {
            if (id == 0)
            {
                return Redirect("/Painting");
            }
            var item = await _context.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item == null)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Data not found!!";
                return Redirect("/Painting");
            }
            return View("PaintingEdit", item);
        }

        [ActionName("Update")]
        public async Task<IActionResult> PaintingUpdate(int id, PaintingModel paintingModel)
        {
            if (id == 0)
            {
                return Redirect("/Painting");
            }
            var item = await _context.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item == null)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Data not found!!";
                return Redirect("/Painting");
            }

            item.PaintingName = paintingModel.PaintingName;
            item.PaintingType = paintingModel.PaintingType;
            item.PaintingPrice = paintingModel.PaintingPrice;
            var result = await _context.SaveChangesAsync();
            var message = result > 0 ? "Updating successful " : "Updating failed";
            TempData["isSuccess"] = result > 0;
            TempData["message"] = message;
            return Redirect("/Painting");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> PaintingDelete(int id)
        {
            MessageResponseModel model = null;
            if (id == 0)
            {
                model = new MessageResponseModel(false, "Data Not Found!!");
                goto result;
            }
            var item = await _context.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item == null)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Data not found!!";
                return Redirect("/Painting");
            }
            _context.Painting.Remove(item);
            var result = await _context.SaveChangesAsync();
            var message = result > 0 ? "Deletion successful " : "Deletion failed";
            model = new MessageResponseModel(result > 0, message, "/Painting");
        result:
            return Json(model);
        }
    }
    public class MessageResponseModel
    {
        public MessageResponseModel(bool isSuccess, string message, string? pageUrl = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            PageUrl = pageUrl;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string PageUrl { get; set; }
    }
}
