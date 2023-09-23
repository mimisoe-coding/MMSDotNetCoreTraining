namespace MDotNetCore.MVCApp.Models
{
    public class PaintingResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public PaintingModel Data { get; set; }
    }
}
