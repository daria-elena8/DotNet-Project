using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Repositories.VisitRepository
{
    public interface IVisitRepository
    {
        public Task AddVisitAsync(Visit visit);

    }
}
