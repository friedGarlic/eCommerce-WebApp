using eTickets.DataAccess.Data;
using eTickets.DataAccess.Repositories.Interfaces;
using eTickets.Models;
using eTickets.Models.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;

        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var findEntityId = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            //_context.Set<T>().Remove(findId);
            EntityEntry entityEntry = _context.Entry<T>(findEntityId);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var getActorList = await _context.Set<T>().ToListAsync();

            return getActorList;
        }

        public async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task Update(T entity)
        {
            //_context.Set<T>().Update(entity);

            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
