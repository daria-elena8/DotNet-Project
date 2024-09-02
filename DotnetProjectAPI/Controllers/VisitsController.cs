using AutoMapper;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.VisitService;
using Microsoft.AspNetCore.Mvc;

namespace DotnetProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {

        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public VisitsController(IVisitService visitService, IMapper mapper)
        {
            _visitService = visitService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisits()
        {
            var visits = await _visitService.GetAllAsync();
            return Ok(visits);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetVisitById(Guid id)
        {
            var visit = await _visitService.GetByIdAsync(id);
            if (visit == null)
            {
                return NotFound("Visit not found");
            }
            return Ok(visit);
        }

        [HttpGet("place/{placeId:guid}")]
        public async Task<IActionResult> GetVisitsByPlaceId(Guid placeId)
        {
            var visits = await _visitService.GetByIdAsync(placeId);
            return Ok(visits);
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetVisitsByUserId(Guid userId)
        {
            var visits = await _visitService.GetByIdAsync(userId);
            return Ok(visits);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] VisitDto visitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var visit = await _visitService.CreateAsync(visitDto);
            return CreatedAtAction(nameof(GetVisitById), new { id = visit.Id }, visit);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateVisit(Guid id, [FromBody] VisitDto visitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _visitService.UpdateAsync(id, visitDto);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVisit(Guid id)
        {
            await _visitService.DeleteAsync(id);

            return NoContent();
        }



    }
}
