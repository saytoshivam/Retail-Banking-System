using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransactionMicroservice.Models
{
    public class Services
    {
        [Key]
        public int Service_ID { get; set; }
        public DateTime Date_Service_Provided { get; set; }
        public string Other_Details { get; set; }
    }
}
