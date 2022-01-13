using BudgetMe.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BudgetMe.Service
{
    public partial class ApplicationService
    {
        public async Task<TransactionCategoryEntity> InsertTransactionCategoryAsync(TransactionCategoryEntity transactionCategory)
        {
            if (IsTransactionCategoryCodeUsed(transactionCategory.Code))
            {
                throw new Exception("Transaction Category already used");
            }

            int tpId = await _transactionCategoryModel.InsertTransactionCategoryAsync(transactionCategory);
            transactionCategory = await _transactionCategoryModel.GetTransactionCategoryByIdAsync(tpId);

            IList<TransactionCategoryEntity> transactionCategories = TransactionCategories.ToList();
            transactionCategories.Add(transactionCategory);
            TransactionCategories = transactionCategories;

            return transactionCategory;
        }

        public bool IsTransactionCategoryCodeUsed(string code) =>
            TransactionCategories.Any(tp => tp.Code?.ToUpper() == code?.ToUpper());

        public bool IsTransactionCategoryCodeUsedWithoutCurrent(string code, int currentId) =>
            TransactionCategories.Any(tp => tp.Code?.ToUpper() == code?.ToUpper() && tp.Id != currentId);

        public async Task<TransactionCategoryEntity> UpdateTransactionCategoryAsync(TransactionCategoryEntity transactionCategory)
        {
            if (IsTransactionCategoryCodeUsedWithoutCurrent(transactionCategory.Code, transactionCategory.Id))
            {
                throw new Exception("Transaction Category already used");
            }

            await _transactionCategoryModel.UpdateTransactionCategoryAsync(transactionCategory);
            transactionCategory = await _transactionCategoryModel.GetTransactionCategoryByIdAsync(transactionCategory.Id);

            IEnumerable<TransactionCategoryEntity> transactionCategories = await _transactionCategoryModel.GetTransactionCategoriesAsync();
            TransactionCategories = transactionCategories;

            return transactionCategory;
        }

        public async Task DeleteTransactionCategoryAsync(int id)
        {
            await _transactionCategoryModel.DeleteTransactionCategoryAsync(id);

            IList<TransactionCategoryEntity> transactionCategories = TransactionCategories.ToList();
            TransactionCategoryEntity transactionCategory = transactionCategories.First(tp => tp.Id == id);
            transactionCategory.IsActive = false;
            transactionCategories.Add(transactionCategory);
            TransactionCategories = transactionCategories;
        }
    }
}
