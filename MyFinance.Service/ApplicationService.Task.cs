using MyFinance.Entities;
using MyFinance.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFinance.Service
{
    public partial class ApplicationService
    {
        static SemaphoreSlim _insertTaskSemaphoreSlim = new SemaphoreSlim(1,1);
        ApplicationErrorLog applicationErrorLog = new ApplicationErrorLog();

        public async Task<OneTimeTasks> InsertTaskAsync(OneTimeTasks task, bool isUserPerformed = false)
        {
            await _insertTaskSemaphoreSlim.WaitAsync();
            try
            {
                UserEntity userEntity = await _userModel.GetUserDetailsAsync();
                task.CreatedUser = userEntity.Id;

                int tId = await _taskModel.InsertTaskAsync(task, isUserPerformed);
                task = await _taskModel.GetTaskByIdAsync(tId);

                IList<OneTimeTasks> tasks = OneTimeTasks.ToList();
                tasks.Add(task);

                OneTimeTasks = tasks;
                CurrentUser = userEntity;

                return task;
            }
            catch (Exception k)
            {
                applicationErrorLog.ErrorLog("Task", "Insert one time task", k.ToString());
                return task;
            }
            finally
            {
                _insertTaskSemaphoreSlim.Release();

            }
        }

        public async Task<ScheduledTasks> InsertSheduledTasktAsync(ScheduledTasks task)
        {
            await _insertTaskSemaphoreSlim.WaitAsync();
            try
            {
                UserEntity userEntity = await _userModel.GetUserDetailsAsync();
                task.CreatedUser = userEntity.Id;
                int tId = await _taskModel.InsertSheduledTasktAsync(task);
                task = await _taskModel.GetScheduledTasksByIdAsync(tId);

                IList<ScheduledTasks> tasks = ScheduledTasks.ToList();
                tasks.Add(task);

                ScheduledTasks = tasks;
                CurrentUser = userEntity;

                return task;
            }
            catch (Exception k)
            {
                applicationErrorLog.ErrorLog("Task", "Insert scheduled task", k.ToString());
                return task;
            }
            finally
            {
                _insertTaskSemaphoreSlim.Release();
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
             _taskModel.DeleteTaskAsync(id);
            OneTimeTasks task = await _taskModel.GetTaskByIdAsync(id);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();
            IList<OneTimeTasks> tasks = OneTimeTasks.ToList();
            OneTimeTasks deletedTask = tasks.First(tp => tp.Id == id);
            deletedTask.IsDelete = true;

            OneTimeTasks = tasks;
            CurrentUser = userEntity;
        }

        public async Task<OneTimeTasks> UpdateTaskAsync(OneTimeTasks task)
        {       
            await _taskModel.UpdateTaskAsync(task);
           
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();

            IEnumerable<OneTimeTasks> tasks = await _taskModel.GetTaskAsync();

            OneTimeTasks = tasks;
            CurrentUser = userEntity;

            return task;
        }

        public async Task<ScheduledTasks> UpdateSheduledTaskListAsync(ScheduledTasks task)
        {
            await _taskModel.UpdateSheduledTaskListAsync(task);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();

            IEnumerable<ScheduledTasks> tasks = await _taskModel.GetScheduledTasksAsync();

            ScheduledTasks = tasks;
            CurrentUser = userEntity;

            return task;
        }

        public async Task DeleteSheduledTaskAsync(int id)
        {
             _taskModel.DeleteSheduledTaskAsync(id);
            ScheduledTasks task = await _taskModel.GetScheduledTasksByIdAsync(id);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();
            IList<ScheduledTasks> tasks = ScheduledTasks.ToList();
            ScheduledTasks deletedTask = tasks.First(tp => tp.Id == id);
            deletedTask.IsDelete = true;
            deletedTask.IsActive = false;

            ScheduledTasks = tasks;
            CurrentUser = userEntity;
            
         
        }
    }
}
