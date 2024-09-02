using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;


namespace DotnetProjectAPI.Services.RatingService
{
    public interface IRatingService : IGenericService<PlaceRatingDto, PlaceRating>
    {
        public Task UpdatePlaceRatingAsync(Guid placeId);
    }
}
