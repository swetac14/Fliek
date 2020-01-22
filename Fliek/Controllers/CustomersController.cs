using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fliek.Models;

namespace Fliek.Controllers
{ 
  
    public class CustomersController : Controller
    {

        List<Customer> customerList = new List<Customer>()
            {
                new Customer{Id=1, FirstName="Shailesh", LastName="Kushwaha", DateOFBirth=DateTime.Now },
                new Customer{Id=2, FirstName="Sweta", LastName="Chauhan", DateOFBirth=DateTime.Now },
                new Customer{Id=3, FirstName="Shanvi", LastName="Baby", DateOFBirth=DateTime.Now }
            };


        // GET: Customer
        public ActionResult Index()
        {
            return View(customerList);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }
            var cust = customerList.Where(c => c.Id == id).FirstOrDefault();

            if (cust == null)
                return HttpNotFound();

            return View(cust);
        }

        public ActionResult Edit(int id)
        {
            var cust = customerList.Where(c => c.Id == id).FirstOrDefault();

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