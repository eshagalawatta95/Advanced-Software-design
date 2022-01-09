using MyFinance.Core.Models;
using MyFinance.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.Core.Service
{
    public partial interface IApplicationService
    {
        event NotifyDataChangesEvent<UserEntity> CurrentUserOnChange;
        UserEntity CurrentUser { get; }

        event NotifyDataChangesListEvent<TransactionLogEntity> TransactionLogsOnChange;
        IEnumerable<TransactionLogEntity> TransactionLogs { get; }

        event NotifyDataChangesListEvent<TransactionEntity> TransactionsOnChange;

        event NotifyDataChangesListEvent<SheduledTransactionList> ScheduleTransactionsOnChange;
        event NotifyDataChangesListEvent<ScheduledTasks> ScheduledTasksOnChange;
        IEnumerable<TransactionEntity> Transactions { get; }
        event NotifyDataChangesListEvent<TransactionPartyEntity> TransactionPartiesOnChange;
        IEnumerable<TransactionPartyEntity> TransactionParties { get; }

        Task InitialLoadingProcessAsync(Action<string> setProgressStatusTextAction, Action loadMainForm, Action showUserRegistraion);
        void ReleaseResourcesToExit(Action<string> SetProgressStatusText, Action preventApplicationExitAction, Action exitApplicationAction);
        Task<UserEntity> InsertUserEntityAsync(UserEntity userEntity);


        Task<TransactionPartyEntity> InsertTransactionPartyAsync(TransactionPartyEntity transactionParty);
        bool IsTransactionPartyCodeUsed(string code);
        bool IsTransactionPartyCodeUsedWithoutCurrent(string code, int currentId);
        Task<TransactionPartyEntity> UpdateTransactionPartyAsync(TransactionPartyEntity transactionParty);
        Task DeleteTransactionPartyAsync(int id);

        Task<TransactionEntity> InsertTransactionAsync(TransactionEntity transaction, bool isUserPerformed = false);
        Task<TransactionEntity> UpdateTransactionAsync(TransactionEntity transaction);
        Task DeleteTransactionAsync(int id);
        Task DeleteSheduledTransactionAsync(int id);
        Task<SheduledTransactionList> InsertSheduledTransactionListAsync(SheduledTransactionList transaction);
        Task<SheduledTransactionList> UpdateSheduledTransactionListAsync(SheduledTransactionList transaction);
        bool IsAvailableEnoughtData(int monthBack);
        Task<PredictionEntity> GetPredictionsAsync(int monthsBack, DateTime predictDate);
        Task AutoRunMethod();

        event NotifyDataChangesListEvent<OneTimeTasks> TasksOnChange;
        IEnumerable<SheduledTransactionList> SheduledTransactions { get; }

        IEnumerable<OneTimeTasks> OneTimeTasks { get; }
        IEnumerable<ScheduledTasks> ScheduledTasks { get; }

        Task<OneTimeTasks> InsertTaskAsync(OneTimeTasks task, bool isUserPerformed = false);
        Task<OneTimeTasks> UpdateTaskAsync(OneTimeTasks task);
        Task<ScheduledTasks> InsertSheduledTasktAsync(ScheduledTasks task);
        Task<ScheduledTasks> UpdateSheduledTaskListAsync(ScheduledTasks task);
        Task DeleteTaskAsync(int id);
        Task DeleteSheduledTaskAsync(int id);
    }
}
