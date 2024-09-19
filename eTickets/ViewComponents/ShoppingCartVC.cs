using eTickets.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.ViewComponents
{
    public class ShoppingCartVC : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartVC(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
