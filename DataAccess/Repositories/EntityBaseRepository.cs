using eTickets.DataAccess.Repositories.Interfaces;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
