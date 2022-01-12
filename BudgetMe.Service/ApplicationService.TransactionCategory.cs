using BudgetMe.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BudgetMe.Service
{
    public partial class ApplicationService
    {
        public async Task<TransactionCategoryEntity> InsertTransactionCategoryAsync(TransactionCategoryEntity transactionParty)
        {
            if (IsTransactionCategoryCodeUsed(transactionParty.Code))
            {
                throw new Exception("Transaction Party already used");
            }

            int tpId = await _transactionCategoryModel.InsertTransactionCategoryAsync(transactionParty);
            transactionParty = await _transactionCategoryModel.GetTransactionCategoryByIdAsync(tpId);

            IList<TransactionCategoryEntity> transactionCategories = TransactionCategories.ToList();
            transactionCategories.Add(transactionParty);
            TransactionCategories = transactionCategories;

            return transactionParty;
        }

        public bool IsTransactionCategoryCodeUsed(string code) =>
            TransactionCategories.Any(tp => tp.Code?.ToUpper() == code?.ToUpper());

        public bool IsTransactionCategoryCodeUsedWithoutCurrent(string code, int currentId) =>
            TransactionCategories.Any(tp => tp.Code?.ToUpper() == code?.ToUpper() && tp.Id != currentId);

        public async Task<TransactionCategoryEntity> UpdateTransactionCategoryAsync(TransactionCategoryEntity transactionParty)
        {
            if (IsTransactionCategoryCodeUsedWithoutCurrent(transactionParty.Code, transactionParty.Id))
            {
                throw new Exception("Transaction Party already used");
            }

            await _transactionCategoryModel.UpdateTransactionCategoryAsync(transactionParty);
            transactionParty = await _transactionCategoryModel.GetTransactionCategoryByIdAsync(transactionParty.Id);

            IEnumerable<TransactionCategoryEntity> transactionCategories = await _transactionCategoryModel.GetTransactionCategoriesAsync();
            TransactionCategories = transactionCategories;

            return transactionParty;
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
