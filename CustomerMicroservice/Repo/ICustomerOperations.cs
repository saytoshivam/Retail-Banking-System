using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Repo
{
    public interface ICustomerOperations
    {
        public Customer GetCustomer(int customer_Id,CustomerContext context);

        public CustomerCreationStatus AddCust([FromBody] Customer customer,CustomerContext context);
    }
}
