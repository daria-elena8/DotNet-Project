using DotnetProjectAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        public readonly projectContext _context;

        public DatabaseController(projectContext context)
        {
            _context = context;
        }





    }
}
