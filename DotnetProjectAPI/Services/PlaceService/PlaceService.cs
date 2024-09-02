using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Repositories.PlaceRepo;
using DotnetProjectAPI.Services.GenericService;


namespace DotnetProjectAPI.Services.PlaceService
{
    public class PlaceService : GenericService<PlaceDto, Place>, IPlaceService
    {
        private readonly IPlaceRepo _placeRepository;


        public PlaceService(IPlaceRepo placeRepository, IMapper mapper)
            : base(placeRepository, mapper)
        {
            _placeRepository = placeRepository;
        }

    }
}
