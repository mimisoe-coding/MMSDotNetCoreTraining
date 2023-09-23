using MDotNetCore.MVCApp.Models;
using Refit;

namespace MDotNetCore.MVCApp
{
    public interface IPaintingApi
    {
        [Get("/api/PaintingWithMvc/{pageNo}/{pageSize}")]
        Task<PaintingListResponseModel> GetPaintings(int pageNo, int pageSize);

        [Get("/api/PaintingWithMvc/{id}")]
        Task<PaintingResponseModel> GetPainting(int id);

        [Post("/api/PaintingWithMvc")]
        Task<PaintingResponseModel> CreatePainting(PaintingModel painting);

        [Put("/api/PaintingWithMvc/{id}")]
        Task<PaintingResponseModel> UpdatePainting(int id, PaintingModel painting);

        [Delete("/api/PaintingWithMvc/{id}")]
        Task<PaintingResponseModel> DeletePainting(int id);
    }
}
