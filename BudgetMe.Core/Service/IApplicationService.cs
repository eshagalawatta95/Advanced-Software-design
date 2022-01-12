using BudgetMe.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetMe.Core.Service
{
    public partial interface IApplicationService
    {
        event NotifyDataChangesEvent<UserEntity> CurrentUserOnChange;
        UserEntity CurrentUser { get; }
        event NotifyDataChangesListEvent<TransactionLogEntity> TransactionLogsOnChange;
        IEnumerable<TransactionLogEntity> TransactionLogs { get; }
        event NotifyDataChangesListEvent<TransactionEntity> TransactionsOnChange;
        event NotifyDataChangesListEvent<SheduledTransactionList> ScheduleTransactionsOnChange;
        IEnumerable<TransactionEntity> Transactions { get; }
        event NotifyDataChangesListEvent<TransactionCategoryEntity> TransactionCategoriesOnChange;
        IEnumerable<TransactionCategoryEntity> TransactionCategories { get; }
        Task InitialLoadingProcessAsync(Action<string> setProgressStatusTextAction, Action loadMainForm, Action showUserRegistraion);
        void ReleaseResourcesToExit(Action<string> SetProgressStatusText, Action preventApplicationExitAction, Action exitApplicationAction);
        Task<UserEntity> InsertUserEntityAsync(UserEntity userEntity);
        Task<TransactionCategoryEntity> InsertTransactionCategoryAsync(TransactionCategoryEntity transactionCategory);
        bool IsTransactionCategoryCodeUsed(string code);
        bool IsTransactionCategoryCodeUsedWithoutCurrent(string code, int currentId);
        Task<TransactionCategoryEntity> UpdateTransactionCategoryAsync(TransactionCategoryEntity transactionCategory);
        Task DeleteTransactionCategoryAsync(int id);
        Task<TransactionEntity> InsertTransactionAsync(TransactionEntity transaction, bool isUserPerformed = false);
        Task<TransactionEntity> UpdateTransactionAsync(TransactionEntity transaction);
        Task DeleteTransactionAsync(int id);
        Task DeleteSheduledTransactionAsync(int id);
        Task<SheduledTransactionList> InsertSheduledTransactionListAsync(SheduledTransactionList transaction);
        Task<SheduledTransactionList> UpdateSheduledTransactionListAsync(SheduledTransactionList transaction);     
        Task AutoRunMethod();
        IEnumerable<SheduledTransactionList> SheduledTransactions { get; }
    }
}
