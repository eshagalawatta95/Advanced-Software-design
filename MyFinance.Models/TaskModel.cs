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
    public class TaskModel : ITaskModel
    {
        public OneTimeTasks ReaderToEntity(SQLiteDataReader reader)
        {
            return new OneTimeTasks()
            {
                Id = int.Parse(reader["Id"].ToString()),
                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                Type = int.Parse(reader["Type"].ToString()),
                IsDelete = Convert.ToBoolean(int.Parse(reader["IsDelete"].ToString())),
                Duration = double.Parse(reader["Duration"].ToString()),
                Comments = reader["Comments"].ToString(),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                Effectivedate = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["Effectivedate"].ToString())),
            };
        }

        public ScheduledTasks ReaderToEntitySheduledTask(SQLiteDataReader reader)
        {
            return new ScheduledTasks()
            {
                Id = int.Parse(reader["Id"].ToString()),
                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                Type = int.Parse(reader["Type"].ToString()),
                IsDelete = Convert.ToBoolean(int.Parse(reader["IsDelete"].ToString())),
                IsActive = Convert.ToBoolean(int.Parse(reader["IsActive"].ToString())),
                Duration = double.Parse(reader["Duration"].ToString()),
                Comments = reader["Comments"].ToString(),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                Effectivedate = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["Effectivedate"].ToString())),
                RepeatType = reader["RepeatType"].ToString(),
                EndDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["EndDateTime"].ToString()))
            };
        }

        public async Task<OneTimeTasks> GetTaskByIdAsync(int id)
        {
            string query = "SELECT * FROM `OneTimeTasks` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity, parameters);
        }

        public async Task<IEnumerable<OneTimeTasks>> GetTaskAsync()
        {
            string query = "SELECT * FROM `OneTimeTasks`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntity);
        }

        public async Task<int> InsertTaskAsync(OneTimeTasks task, bool isUserPerformed = false)
        {
            string query = "INSERT INTO `OneTimeTasks`" +
                "(`Type`,`Comments`,`Duration`,`CreatedUser`,`CreatedDateTime`,`IsDelete`,`Effectivedate`) " +
                "VALUES (@Type,@Comments,@Duration,@CreatedUser,@CreatedDateTime,@IsDelete,@Effectivedate);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Type", task.Type),
                new KeyValuePair<string, object>("@Comments", task.Comments),
                new KeyValuePair<string, object>("@Duration", task.Duration),
                new KeyValuePair<string, object>("@CreatedUser", task.CreatedUser),
                new KeyValuePair<string, object>("@Effectivedate", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.Effectivedate)),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.CreatedDateTime)),
                new KeyValuePair<string, object>("@IsDelete", 0)
            };

            int id = await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);

            query = "UPDATE `OneTimeTasks` SET `ReferenceNumber`=@ReferenceNumber WHERE `Id`=@Id";

            parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@ReferenceNumber", id.ToString("OTASK000000")),
                new KeyValuePair<string, object>("@Id", id)
            };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

            return id;
        }

        public async Task<int> UpdateTaskAsync(OneTimeTasks task)
        {
            string query = "UPDATE `OneTimeTasks` " +
                "SET `Type`=@Type,`Comments`=@Comments,`Duration`=@Duration,`Effectivedate`=@Effectivedate " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Type", task.Type),
                new KeyValuePair<string, object>("@Comments", task.Comments),
                new KeyValuePair<string, object>("@Duration", task.Duration),
                new KeyValuePair<string, object>("@Effectivedate", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.Effectivedate)),
                new KeyValuePair<string, object>("@Id", task.Id),
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async void DeleteTaskAsync(int id)
        {
            string query = "UPDATE `OneTimeTasks` " +
                "SET `IsDelete`=@IsDelete " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsDelete", 1),
                new KeyValuePair<string, object>("@Id", id)
            };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> InsertSheduledTasktAsync(ScheduledTasks task)
        {
            string query = "INSERT INTO `ScheduledTasks`" +
                "(`Type`,`Comments`,`Duration`,`CreatedUser`,`Effectivedate`,`CreatedDateTime`,`IsDelete`,`RepeatType`,`StartDateTime`,`EndDateTime`,`IsDelete`,`IsActive`) " +
                "VALUES (@Type,@Comments,@Duration,@CreatedUser,@Effectivedate,@CreatedDateTime,@IsDelete,@RepeatType,@StartDateTime,@EndDateTime,@IsDelete,@IsActive);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Type", task.Type),
                new KeyValuePair<string, object>("@Comments", task.Comments),
                new KeyValuePair<string, object>("@Duration", task.Duration),
                new KeyValuePair<string, object>("@CreatedUser", task.CreatedUser),
                new KeyValuePair<string, object>("@Effectivedate", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.Effectivedate)),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.CreatedDateTime)),
                new KeyValuePair<string, object>("@IsDelete", 0),
                new KeyValuePair<string, object>("@RepeatType", task.RepeatType),
                new KeyValuePair<string, object>("@StartDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.StartDateTime)),
                new KeyValuePair<string, object>("@EndDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.EndDateTime)),
                new KeyValuePair<string, object>("@IsActive", task.IsActive)

            };

            int id = await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);

            query = "UPDATE `ScheduledTasks` SET `ReferenceNumber`=@ReferenceNumber WHERE `Id`=@Id";

            parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("@ReferenceNumber", id.ToString("STASK000000")),
                    new KeyValuePair<string, object>("@Id", id)
                };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

            return id;
        }

        public async Task<int> UpdateSheduledTaskListAsync(ScheduledTasks task)
        {
            string query = "UPDATE `ScheduledTasks` " +
                "SET `Type`=@Type,`Comments`=@Comments,`Duration`=@Duration,`Effectivedate`=@Effectivedate,`RepeatType`=@RepeatType,`StartDateTime`=@StartDateTime,`EndDateTime`=@EndDateTime,`IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("@Type", task.Type),
                    new KeyValuePair<string, object>("@Comments", task.Comments),
                    new KeyValuePair<string, object>("@Duration", task.Duration),
                    new KeyValuePair<string, object>("@Effectivedate", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.Effectivedate)),
                    new KeyValuePair<string, object>("@RepeatType", task.RepeatType),
                    new KeyValuePair<string, object>("@StartDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.StartDateTime)),
                    new KeyValuePair<string, object>("@EndDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(task.EndDateTime)),
                    new KeyValuePair<string, object>("@IsActive", task.IsActive),
                    new KeyValuePair<string, object>("@Id", task.Id),
                };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
        public async void DeleteSheduledTaskAsync(int id)
        {
            string query = "UPDATE `ScheduledTasks` " +
                "SET `IsDelete`=@IsDelete,`IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsDelete", 1),
                new KeyValuePair<string, object>("@IsActive", 0),
                new KeyValuePair<string, object>("@Id", id)
            };

             await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
        public async Task<IEnumerable<ScheduledTasks>> GetTodayActiveScheduleTasksAsync()
        {
            string query = "SELECT * FROM `ScheduledTasks` WHERE `IsDelete` = 0 ";

            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntitySheduledTask);

        }

        public async void UpdateNextTransactionDate(int id, DateTime dtAddDates)
        {

            string query = "UPDATE `ScheduledTasks` SET `Effectivedate`=@Effectivedate WHERE `Id`=@Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id),
                new KeyValuePair<string, object>("@Effectivedate", TimeConverterMethods.ConvertDateTimeToTimeStamp(dtAddDates))
            };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

        }

        public async Task<IEnumerable<ScheduledTasks>> GetScheduledTasksAsync()
        {
            string query = "SELECT * FROM `ScheduledTasks`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntitySheduledTask);
        }

        public async Task<ScheduledTasks> GetScheduledTasksByIdAsync(int id)
        {
            string query = "SELECT * FROM `ScheduledTasks` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntitySheduledTask, parameters);

        }
    }
}
