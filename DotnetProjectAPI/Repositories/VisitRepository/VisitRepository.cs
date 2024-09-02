using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotnetProjectAPI.Repositories.VisitRepository
{
    public class VisitRepository : GenericRepository<Visit>, IVisitRepository
    {

        public VisitRepository(projectContext context) : base(context) {

        }
        public async Task<List<Visit>> GetVisitsByPlaceIdAsync(Guid placeId)
        {
            return await _table.Where(v => v.placeId == placeId).ToListAsync();
        }

    }
}
