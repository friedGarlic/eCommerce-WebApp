using eTickets.DataAccess.Data;
using eTickets.DataAccess.Services.Interfaces;
using eTickets.DataModel;
using eTickets.DataModel.DataModelVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;

        public OrderController(ApplicationDbContext dbContext
            ,IMovieService movieService
            ,ShoppingCart shoppingCart, IOrderService orderService)
        {
            _dbContext = dbContext;
            _movieService = movieService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
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

        public IActionResult Index()
        {
            //TODO dont forget to filter using user id, when identity is implemented
            //also use the orderservice method of getting the orders by id
            var getOrderList = _dbContext.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Movie).ToList();
             
            return View(getOrderList);
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

        public async Task<IActionResult> CompleteOrder()
        {
            var items = await _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmail = "";

            await _orderService.StoreOrder(items,userId,userEmail);
            await _shoppingCart.ClearShoppingCartAsync();
             
            return View("CompleteOrder");
        }

    }
}
