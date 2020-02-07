using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fliek.Models;
using Fliek.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
            // var cust = _context.Customers.Include(c => c.MembershipType).ToList();
            // return View(cust);

            return View();
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

        
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cust == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel(cust)
            {
               // Customer = cust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                Console.WriteLine(errors);
                var viewModel = new CustomerFormViewModel
                {
                  //  Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
               var custDB= _context.Customers.Single(c => c.Id== customer.Id);
                custDB.FirstName = customer.FirstName;
                custDB.LastName = customer.LastName;
                custDB.DateOFBirth = customer.DateOFBirth;
                custDB.MembershipTypeID = customer.MembershipTypeID;               
                custDB.MembershipType = customer.MembershipType;
                custDB.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
            }
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index","Customers");
        }

       

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // delete Customer from the database whose id matches with specified id

            return RedirectToAction("Index");
        }



    }
}