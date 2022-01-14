using BudgetMe.Methods;
using BudgetMe.Core.Models;
using BudgetMe.DataAccess;
using BudgetMe.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace BudgetMe.Models
{
    public class TransactionCategoryModel : ITransactionCategoryModel
    {
        public TransactionCategoryEntity ReaderToEntity(SQLiteDataReader reader)
        {
            return new TransactionCategoryEntity()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Code = reader["Code"].ToString(),
                Description = reader["Description"].ToString(),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                MaxAmount = double.Parse(reader["MaxAmount"].ToString()),
                IsActive = Convert.ToBoolean(int.Parse(reader["IsActive"].ToString()))
            };
        }

        public async Task<TransactionCategoryEntity> GetTransactionCategoryByIdAsync(int id)
        {
            string query = "SELECT * FROM `TransactionCategory` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity, parameters);
        }

        public async Task<IEnumerable<TransactionCategoryEntity>> GetTransactionCategoriesAsync()
        {
            string query = "SELECT * FROM `TransactionCategory`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntity);
        }

        public async Task<int> InsertTransactionCategoryAsync(TransactionCategoryEntity transactionCategoryEntity)
        {
            string query = "INSERT INTO `TransactionCategory`" +
                "(`Code`,`Description`,`MaxAmount`,`CreatedDateTime`) " +
                "VALUES (@Code,@Description,@MaxAmount,@CreatedDateTime);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Code", transactionCategoryEntity.Code),
                new KeyValuePair<string, object>("@MaxAmount", transactionCategoryEntity.MaxAmount),
                new KeyValuePair<string, object>("@Description", transactionCategoryEntity.Description),               
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionCategoryEntity.CreatedDateTime))
            };

            return await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);
        }

        public async Task<int> UpdateTransactionCategoryAsync(TransactionCategoryEntity transactionCategoryEntity)
        {
            string query = "UPDATE `TransactionCategory` " +
                "SET `Code`=@Code,`Description`=@Description,`MaxAmount`=@MaxAmount " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Code", transactionCategoryEntity.Code),
                new KeyValuePair<string, object>("@MaxAmount", transactionCategoryEntity.MaxAmount),
                new KeyValuePair<string, object>("@Description", transactionCategoryEntity.Description),
                new KeyValuePair<string, object>("@Id", transactionCategoryEntity.Id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> DeleteTransactionCategoryAsync(int id)
        {
            string query = "UPDATE `TransactionCategory` " +
                "SET `IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsActive", 0),
                new KeyValuePair<string, object>("@Id", id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> UpdateTransactionCategoryBalanceAsync(int transactionCategoryId, double currentAmount, bool isIncome)
        {
            if (isIncome) return 0;

            TransactionCategoryEntity obj= await GetTransactionCategoryByIdAsync(transactionCategoryId);
            currentAmount += obj.CurrentAmount;

            string query = "UPDATE `TransactionCategory` " +
                "SET `CurrentAmount`=@CurrentAmount " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@CurrentAmount", currentAmount),
                new KeyValuePair<string, object>("@Id", transactionCategoryId)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
    }
}
