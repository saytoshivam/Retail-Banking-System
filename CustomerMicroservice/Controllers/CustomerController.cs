using CustomerMicroservice.Models;
using CustomerMicroservice.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperations _rep;
        private readonly CustomerContext _context;
        public CustomerController(CustomerContext context, ICustomerOperations rep)
        {
            _context = context;
            _rep = rep;
        }
        [HttpGet]
        public string GetCustomerAgain()
        {
            //return Ok(_context.Customers.ToList());
            
            return "Working";
        }

        [HttpGet("getCustomerDetails/{customer_Id}")]
        public IActionResult GetCustomer(int customer_Id)
        {
            //Call Account Microservice for getting account details for customerId 
            //Calling getCustomerAccount
            return Ok(_rep.GetCustomer(customer_Id, _context));
        }

        [HttpPost("createCustomer")]
        public IActionResult AddCust([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                return Ok(_rep.AddCust(customer, _context));
            }
            //This will call Account Microservice for account creation
            //Calling createAccount
            return BadRequest("Failed");
        }




    }
}
