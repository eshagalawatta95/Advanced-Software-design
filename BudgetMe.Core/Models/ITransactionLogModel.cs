using BudgetMe.Core.Models;
using BudgetMe.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetMe.Core.Models
{
    public interface ITransactionLogModel : IModel
    {
        Task<TransactionLogEntity> GetTransactionLogByIdAsync(int id);
        Task<IEnumerable<TransactionLogEntity>> GetTransactionLogsAsync();
        Task<int> InsertTransactionLogAsync(TransactionLogEntity transactionLogEntity);
    }
}
