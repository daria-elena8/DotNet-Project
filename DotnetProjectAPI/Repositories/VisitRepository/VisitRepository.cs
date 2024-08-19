using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.VisitRepository
{
    public class VisitRepository : GenericRepository<Visit>, IVisitRepository
    {
        private readonly projectContext _context;

        public VisitRepository(projectContext context, RatingService ratingService) : base(context) 
        {
            _context = context;
        }

        public async Task AddVisitAsync(Visit visit)
        {
            await _table.AddAsync(visit);
            await _context.SaveChangesAsync();

            var placeRepository = new PlaceRepository(_context);
            await placeRepository.UpdatePlaceRatingAsync(visit.placeId);
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
                    PlaceId = placeId,
                    Rating = (int)averageRating
                };

                await _context.PlaceRatings.AddAsync(placeRating);
            }
            else
            {
                placeRating.Rating = (int)averageRating;
                _context.PlaceRatings.Update(placeRating);
            }

            await _context.SaveChangesAsync();
        }



    }
}
