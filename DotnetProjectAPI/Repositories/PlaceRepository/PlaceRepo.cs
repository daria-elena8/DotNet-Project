using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Repositories.VisitRepository;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.PlaceRepo
{
    public class PlaceRepo : GenericRepository<Place>, IPlaceRepo
    {
        private readonly projectContext _context;

        public PlaceRepo(projectContext context) : base(context) 
        {
            _context = context;
        }

        public List<Place> OrderByPlaceNameAsc()
        {
            var placesOrdered = from p in _table
                                      orderby p.name
                                      select p;
            return placesOrdered.ToList();
        }

        public List<Place> OrderByPlaceNameDesc()
        {
            var placesOrdered = from p in _table
                                orderby p.name descending
                                select p;
            return placesOrdered.ToList();
        }

        public List<Place> OrderByVisitsAsc()
        {
            return _table.OrderBy(x => x.visits.Count).ToList();
        }

        public List<Place> OrderByVisitsDesc()
        {
            return _table.OrderByDescending(x => x.visits.Count).ToList();
        }


        public List<Place> GetByRating(int rating)
        {
            return _table.Where(p => p.placeRating.rating == rating).ToList();

        }

        public void GroupBy()
        {

            // Group By Name

            var groupedPlaces = _table.GroupBy(p => p.name);

            foreach(var group in groupedPlaces)
            {
                Console.WriteLine("Place group: " + group.Key);
                foreach(var place in group)
                {
                    Console.WriteLine($"Place ID: {place.id}\tName:{place.name} ");
                }
            }
        }

        public async Task UpdatePlaceRatingAsync(Guid placeId)
        {
            var place = await _context.Places
                .Include(p => p.visits)
                .FirstOrDefaultAsync(p => p.id == placeId);

            if (place == null)
                throw new ArgumentException("Place not found");

            var averageRating = place.visits.Any() ? place.visits.Average(v => v.rating) : 0;

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
