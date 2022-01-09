using MyFinance.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.Core.Models
{
    public interface ITaskModel : IModel
    {
        Task<IEnumerable<OneTimeTasks>> GetTaskAsync();
        Task<IEnumerable<ScheduledTasks>> GetScheduledTasksAsync(); 
        Task<OneTimeTasks> GetTaskByIdAsync(int id);
        Task<ScheduledTasks> GetScheduledTasksByIdAsync(int id);
        Task<int> InsertTaskAsync(OneTimeTasks task, bool isUserPerformed = false);
        Task<int> UpdateTaskAsync(OneTimeTasks task);
        Task<int> InsertSheduledTasktAsync(ScheduledTasks task);
        Task<int> UpdateSheduledTaskListAsync(ScheduledTasks task);
        void DeleteTaskAsync(int id);
        void DeleteSheduledTaskAsync(int id);
        void UpdateNextTransactionDate(int id, DateTime dtAddDates);
        Task<IEnumerable<ScheduledTasks>> GetTodayActiveScheduleTasksAsync();
    }
}
