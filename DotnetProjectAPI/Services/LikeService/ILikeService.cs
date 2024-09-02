using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;
using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Services.LikeService
{
    public interface ILikeService : IGenericService<LikeDto, Like>
    {
        Task<LikeDto> AddLike(LikeDto likeDto);
        Task<bool> RemoveLike(Guid id);
    }
}
