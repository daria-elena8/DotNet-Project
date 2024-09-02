using DotnetProjectAPI.Models;
using DotnetProjectAPI.Repositories.GenericRepository;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace DotnetProjectAPI.Repositories.VisitRepository
{
    public interface IVisitRepository : IGenericRepository<Visit>
    {
        Task<List<Visit>> GetVisitsByPlaceIdAsync(Guid placeId);

    }
}
