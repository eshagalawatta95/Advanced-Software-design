using MyFinance.Entities;
using MyFinance.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Service
{
    public partial class ApplicationService
    {
        private int _optimalDataCount = 20;
        private int _optimalDaysCount = 10;
        private string _warningMessage = "Warning: Predictions can incorrect due to insufficient data";

        public bool IsAvailableEnoughtData(int monthsBack)
        {
            bool isAvailable = false;

            DateTime todayDate = DateTime.Now;
            todayDate = todayDate.Date;// Remove time
            DateTime monthsBackDate = todayDate.AddMonths(-1 * monthsBack);

            IEnumerable<TransactionEntity> orderedTransactions = Transactions.Where(t => t.TransactionDateTime >= monthsBackDate && t.IsActive).OrderBy(t => t.TransactionDateTime);

            if (orderedTransactions.Count() < _optimalDataCount)
            {
                isAvailable = false;
            }

            int daysCount = orderedTransactions
                .GroupBy(t => t.TransactionDateTime.Date)
                .Select(x => new
                {
                    Value = x.Count(),
                    Date = x.Key
                }).Count();

            if (daysCount < _optimalDaysCount)
            {
                isAvailable = false;
            }

            return isAvailable;
        }

        public async Task<PredictionEntity> GetPredictionsAsync(int monthsBack, DateTime predictDate)
        {
            PredictionEntity predictionEntity = null;

            await Task.Run(() =>
            {
                predictionEntity = new PredictionEntity()
                {
                    WarningMessage = IsAvailableEnoughtData(monthsBack) ? "" : _warningMessage,
                    TodayBalanace = CurrentUser.CurrentBalance
                };
                IList<DailyBreakDownPredictionEntity> dailyBreakDownPredictions = new List<DailyBreakDownPredictionEntity>();

                predictDate = predictDate.Date;
                DateTime todayDate = DateTime.Now;
                todayDate = todayDate.Date;// Remove time
                DateTime monthsBackDate = todayDate.AddMonths(-1 * monthsBack);

                IEnumerable<TransactionEntity> orderedTransactions = Transactions.Where(t => t.TransactionDateTime >= monthsBackDate && t.IsActive).OrderBy(t => t.TransactionDateTime);

                if (orderedTransactions.Count() > 0)
                {
                    predictionEntity.IsPredicted = true;
                    int daysFromBackMonth = (int)todayDate.Subtract(monthsBackDate.Date).TotalDays;

                    double totalInCome = orderedTransactions.Where(ot => ot.IsIncome).Select(ot => ot.Amount).Sum();
                    double totalInExpenses = orderedTransactions.Where(ot => !ot.IsIncome).Select(ot => ot.Amount).Sum();

                    predictionEntity.AverageIncome = totalInCome / daysFromBackMonth;
                    predictionEntity.AverageExpense = totalInExpenses / daysFromBackMonth;

                    int daysToPredictDate = (int)predictDate.Subtract(todayDate).TotalDays;
                    predictionEntity.PredictBalanace = CurrentUser.CurrentBalance + ((totalInCome - totalInExpenses) / daysFromBackMonth) * daysToPredictDate;

                    // Day by day predictions
                    IEnumerable<DayOfWeek> daysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();

                    foreach (DayOfWeek dayOfWeek in daysOfWeek)
                    {
                        DailyBreakDownPredictionEntity dailyBreakDown = new DailyBreakDownPredictionEntity()
                        {
                            DayOfWeek = dayOfWeek
                        };

                        IEnumerable<DateTime> dates = TimeConverterMethods.DatesDayOfWeekForDuration(monthsBackDate, todayDate, dayOfWeek);

                        if (dates.Count() > 0)
                        {
                            IEnumerable<TransactionEntity> dayOfWeekIncomeTransactions = orderedTransactions.Where(t => t.IsIncome && dates.Any(d => d.Date == t.TransactionDateTime.Date));
                            dailyBreakDown.AverageIncome = dayOfWeekIncomeTransactions.Select(x => x.Amount).Sum() / dates.Count();

                            IEnumerable<TransactionEntity> dayOfWeekExpensesTransactions = orderedTransactions.Where(t => !t.IsIncome && dates.Any(d => d.Date == t.TransactionDateTime.Date));
                            dailyBreakDown.AverageExpense = dayOfWeekExpensesTransactions.Select(x => x.Amount).Sum() / dates.Count();
                        }
                        else
                        {
                            dailyBreakDown.AverageIncome = 0;
                            dailyBreakDown.AverageExpense = 0;
                        }

                        dailyBreakDownPredictions.Add(dailyBreakDown);
                    }

                    predictionEntity.DailyBreakDownPredictions = dailyBreakDownPredictions;
                }
                else
                {
                    predictionEntity.IsPredicted = false;
                    predictionEntity.WarningMessage = "Error: No data found to do the predictions";
                }
            });

            return predictionEntity;
        }
    }
}
