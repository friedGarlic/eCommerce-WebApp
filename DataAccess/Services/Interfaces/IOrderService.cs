using eTickets.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services.Interfaces
{
    public interface IOrderService
    {
        public Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        public Task<List<Order>> GetListOfUserByIdAsync(string userId);
    }
}
