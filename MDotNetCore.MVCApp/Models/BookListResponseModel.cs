namespace MDotNetCore.MVCApp.Models
{
    public class BookListResponseModel:MessageModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public List<BookModel>? Data { get; set; }
    }
}
