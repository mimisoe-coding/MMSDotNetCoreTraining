using Azure;
using MDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDotNetCore.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        public async Task Run()
        {
           // await Create();
            await Read();
            Console.WriteLine("Enter to print id : ");
            string? input = Console.ReadLine();
            bool result = int.TryParse(input, out int id);
            //if (result)
            //    await Edit(id);
            //if (result)
            //    await Delete(id);
            Console.Write("Enter Name: ");
            string? paintName = Console.ReadLine();
            Console.Write("Enter Type : ");
            string? paintType = Console.ReadLine();
            Console.Write("Enter Price : ");
            string? price = Console.ReadLine();
            bool isDecimal = decimal.TryParse(price, out decimal paintPrice);
            //if (!string.IsNullOrWhiteSpace(paintName) &&
            //    !string.IsNullOrWhiteSpace(paintType) &&
            //    paintPrice > 0)
            //    await Create(
            //            new PaintingModel
            //            {
            //                PaintingName = paintName,
            //                PaintingType = paintType,
            //                PaintingPrice = paintPrice
            //            });

            //if (result &&
            //    !string.IsNullOrWhiteSpace(paintName) &&
            //    !string.IsNullOrWhiteSpace(paintType) &&
            //    paintPrice > 0)
            //{
            //    await Put(id, new PaintingModel
            //    {
            //        PaintingName = paintName,
            //        PaintingType = paintType,
            //        PaintingPrice = paintPrice
            //    });
            //}

            await Patch(id, new PaintingModel
            {
                PaintingName = paintName,
                PaintingType = paintType,
                PaintingPrice = paintPrice
            });

        }
        public async Task Read()
        {
            var paintingApi = RestService.For<IPaintingAPI>("https://localhost:7146");
            var result = await paintingApi.GetPaintings();
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public async Task Edit(int id)
        {
            var paintingApi = RestService.For<IPaintingAPI>("https://localhost:7146");
            var result = await paintingApi.GetPaintingsById(id);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        public async Task Create(PaintingModel model)
        {
            var paintingApi = RestService.For<IPaintingAPI>("https://localhost:7146");
            var result = await paintingApi.CreatePainting(model);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public async Task Delete(int id)
        {
            var paintingApi = RestService.For<IPaintingAPI>("https://localhost:7146");
            var result = await paintingApi.DeletePainting(id);
            Console.WriteLine(JsonConvert.SerializeObject(result,Formatting.Indented));
        }

        public async Task Put(int id,PaintingModel model)
        {
            var paintingApi = RestService.For<IPaintingAPI>("https://localhost:7146");
            var result = await paintingApi.PutPainting(id, model);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public async Task Patch(int id,PaintingModel model)
        {
            var paintingApi = RestService.For<IPaintingAPI>("https://localhost:7146");
            var result = await paintingApi.PatchPainting(id, model);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

    }
    public interface IPaintingAPI
    {
        [Get("/api/PaintingModel")]
        Task<List<PaintingModel>> GetPaintings();

        [Get("/api/PaintingModel/{id}")]
        Task<PaintingModel> GetPaintingsById(int id);

        [Post("/api/PaintingModel")]
        Task<PaintingModel> CreatePainting(PaintingModel painting);

        [Delete("/api/PaintingModel/{id}")]
        Task<PaintingResponseModel> DeletePainting(int id);

        [Put("/api/PaintingModel/{id}")]
        Task<PaintingResponseModel> PutPainting(int id,PaintingModel painting);

        [Patch("/api/PaintingModel/{id}")]
        Task<PaintingResponseModel> PatchPainting(int id,PaintingModel painting);
    }
    public class PaintingResponseModel
    {
        public string? Message { get; set; }
        public PaintingModel? Data { get; set; }
    }
}
