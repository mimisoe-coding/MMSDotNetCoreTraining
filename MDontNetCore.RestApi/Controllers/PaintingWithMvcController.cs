using MDotNetCore.RestApi.EFDBContext;
using MDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingWithMvcController : Controller
    {
        private readonly AppDbContext _context;
        public PaintingWithMvcController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> PaintingIndexAsync()
        {
            var pageNo = 1;
            var pageSize = 10;
            var model = await GetPaintingsAsync(pageNo, pageSize);
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IActionResult> PaintingIndexAsync(int pageNo = 1, int pageSize = 10)
        {
            var model = await GetPaintingsAsync(pageNo, pageSize);
            return Ok(model);
        }

        private async Task<PaintingListResponseModel> GetPaintingsAsync(int pageNo = 1, int pageSize = 10)
        {
            PaintingListResponseModel model = null;
            try
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

                model = new PaintingListResponseModel()
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = lst,
                    PageNo = pageNo,
                    PageSize = pageSize,
                    PageCount = pageCount,
                    PageUrl = "/BlogAjax/Index"
                };
            }
            catch (Exception ex)
            {
                model = new PaintingListResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
            return model;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EditPaintingAsync(int id)
        {
            var model = new PaintingResponseModel();

            if (id == 0)
            {
                model.IsSuccess = false;
                model.Message = "No Data Found.";
                return BadRequest(model);
            }

            var item = await _context.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item == null)
            {
                model.IsSuccess = false;
                model.Message = "No Data Found.";
                return NotFound(model);
            }

            model.IsSuccess = true;
            model.Message = "Success";
            model.Data = item;

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPaintingAsync(PaintingModel painting)
        {
            var model = new PaintingResponseModel();
            try
            {
                await _context.Painting.AddAsync(painting);
                var result = await _context.SaveChangesAsync();
                var message = result > 0 ? "Saving Successful." : "Saving Failed.";

                model.IsSuccess = result > 0;
                model.Message = message;
                model.Data = painting;

                return Ok(model);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Data cannot be saved!";
                model.Data = painting;
                return BadRequest(model);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogAsync(int id, PaintingModel painting)
        {
            var model = new PaintingResponseModel();
            try
            {
                var item = await _context.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
                if (item is null)
                {
                    model.IsSuccess = false;
                    model.Message = "Data Not Found";
                    return BadRequest(model);
                }
                item.PaintingName = painting.PaintingName;
                item.PaintingType = painting.PaintingType;
                item.PaintingPrice = painting.PaintingPrice;

                var result = await _context.SaveChangesAsync();
                string message = result > 0 ? "Updating Successful!" : "Updating Failed.";

                model.IsSuccess = result > 0;
                model.Message = message;
                model.Data = item;
                return Ok(model);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Data Updating Failed!";

                return BadRequest(model);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogAsync(int id)
        {
            var model = new PaintingResponseModel();
            try
            {
                if (id == 0)
                {
                    model.IsSuccess = false;
                    model.Message = "Data not found";
                    return BadRequest(model);
                }

                var item = await _context.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
                if (item is null)
                {
                    model.IsSuccess = false;
                    model.Message = "Data not found";
                    return NotFound(model);
                }
                _context.Painting.Remove(item);
                var result = await _context.SaveChangesAsync();
                var message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

                model.IsSuccess = result > 0;
                model.Message = message;
                return Ok(model);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Not found";
                return BadRequest(model);
            }
        }
    }
}
