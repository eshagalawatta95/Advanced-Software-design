using BudgetMe.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetMe.Core.Models
{
    public interface ITransactionModel : IModel
    {
        Task<TransactionEntity> GetTransactionByIdAsync(int id);
        Task<IEnumerable<TransactionEntity>> GetTransactionsAsync();
        Task<int> InsertTransactionAsync(TransactionEntity transactionEntity, bool isUserPerformed = false);
        Task<int> UpdateTransactionAsync(TransactionEntity transactionEntity);
        Task<int> DeleteTransactionAsync(int id);
        Task<int> InsertScheduledTransactionListAsync(SheduledTransactionList transactionEntity);
        Task<int> UpdateScheduledTransactionListAsync(SheduledTransactionList transactionEntity);
        Task<int> DeleteSheduledTransactionAsync(int id);
        Task<IEnumerable<SheduledTransactionList>> GetTodayActiveTransactionScheduleAsync();
        void UpdateNextTransactionDate(int id, System.DateTime dtAddDates);
        Task<IEnumerable<SheduledTransactionList>> GetSheduledTransactionsAsync();
        Task<SheduledTransactionList> GetSheduledTransactionByIdAsync(int id);
    }
}
