using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetListOfUserByIdAsync(string userId)
        {
            //EAGER LOADING
            var orders = await _dbContext.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Movie)
                .Where(n => n.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order() { 
                UserId = userId,
                Email = userEmailAddress,
            };
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _dbContext.OrderItems.AddAsync(orderItem);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
