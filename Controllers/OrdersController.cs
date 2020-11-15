using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DROD.Data;
using DROD.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace DROD.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MvcDRODContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(MvcDRODContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }


        // GET: Orders
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int itemId, ItemType? type)
        {
            var orders =
            from o in _context.Orders
            join od in _context.OrderDetail on o.Id equals od.OrderId
            join p in _context.Items on od.ProductId equals p.ID
            select o;


            if (itemId != 0 && type.HasValue)
            {
                orders = orders.Where(
                    o => o.OrderLines.Any(
                        od => od.ProductId == itemId)).Concat(orders.Where(
                    o => o.OrderLines.Any(
                        od => ((Items)od.Items).Gender == type))).Distinct();
            }
            else if (itemId != 0)
            {
                orders = orders.Where(
                    o => o.OrderLines.Any(
                        od => od.ProductId == itemId));
            }
            else if (type.HasValue)
            {
                orders = orders.Where(
                    o => o.OrderLines.Any(
                        od => ((Items)od.Items).Gender == type));
            }

            return View(await orders.Distinct().ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Orders orders)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Your cart is empty. add some products first");

            if (ModelState.IsValid)
            {
                CreateOrder(orders);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(orders);
        }

        [Authorize]
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! ♡";
            return View();
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrderId,ItemId,Quantity,Price,Discount")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrderId,ItemId,Quantity,Price,Discount")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }


        [Authorize]
        private void CreateOrder(Orders orders)
        {
            orders.OrderPlaced = DateTime.Now;
            orders.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _context.Orders.Add(orders);

            _context.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    ProductId = item.Items.ID,
                    OrderId = orders.Id,
                    Price = item.Items.Price,
                    //ItemsID =
                };
                _context.OrderDetail.Add(orderDetail);
            }

            _context.SaveChanges();

        }
    }
}
