using DotnetProjectAPI.Models.DTOs;

namespace DotnetProjectAPI.Services.RatingService
{
    public interface IRatingService
    {
        public Task UpdatePlaceRatingAsync(Guid placeId);
    }
}
