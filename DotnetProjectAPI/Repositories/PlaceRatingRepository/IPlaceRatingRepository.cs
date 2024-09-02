using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Repositories.PlaceRatingRepository
{
    public interface IPlaceRatingRepository : IGenericRepository<PlaceRating>
    {
        Task<PlaceRating?> GetPlaceRatingByPlaceIdAsync(Guid placeId);

    }
}
