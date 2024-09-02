using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;

namespace DotnetProjectAPI.Services.PlaceService
{
    public interface IPlaceService : IGenericService<PlaceDto, Place>
    {
       
    }
}
