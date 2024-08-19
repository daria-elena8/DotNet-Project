namespace DotnetProjectAPI.Repositories.VisitRepository
{
    public interface IVisitRepository
    {
        public async Task AddVisitAsync(Visit visit);
        private async Task UpdatePlaceRatingAsync(Guid placeId);

    }
}
