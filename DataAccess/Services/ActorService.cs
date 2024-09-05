using eTickets.DataAccess.Data;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services
{
    public class ActorService : IActorService
    {
        public readonly ApplicationDbContext _context;

        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Actor actor)
        {
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }
         
        public void Delete(int id)
        {
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var getActorList = await _context.Actors.ToListAsync();

            return getActorList;
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync( x => x.Id == id);

            return result;
        }

        public async Task<Actor> Update(int id, Actor actor)
        {
            _context.Update(actor);
            await _context.SaveChangesAsync();

            return actor;
        }
    }
}
