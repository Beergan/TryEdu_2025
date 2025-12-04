using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static SLK.TryEdu.Abstract.ModelPage;

namespace SLK.TryEdu.Base;

public class MyPagingService 
{
    public interface IPagingService<T>
    {
        Task<PagedResult<T>> GetPagedAsync(int skip, int take, string filter, string sort);
    }

    public class PagingService<T> : IPagingService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public PagingService(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<PagedResult<T>> GetPagedAsync(int skip, int take, string filter, string sort)
        {
            var url = $"{_endpoint}?skip={skip}&take={take}&filter={filter}&sort={sort}";
            return await _httpClient.GetFromJsonAsync<PagedResult<T>>(url);
        }
    }


}
