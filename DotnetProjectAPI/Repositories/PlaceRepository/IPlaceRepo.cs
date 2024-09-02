using DotnetProjectAPI.Models;
using DotnetProjectAPI.Repositories.GenericRepository;
using System.Linq.Expressions;

namespace DotnetProjectAPI.Repositories.PlaceRepo
{
    public interface IPlaceRepo : IGenericRepository<Place>
    {
        public List<Place> OrderByPlaceNameAsc();
        public List<Place> OrderByPlaceNameDesc();
        public List<Place> OrderByVisitsAsc();
        public List<Place> OrderByVisitsDesc();
        public List<Place> GetByRating(int rating);
        public void GroupBy();


    }
}
