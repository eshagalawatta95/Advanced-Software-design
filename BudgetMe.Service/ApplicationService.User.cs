using BudgetMe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMe.Service
{
    public partial class ApplicationService
    {
        public async Task<UserEntity> InsertUserEntityAsync(UserEntity userEntity)
        {
            int id = await _userModel.InsertUserDetailsAsync(userEntity);
            CurrentUser = await _userModel.GetUserDetailsAsync();

            TransactionLogEntity transactionLogEntity = new TransactionLogEntity()
            {
                TransactionId = 0,
                TransactionCategoryId = 1, // OWN
                ScheduledTransactionId = null,
                IsDeletedTransaction = false,
                IsIncome = true,
                TransactionDateTime = DateTime.Now,
                Amount = userEntity.StartingAmount,
                StartingBalance = 0,
                FinalBalance = userEntity.StartingAmount,
                CreatedDateTime = DateTime.Now,
                IsUserPerformed = true,
                Remarks = "Starting Balance"
            };
            int tranLogId = await _transactionLogModel.InsertTransactionLogAsync(transactionLogEntity);
            transactionLogEntity = await _transactionLogModel.GetTransactionLogByIdAsync(tranLogId);

            IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
            transactionLogs.Add(transactionLogEntity);
            TransactionLogs = transactionLogs;

            return CurrentUser;
        }
    }
}
