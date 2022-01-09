using MyFinance.Core.Models;
using MyFinance.DataAccess;
using MyFinance.Methods;
using MyFinance.Core.Models;
using MyFinance.DataAccess;
using MyFinance.Entities;
using MyFinance.Methods;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class TransactionModel : ITransactionModel
    {
        public TransactionEntity ReaderToEntity(SQLiteDataReader reader)
        {
            return new TransactionEntity()
            {
                Id = int.Parse(reader["Id"].ToString()),
                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                TransactionPartyId = int.Parse(reader["TransactionPartyId"].ToString()),
                ScheduledTransactionId = reader["ScheduledTransactionId"] == DBNull.Value ? null : (int?)int.Parse(reader["ScheduledTransactionId"].ToString()),
                IsIncome = Convert.ToBoolean(int.Parse(reader["IsIncome"].ToString())),
                Amount = double.Parse(reader["Amount"].ToString()),
                Remarks = reader["Remarks"].ToString(),
                TransactionDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["TransactionDateTime"].ToString())),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                IsUserPerformed = Convert.ToBoolean(int.Parse(reader["IsUserPerformed"].ToString())),
                IsActive = Convert.ToBoolean(int.Parse(reader["IsActive"].ToString()))
            };
        }

        public SheduledTransactionList ReaderToEntitySheduledTransactionList(SQLiteDataReader reader)
        {
            return new SheduledTransactionList()
            {
                Id = int.Parse(reader["Id"].ToString()),
                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                TransactionPartyId = int.Parse(reader["TransactionPartyId"].ToString()),
                IsIncome = Convert.ToBoolean(int.Parse(reader["IsIncome"].ToString())),
                IsActive = Convert.ToBoolean(int.Parse(reader["IsActive"].ToString())),
                InfiniteSchedule = Convert.ToBoolean(int.Parse(reader["InfiniteSchedule"].ToString())),
                Amount = double.Parse(reader["Amount"].ToString()),
                Remarks = reader["Remarks"].ToString(),
                RepeatType = reader["RepeatType"].ToString(),
                EndDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["EndDateTime"].ToString())),
                NextTransactionDate = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["NextTransactionDate"].ToString()))
            };
        }

        public async Task<TransactionEntity> GetTransactionByIdAsync(int id)
        {
            string query = "SELECT * FROM `Transaction` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity, parameters);
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsAsync()
        {
            string query = "SELECT * FROM `Transaction`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntity);
        }

        public async Task<int> InsertTransactionAsync(TransactionEntity transactionEntity, bool isUserPerformed = false)
        {
            string query = "INSERT INTO `Transaction`" +
                "(`TransactionPartyId`,`Amount`,`IsIncome`,`TransactionDateTime`,`ScheduledTransactionId`,`Remarks`,`CreatedDateTime`,`IsUserPerformed`) " +
                "VALUES (@TransactionPartyId,@Amount,@IsIncome,@TransactionDateTime,@ScheduledTransactionId,@Remarks,@CreatedDateTime,@IsUserPerformed);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionPartyId", transactionEntity.TransactionPartyId),
                new KeyValuePair<string, object>("@Amount", transactionEntity.Amount),
                new KeyValuePair<string, object>("@IsIncome", transactionEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@TransactionDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.TransactionDateTime)),
                new KeyValuePair<string, object>("@ScheduledTransactionId", transactionEntity.ScheduledTransactionId),
                new KeyValuePair<string, object>("@Remarks", transactionEntity.Remarks),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.CreatedDateTime)),
                new KeyValuePair<string, object>("@IsUserPerformed", isUserPerformed ? 1 : 0)
            };

            int id = await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);

            query = "UPDATE `Transaction` SET `ReferenceNumber`=@ReferenceNumber WHERE `Id`=@Id";

            parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@ReferenceNumber", id.ToString("TC00000000")),
                new KeyValuePair<string, object>("@Id", id)
            };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

            return id;
        }

        public async Task<int> UpdateTransactionAsync(TransactionEntity transactionEntity)
        {
            string query = "UPDATE `Transaction` " +
                "SET `TransactionPartyId`=@TransactionPartyId,`Amount`=@Amount,`IsIncome`=@IsIncome,`Remarks`=@Remarks,`TransactionDateTime`=@TransactionDateTime " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionPartyId", transactionEntity.TransactionPartyId),
                new KeyValuePair<string, object>("@Amount", transactionEntity.Amount),
                new KeyValuePair<string, object>("@IsIncome", transactionEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@Remarks", transactionEntity.Remarks),
                new KeyValuePair<string, object>("@Id", transactionEntity.Id),
                new KeyValuePair<string, object>("@TransactionDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.TransactionDateTime)),
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> DeleteTransactionAsync(int id)
        {
            string query = "UPDATE `Transaction` " +
                "SET `IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsActive", 0),
                new KeyValuePair<string, object>("@Id", id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> InsertScheduledTransactionListAsync(SheduledTransactionList transactionEntity)
        {
            string query = "INSERT INTO `ScheduledTransaction`" +
                "(`TransactionPartyId`,`Amount`,`IsIncome`,`RepeatType`,`StartDateTime`,`Remarks`,`CreatedDateTime`,`EndDateTime`,`NextTransactionDate`,`InfiniteSchedule`,`IsDelete`,`CreatedUser`,`IsActive`) " +
                "VALUES (@TransactionPartyId,@Amount,@IsIncome,@RepeatType,@StartDateTime,@Remarks,@CreatedDateTime,@EndDateTime,@NextTransactionDate,@InfiniteSchedule,@IsDelete,@CreatedUser,@IsActive);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionPartyId", transactionEntity.TransactionPartyId),
                new KeyValuePair<string, object>("@Amount", transactionEntity.Amount),
                new KeyValuePair<string, object>("@IsIncome", transactionEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@RepeatType", transactionEntity.RepeatType),
                new KeyValuePair<string, object>("@StartDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.StartDateTime)),
                new KeyValuePair<string, object>("@Remarks", transactionEntity.Remarks),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.CreatedDateTime)),
                new KeyValuePair<string, object>("@EndDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.EndDateTime?? transactionEntity.StartDateTime)),
                new KeyValuePair<string, object>("@NextTransactionDate", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.NextTransactionDate)),
                new KeyValuePair<string, object>("@InfiniteSchedule", transactionEntity.InfiniteSchedule ? 1 : 0),
                new KeyValuePair<string, object>("@IsDelete", 0),
                new KeyValuePair<string, object>("@CreatedUser", transactionEntity.CreatedUser),
                new KeyValuePair<string, object>("@IsActive", 1)

            };

            int id = await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);

            query = "UPDATE `ScheduledTransaction` SET `ReferenceNumber`=@ReferenceNumber WHERE `Id`=@Id";

            parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@ReferenceNumber", id.ToString("SYSTC00000000")),
                new KeyValuePair<string, object>("@Id", id)
            };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

            return id;
        }

        public async Task<int> UpdateScheduledTransactionListAsync(SheduledTransactionList transactionEntity)
        {
            string query = "UPDATE `ScheduledTransaction` " +
                "SET `TransactionPartyId`=@TransactionPartyId,`Amount`=@Amount,`RepeatType`=@RepeatType,`StartDateTime`=@StartDateTime,`EndDateTime`=@EndDateTime,`InfiniteSchedule`=@InfiniteSchedule,`NextTransactionDate`=@NextTransactionDate,`IsActive`=@IsActive,`Remarks`=@Remarks " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionPartyId", transactionEntity.TransactionPartyId),
                new KeyValuePair<string, object>("@Amount", transactionEntity.Amount),
                new KeyValuePair<string, object>("@IsIncome", transactionEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@Remarks", transactionEntity.Remarks),
                 new KeyValuePair<string, object>("@RepeatType", transactionEntity.RepeatType),
                new KeyValuePair<string, object>("@StartDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.StartDateTime)),
                new KeyValuePair<string, object>("@EndDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.EndDateTime?? transactionEntity.StartDateTime)),
                new KeyValuePair<string, object>("@NextTransactionDate", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.NextTransactionDate)),
                new KeyValuePair<string, object>("@InfiniteSchedule", transactionEntity.InfiniteSchedule ? 1 : 0),
                new KeyValuePair<string, object>("@IsActive", transactionEntity.IsActive),
                new KeyValuePair<string, object>("@Id", transactionEntity.Id),
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
        public async Task<int> DeleteSheduledTransactionAsync(int id)
        {
            string query = "UPDATE `ScheduledTransaction` " +
                "SET `IsDelete`=@IsDelete,`IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsDelete", 0),
                new KeyValuePair<string, object>("@IsActive", 0),
                new KeyValuePair<string, object>("@Id", id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
        public async Task<IEnumerable<SheduledTransactionList>> GetTodayActiveTransactionScheduleAsync()
        {
            string query = "SELECT * FROM `ScheduledTransaction` WHERE `IsDelete` = 0 ";

            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntitySheduledTransactionList);

        }

        public async void UpdateNextTransactionDate(int id,DateTime dtAddDates){

         string query = "UPDATE `ScheduledTransaction` SET `NextTransactionDate`=@NextTransactionDate WHERE `Id`=@Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id),
                new KeyValuePair<string, object>("@NextTransactionDate", TimeConverterMethods.ConvertDateTimeToTimeStamp(dtAddDates))
            };

          await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

        }

        public async Task<IEnumerable<SheduledTransactionList>> GetSheduledTransactionsAsync()
        {
            string query = "SELECT * FROM `ScheduledTransaction`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntitySheduledTransactionList);
        }

        public async Task<SheduledTransactionList> GetSheduledTransactionByIdAsync(int id)
        {
            string query = "SELECT * FROM `ScheduledTransaction` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntitySheduledTransactionList, parameters);
        }
    }
}
