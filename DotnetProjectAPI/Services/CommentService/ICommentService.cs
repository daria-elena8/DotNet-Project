using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;
using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Services.CommentService
{
    public interface ICommentService : IGenericService<CommentDto, Comment>
    {
        Task<CommentDto> AddComment(CommentDto commentDto);
        Task<bool> RemoveComment(Guid id);
    }
}
