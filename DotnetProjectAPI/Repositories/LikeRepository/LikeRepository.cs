using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.LikeRepository
{
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        public LikeRepository(projectContext context) : base(context) { }

    }




}
