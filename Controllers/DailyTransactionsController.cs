using E_WalletAPI.DataDbContext;
using E_WalletAPI.Models;
using E_WalletAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTransactionsController : ControllerBase
    {
        private readonly TransactionDbContext dbContext;
        public DailyTransactionsController (TransactionDbContext dbContext)
	    {
           this.dbContext = dbContext;
	    }

        [HttpPost]
        public async Task<IActionResult> CreateDailyTransactions(AddDailyTransactions addDT)
        {
          var DailyT = new DailyTransaction()
          {
              Id = Guid.NewGuid(),
              TransactionName = addDT.TransactionName, 
              CompanyName = addDT.CompanyName ,
              TransactionCost = addDT.TransactionCost,
              TransactionCostCharges = addDT.TransactionCostCharges,
              ModeOfPayment = addDT.ModeOfPayment, 
              DateOfTransaction = addDT.DateOfTransaction,
              
              TransactionType = addDT.TransactionType,
             //TransactionNecessary = addDT.TransactionNecessary,
            
          };
            await dbContext.Transactions.AddAsync(DailyT);
            await dbContext.SaveChangesAsync();
             return Ok(DailyT);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(Guid id)
        {
            var dailyT = await dbContext.Transactions.FindAsync(id);
            if (dailyT == null)
            {
                return NotFound();
            }
            return Ok(dailyT);
        }
        
        [HttpGet]
        public async Task <IActionResult> GetDailyTransaction()
        {
           
            return Ok(await dbContext.Transactions.ToListAsync()); 
            //return Ok(wallRepo.GetDailyTransactions());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(Guid id,UpdateTransaction updateT)
        {
           var dailyT =await dbContext.Transactions.FindAsync(id);
           if(dailyT !=null)
            {
                 dailyT.TransactionName = updateT.TransactionName; 
                 dailyT.CompanyName = updateT.CompanyName ;
                 dailyT.TransactionCost = updateT.TransactionCost;
                 dailyT.TransactionCostCharges = updateT.TransactionCostCharges;
                 dailyT.ModeOfPayment = updateT.ModeOfPayment; 
                 dailyT.DateOfTransaction = updateT.DateOfTransaction;
                 dailyT.TransactionType =updateT.TransactionType;

                await dbContext.SaveChangesAsync(); 
                return Ok(dailyT);

            }
           return NotFound();
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteTransaction(Guid id)
        {
            var dailyT = await dbContext.Transactions.FindAsync(id);
            if(dailyT != null)
            {
                dbContext.Remove(dailyT);
                await dbContext.SaveChangesAsync();
                return Ok(dailyT);
            }
            return NotFound();
        }

      
    }
}
