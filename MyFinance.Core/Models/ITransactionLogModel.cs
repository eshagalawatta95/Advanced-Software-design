using MyFinance.Core.Models;
using MyFinance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.Core.Models
{
    public interface ITransactionLogModel : IModel
    {
        Task<TransactionLogEntity> GetTransactionLogByIdAsync(int id);
        Task<IEnumerable<TransactionLogEntity>> GetTransactionLogsAsync();
        Task<int> InsertTransactionLogAsync(TransactionLogEntity transactionLogEntity);
    }
}
