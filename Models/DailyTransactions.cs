using System.ComponentModel.DataAnnotations;

namespace E_WalletAPI.Models
{
    public class DailyTransaction
    {
        public Guid Id { get; set; }
        [Required]
        public string TransactionName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int TransactionCost { get; set; }
        [Required]
        public int TransactionCostCharges { get; set; }
        [Required]
        public string ModeOfPayment { get; set; } //Enum Mpesa/Bank
        public DateTime DateOfTransaction { get; set; }
        [Required]
        public string? TransactionType { get; set; }   //Enum whether Random or Constant
        
        [Required]
        public bool TransactionNecessary { get; set; }
        [Required]
        public int TotalAmount { get; set; }
    }



    
}
