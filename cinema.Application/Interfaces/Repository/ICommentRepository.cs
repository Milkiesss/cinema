using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Repository
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(Comment entity);
        Task<Comment> UpdateAsync(Comment entity);
        Task<bool> DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
