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

        public void Add(Actor actor)
        {
        }

        public void Delete(int id)
        {
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var getActorList = await _context.Actors.ToListAsync();

            return getActorList;
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
