using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoke.Rnd.Solr.Api.Models;
using Evoke.Rnd.Solr.Api.Models.ModelRepository;

namespace Evoke.Rnd.Solr.Api.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/
        private SalesContext _objContext;

        public CustomersController()
        {
            _objContext = new SalesContext();
        }
        public ActionResult Index()
        {
            var customers = _objContext.Customers.ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            var customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer cust )
        {
            _objContext.Customers.Add(cust);
            _objContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cust = _objContext.Customers.First(c => c.CustomerId == id);
            return View(cust);
        }
        [HttpPost]
        public ActionResult Delete(int id, Customer cust)
        {
            var customer = _objContext.Customers.First(c => c.CustomerId == id);
            if (customer != null)
            {
                _objContext.Customers.Remove(customer);
                _objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
