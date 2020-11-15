using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DROD.Data;
using DROD.Models;

namespace DROD.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly MvcDRODContext _context;

        public StatisticsController(MvcDRODContext context)
        {
            _context = context;
        }


        // GET: Statistics
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            var result = (from o in _context.OrderDetail
                          group o by o.Items.ItemName into o
                          orderby o.Count() descending
                          select new { o.Key, Total = o.Count() })
             .ToDictionary(x => x.Key, x => x.Total);

            //var result = _context.OrderDetail
            //    .GroupBy(order => order.ProductId)
            //    //.SelectMany(order => order)
            //    .OrderBy(order => order.Count())
            //    .Select(order => new { order.Key, Total = order.Count() })
            //    .ToDictionary(order => order.Key, order => order.Total)
            //    .ToList();


            ViewBag.OrderCount = result;
            var DateResult = _context.Orders.GroupBy(x => x.OrderPlaced.Date, x => x.Id)
                        .Select(x => new { Date = x.Key.ToShortDateString(), Count = x.Count() }).ToList();
            ViewBag.DateResult = DateResult;
            return View("Index");
        }
    }
}