using Microsoft.AspNetCore.Mvc;
using UdemyBackend.DTOs;
using UdemyBackend.Services;

namespace UdemyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _postsService.Get();
    }
}
