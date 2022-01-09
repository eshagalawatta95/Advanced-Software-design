using System;

namespace MyFinance.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public int TransactionPartyId { get; set; }
        public double Amount { get; set; }
        public int? ScheduledTransactionId { get; set; }
        public bool IsIncome { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Remarks { get; set; }
        public bool IsUserPerformed { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class SheduledTransactionList
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public int TransactionPartyId { get; set; }
        public string RepeatType { get; set; }
        public double Amount { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime NextTransactionDate { get; set; }
        public bool InfiniteSchedule { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedUser { get; set; }
        public bool IsIncome { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

    }


 }
