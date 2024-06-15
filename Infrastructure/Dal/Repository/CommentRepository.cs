using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Infrastructure.Dal.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _db;
        public CommentRepository( DataContext db)
        {
            _db = db;
        }

        public async Task<Comment> Create(Comment entity)
        {
            await _db.comments.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _db.comments.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            return true;
        }

        public async Task<Comment> Update(Comment entity)
        {
            _db.comments.Update(entity);
            await SaveChanges();
            return entity;
        }
        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
