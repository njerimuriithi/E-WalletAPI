using E_WalletAPI.DataDbContext;
using E_WalletAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTransactionsController : ControllerBase
    {
        private readonly TransactionDbContext _transactionDbContext;
        public DailyTransactionsController (TransactionDbContext dbContext)
	        {
            _transactionDbContext = dbContext;
	        }

        [HttpPost]
public async Task<ActionResult<DailyTransaction>> PostDailyTransaction(DailyTransaction DailyT)
{
    _transactionDbContext.DailyTransactions.Add(DailyT);
    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(GetDailyTransaction), new { id = DailyT.Id }, DailyT);
}

        // GET: api/<DailyTransactionsController>
        [HttpGet]
        public IActionResult GetDailyTransactions()
        {
            return Ok(wallRepo.GetDailyTransactions());
        }

        // GET api/<DailyTransactionsController>/5
        [HttpGet("{id}")]
        public IActionResult GetDailyTransaction(Guid id)
        {
            var transaction = wallRepo.GetDailyTransaction(id);
            if(transaction != null)
            { 
                return Ok(transaction);
            }
            return NotFound("TransactionNotFound");
        }

        // POST api/<DailyTransactionsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<DailyTransactionsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DailyTransactionsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
