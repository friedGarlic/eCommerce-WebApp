using eTickets.DataAccess.Data;
using eTickets.Models;
using eTickets.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.DataModel
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

        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<ApplicationDbContext>();


            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { 
                ShoppingCartId = cartId,
            };
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
                Items = await _dbContext.ShoppingCartItems
                    .Where(n => n.ShoppingCartId == ShoppingCartId)
                    .Include(n => n.Movie).ToListAsync();
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
