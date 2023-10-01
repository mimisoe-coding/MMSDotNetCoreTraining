using MDotNetCore.BlazorServerApp.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace MDotNetCore.BlazorServerApp.Pages.Painting
{
    public partial class PagePainting
    {
        private EnumPageType _pageType = EnumPageType.List;
        private int _pageNo = 1;
        private int _pageSize = 10;
        private PaintingListResponseModel? model = null;
        private PaintingModel reqModel = new PaintingModel();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await List(_pageNo, _pageSize);
            }
        }

        private async Task List(int pageNo, int pageSize)
        {
            var response = await _httpClient.GetAsync($"api/PaintingModel/{_pageNo}/{_pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<PaintingListResponseModel>(jsonStr);
                StateHasChanged();
            }
        }
        private async Task PageChanged(int i)
        {
            _pageNo = i;
            await List(_pageNo, _pageSize);
        }
        private async Task Back()
        {
            reqModel = new PaintingModel();
            _pageType = EnumPageType.List;
            _pageNo = 1;
            await List(_pageNo, _pageSize);
        }
        private void Create()
        {
            _pageType = EnumPageType.Create;
        }
        private async Task Save()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(reqModel), Encoding.UTF8, Application.Json);
            HttpResponseMessage response = null;
            if (_pageType == EnumPageType.Create)
            {
                response = await _httpClient.PostAsync("api/PaintingModel", content);
            }
            else if (_pageType == EnumPageType.Edit)
            {
                response = await _httpClient.PutAsync($"api/PaintingModel/{reqModel.PaintingId}", content);
            }
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var paintingResponse = JsonConvert.DeserializeObject<PaintingResponseModel>(jsonStr);
                await Back();
            }
        }

        private async Task Edit(int id)
        {
            var response = await _httpClient.GetAsync($"api/PaintingModel/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                reqModel = JsonConvert.DeserializeObject<PaintingModel>(jsonStr);
                _pageType = EnumPageType.Edit;
                StateHasChanged();
            }
        }

        private async Task Update()
        {
            await Save();
        }

        private async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/PaintingModel/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                await List(_pageNo, _pageSize);
            }
        }
    }
}
