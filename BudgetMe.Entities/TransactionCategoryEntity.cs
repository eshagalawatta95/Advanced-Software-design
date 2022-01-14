using System;

namespace BudgetMe.Entities
{
    public class TransactionCategoryEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double MaxAmount { get; set; }
        public double CurrentAmount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
