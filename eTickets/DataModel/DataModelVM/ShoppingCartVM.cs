using eTickets.Controllers;
using eTickets.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataModel.DataModelVM
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }

        public double ShoppingCartItemTotal { get; set; }
    }
}
