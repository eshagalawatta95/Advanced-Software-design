using MyFinance.Methods;
using MyFinance.Core.Models;
using MyFinance.DataAccess;
using MyFinance.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class TransactionPartyModel : ITransactionPartyModel
    {
        public TransactionPartyEntity ReaderToEntity(SQLiteDataReader reader)
        {
            return new TransactionPartyEntity()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Code = reader["Code"].ToString(),
                Description = reader["Description"].ToString(),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                IsActive = Convert.ToBoolean(int.Parse(reader["IsActive"].ToString()))
            };
        }

        public async Task<TransactionPartyEntity> GetTransactionPartyByIdAsync(int id)
        {
            string query = "SELECT * FROM `TransactionParty` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity, parameters);
        }

        public async Task<IEnumerable<TransactionPartyEntity>> GetTransactionPartiesAsync()
        {
            string query = "SELECT * FROM `TransactionParty`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntity);
        }

        public async Task<int> InsertTransactionPartyAsync(TransactionPartyEntity transactionPartyEntity)
        {
            string query = "INSERT INTO `TransactionParty`" +
                "(`Code`,`Description`,`CreatedDateTime`) " +
                "VALUES (@Code,@Description,@CreatedDateTime);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Code", transactionPartyEntity.Code),
                new KeyValuePair<string, object>("@Description", transactionPartyEntity.Description),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionPartyEntity.CreatedDateTime))
            };

            return await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);
        }

        public async Task<int> UpdateTransactionPartyAsync(TransactionPartyEntity transactionPartyEntity)
        {
            string query = "UPDATE `TransactionParty` " +
                "SET `Code`=@Code,`Description`=@Description " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Code", transactionPartyEntity.Code),
                new KeyValuePair<string, object>("@Description", transactionPartyEntity.Description),
                new KeyValuePair<string, object>("@Id", transactionPartyEntity.Id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> DeleteTransactionPartyAsync(int id)
        {
            string query = "UPDATE `TransactionParty` " +
                "SET `IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsActive", 0),
                new KeyValuePair<string, object>("@Id", id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
    }
}
