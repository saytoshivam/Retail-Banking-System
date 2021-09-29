using AccountMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repo
{
    public class AccountTransactionRepo : IAccountTransactionRepo
    {
        public TransactionStatus Deposite(int AccountID, float Amount, ApplicationDbContext _context)
        {
            var account = _context.Account.Find(AccountID);
            if (account != null)
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    transaction.CreateSavepoint("BeforeDeposite");

                    account.AccountBalance += Amount;
                    _context.Update(account);
                    _context.SaveChanges();


                    TransactionStatus TransactionStatus = new TransactionStatus();
                    TransactionStatus.DestinationBalance = account.AccountBalance;
                    TransactionStatus.Message = "Deposited Successfully";

                    Statement statement = new Statement();
                    statement.AccountID = AccountID;
                    statement.Date = DateTime.Now;
                    statement.Deposite = Amount;
                    statement.Withdrawal = 0;
                    statement.ClosingBalance = account.AccountBalance;
                    statement.Ref = 0;
                    statement.Description = "Deposited";

                    _context.Statement.Add(statement);
                    _context.SaveChanges();

                    transaction.Commit();
                    return TransactionStatus;
                }
                catch
                {
                    transaction.RollbackToSavepoint("BeforeDeposite");
                }
            }
            return null;
        }

        public TransactionStatus Withdraw(int AccountID, float Amount, ApplicationDbContext _context)
        {
            var account = _context.Account.Find(AccountID);
            if (account != null)
            {

                //Will implement Rule Service req for validating withdraw
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    transaction.CreateSavepoint("BeforeWithdraw");

                    account.AccountBalance -= Amount;
                    _context.Update(account);
                    _context.SaveChanges();


                    TransactionStatus TransactionStatus = new TransactionStatus();
                    TransactionStatus.SourceBalance = account.AccountBalance;
                    TransactionStatus.Message = "Withdrawn Successfully";

                    Statement statement = new Statement();
                    statement.AccountID = AccountID;
                    statement.Date = DateTime.Now;
                    statement.Deposite = 0;
                    statement.Withdrawal = Amount;
                    statement.ClosingBalance = account.AccountBalance;
                    statement.Ref = 0;
                    statement.Description = "Withdrawn";

                    _context.Statement.Add(statement);
                    _context.SaveChanges();

                    transaction.Commit();

                    return TransactionStatus;
                        
                }
                catch
                {
                    transaction.RollbackToSavepoint("BeforeWithdraw");
                }
            }
            return null;

        }
    }
}
