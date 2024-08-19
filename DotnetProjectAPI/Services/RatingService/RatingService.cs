using AutoMapper;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Repositories.PlaceRepository;
using DotnetProjectAPI.Repositories.UserRepository;
using DotnetProjectAPI.Services.UserService;

namespace DotnetProjectAPI.Services.RatingService
{
    public class RatingService : IRatingService
    {
        private readonly projectContext _context;
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public RatingService(projectContext context)
        {
            _context = context;
        }

        private async Task UpdatePlaceRatingAsync(Guid placeId)
        {
            var place = await _context.Places
                .Include(p => p.visits)
                .FirstOrDefaultAsync(p => p.id == placeId);

            if (place == null)
                throw new ArgumentException("Place not found");

            var averageRating = place.Visits.Any() ? place.Visits.Average(v => v.rating) : 0;

            var placeRating = await _context.PlaceRatings
                .FirstOrDefaultAsync(pr => pr.placeId == placeId);

            if (placeRating == null)
            {
                placeRating = new PlaceRating
                {
                    placeId = placeId,
                    rating = (int)averageRating
                };

                await _context.PlaceRatings.AddAsync(placeRating);
            }
            else
            {
                placeRating.rating = (int)averageRating;
                _context.PlaceRatings.Update(placeRating);
            }

            await _context.SaveChangesAsync();
        }
    }
}
