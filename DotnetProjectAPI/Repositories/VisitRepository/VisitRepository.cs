using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Repositories.PlaceRepository;
using Microsoft.EntityFrameworkCore;
using DotnetProjectAPI.Services.RatingService;

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

            //var placeRepository = new PlaceRepository(_context);
            await PlaceRepository.UpdatePlaceRatingAsync(visit.placeId);
        }





    }
}
