using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CustomerMicroservice.Repo
{
    public class CustomerOperations : ICustomerOperations
    {

        Uri baseAddress;
        HttpClient client;
        IConfiguration _config;

        public CustomerOperations(IConfiguration config)
        {
            _config = config;
            baseAddress = new Uri(_config["Links:CLAIM"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public CustomerCreationStatus AddCust(Customer customer,CustomerContext _context)
        {

            int custId = 0;
            var id = _context.Customers.Add(customer);
            _context.SaveChanges();
            custId = id.Entity.CustId;
            if (custId != 0)
            {
                //Call createAccount which call Account sevice
                string msg = createAccount(customer);
                return new CustomerCreationStatus(custId, msg);
            }
            else
            {
                return new CustomerCreationStatus(custId, "Failed");
            } 
        }

        public Customer GetCustomer(int customer_Id,CustomerContext _context)
        {
            return _context.Customers.FirstOrDefault(c => c.CustId == customer_Id);
        }

        public string createAccount(Customer customer)
        {
            try
            {
                string data = JsonConvert.SerializeObject(customer);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress+"/create/"+customer.CustId, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

    }
}
