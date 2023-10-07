// See https://aka.ms/new-console-template for more information
using MDotNetCore.DbService.AppDbContextModels;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
AppDbContext db = new AppDbContext();
var lst = db.TblPaintings.ToList();
var jsonStr = JsonConvert.SerializeObject(lst);
Console.WriteLine(jsonStr);
Console.ReadKey();