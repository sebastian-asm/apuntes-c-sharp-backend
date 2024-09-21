using System.Text.Json;
using UdemyBackend.DTOs;

namespace UdemyBackend.Services
{
    public class PostsService : IPostsService
    {
        // HttpClient nos permite realizar peticiones http a otros servicios
        private HttpClient _httpClient;

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            // string url = "https://jsonplaceholder.typicode.com/posts";
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();
            // Opciones para no tener problemas con las keys del JSON en caso de tener 
            // mayúsculas o minúsculas
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var posts = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);
            return posts;
        }
    }
}
