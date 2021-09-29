using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using TransactionMicroservice.DBContexts;
using TransactionMicroservice.Models;
using TransactionMicroservice.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionMicroservice.Controllers
{
    [Route("api/TransactionHistory")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        //TransactionsHistoryContext cts = new TransactionsHistoryContext();

        //private readonly TransactionsHistoryContext _context;
        private ITransactionsRepo _transactionsRepo;
        protected ResponseDto _response;
        public TransactionHistoryController(ITransactionsRepo transactionsRepo)
        {
            //_context= context;
            _transactionsRepo = transactionsRepo;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            //IEnumerable<Services> servicesList = _context.services.ToList();
            //return Ok();
            
            try
            {
                IEnumerable<Services> serviceobj = await _transactionsRepo.GetServices();
                _response.Result = serviceobj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }



        [HttpPost]
        public async Task<object> AddToServices([FromBody] Services obj)
        {
            try
            {
               Services model=await _transactionsRepo.CreateServices(obj);

                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
           
            
            
        }
        

        // GET: api/<TransactionHistoryController>
        [HttpGet("{custid}")]
        public TransactionsHistory Get(int custid)
        {
            TransactionsHistory obj = new TransactionsHistory();
            obj.list = new List<FinancialTransactions>();
            //IList<FinancialTransactions> list1 = new List<FinancialTransactions>();
            //getallaccountsofcustomer
            /*foreach (var l in AllCustList)
            {
                int id = l.Account_ID;
                obj.list.Concat(_context.financialTransactions.Where(c => c.Account_ID == id));
            }*/
            

            return obj;
            
        }

        [HttpPost("{id}/{amount}")]
        public RefTransactionStatus Deposit(int id,float amount)
        {
            //rulemethodstatuscode
            //accountdepositTransactionStatus
            RefTransactionStatus obj = new RefTransactionStatus();

            

            return obj;


        }
        





        

        // POST api/<TransactionHistoryController>
        

        // PUT api/<TransactionHistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionHistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
