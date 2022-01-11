using BudgetMe.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetMe.Core.Models
{
    public interface ITransactionPartyModel : IModel
    {
        Task<TransactionPartyEntity> GetTransactionPartyByIdAsync(int id);
        Task<IEnumerable<TransactionPartyEntity>> GetTransactionPartiesAsync();
        Task<int> InsertTransactionPartyAsync(TransactionPartyEntity transactionPartyEntity);
        Task<int> UpdateTransactionPartyAsync(TransactionPartyEntity transactionPartyEntity);
        Task<int> DeleteTransactionPartyAsync(int id);
    }
}
