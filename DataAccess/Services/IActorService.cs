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
        Task<IEnumerable<Actor>> GetAll();

        public Task<Actor> GetById(int id);

        Task<Actor> Update(int id, Actor actor);

        public Task Add(Actor actor);

        void Delete(int id);
    }
}
