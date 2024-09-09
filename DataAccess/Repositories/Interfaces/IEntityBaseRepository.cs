using eTickets.Models;
using eTickets.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Repositories.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] properties);

        public Task<T> GetById(int id);

        public Task Update(T entity);

        public Task<T> Add(T entity);

        public Task DeleteAsync(int id);
    }
}
