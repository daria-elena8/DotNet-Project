using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotnetProjectAPI.Services.LikeService;
using DotnetProjectAPI.Models.DTOs;


namespace DotnetProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] LikeDto likeDto)
        {
            var like = await _likeService.AddLike(likeDto);

            return CreatedAtAction(nameof(GetLikeById), new { id = like.Id }, like);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLikeById(Guid id)
        {
            var like = await _likeService.GetByIdAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveLike(Guid id)
        {
            var result = await _likeService.RemoveLike(id);
            if (!result)
            {
                return NotFound("Like not found");
            }

            return NoContent();
        }


    }
}
