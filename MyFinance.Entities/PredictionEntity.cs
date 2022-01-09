using System.Collections.Generic;

namespace MyFinance.Entities
{
    public class PredictionEntity
    {
        public double PredictBalanace { get; set; }
        public double TodayBalanace { get; set; }
        public double AverageIncome { get; set; }
        public double AverageExpense { get; set; }
        public string WarningMessage { get; set; }
        public bool IsPredicted { get; set; }

        public IEnumerable<DailyBreakDownPredictionEntity> DailyBreakDownPredictions { get; set; }
    }
}
