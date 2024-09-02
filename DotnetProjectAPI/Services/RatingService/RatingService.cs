using DotnetProjectAPI.Repositories.PlaceRepo;
using DotnetProjectAPI.Repositories.VisitRepository;
using DotnetProjectAPI.Repositories.PlaceRatingRepository;
using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Models;
using System.Linq;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;
using AutoMapper;


namespace DotnetProjectAPI.Services.RatingService
{
    public class RatingService : GenericService<PlaceRatingDto, PlaceRating>, IRatingService
    {
        private readonly IPlaceRepo _placeRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IPlaceRatingRepository _placeRatingRepository;

        public RatingService(
            IGenericRepository<PlaceRating> repository,
            IMapper mapper,
            IPlaceRepo placeRepository,
            IVisitRepository visitRepository,
            IPlaceRatingRepository placeRatingRepository)
            : base(repository, mapper)
        {
            _placeRepository = placeRepository;
            _visitRepository = visitRepository;
            _placeRatingRepository = placeRatingRepository;
        }

        public async Task UpdatePlaceRatingAsync(Guid placeId)
        {
            var visits = await _visitRepository.GetVisitsByPlaceIdAsync(placeId);

            if (!visits.Any()) 
            {
                throw new ArgumentException("No visits found for this place");
            }

            var averageRating = visits.Average(v => v.rating); 

            var placeRating = await _placeRatingRepository.GetPlaceRatingByPlaceIdAsync(placeId);
            if (placeRating == null)
            {
                placeRating = new PlaceRating
                {
                    placeId = placeId,
                    rating = (double)averageRating 
                };

                await _placeRatingRepository.CreateAsync(placeRating);
            }
            else
            {
                placeRating.rating = (double)averageRating;
                _placeRatingRepository.Update(placeRating);
            }

            await _placeRatingRepository.SaveAsync();
        }

    }
}
