namespace DotnetProjectAPI.Repositories.PlaceRepository
{
    public interface IPlaceRepository
    {
        public List<Place> OrderByPlaceNameAsc();
        public List<Place> OrderByPlaceNameDesc();
        public List<Place> OrderByVisitsAsc();
        public List<Place> OrderByVisitsDesc();
        public List<Place> GetByRating(int rating);
        public void GroupBy();
        public PlaceRepository GetPlaceWithRating(string placename);
        public void UpdatePlaceRating();


    }
}
