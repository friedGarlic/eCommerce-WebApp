using eTickets.DataAccess.Data;
using eTickets.DataAccess.Repositories;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
