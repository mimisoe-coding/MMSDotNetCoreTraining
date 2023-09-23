using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMSDotNetCor.MinimalAPI;
using MMSDotNetCore.MinimalAPI.Features.Painting;
using MMSDotNetCore.MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSDBConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//#region Painting
//app.MapGet("/api/paintingModel/{pageNo}/{pageSize}", async ([FromServices] AppDbContext _appDbContext, int pageNo, int pageSize) =>
//{
//    var query = _appDbContext.Painting.OrderByDescending(x => x.PaintingId);
//    var lst = await query
//        .Skip((pageNo - 1) * pageSize)
//        .Take(pageSize)
//        .ToListAsync();

//    var pageCount = 0;
//    var pageRowCount = await query.CountAsync();
//    pageCount = pageRowCount / pageSize;
//    if (pageRowCount % pageSize > 0)
//        pageCount++;
//    return Results.Ok(new { Paintings = lst, PageNo = pageNo, PageCount = pageCount, PageSize = pageSize });
//})
//.WithName("GetPainting")
//.WithOpenApi();

//app.MapGet("/api/paintingModel/{id}", async ([FromServices] AppDbContext _appDbContext, int id) =>
//{
//    var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
//    if (item is null)
//    {
//        return Results.NotFound(new { Message = $"Painting Not Found with id {id}" });
//    }
//    return Results.Ok(item);
//})
//.WithName("EditPainting")
//.WithOpenApi();

//app.MapPost("/api/paintingModel", async ([FromServices] AppDbContext _appDbContext, PaintingModel painting) =>
//{
//    await _appDbContext.Painting.AddAsync(painting);
//    var result = await _appDbContext.SaveChangesAsync();
//    string message = result > 0 ? "Painting Insertion Successful" : "Painting Insertion Unsuccessful";
//    return Results.Ok(new { Message = message, Data = painting });
//})
//.WithName("PostPainting")
//.WithOpenApi();

//app.MapPut("/api/paintingModel/{id}", async ([FromServices] AppDbContext _appDbContext, int id, PaintingModel painting) =>
//{
//    var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
//    if (item is null)
//    {
//        return Results.NotFound(new { Message = $"Painting Not Found with id {id}" });
//    }
//    item.PaintingName = painting.PaintingName;
//    item.PaintingType = painting.PaintingType;
//    item.PaintingPrice = painting.PaintingPrice;
//    var result = await _appDbContext.SaveChangesAsync();
//    string message = result > 0 ? "Painting Updating Successful" : "Painting Updating Unsuccessful";
//    item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
//    return Results.Ok(new { Message = message, Data = item });
//})
//.WithName("PutPainting")
//.WithOpenApi();

//app.MapPatch("/api/paintingModel/{id}", async ([FromServices] AppDbContext _appDbContext, int id, PaintingModel painting) =>
//{
//    var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
//    if (item is null)
//    {
//        return Results.NotFound(new { Message = $"Painting Not Found with id {id}" });
//    }
//    if (!string.IsNullOrWhiteSpace(painting.PaintingName))
//    {
//        item.PaintingName = painting.PaintingName;
//    }
//    if (!string.IsNullOrWhiteSpace(painting.PaintingType))
//    {
//        item.PaintingType = painting.PaintingType;
//    }
//    if (painting.PaintingPrice > 0)
//    {
//        item.PaintingPrice = painting.PaintingPrice;
//    }
//    var result = await _appDbContext.SaveChangesAsync();
//    string message = result > 0 ? "Painting Updating Successful" : "Painting Updating Unsuccessful";
//    item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
//    return Results.Ok(new { Message = message, Data = item });
//})
//.WithName("PatchPainting")
//.WithOpenApi();

//app.MapDelete("/api/paintingModel/{id}", async ([FromServices] AppDbContext _appDbContext, int id) =>
//{
//    var item = await _appDbContext.Painting.FirstOrDefaultAsync(x => x.PaintingId == id);
//    if (item is null)
//    {
//        return Results.NotFound(new { Message = $"Painting Not Found with id {id}" });
//    }
//    _appDbContext.Painting.Remove(item);
//    var result = await _appDbContext.SaveChangesAsync();
//    string message = result > 0 ? "Painting Deleting Successful" : "Painting Deleting Unsuccessful";
//    return Results.Ok(new { Message = message });
//})
//.WithName("DeletePainting")
//.WithOpenApi();
//#endregion

app.MapPainting();
app.Run();
