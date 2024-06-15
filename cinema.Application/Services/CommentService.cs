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

        public async Task<CommentCreateResponce> Create(CommentCreateRequest entity)
        {
            var result = _mapper.Map<Comment>(entity);
            await _rep.Create(result);
            return _mapper.Map<CommentCreateResponce>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _rep.Delete(id);
        }

        public async Task<CommentUpdateResponce> Update(CommentUpdateRequest entity)
        {
            var result = _mapper.Map<Comment>(entity);
            await _rep.Update(result);
            return _mapper.Map<CommentUpdateResponce>(result);
        }
    }
}
