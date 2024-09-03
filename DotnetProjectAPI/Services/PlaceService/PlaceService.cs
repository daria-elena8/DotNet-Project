using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Repositories.PlaceRepo;
using DotnetProjectAPI.Services.GenericService;
using System.Data.Entity;


namespace DotnetProjectAPI.Services.PlaceService
{
    public class PlaceService : GenericService<PlaceDto, Place>, IPlaceService
    {
        private readonly IPlaceRepo _placeRepository;
        private readonly IMapper _mapper;


        public PlaceService(IPlaceRepo placeRepository, IMapper mapper)
            : base(placeRepository, mapper)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }
        public async Task<Place> CreateNewAsync(PlaceDto placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);

            await _placeRepository.CreateAsync(place);
            await _placeRepository.SaveAsync();

            return place;
        }
    }
}
