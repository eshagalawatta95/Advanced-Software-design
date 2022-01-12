using BudgetMe.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetMe.Core.Models
{
    public interface ITransactionCategoryModel : IModel
    {
        Task<TransactionCategoryEntity> GetTransactionCategoryByIdAsync(int id);
        Task<IEnumerable<TransactionCategoryEntity>> GetTransactionCategoriesAsync();
        Task<int> InsertTransactionCategoryAsync(TransactionCategoryEntity transactionCategoryEntity);
        Task<int> UpdateTransactionCategoryAsync(TransactionCategoryEntity transactionCategoryEntity);
        Task<int> DeleteTransactionCategoryAsync(int id);
    }
}
