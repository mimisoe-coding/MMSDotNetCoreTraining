using MDotNetCore.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection.Metadata;

namespace MDotNetCore.MVCApp.Controllers
{
    public class PaintingRestClientController : Controller
    {
        private readonly RestClient _restClient;

        public PaintingRestClientController(RestClient restClient)
        {
            _restClient = restClient;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> PaintingIndex(int pageNo = 1, int pageSize = 10)
        {
            PaintingListResponseModel model = new PaintingListResponseModel();

            RestRequest request = new RestRequest($"api/PaintingWithMvc/{pageNo}/{pageSize}");
            var response = await _restClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
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

        [ActionName("Save")]
        public async Task<IActionResult> PaintingSave(PaintingModel painting)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            RestRequest request = new RestRequest($"api/PaintingWithMvc");
            request.AddJsonBody(painting);
            var response = await _restClient.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
            }
            TempData["message"] = model.Message;
            TempData["isSuccess"] = model.IsSuccess;
            return Redirect("/PaintingRestClient");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> PaintingDelete(int id)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            RestRequest request = new RestRequest($"api/PaintingWithMvc/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
            }
            TempData["message"] = model.Message;
            TempData["isSuccess"] = model.IsSuccess;
            return Json(model);
        }

        [ActionName("Edit")]
        public async Task<IActionResult> PaintingEdit(int id)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            RestRequest request = new RestRequest($"api/PaintingWithMvc/{id}");
            var response = await _restClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
                if (model.IsSuccess)
                {
                    Console.WriteLine(model.Message);
                    Console.WriteLine(JsonConvert.SerializeObject(model.Data, Formatting.Indented));
                }
            }
            else
            {
                var jsonStr = response.Content;
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
                Console.WriteLine(model.Message);
            }
            ViewBag.Paintings = model.Data;
            return View("PaintingEdit", model.Data);
        }

        [ActionName("Update")]
        public async Task<IActionResult> PaintingUpdate(int id, PaintingModel painting)
        {
            PaintingResponseModel model = new PaintingResponseModel();
            RestRequest request = new RestRequest($"api/PaintingWithMvc/{id}");
            request.AddJsonBody(painting);
            var response = await _restClient.PutAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
                model = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
            }
            TempData["message"] = model.Message;
            TempData["isSuccess"] = model.IsSuccess;
            return Redirect("/PaintingRestClient");
        }
    }
}
