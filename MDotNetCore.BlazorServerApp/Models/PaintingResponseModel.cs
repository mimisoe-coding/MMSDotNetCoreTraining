namespace MDotNetCore.BlazorServerApp.Models
{
    public class PaintingResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public PaintingModel Data { get; set; }
    }
}
