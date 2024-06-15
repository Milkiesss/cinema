using cinema.Application.DTOs.Comment.Request;
using cinema.Application.DTOs.Comment.Responce;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Services
{
    public interface ICommentService
    {
        Task<CommentCreateResponce> Create(CommentCreateRequest entity);
        Task<CommentUpdateResponce> Update(CommentUpdateRequest entity);
        Task<bool> Delete(Guid id);

    }
}
