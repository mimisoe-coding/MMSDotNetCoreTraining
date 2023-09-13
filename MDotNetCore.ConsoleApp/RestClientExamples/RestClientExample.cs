using MDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MDotNetCore.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        public async Task Run()
        {
            await Read();

            Console.WriteLine("Enter to print id : ");
            string? input = Console.ReadLine();
            bool result = int.TryParse(input, out int id);
            if (result)
                await Edit(id);

            //Console.WriteLine("Enter to delete id : ");
            //string? delId = Console.ReadLine();
            //bool res = int.TryParse(input, out int Id);
            //if (res)
            //    await Delete(id);

            Console.WriteLine("Enter painting data information to put :");
            Console.Write("Enter id : ");
            string? pId = Console.ReadLine();
            bool isInt = int.TryParse(pId, out int paintId);
            Console.Write("Enter Name: ");
            string? paintName = Console.ReadLine();
            Console.Write("Enter Type : ");
            string? paintType = Console.ReadLine();
            Console.Write("Enter Price : ");
            string? price = Console.ReadLine();
            bool isDecimal = decimal.TryParse(price, out decimal paintPrice);
            //if (isInt &&
            //    !string.IsNullOrWhiteSpace(paintName) &&
            //    !string.IsNullOrWhiteSpace(paintType) &&
            //    paintPrice > 0)
            //{
            //    await Put(paintId, new PaintingModel
            //    {
            //        PaintingName = paintName,
            //        PaintingType = paintType,
            //        PaintingPrice = paintPrice
            //    });
            //}

            //if (!string.IsNullOrWhiteSpace(paintName) &&
            //    !string.IsNullOrWhiteSpace(paintType) &&
            //    paintPrice > 0)
            //    await Post(
            //            new PaintingModel
            //            {
            //                PaintingName = paintName,
            //                PaintingType = paintType,
            //                PaintingPrice = paintPrice
            //            });

            await Patch(paintId, new PaintingModel
            {
                PaintingName = paintName,
                PaintingType = paintType,
                PaintingPrice = paintPrice
            });
        }

        private async Task Read()
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest("https://localhost:7146/api/PaintingModel", Method.Get);
            var response = await restClient.ExecuteAsync(request);
            Console.WriteLine($"Http response status code : {response.StatusCode}");
            if (response.IsSuccessStatusCode)
            {
                string? json = response.Content;
                Console.WriteLine(json);
            }
        }

        private async Task Edit(int id)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7146/api/PaintingModel/{id}", Method.Get);
            var response = await restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string? json = response.Content;
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine($"Http response status code : {response.StatusCode}");
            }
        }

        private async Task Delete(int id)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7146/api/PaintingModel/{id}", Method.Delete);
            var response = await restClient.ExecuteAsync(request);
            Console.WriteLine($"Http response status code : {response.StatusCode}");
        }

        private async Task Put(int id, PaintingModel model)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7146/api/PaintingModel/{id}", Method.Put);
            request.AddJsonBody(model);
            var response = await restClient.ExecuteAsync(request);
            Console.WriteLine($"Status Code : {response.StatusCode}");
            string? jsonStr = response.Content;
            Console.WriteLine(jsonStr);
        }

        private async Task Post(PaintingModel model)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest("https://localhost:7146/api/PaintingModel", Method.Post);
            request.AddJsonBody(model);
            var response = await restClient.ExecuteAsync(request);
            Console.WriteLine(response.StatusCode);
        }

        private async Task Patch(int id, PaintingModel model)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7146/api/PaintingModel/{id}", Method.Patch);
            request.AddJsonBody(model);
            var response = await restClient.ExecuteAsync(request);
            Console.WriteLine($"Status Code : {response.StatusCode}");
            string? jsonStr = response.Content;
            Console.WriteLine(jsonStr);
        }
    }
}
