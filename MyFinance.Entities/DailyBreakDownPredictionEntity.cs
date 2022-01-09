using System;

namespace MyFinance.Entities
{
    public class DailyBreakDownPredictionEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public double AverageIncome { get; set; }
        public double AverageExpense { get; set; }
    }
}
