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
        Task<Comment> Create(Comment entity);
        Task<Comment> Update(Comment entity);
        Task<bool> Delete(Guid id);
        Task SaveChanges();
    }
}
