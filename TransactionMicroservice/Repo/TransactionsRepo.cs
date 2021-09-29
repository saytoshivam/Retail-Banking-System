using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.DBContexts;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repo
{
    public class TransactionsRepo : ITransactionsRepo
    {


        private readonly TransactionsHistoryContext _context;
       
        public TransactionsRepo(TransactionsHistoryContext context)
        {
            _context = context;
           
        }


        public RefTransactionStatus Deposit(int accountid, float amount)
        {
            throw new NotImplementedException();
        }

        public TransactionsHistory GetTransactionHistory(int custid)
        {
            throw new NotImplementedException();
        }

        public RefTransactionStatus Transfer(int accountid, float amount)
        {
            throw new NotImplementedException();
        }

        public RefTransactionStatus Withdraw(int accountid, float amount)
        {
            throw new NotImplementedException();
        }

        public async Task<Services> CreateServices(Services obj)
        {
           
                _context.services.Add(obj);
            
           await _context.SaveChangesAsync();
            return obj;
           
        }

        public async Task<IEnumerable<Services>> GetServices()
        {
            List<Services> productList = await _context.services.ToListAsync();
            return productList;

        }

    }
}
