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

        Actor GetById(int id);

        Actor Update(int id, Actor actor);

        void Add(Actor actor);

        void Delete(int id);
    }
}
