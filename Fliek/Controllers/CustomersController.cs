using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fliek.Models;
using System.Data.Entity;

namespace Fliek.Controllers
{  
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

      // GET: Customer
        public ActionResult Index()
        {
            var cust = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(cust);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var cust = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(cust);
        }

        [HttpPost]
        public ActionResult Edit(Customer c)
        {
            //write code to update customer 
            
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // delete Customer from the database whose id matches with specified id

            return RedirectToAction("Index");
        }



    }
}