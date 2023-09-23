using MDotNetCore.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDotNetCore.MVCApp.Controllers
{
    public class BookAjaxController : Controller
    {
        private readonly AppDbContext _context;

        public BookAjaxController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ActionName("Generate")]
        public async Task<IActionResult> Create()
        {
            for (int i = 1; i <= 1000; i++)
            {
                await _context.Book.AddAsync(new Models.BookModel
                {
                    Name = i.ToString(),
                    Author = i.ToString(),
                    Category = i.ToString(),
                    Price = i
                });
                await _context.SaveChangesAsync();
            }
            return Redirect("/BookAjax");
        }

        [ActionName("Index")]
        public async Task<IActionResult> BookAjaxIndex()
        {
            var pageNo = 1;
            var pageSize = 10;
            //ViewBag.pageNo = 1;
            // ViewBag.pageSize = 10;
            var model = await GetBooksAsync(pageNo, pageSize);
            return View("BookAjaxIndex", model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> BookAjaxIndex(int pageNo = 1, int pageSize = 10)
        {
            var model = await GetBooksAsync(pageNo, pageSize);
            return Json(model);
        }

        private async Task<BookListResponseModel> GetBooksAsync(int pageNo = 1, int pageSize = 10)
        {
            BookListResponseModel? model = null;
            try
            {
                var query = _context.Book
                .OrderByDescending(x => x.Id);
                var lst = await query
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var pageCount = 0;
                var pageRowCount = await query.CountAsync();
                pageCount = pageRowCount / pageSize;
                if (pageRowCount % pageSize > 0)
                    pageCount++;

                model = new BookListResponseModel()
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = lst,
                    PageNo = pageNo,
                    PageSize = pageSize,
                    PageCount = pageCount,
                    PageUrl = "/BookAjax/Index"
                };
            }
            catch (Exception ex)
            {
                model = new BookListResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
            return model;
        }

        [HttpGet]
        [ActionName("Create")]
        public IActionResult BookAjaxCreate()
        {
            return View("BookAjaxCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BookAjaxSave(BookModel bookModel)
        {
            await _context.AddAsync(bookModel);
            var result = await _context.SaveChangesAsync();
            var message = result > 0 ? "Saving successful " : "Saving failed";
            TempData["isSuccess"] = result > 0;
            TempData["message"] = message;
            MessageResponseModel model = new MessageResponseModel(result > 0, message, "/BookAjax");
            return Json(model);
        }

        [ActionName("Edit")]
        public async Task<IActionResult> BookAjaxEdit(int id)
        {
            if (id == 0)
            {
                return Redirect("/BookAjax");
            }
            var item = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Data not found!!";
                return Redirect("/BookAjax");
            }
            return View("BookAjaxEdit", item);
        }

        [ActionName("Update")]
        public async Task<IActionResult> BookAjaxUpdate(int id, BookModel bookModel)
        {
            MessageResponseModel model = null;
            if (id == 0)
            {
                model = new MessageResponseModel(false, "Data Not Found!!");
                goto result;
            }
            var item = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Data not found!!";
                return Redirect("/BookAjax");
            }

            item.Name = bookModel.Name;
            item.Author = bookModel.Author;
            item.Category = bookModel.Category;
            item.Price = bookModel.Price;
            var result = await _context.SaveChangesAsync();
            var message = result > 0 ? "Updating successful " : "Updating failed";
            model = new MessageResponseModel(result > 0, message, "/BookAjax");
        result:
            return Json(model);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> BookAjaxDelete(int id)
        {
            MessageResponseModel model = null;
            if (id == 0)
            {
                model = new MessageResponseModel(false, "Data Not Found!!");
                goto result;
            }
            var item = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Data not found!!";
                return Redirect("/BookAjax");
            }
            _context.Book.Remove(item);
            var result = await _context.SaveChangesAsync();
            var message = result > 0 ? "Deletion successful " : "Deletion failed";
            model = new MessageResponseModel(result > 0, message, "/BookAjax");
        result:
            return Json(model);
        }

        [HttpGet]
        [ActionName("Pagination")]
        public async Task<IActionResult> BookAjaxPagination(int pageNo, int pageSize, int pageCount, string pageUrl)
        {
            PageSettingModel model = new PageSettingModel
            {
                PageNo = pageNo,
                PageSize = pageSize,
                PageCount = pageCount,
                PageUrl = pageUrl
            };
            return PartialView("_PaginationAjax", model);
        }
    }
}
