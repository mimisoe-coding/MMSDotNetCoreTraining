using MDotNetCore.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Text;

namespace MDotNetCore.MVCApp.Controllers
{
    public class PaintingHttpClientController : Controller
    {
        private readonly HttpClient _httpClient;

        public PaintingHttpClientController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> PaintingIndex(int pageNo = 1, int pageSize = 10)
        {
            PaintingListResponseModel model = new PaintingListResponseModel();

            var response = await _httpClient.GetAsync($"api/PaintingWithMvc/{pageNo}/{pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingListResponseModel>(jsonStr);
            }
            ViewBag.Paintings = model.Data;
            ViewBag.PageCount = model.PageCount;
            ViewBag.PageSize = model.PageSize;
            ViewBag.PageNo = model.PageNo;
            return View("PaintingIndex", model.Data);
        }

        [ActionName("Create")]
        public IActionResult PaintingCreate()
        {
            return View("PaintingCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> PaintingSave(PaintingModel painting)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(painting), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync($"api/PaintingWithMvc", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
            }
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return Redirect("/PaintingHttpClient");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> PaintingDelete(int id)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            var response = await _httpClient.DeleteAsync($"api/PaintingWithMvc/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
            }
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return Json(model);
        }

        [ActionName("Edit")]
        public async Task<IActionResult> PaintingEdit(int id)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            var response = await _httpClient.GetAsync($"api/PaintingWithMvc/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
                if (model.IsSuccess)
                {
                    Console.WriteLine(model.Message);
                    Console.WriteLine(JsonConvert.SerializeObject(model.Data, Formatting.Indented));
                }
            }
            else
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return View("PaintingEdit", model.Data);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> PaintingUpdate(int id, PaintingModel painting)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            var jsonBlog = JsonConvert.SerializeObject(painting);
            HttpContent content = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"api/PaintingWithMvc/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
            }
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return Redirect("/PaintingHttpClient");
        }
    }
}
