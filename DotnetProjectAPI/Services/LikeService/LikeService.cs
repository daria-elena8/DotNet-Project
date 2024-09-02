using AutoMapper;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Models.Enums;
using DotnetProjectAPI.Services.GenericService;
using DotnetProjectAPI.Repositories.LikeRepository;



namespace DotnetProjectAPI.Services.LikeService
{
    public class LikeService : GenericService<LikeDto, Like>,  ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LikeService(ILikeRepository likeRepository, IMapper mapper)
            : base(likeRepository, mapper) 
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<LikeDto> AddLike(LikeDto likeDto)
        {
            var like = _mapper.Map<Like>(likeDto);
            await _likeRepository.CreateAsync(like);
            await _likeRepository.SaveAsync();

            return _mapper.Map<LikeDto>(like);
        }

        public async Task<bool> RemoveLike(Guid id)
        {
            var like = await _likeRepository.GetByIdAsync(id);
            if (like == null)
            {
                return false;
            }

            _likeRepository.Delete(like);
            await _likeRepository.SaveAsync();

            return true;
        }

    }
}
