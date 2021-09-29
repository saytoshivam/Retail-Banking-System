using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.Models;
using Microsoft.OpenApi;
using AccountMicroservice.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        private readonly IAccountCustomerRepo AC_Repo;
        private readonly IAccountTransactionRepo AT_Repo;
        public AccountsController(ApplicationDbContext context,IAccountCustomerRepo AC_Repo,IAccountTransactionRepo At_Repo)
        {
            _context = context;
            this.AC_Repo = AC_Repo;
            this.AT_Repo = At_Repo;
        }

        // GET api/<AccountController>/5
        [HttpGet("all/{CustomerID}")]
        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID)
        {
            return AC_Repo.GetCustomerAccounts(CustomerID, _context); //out List<Models.Account>);
        
        }


        //GET api/<AccountController>/{id}/{fromdate}/{todate}
        [HttpGet("getStatement/{AccountID}/{FromDate}/{ToDate}")]
        public IEnumerable<Statement> GetAccountStatement(int AccountID,DateTime FromDate,DateTime ToDate)
        {  
            if(FromDate==default(DateTime) && ToDate==default(DateTime))
            {
                ToDate = DateTime.UtcNow;
                FromDate = DateTime.UtcNow.AddDays(-30);
                return _context.Statement.Where(x => (x.Date <= ToDate && x.Date >= ToDate));
            }
           return _context.Statement.Where(x => (x.Date <= ToDate && x.Date >= ToDate));
        }


        //GET api/<AccountController>/{id}
        [HttpGet("get/{AccountID}")]
        public IActionResult GetAccount(int AccountID)
        {
            var account = _context.Account.Find(AccountID);
            if(account!=null)
            {
  
                return Ok(account);
            }
            return NotFound("Account not Found");
        }

        //POST api/<AccountController>
        [HttpPost("create/{CustomerID}")]
        public IActionResult CreateAccount(int CustomerID)
        {
            AccountCreationStatus accountCreationStatus = AC_Repo.CreateAccount(CustomerID, _context);
            if (accountCreationStatus != null)
                return Ok(accountCreationStatus);
            return BadRequest(accountCreationStatus);
        }

        //[HttpPost("{id}")]
        //public IActionResult CreateAccount(int id)
        //{
        //    return Ok();
        //}

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("deposit/{AccountID}/{Amount}")]
        public IActionResult Deposite(int AccountID,float Amount)
        {
            TransactionStatus TransactionStatus = AT_Repo.Deposite(AccountID, Amount, _context);
            if (TransactionStatus != null)
                return Ok(TransactionStatus);
            return BadRequest(TransactionStatus);
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("withdraw/{AccountID}/{Amount}")]
        public IActionResult Withdraw(int AccountID, float Amount)
        {
            TransactionStatus TransactionStatus = AT_Repo.Withdraw(AccountID, Amount, _context);
            if (TransactionStatus != null)
                return Ok(TransactionStatus);
            return BadRequest(TransactionStatus);
        }
    }
}
