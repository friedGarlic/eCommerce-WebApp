using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetAll();

        public Task<Actor> GetById(int id);

        public Task<Actor> Update(int id, Actor actor);

        public Task Add(Actor actor);

        public Task Delete(int id);
    }
}
