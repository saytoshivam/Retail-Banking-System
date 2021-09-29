
using AccountMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repo
{
    public interface IAccountTransactionRepo
    {
        public TransactionStatus Deposite(int AccountID,float Amount,ApplicationDbContext _context);
        public TransactionStatus Withdraw(int AccountId, float Amount, ApplicationDbContext _context);
    }
}
