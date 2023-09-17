﻿using MDotNetCore.ConsoleApp.EFCoreExamples;
using MDotNetCore.ConsoleApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingModelController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PaintingModelController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IActionResult> GetPaintingAsync(int pageNo,int pageSize) 
        {
            //var lst = await _appDbContext.Painting.ToListAsync();
            //return Ok(lst);

            //Pagination
            var query = _appDbContext.Painting.OrderByDescending(x => x.PaintingId);
            var lst = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pageCount = 0;
            var pageRowCount= await query.CountAsync();
            pageCount = pageRowCount / pageSize;
            if (pageRowCount % pageSize > 0)
                pageCount++;
            return Ok(new { Paintings = lst, PageNo = pageNo, PageCount = pageCount ,PageSize = pageSize});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EditPaintingAsyn(int id) 
        {
            var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId== id);
            if (item is null)
            {
                return NotFound(new {Message = $"Painting Not Found with id {id}"});
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostPainting(PaintingModel painting) 
        {
            await _appDbContext.Painting.AddAsync(painting);
            var result=await _appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Painting Insertion Successful" : "Painting Insertion Unsuccessful";
            return Ok(new { Message = message, Data = painting });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPainting(int id,PaintingModel painting) 
        {
            var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item is null)
            {
                return NotFound(new { Message = $"Painting Not Found with id {id}" });
            } 
            item.PaintingName= painting.PaintingName;
            item.PaintingType= painting.PaintingType;
            item.PaintingPrice= painting.PaintingPrice;
            var result= await _appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Painting Updating Successful" : "Painting Updating Unsuccessful";
            item=await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            return Ok(new {Message =message,Data =item});
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPainting(int id,PaintingModel painting) 
        {
            var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item is null)
            {
                return NotFound(new { Message = $"Painting Not Found with id {id}" });
            }
            if(!string.IsNullOrWhiteSpace(painting.PaintingName)) 
            { 
                item.PaintingName = painting.PaintingName;
            }
            if(!string.IsNullOrWhiteSpace(painting.PaintingType)) 
            {
                item.PaintingType = painting.PaintingType;
            }
            if(painting.PaintingPrice > 0)
            {
                item.PaintingPrice = painting.PaintingPrice;
            }
            var result = await _appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Painting Updating Successful" : "Painting Updating Unsuccessful";
            item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
            return Ok(new { Message = message, Data = item });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePainting(int id) 
        {
            var item=await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId== id); 
            if (item is null)
            {
                return NotFound(new { Message = $"Painting Not Found with id {id}" });
            }
            _appDbContext.Painting.Remove(item);
            var result = await _appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Painting Deleting Successful" : "Painting Deleting Unsuccessful";
            return Ok(new { Message = message });
        }
    }
}