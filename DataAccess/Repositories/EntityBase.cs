using eTickets.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Repositories
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}
