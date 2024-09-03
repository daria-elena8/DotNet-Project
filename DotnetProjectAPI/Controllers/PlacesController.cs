using DotnetProjectAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotnetProjectAPI.Services.PlaceService;
using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {

        private readonly IPlaceService _placeService;


        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        // Get all places
        [HttpGet]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllAsync();
            return Ok(places);
        }

        // Get place by ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPlaceById(Guid id)
        {
            var place = await _placeService.GetByIdAsync(id);
            if (place == null)
            {
                return NotFound("Place not found");
            }
            return Ok(place);
        }



        /// <summary>
        /// //  NU INREGISTREAZA PLACE URILE, NU MERGE AUTH
        /// </summary>
        /// <param name="placeCreateDto"></param>
        /// <returns></returns>


        // Create a new place (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePlace([FromBody] PlaceCreateDto placeCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var placeDto = new PlaceDto
            {
                Name = placeCreateDto.Name,
                Description = placeCreateDto.Description,
            };

            var place = await _placeService.CreateNewAsync(placeDto);
            return CreatedAtAction(nameof(GetPlaceById), new { id = place.id }, place);
        }


        // Update an existing place (Admin only)
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePlace(Guid id, [FromBody] PlaceDto placeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _placeService.UpdateAsync(id, placeDto);
            
            return NoContent();
        }

        // Delete a place (Admin only)
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlace(Guid id)
        {
            await _placeService.DeleteAsync(id);
            
            return NoContent();
        }

    }
}
