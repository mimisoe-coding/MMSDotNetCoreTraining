using MDotNetCore.ConsoleApp.Models;
using MDotNetCore.RestApi.EFDBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDontNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPainting()
        {
            AppDbContext appDbContext = new AppDbContext();
            var lst=await appDbContext.paintingModel.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPainting(int id)
        {
            AppDbContext appDbContext = new AppDbContext();
            var item =await appDbContext.paintingModel.FirstOrDefaultAsync(x=>x.PaintingId==id);  
            if(item is null)
            {
                return NotFound(new { Message = $"Painting Data Not Found With Id {id}" });
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddPainting(PaintingModel painting)
        {
            AppDbContext appDbContext = new AppDbContext();
            await appDbContext.paintingModel.AddAsync(painting);
            var result = await appDbContext.SaveChangesAsync();

            string message = result > 0 ? "Creating painting data successful" : "Creating Painting Data Failed";
            return Ok(new {Message=message,Data=painting});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePainting(int id,PaintingModel model)
        {   
            AppDbContext appDbContext = new AppDbContext(); 
            var item = await appDbContext.paintingModel.FirstOrDefaultAsync(x=>x.PaintingId == id);
            if(item is null)
            {
                return NotFound(new { Message = $"Painting Data Not Found With Id {id}" });
            }
            item.PaintingName = model.PaintingName;
            item.PaintingType = model.PaintingType;
            item.PaintingPrice = model.PaintingPrice;
            var result=await appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Updating painting data successful " : "Updating painting data failed";

            var data = await appDbContext.paintingModel.FirstOrDefaultAsync(x=>x.PaintingId == id); 
            return Ok(new {Message = message, Data=data});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePainting(int id)
        {
            AppDbContext appDbContext = new AppDbContext();
            var item = await appDbContext.paintingModel.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item is null)
            {
                return NotFound(new { Message = $"Painting Data Not Found With Id {id}" });
            }
            appDbContext.paintingModel.Remove(item);
            var result = await appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Updating painting data successful " : "Updating painting data failed";
            return Ok(new { Message = message });
        }
    }
}
