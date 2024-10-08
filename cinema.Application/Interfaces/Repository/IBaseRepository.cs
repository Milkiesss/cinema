using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Repository
{
    public interface IBaseRepository<Ttype>
    {
        Task<Ttype> CreateAsync(Ttype entity);
        Task<Ttype> UpdateAsync(Ttype entity);
        Task<bool> DeleteAsync(Guid id);
        Task<Ttype> GetByIdAsync(Guid id);
        Task<ICollection<Ttype>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
