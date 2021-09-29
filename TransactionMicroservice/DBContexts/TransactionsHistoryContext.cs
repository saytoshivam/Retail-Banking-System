using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.DBContexts
{
    public class TransactionsHistoryContext:DbContext
    {
        public TransactionsHistoryContext(DbContextOptions options)
            : base(options)
        {
        }

       
        
        public DbSet<FinancialTransactions> financialTransactions{ get; set; }
        public DbSet<Counterparties> Counterparties { get; set; }
        public DbSet<RefPaymentMethods> RefPaymentMethod { get; set; }
        public DbSet<RefTransactionStatus> RefTransactionStatuse { get; set; }
        public DbSet<RefTransactionTypes> RefTransactionType { get; set; }
        public DbSet<Services> services { get; set; }

    }
}
