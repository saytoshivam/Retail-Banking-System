using BankUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankUI.Controllers
{
    [Authorize(Roles ="Employee")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View("Admin");
        }

        [HttpPost]
        public IActionResult CreateCustomer()
        {
            IEnumerable<Customer> mylist = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:25536/api/");
                var responseTask = client.GetAsync("Customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Customer>>();
                    readjob.Wait();
                    mylist = readjob.Result;
                }
                else
                {
                    mylist = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, "Server Error Occurred");
                }
            }
            return View(mylist);
        }
    }
}
