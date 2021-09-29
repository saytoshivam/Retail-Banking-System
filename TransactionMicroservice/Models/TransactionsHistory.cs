using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class TransactionsHistory
    {
        public TransactionsHistory()
        {

        }
        public int CustId { get; set; }

        public IList<FinancialTransactions> list { get; set; }
    }
}
