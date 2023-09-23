namespace MDotNetCore.MVCApp.Models
{
    public class PaintingListResponseModel:MessageModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public string? PageUrl { get; set; }
        public List<PaintingModel>? Data { get; set; }
    }
}
