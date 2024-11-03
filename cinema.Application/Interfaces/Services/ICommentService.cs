using cinema.Application.DTOs.Comment.Request;

using cinema.Application.DTOs.Comment.Response;

namespace cinema.Application.Interfaces.Services
{
    public interface ICommentService
    {
        Task<CommentCreateResponse> CreateAsync(CommentCreateRequest entity);
        Task<CommentUpdateResponse> UpdateAsync(CommentUpdateRequest entity);
        Task<bool> DeleteAsync(Guid id);

    }
}
