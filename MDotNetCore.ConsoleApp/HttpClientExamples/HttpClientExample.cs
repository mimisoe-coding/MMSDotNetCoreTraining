using MDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MDotNetCore.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Read();
            //Console.WriteLine("Enter to print id : ");
            //string? input = Console.ReadLine();
            //bool result = int.TryParse(input, out int id);
            //if (result)
            //    await Edit(id);
            Console.WriteLine("Enter to delete id : ");
            string? delId = Console.ReadLine();
            bool res = int.TryParse(delId, out int id);
            if (res)
                await Delete(id);

            Console.WriteLine("Enter painting data information to patch :");
            Console.Write("Enter id : ");
            string? pId = Console.ReadLine();
            bool isInt = int.TryParse(pId, out int paintId);
            Console.Write("Enter Name: ");
            string? paintName = Console.ReadLine();
            Console.Write("Enter Type : ");
            string? paintType = Console.ReadLine();
            Console.Write("Enter Price : ");
            string? price = Console.ReadLine();
            bool isDecimal = decimal.TryParse(price, out decimal pantPrice);
            //if(isInt &&
            //    !string.IsNullOrWhiteSpace(paintName)&&
            //    !string.IsNullOrWhiteSpace(paintType)&&
            //    pantPrice > 0)
            //{
            //    await Put(paintId, new PaintingModel
            //    {
            //        PaintingName = paintName,
            //        PaintingType = paintType,
            //        PaintingPrice = pantPrice
            //    });

            //}
            
            //if(!string.IsNullOrWhiteSpace(paintName) &&
            //    !string.IsNullOrWhiteSpace(paintType)&&
            //    pantPrice > 0)
            //await Post(
            //        new PaintingModel
            //        {
            //            PaintingName = paintName,
            //            PaintingType = paintType,
            //            PaintingPrice = pantPrice
            //        });
     
            //await Patch(paintId, new PaintingModel
            //{
            //    PaintingName = paintName,
            //    PaintingType = paintType,
            //    PaintingPrice = pantPrice
            //});



        }
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://localhost:7146/api/PaintingModel");
            Console.WriteLine($"Http response status code : {httpResponseMessage.StatusCode}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string json = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
        }

        private async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync($"https://localhost:7146/api/PaintingModel/{id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string json = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine($"Http response status code : {httpResponseMessage.StatusCode}");
            }
        }

        private async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"https://localhost:7146/api/PaintingModel/{id}");
            Console.WriteLine($"Http response status code : {httpResponseMessage.StatusCode}");
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(json);
        }

        private async Task Put(int id, PaintingModel model)
        {
            HttpClient client = new HttpClient();
            string jsonFormat = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonFormat, Encoding.UTF8, Application.Json);
            HttpResponseMessage result = await client.PutAsync($"https://localhost:7146/api/PaintingModel/{id}", httpContent);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine($"Http response status code : {result.StatusCode}");
                string json = await result.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine($"Updating failed with id {id}");
            }

        }

        private async Task Post(PaintingModel model)
        {
            HttpClient client = new HttpClient();
            string jsonFormat = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonFormat, Encoding.UTF8, Application.Json);
            HttpResponseMessage responsMessage = await client.PostAsync("https://localhost:7146/api/PaintingModel", httpContent);
            Console.WriteLine(responsMessage.StatusCode);
        }

        private async Task Patch(int id, PaintingModel model)
        {
            HttpClient client = new HttpClient();
            string jsonFormat = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonFormat, Encoding.UTF8, Application.Json);
            HttpResponseMessage responseMessage = await client.PatchAsync($"https://localhost:7146/api/PaintingModel/{id}", httpContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine($"Http response status code : {responseMessage.StatusCode}");
                string json = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine($"Updating failed with id {id}");
            }
        }
    }
}
