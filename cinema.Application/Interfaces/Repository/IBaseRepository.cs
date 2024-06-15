using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Repository
{
    public interface IBaseRepository<Ttype>
    {
        Task<Ttype> Create(Ttype entity);
        Task<Ttype> Update(Ttype entity);
        Task<bool> Delete(Guid id);
        Task<Ttype> GetById(Guid id);
        Task<ICollection<Ttype>> GetAll();
        Task SaveChanges();
    }
}
