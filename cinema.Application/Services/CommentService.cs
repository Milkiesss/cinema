using AutoMapper;
using cinema.Application.DTOs.Comment.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Comment.Response;

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

        public async Task<CommentCreateResponse> CreateAsync(CommentCreateRequest entity)
        {
            var result = _mapper.Map<Comment>(entity);
            await _rep.CreateAsync(result);
            return _mapper.Map<CommentCreateResponse>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<CommentUpdateResponse> UpdateAsync(CommentUpdateRequest entity)
        {
            var result = _mapper.Map<Comment>(entity);
            await _rep.UpdateAsync(result);
            return _mapper.Map<CommentUpdateResponse>(result);
        }
    }
}
