using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionMicroservice.Models
{
    public class FinancialTransactions
    {
        [Key]
        public int Transaction_ID { get; set; }

        [ForeignKey("Account_ID")]
        public int Account_ID { get; set; }

        [ForeignKey("Counterparty_ID")]
        public int Counterparty_ID { get; set; }

        [ForeignKey("Payment_Method_Code")]
        public int Payment_Method_Code { get; set; }

        [ForeignKey("Service_ID")]
        public int Service_ID { get; set; }

        [ForeignKey("transaction_status_code")]
        public int transaction_status_code { get; set; }

        [ForeignKey("Transaction_type_code")]
        public int Transaction_type_code { get; set; }
        public DateTime Date_of_Transaction { get; set; }
        public float Amount_of_Transaction { get; set; }
        public string Other_Details { get; set; }
    }
}
