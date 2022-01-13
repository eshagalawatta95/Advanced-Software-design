using BudgetMe.Core.Models;
using BudgetMe.DataAccess;
using BudgetMe.Entities;
using BudgetMe.Methods;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace BudgetMe.Models
{
    public class TransactionLogModel : ITransactionLogModel
    {
        public TransactionLogEntity ReaderToEntity(SQLiteDataReader reader)
        {
            return new TransactionLogEntity()
            {
                Id = int.Parse(reader["Id"].ToString()),
                TransactionId = int.Parse(reader["TransactionId"].ToString()),
                TransactionCategoryId = int.Parse(reader["TransactionCategoryId"].ToString()),
                ScheduledTransactionId = reader["ScheduledTransactionId"] == DBNull.Value ? null : (int?)int.Parse(reader["ScheduledTransactionId"].ToString()),
                IsDeletedTransaction = Convert.ToBoolean(int.Parse(reader["IsDeletedTransaction"].ToString())),
                IsIncome = Convert.ToBoolean(int.Parse(reader["IsIncome"].ToString())),
                Amount = double.Parse(reader["Amount"].ToString()),
                StartingBalance = double.Parse(reader["StartingBalance"].ToString()),
                FinalBalance = double.Parse(reader["FinalBalance"].ToString()),
                Remarks = reader["Remarks"].ToString(),
                TransactionDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["TransactionDateTime"].ToString())),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                IsUserPerformed = Convert.ToBoolean(int.Parse(reader["IsUserPerformed"].ToString()))
            };
        }

        public async Task<TransactionLogEntity> GetTransactionLogByIdAsync(int id)
        {
            string query = "SELECT * FROM `TransactionLog` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity, parameters);
        }

        public async Task<IEnumerable<TransactionLogEntity>> GetTransactionLogsAsync()
        {
            string query = "SELECT * FROM `TransactionLog`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntity);
        }

        public async Task<int> InsertTransactionLogAsync(TransactionLogEntity transactionLogEntity)
        {
            string query = "INSERT INTO `TransactionLog`" +
                "(`TransactionId`,`ScheduledTransactionId`,`TransactionCategoryId`,`IsDeletedTransaction`,`IsIncome`,`TransactionDateTime`,`Amount`,`StartingBalance`,`FinalBalance`,`Remarks`,`CreatedDateTime`,`IsUserPerformed`) " +
                "VALUES(@TransactionId,@ScheduledTransactionId,@TransactionCategoryId,@IsDeletedTransaction,@IsIncome,@TransactionDateTime,@Amount,@StartingBalance,@FinalBalance,@Remarks,@CreatedDateTime,@IsUserPerformed);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionId", transactionLogEntity.TransactionId),
                new KeyValuePair<string, object>("@ScheduledTransactionId", transactionLogEntity.ScheduledTransactionId),
                new KeyValuePair<string, object>("@TransactionCategoryId", transactionLogEntity.TransactionCategoryId),
                new KeyValuePair<string, object>("@IsDeletedTransaction", transactionLogEntity.IsDeletedTransaction ? 1 : 0),
                new KeyValuePair<string, object>("@IsIncome", transactionLogEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@Amount", transactionLogEntity.Amount),
                new KeyValuePair<string, object>("@StartingBalance", transactionLogEntity.StartingBalance),
                new KeyValuePair<string, object>("@FinalBalance", transactionLogEntity.FinalBalance),
                new KeyValuePair<string, object>("@Remarks", transactionLogEntity.Remarks),
                new KeyValuePair<string, object>("@TransactionDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionLogEntity.TransactionDateTime)),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionLogEntity.CreatedDateTime)),
                new KeyValuePair<string, object>("@IsUserPerformed", transactionLogEntity.IsUserPerformed ? 1 : 0)
            };

            return await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);
        }
    }
}
