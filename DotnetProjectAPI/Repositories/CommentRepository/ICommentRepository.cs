using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Repositories.CommentRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
