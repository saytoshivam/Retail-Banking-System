using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repo
{
    public interface ITransactionsRepo
    {
        public RefTransactionStatus Deposit(int accountid,float amount);
        public RefTransactionStatus Withdraw(int accountid, float amount);
        public RefTransactionStatus Transfer(int accountid, float amount);

        public TransactionsHistory GetTransactionHistory(int custid);
        public Task<Services> CreateServices(Services productDto);
        public Task<IEnumerable<Services>> GetServices();
    }

   
}
