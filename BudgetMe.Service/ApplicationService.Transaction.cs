using BudgetMe.Entities;
using BudgetMe.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetMe.Service
{
    public partial class ApplicationService
    {
        static SemaphoreSlim _insertTransactionSemaphoreSlim = new SemaphoreSlim(1, 1);
        ApplicationErrorLog applicationErrorLog = new ApplicationErrorLog();

        public async Task<TransactionEntity> InsertTransactionAsync(TransactionEntity transaction, bool isUserPerformed = false)
        {
            await _insertTransactionSemaphoreSlim.WaitAsync();
            try
            {
                int tId = await _transactionModel.InsertTransactionAsync(transaction, isUserPerformed);
                transaction = await _transactionModel.GetTransactionByIdAsync(tId);

                IList<TransactionEntity> transactions = Transactions.ToList();
                transactions.Add(transaction);

                double startingBalance = CurrentUser.CurrentBalance;
                double newBalance = startingBalance + ((transaction.IsIncome ? 1 : -1) * transaction.Amount);

                await _transactionCategoryModel.UpdateTransactionCategoryBalanceAsync(transaction.TransactionCategoryId, transaction.Amount, transaction.IsIncome);

                await _userModel.UpdateUserCurrentBalanceAsync(newBalance);
                UserEntity userEntity = await _userModel.GetUserDetailsAsync();
                TransactionCategories = await _transactionCategoryModel.GetTransactionCategoriesAsync();

                TransactionLogEntity transactionLog = new TransactionLogEntity()
                {
                    Amount = transaction.Amount,
                    IsIncome = transaction.IsIncome,
                    IsDeletedTransaction = false,
                    ScheduledTransactionId = transaction.ScheduledTransactionId,
                    TransactionDateTime = transaction.TransactionDateTime,
                    CreatedDateTime = DateTime.Now,
                    IsUserPerformed = isUserPerformed,
                    TransactionId = transaction.Id,
                    TransactionCategoryId = transaction.TransactionCategoryId,
                    Remarks = $"Transaction: {transaction.ReferenceNumber} Added",
                    StartingBalance = startingBalance,
                    FinalBalance = newBalance,
                };

                int tlId = await _transactionLogModel.InsertTransactionLogAsync(transactionLog);
                transactionLog = await _transactionLogModel.GetTransactionLogByIdAsync(tlId);

                IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
                transactionLogs.Add(transactionLog);

                Transactions = transactions;
                TransactionLogs = transactionLogs;
                CurrentUser = userEntity;

                return transaction;
            }
            catch (Exception k)
            {
                applicationErrorLog.ErrorLog("Transaction", "Insert onetime transaction", k.ToString());
                return transaction;
            }
            finally
            {
                _insertTransactionSemaphoreSlim.Release();
            }
        }

        public async Task<SheduledTransactionList> InsertSheduledTransactionListAsync(SheduledTransactionList transaction)
        {
            await _insertTransactionSemaphoreSlim.WaitAsync();
            try
            {
                UserEntity userEntity = await _userModel.GetUserDetailsAsync();
                transaction.CreatedUser = userEntity.Id;
                int tId = await _transactionModel.InsertScheduledTransactionListAsync(transaction);
                transaction = await _transactionModel.GetSheduledTransactionByIdAsync(tId);
                IList<SheduledTransactionList> transactions = SheduledTransactions.ToList();
                transactions.Add(transaction);
                SheduledTransactions = transactions;
                CurrentUser = userEntity;
                return transaction;
            }
            catch (Exception k)
            {
                applicationErrorLog.ErrorLog("Transaction", "Insert Sheduled transaction", k.ToString());
                return transaction;
            }
            finally
            {
                _insertTransactionSemaphoreSlim.Release();
            }
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transactionModel.DeleteTransactionAsync(id);
            TransactionEntity transaction = await _transactionModel.GetTransactionByIdAsync(id);

            double startingBalance = CurrentUser.CurrentBalance;
            double newBalance = startingBalance + (transaction.IsIncome ? -1 : 1) * transaction.Amount; // Reversed because transaction deleted

            await _transactionCategoryModel.UpdateTransactionCategoryBalanceAsync(transaction.TransactionCategoryId, -1*transaction.Amount, transaction.IsIncome);

            await _userModel.UpdateUserCurrentBalanceAsync(newBalance);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();
            TransactionCategories = await _transactionCategoryModel.GetTransactionCategoriesAsync();
            TransactionLogEntity transactionLog = new TransactionLogEntity()
            {
                Amount = transaction.Amount,
                IsIncome = !transaction.IsIncome,
                IsDeletedTransaction = true,
                ScheduledTransactionId = transaction.ScheduledTransactionId,
                TransactionDateTime = DateTime.Now,
                CreatedDateTime = DateTime.Now,
                IsUserPerformed = true,
                TransactionId = transaction.Id,
                TransactionCategoryId = transaction.TransactionCategoryId,
                Remarks = $"Transaction: {transaction.ReferenceNumber} Deleted",
                StartingBalance = startingBalance,
                FinalBalance = newBalance,
            };

            int tlId = await _transactionLogModel.InsertTransactionLogAsync(transactionLog);
            transactionLog = await _transactionLogModel.GetTransactionLogByIdAsync(tlId);

            IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
            transactionLogs.Add(transactionLog);

            IList<TransactionEntity> transactions = Transactions.ToList();
            TransactionEntity deletedTransaction = transactions.First(tp => tp.Id == id);
            deletedTransaction.IsActive = false;

            Transactions = transactions;
            TransactionLogs = transactionLogs;
            CurrentUser = userEntity;
        }

        public async Task<TransactionEntity> UpdateTransactionAsync(TransactionEntity transaction)
        {
            TransactionEntity beforeTransaction = await _transactionModel.GetTransactionByIdAsync(transaction.Id);
            await _transactionModel.UpdateTransactionAsync(transaction);
            TransactionEntity afterTransaction = await _transactionModel.GetTransactionByIdAsync(transaction.Id);
            
            //get diffrent amount
            double differenceIncome = (afterTransaction.IsIncome ? 1 : -1) * afterTransaction.Amount - (beforeTransaction.IsIncome ? 1 : -1) * beforeTransaction.Amount;

            double startingBalance = CurrentUser.CurrentBalance;
            double newBalance = startingBalance + differenceIncome;

            await _transactionCategoryModel.UpdateTransactionCategoryBalanceAsync(transaction.TransactionCategoryId, differenceIncome, transaction.IsIncome);

            await _userModel.UpdateUserCurrentBalanceAsync(newBalance);
            TransactionCategories = await _transactionCategoryModel.GetTransactionCategoriesAsync();
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();

            TransactionLogEntity transactionLog = new TransactionLogEntity()
            {
                Amount = Math.Abs(differenceIncome),
                IsIncome = differenceIncome > 0,
                IsDeletedTransaction = false,
                ScheduledTransactionId = transaction.ScheduledTransactionId,
                TransactionDateTime = transaction.TransactionDateTime,
                CreatedDateTime = DateTime.Now,
                IsUserPerformed = true,
                TransactionId = transaction.Id,
                TransactionCategoryId = transaction.TransactionCategoryId,
                Remarks = $"Transaction: {beforeTransaction.ReferenceNumber} Updated; Diff: {differenceIncome}",
                StartingBalance = startingBalance,
                FinalBalance = newBalance,
            };

            int tlId = await _transactionLogModel.InsertTransactionLogAsync(transactionLog);
            transactionLog = await _transactionLogModel.GetTransactionLogByIdAsync(tlId);

            IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
            transactionLogs.Add(transactionLog);

            IEnumerable<TransactionEntity> transactions = await _transactionModel.GetTransactionsAsync();

            Transactions = transactions;
            TransactionLogs = transactionLogs;
            CurrentUser = userEntity;

            return afterTransaction;
        }

        public async Task<SheduledTransactionList> UpdateSheduledTransactionListAsync(SheduledTransactionList transaction)
        {
            await _transactionModel.UpdateScheduledTransactionListAsync(transaction);
            IEnumerable<SheduledTransactionList> transactions = await _transactionModel.GetSheduledTransactionsAsync();
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();

            SheduledTransactions = transactions;
            CurrentUser = userEntity;
            return transaction;
        }

        public async Task DeleteSheduledTransactionAsync(int id)
        {
            await _transactionModel.DeleteSheduledTransactionAsync(id);
           
            IList<SheduledTransactionList> transactions = SheduledTransactions.ToList();
            SheduledTransactionList deletedTransaction = transactions.First(tp => tp.Id == id);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();
            deletedTransaction.IsActive = false;
            SheduledTransactions = transactions;
            CurrentUser = userEntity;
        }

        public bool IsOverDraft(int transactionCategory,double amount, bool isIncome)
        {
            if (isIncome) return false;

            TransactionCategoryEntity result = TransactionCategories.Where(x => x.Id == transactionCategory).FirstOrDefault();
            double val = result.CurrentAmount + amount;
            if(result.MaxAmount != 0)
            {
                if (result.MaxAmount < val)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

    }
}
