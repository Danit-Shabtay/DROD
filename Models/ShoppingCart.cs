using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DROD.Data;

namespace DROD.Models
{
    public class ShoppingCart
    {
        private readonly MvcDRODContext _context;

        public ShoppingCart(MvcDRODContext context)
        {
            _context = context;
        }

        public string Id { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<MvcDRODContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { Id = cartId };
        }

        public void AddToCart(Items items, int amount)
        {
            var shoppingCartItem = _context.ShoppingCartItem.SingleOrDefault(s => s.Items.ID == items.ID && s.ShoppingCartId == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Items = items,
                    Amount = amount
                };

                _context.ShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Items product)
        {
            var shoppingCartItem = _context.ShoppingCartItem.SingleOrDefault(s => s.Items.ID == product.ID && s.ShoppingCartId == Id);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItem.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                    (ShoppingCartItems = _context.ShoppingCartItem.Where(c => c.ShoppingCartId == Id)
                                            .Include(s => s.Items)
                                            .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context
                                .ShoppingCartItem
                                .Where(cart => cart.ShoppingCartId == Id);

            _context.ShoppingCartItem.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItem.Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Items.Price * c.Amount).Sum();
            return total;
        }
    }
}
