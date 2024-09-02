using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Repositories.PlaceRepo;
using DotnetProjectAPI.Repositories.VisitRepository;
using DotnetProjectAPI.Services.GenericService;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;




namespace DotnetProjectAPI.Services.VisitService
{
    public class VisitService : GenericService<VisitDto, Visit>, IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IPlaceRepo _placeRepository;
        private readonly IMapper _mapper;

        public VisitService(IVisitRepository visitRepository, IPlaceRepo placeRepository, IMapper mapper)
            :base(visitRepository, mapper)
        {
            _visitRepository = visitRepository;
            _placeRepository = placeRepository;
            _mapper = mapper;
        }


        public async Task<List<VisitDto>> GetVisitsByPlaceIdAsync(Guid placeId)
        {
            var visits = await _visitRepository.FindByCondition(v => v.placeId == placeId).ToListAsync();
            return _mapper.Map<List<VisitDto>>(visits);
        }

        public async Task<List<VisitDto>> GetVisitsByUserIdAsync(Guid userId)
        {
            var visits = await _visitRepository.FindByCondition(v => v.userId == userId).ToListAsync();
            return _mapper.Map<List<VisitDto>>(visits);
        }
    }
}


