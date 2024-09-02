using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(projectContext context) : base(context) { }

    }
}
