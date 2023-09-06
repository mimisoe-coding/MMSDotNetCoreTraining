using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public async Task Run()
        {
            //await Create(new PaintingModel{
            //    PaintingName = "Running People",
            //    PaintingType = "Watercolour",
            //    PaintingPrice = 150000
            //});
            //await Read();
            //await Edit(40);
            //await Update(4,new PaintingModel
            //{
            //    PaintingName="Beauty Of Bagan",
            //    PaintingType="Acrylic",
            //    PaintingPrice=500000
            //});
            await Delete(3);
            await Edit(3);
            await Read();
        }

        private async Task Read()
        {
            AppDbContext db = new AppDbContext();
            List<PaintingModel> lst = await db.paintingModel.ToListAsync();

            foreach (var model in lst)
            {
                Console.WriteLine($"PaintingId =>{model.PaintingId}");
                Console.WriteLine($"PaintingName =>{model.PaintingName}");
                Console.WriteLine($"PaintingType =>{model.PaintingType}");
                Console.WriteLine($"PaintingPrice =>{model.PaintingPrice}");
            }
        }

        private async Task Create(PaintingModel model)
        {
            AppDbContext appDbContext = new AppDbContext();
            await appDbContext.paintingModel.AddAsync(model);
            var result = await appDbContext.SaveChangesAsync();

            string message = result > 0 ? "Insertion Successful" : "Insertion Unsuccessful";
            Console.WriteLine(message);
        }

        private async Task Update(int id, PaintingModel model)
        {
            AppDbContext appDbContext = new AppDbContext();
            var item = await appDbContext.paintingModel.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item is null)
            {
                await Console.Out.WriteLineAsync($"No Painting Data Found With Id {id}");
                return;
            }
            item.PaintingName = model.PaintingName;
            item.PaintingType = model.PaintingType;
            item.PaintingPrice = model.PaintingPrice;
            var result = await appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Updating painting data successful" : "Updating painting data unsuccessful";
            Console.WriteLine(message);
        }

        private async Task Edit(int id)
        {
            AppDbContext appDbContext = new AppDbContext();
            var item = await appDbContext.paintingModel.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item is null)
            {
                await Console.Out.WriteLineAsync($"No Data Found with id {id}");
                return;
            }
            Console.WriteLine($"PaintingId =>{item.PaintingId}");
            Console.WriteLine($"PaintingName =>{item.PaintingName}");
            Console.WriteLine($"PaintingType =>{item.PaintingType}");
            Console.WriteLine($"PaintingPrice =>{item.PaintingPrice}");
        }

        private async Task Delete(int id)
        {
            AppDbContext appDbContext = new AppDbContext();
            var item = await appDbContext.paintingModel.FirstOrDefaultAsync(x => x.PaintingId == id);
            if (item is null)
            {
                await Console.Out.WriteLineAsync($"No Data Found with id {id}");
                return;
            }
            appDbContext.paintingModel.Remove(item);
            var result = await appDbContext.SaveChangesAsync();
            string message = result > 0 ? "Deleting painting data successful" : "Deleting painting data unsuccessful";
            Console.WriteLine(message);
        }
    }
}
