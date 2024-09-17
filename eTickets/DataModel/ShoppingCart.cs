using eTickets.DataAccess.Data;
using eTickets.Models;
using eTickets.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _dbContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> Items { get; set; }

        public ShoppingCart(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItemToCart(Movie movie)
        {
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(n => n.Id == movie.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(n => n.Id == movie.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _dbContext.Remove(movie);

                    await _dbContext.SaveChangesAsync();
                }
            }

        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItems()
        {
            if (Items != null)
            {
                //EAGER loading
                Items = await _dbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToListAsync();
            }

            return Items;
        }

        public double GetShoppingCartTotal()
        {
            var total = _dbContext.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Select(n => n.Movie.Price * n.Amount)
                .Sum();

            return total;
        }
    }
}
