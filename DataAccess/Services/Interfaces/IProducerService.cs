using eTickets.DataAccess.Repositories.Interfaces;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services.Interfaces
{
    public interface IProducerService : IEntityBaseRepository<Producer>
    {
    }
}
