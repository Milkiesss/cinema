using AutoMapper;
using cinema.Application.DTOs.Comment.Request;
using cinema.Application.DTOs.Comment.Responce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _rep;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<CommentCreateResponce> CreateAsync(CommentCreateRequest entity)
        {
            var result = _mapper.Map<Comment>(entity);
            await _rep.CreateAsync(result);
            return _mapper.Map<CommentCreateResponce>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<CommentUpdateResponce> UpdateAsync(CommentUpdateRequest entity)
        {
            var result = _mapper.Map<Comment>(entity);
            await _rep.UpdateAsync(result);
            return _mapper.Map<CommentUpdateResponce>(result);
        }
    }
}
