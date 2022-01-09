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
    public class UserModel : IUserModel
    {
        public UserEntity ReaderToEntity(SQLiteDataReader reader)
        {
            return new UserEntity()
            {
                Id = int.Parse(reader["Id"].ToString()),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                StartingAmount = double.Parse(reader["StartingAmount"].ToString()),
                CurrentBalance = double.Parse(reader["CurrentBalance"].ToString()),
                RegisteredDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["RegisteredDateTime"].ToString())),
                LastCheckDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["LastCheckDateTime"].ToString()))
            };
        }

        public async Task<UserEntity> GetUserDetailsAsync()
        {
            string query = "SELECT `Id`,`FirstName`,`LastName`,`RegisteredDateTime`,`StartingAmount`,`CurrentBalance`,`LastCheckDateTime` FROM `User` WHERE `SID` = @SID";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@SID", System.Security.Principal.WindowsIdentity.GetCurrent().User.Value.ToString()),
            };

            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity,parameters);
        }

        public async Task<int> InsertUserDetailsAsync(UserEntity userEntity)
        {
            userEntity.CurrentBalance = userEntity.StartingAmount;
            userEntity.RegisteredDateTime = DateTime.Now;
            userEntity.LastCheckDateTime = DateTime.Now;

            string query = @"INSERT INTO `User`
                (`FirstName`,`LastName`,`SID`,`RegisteredDateTime`,`StartingAmount`,`CurrentBalance`,`LastCheckDateTime`) 
                VALUES (@FirstName,@LastName,@SID,@RegisteredDateTime,@StartingAmount,@CurrentBalance,@LastCheckDateTime);";

            IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@FirstName", userEntity.FirstName),
                new KeyValuePair<string, object>("@LastName", userEntity.LastName),
                new KeyValuePair<string, object>("@SID", userEntity.SID),
                new KeyValuePair<string, object>("@RegisteredDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(userEntity.RegisteredDateTime)),
                new KeyValuePair<string, object>("@StartingAmount", userEntity.StartingAmount),
                new KeyValuePair<string, object>("@CurrentBalance", userEntity.CurrentBalance),
                new KeyValuePair<string, object>("@LastCheckDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(userEntity.LastCheckDateTime))
            };

            return await SqliteConnector.ExecuteInsertQueryAsync(query, parameters: parameters, true);
        }

        public async Task<int> UpdateUserCurrentBalanceAsync(double balance)
        {
            string query = @"UPDATE `User` SET `CurrentBalance`=@CurrentBalance;";

            IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@CurrentBalance", balance)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters: parameters, true);
        }

        public async Task<int> UpdateUserLastCheckDateTimeAsync(DateTime dateTime)
        {
            string query = @"UPDATE `User` SET `LastCheckDateTime`=@LastCheckDateTime;";

            IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {

                new KeyValuePair<string, object>("@LastCheckDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(dateTime))
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters: parameters, true);
        }
    }
}
