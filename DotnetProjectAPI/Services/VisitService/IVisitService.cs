using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;

namespace DotnetProjectAPI.Services.VisitService
{
    public interface IVisitService : IGenericService<VisitDto, Visit>
    {
        Task<List<VisitDto>> GetVisitsByPlaceIdAsync(Guid placeId);
        Task<List<VisitDto>> GetVisitsByUserIdAsync(Guid userId);
    }
}
