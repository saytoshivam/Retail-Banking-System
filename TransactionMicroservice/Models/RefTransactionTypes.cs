using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransactionMicroservice.Models
{
    public class RefTransactionTypes
    {
        [Key]
        public int Transaction_type_code { get; set; }
        
        public string Transaction_type_description { get; set; }
    }
}
