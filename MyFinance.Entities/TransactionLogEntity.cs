using System;

namespace MyFinance.Entities
{
    public class TransactionLogEntity
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int? ScheduledTransactionId { get; set; }
        public int TransactionPartyId { get; set; }
        public bool IsDeletedTransaction { get; set; }
        public bool IsIncome { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public double Amount { get; set; }
        public double StartingBalance { get; set; }
        public double FinalBalance { get; set; } 
        public string Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsUserPerformed { get; set; }
    }
}
