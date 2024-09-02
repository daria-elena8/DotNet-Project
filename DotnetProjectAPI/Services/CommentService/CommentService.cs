using AutoMapper;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Models.Enums;
using DotnetProjectAPI.Services.GenericService;
using DotnetProjectAPI.Repositories.CommentRepository;



namespace DotnetProjectAPI.Services.CommentService
{
    public class CommentService : GenericService<CommentDto, Comment>,  ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
            : base(commentRepository, mapper) 
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentDto> AddComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.CreateAsync(comment);
            await _commentRepository.SaveAsync();

            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<bool> RemoveComment(Guid id)
        {
            var comm = await _commentRepository.GetByIdAsync(id);
            if (comm == null)
            {
                return false;
            }

            _commentRepository.Delete(comm);
            await _commentRepository.SaveAsync();

            return true;
        }

    }
}
