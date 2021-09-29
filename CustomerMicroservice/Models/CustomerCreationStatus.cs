using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class CustomerCreationStatus
    {

        public int CustomerId { get; set; }
        public string Message { get; set; }

        public CustomerCreationStatus(int id,string msg)
        {
            CustomerId = id;
            Message = msg;
        }
    }
}
