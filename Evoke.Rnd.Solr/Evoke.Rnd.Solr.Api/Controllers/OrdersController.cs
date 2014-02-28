using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoke.Rnd.Solr.Api.Models;

namespace Evoke.Rnd.Solr.Api.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/

        private readonly SalesContext _objContext;
        public OrdersController()
        {
            _objContext = new SalesContext();
        }
        public ActionResult Index()
        {
            var orders = _objContext.Orders.ToList();
            return View(orders);
        }

        public ActionResult Create()
        {
            var order = new ModelRepository.Order();
            return View(order);
        }
        [HttpPost]
        public ActionResult Create(ModelRepository.Order ord)
        {
            _objContext.Orders.Add(ord);
            _objContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var Order = _objContext.Orders.First(o => o.OrderId == id);
            return View(Order);
        }
        [HttpPost]
        public ActionResult Delete(int id, ModelRepository.Order ord)
        {
            var order = _objContext.Orders.First(o => o.OrderId == id);
            if (order != null)
            {
                _objContext.Orders.Remove(order);
                _objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
