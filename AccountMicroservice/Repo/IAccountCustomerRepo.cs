using AccountMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repo
{
    public interface IAccountCustomerRepo
    {
        public AccountCreationStatus CreateAccount(int CustomerID,ApplicationDbContext _context);

        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID,ApplicationDbContext _context);
    }
}
