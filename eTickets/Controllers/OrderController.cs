using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.DataModel;
using eTickets.DataModel.DataModelVM;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(ApplicationDbContext dbContext, IMovieService movieService, ShoppingCart shoppingCart)
        {
            _dbContext = dbContext;
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> ShoppingCart()
        {
            var getAllItems = await _shoppingCart.GetShoppingCartItems();
            _shoppingCart.Items = getAllItems;

            var response = new ShoppingCartVM { 
                ShoppingCart = _shoppingCart,
                ShoppingCartItemTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(response);
        }

        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await _movieService.GetMovieById(id);

            if (item != null)
            {
                await _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int id)
        {
            var item = await _movieService.GetMovieById(id);

            if (item != null)
            {
                await _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
