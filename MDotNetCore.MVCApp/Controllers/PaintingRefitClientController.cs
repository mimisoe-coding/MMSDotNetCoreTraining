using MDotNetCore.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDotNetCore.MVCApp.Controllers
{
    public class PaintingRefitClientController : Controller
    {
        private readonly IPaintingApi _paintingApi;

        public PaintingRefitClientController(IPaintingApi paintingApi)
        {
            _paintingApi = paintingApi;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> PaintingIndex(int pageNo = 1, int pageSize = 10)
        {
            PaintingListResponseModel model = await _paintingApi.GetPaintings(pageNo, pageSize);
            ViewBag.Paintings = model.Data;
            ViewBag.PageCount = model.PageCount;
            ViewBag.PageSize = model.PageSize;
            ViewBag.PageNo = model.PageNo;
            return View("PaintingIndex", model.Data);
        }

        [ActionName("Create")]
        public IActionResult PaintingEdit()
        {
            return View("PaintingCreate");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> PaintingDelete(int id)
        {
            PaintingResponseModel model = await _paintingApi.DeletePainting(id);
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return Json(model);
        }

        [ActionName("Edit")]
        public async Task<IActionResult> PaintingEdit(int id)
        {
            PaintingResponseModel model = await _paintingApi.GetPainting(id);
            return View("PaintingEdit", model.Data);
        }

        [ActionName("Update")]
        public async Task<IActionResult> PaintingUpdate(int id, PaintingModel painting)
        {
            PaintingResponseModel model = await _paintingApi.UpdatePainting(id, painting);
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return Redirect("/PaintingRefitClient");
        }

        [ActionName("Save")]
        public async Task<IActionResult> PaintingSave(PaintingModel painting)
        {
            PaintingResponseModel model = await _paintingApi.CreatePainting(painting);
            TempData["isSuccess"] = model.IsSuccess;
            TempData["message"] = model.Message;
            return Redirect("/PaintingRefitClient");
        }
    }
}
