using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.PlaceRatingRepository
{
    public class PlaceRatingRepository : GenericRepository<PlaceRating>, IPlaceRatingRepository
    {
        public PlaceRatingRepository(projectContext context) : base(context) { }

        public async Task<PlaceRating?> GetPlaceRatingByPlaceIdAsync(Guid placeId)
        {
            return await _table.FirstOrDefaultAsync(pr => pr.placeId == placeId);
        }

    }




}
