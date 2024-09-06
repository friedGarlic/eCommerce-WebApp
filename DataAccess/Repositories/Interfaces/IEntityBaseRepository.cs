using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Repositories.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);

        public Task Update(int id, T entity);

        public Task Add(T entity);

        public Task DeleteAsync(int id);
    }
}
