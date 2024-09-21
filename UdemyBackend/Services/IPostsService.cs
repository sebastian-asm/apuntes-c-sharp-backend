using UdemyBackend.DTOs;

namespace UdemyBackend.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
