using DotnetProjectAPI.Models.DTOs;

namespace DotnetProjectAPI.Services.RatingService
{
    public interface IRatingService
    {
        public async Task UpdatePlaceRatingAsync(Guid placeId);
    }
}
