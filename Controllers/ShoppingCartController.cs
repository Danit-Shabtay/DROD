using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DROD.Models;
using Microsoft.AspNetCore.Authorization;
using DROD.Data;
using DROD.ViewModels;

namespace DROD.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly MvcDRODContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(MvcDRODContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;

            var findShoppingCart = _context.ShoppingCart.FirstOrDefault(s => s.Id == _shoppingCart.Id);

            if (findShoppingCart == null)
                _context.ShoppingCart.Add(_shoppingCart);
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _context.Items.FirstOrDefault(p => p.ID == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _context.Items.FirstOrDefault(p => p.ID == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }
    }
}
