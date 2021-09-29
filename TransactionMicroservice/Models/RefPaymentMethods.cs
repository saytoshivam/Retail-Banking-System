using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TransactionMicroservice.Models
{
    public class RefPaymentMethods
    {
        [Key]
        public int Payment_Method_Code { get; set; }
        public string Payment_Method_Name { get; set; }
       
    }
}
