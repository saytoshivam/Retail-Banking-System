using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransactionMicroservice.Models
{
    public class RefTransactionStatus
    {
        [Key]
        public int transaction_status_code { get; set; }
       
        public string transaction_status_description { get; set; }
    }
}
