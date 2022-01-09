using MyFinance.Core.Models;
using MyFinance.Core.Service;
using MyFinance.Entities;
using MyFinance.Enums;
using MyFinance.Methods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyFinance.Service
{
    public partial class ApplicationService : IApplicationService
    {
        private IApplicationModel _applicationModel;
        private IUserModel _userModel;
        private ITransactionLogModel _transactionLogModel;
        private ITransactionPartyModel _transactionPartyModel;
        private ITransactionModel _transactionModel;
        private ITaskModel _taskModel; 

        public event NotifyDataChangesEvent<UserEntity> CurrentUserOnChange;
        public event NotifyDataChangesListEvent<OneTimeTasks> TasksOnChange;
        public UserEntity CurrentUser
        {
            get => MyFinanceApplication.CurrentUser;
            private set
            {
                MyFinanceApplication.CurrentUser = value;
                CurrentUserOnChange?.Invoke(MyFinanceApplication.CurrentUser);
            }
        }

        public event NotifyDataChangesListEvent<TransactionLogEntity> TransactionLogsOnChange;
        private IEnumerable<TransactionLogEntity> _transactionLogs = new List<TransactionLogEntity>();
        public IEnumerable<TransactionLogEntity> TransactionLogs { 
            get => _transactionLogs; 
            private set
            {
                _transactionLogs = value?.OrderByDescending(tl => tl.TransactionDateTime).ToList() ?? new List<TransactionLogEntity>();
                TransactionLogsOnChange?.Invoke(_transactionLogs);
            }
        }

        public event NotifyDataChangesListEvent<TransactionEntity> TransactionsOnChange;
        private IEnumerable<TransactionEntity> _transactions = new List<TransactionEntity>();
        private IEnumerable<SheduledTransactionList> _schtransactions = new List<SheduledTransactionList>();
        private IEnumerable<OneTimeTasks> _onetimetasks = new List<OneTimeTasks>();
        private IEnumerable<ScheduledTasks> _schtasks = new List<ScheduledTasks>();
        public event NotifyDataChangesListEvent<ScheduledTasks> ScheduledTasksOnChange;
        public event NotifyDataChangesListEvent<SheduledTransactionList> ScheduleTransactionsOnChange;
        public IEnumerable<TransactionEntity> Transactions
        {
            get => _transactions;
            private set
            {
                _transactions = value?.OrderByDescending(tl => tl.TransactionDateTime).ToList() ?? new List<TransactionEntity>();
                TransactionsOnChange?.Invoke(_transactions);
            }
        }

        public event NotifyDataChangesListEvent<TransactionPartyEntity> TransactionPartiesOnChange;
        private IEnumerable<TransactionPartyEntity> _transactionParties = new List<TransactionPartyEntity>();
        public IEnumerable<TransactionPartyEntity> TransactionParties
        {
            get => _transactionParties;
            private set
            {
                _transactionParties = value ?? new List<TransactionPartyEntity>();
                TransactionPartiesOnChange?.Invoke(_transactionParties);
            }
        }

        public ApplicationService()
        {
            _applicationModel = MyFinanceApplication.DependancyContainer.GetInstance<IApplicationModel>();
            _userModel = MyFinanceApplication.DependancyContainer.GetInstance<IUserModel>();
            _transactionLogModel = MyFinanceApplication.DependancyContainer.GetInstance<ITransactionLogModel>();
            _transactionPartyModel = MyFinanceApplication.DependancyContainer.GetInstance<ITransactionPartyModel>();
            _transactionModel = MyFinanceApplication.DependancyContainer.GetInstance<ITransactionModel>();
            _taskModel = MyFinanceApplication.DependancyContainer.GetInstance<ITaskModel>();
        }

        public async Task InitialLoadingProcessAsync(Action<string> setProgressStatusTextAction, Action loadMainForm, Action showUserRegistraion)
        {
            if (!_applicationModel.IsApplicationRunning)
            {
                await Task.Run(async () =>
                {
                    setProgressStatusTextAction("Loading...");
                    Thread.Sleep(500);

                    setProgressStatusTextAction("Checking database...");
                    Thread.Sleep(500);

                    if (!_applicationModel.IsDatabaseInitialized)
                    {
                        setProgressStatusTextAction("Initializing database...");
                        Thread.Sleep(500);
                        _applicationModel.InitializeDatabase();
                    }

                    setProgressStatusTextAction("Initializing application data...");
                    await InitializeApplicationData();
                    Thread.Sleep(500);

                    setProgressStatusTextAction("Checking user information...");
                    Thread.Sleep(500);
                    if (CurrentUser == null)
                    {
                        setProgressStatusTextAction("User information not found...");
                        Thread.Sleep(250);
                        showUserRegistraion();
                        return;
                    }

                    setProgressStatusTextAction($"Welcome, {CurrentUser.FirstName}...");
                    Thread.Sleep(1000);

                    loadMainForm();

                    _applicationModel.IsApplicationRunning = true;
                });

            }
        }

        private async Task InitializeApplicationData()
        {
            CurrentUser = await _userModel.GetUserDetailsAsync();
            TransactionLogs = await _transactionLogModel.GetTransactionLogsAsync();
            TransactionParties = await _transactionPartyModel.GetTransactionPartiesAsync();
            Transactions = await _transactionModel.GetTransactionsAsync();
            SheduledTransactions = await _transactionModel.GetSheduledTransactionsAsync();
            OneTimeTasks = await _taskModel.GetTaskAsync();
            ScheduledTasks = await _taskModel.GetScheduledTasksAsync();
        }

        public void ReleaseResourcesToExit(Action<string> SetProgressStatusText, Action preventApplicationExitAction, Action exitApplicationAction)
        {
            if (_applicationModel.IsApplicationRunning)
            {
                preventApplicationExitAction();

                Task.Run(() =>
                {
                    SetProgressStatusText("Closing...");
                    Thread.Sleep(1000);
                    _applicationModel.IsApplicationRunning = false;
                    exitApplicationAction();
                });
            }
        }

        public async Task AutoRunMethod()
        {
            DateTime dtLastDate=DateTime.Now;
            DateTime dtNextDate = DateTime.Now;
            
            //for transactions

            try           
            {
                if (File.Exists("Schedule_Transaction_File.txt"))
                {
                    try
                    {
                        var LastLine = File.ReadLines("Schedule_Transaction_File.txt").Last();
                        LastLine = LastLine.Split('-')[0];
                        dtLastDate = DateTime.ParseExact(LastLine, "dd/MM/yyyy", null);
                    }
                    catch (Exception k)
                    {
                        File.AppendAllText("Schedule_Transaction_File.txt", DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "-Initial");
                        var LastLine = File.ReadLines("Schedule_Transaction_File.txt").Last();
                        dtLastDate = Convert.ToDateTime(LastLine.Split('-')[0]);
                    }

                }
                else
                {
                    FileStream fs = File.Create("Schedule_Transaction_File.txt");
                    File.AppendAllText("Schedule_Transaction_File.txt", DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "-Initial");
                    fs.Close();
                    var LastLine = File.ReadLines("Schedule_Transaction_File.txt").Last();
                    LastLine = LastLine.Split('-')[0];
                    dtLastDate = DateTime.ParseExact(LastLine, "dd/MM/yyyy", null);
                }

                if (!dtLastDate.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                {
                    var list = await _transactionModel.GetTodayActiveTransactionScheduleAsync();
                    if (list.Count() > 0)
                    {
                        var TodayList = list.Where(x => x.NextTransactionDate <= DateTime.Now && x.EndDateTime > DateTime.Now && x.IsActive==true).ToList();

                        foreach (var item in TodayList)
                        {
                            TransactionEntity transactionEntity = new TransactionEntity();
                            transactionEntity.Amount = item.Amount;
                            transactionEntity.TransactionPartyId = item.TransactionPartyId;
                            transactionEntity.IsIncome = item.IsIncome;
                            transactionEntity.ScheduledTransactionId = item.Id;
                            transactionEntity.Remarks = item.Remarks;
                            transactionEntity.CreatedDateTime = DateTime.Now;

                            await InsertTransactionAsync(transactionEntity, false);

                            //modifiying next date
                            if (item.RepeatType == ContentRepeatItemEnum.Daily.ToString())
                                dtNextDate = item.NextTransactionDate.AddDays(1);
                            if (item.RepeatType == ContentRepeatItemEnum.Weekly.ToString())
                                dtNextDate = item.NextTransactionDate.AddDays(7);
                            if (item.RepeatType == ContentRepeatItemEnum.Monthly.ToString())
                                dtNextDate = item.NextTransactionDate.AddDays(30);
                            if (item.RepeatType == ContentRepeatItemEnum.Yearly.ToString())
                                dtNextDate = item.NextTransactionDate.AddYears(1);

                            _transactionModel.UpdateNextTransactionDate(item.Id, dtNextDate);

                        }
                        //file write 
                        File.AppendAllText("Schedule_Transaction_File.txt", DateTime.Now.ToString("dd/MM/yyyy") + "-Success\n");

                    }
                }
                    
            }
            catch(Exception k)
            {
                File.AppendAllText("Schedule_Transaction_File.txt", DateTime.Now.ToString("dd/MM/yyyy") + "-Error\n");
            }

            //for tasks

            try
            {
                if (File.Exists("Schedule_Task_File.txt"))
                {
                    try
                    {
                        var LastLine = File.ReadLines("Schedule_Task_File.txt").Last();
                        LastLine = LastLine.Split('-')[0];
                        dtLastDate = DateTime.ParseExact(LastLine, "dd/MM/yyyy", null);
                    }
                    catch(Exception k)
                    {
                        File.AppendAllText("Schedule_Task_File.txt", DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "-Initial\n");
                        var LastLine = File.ReadLines("Schedule_Task_File.txt").Last();
                        LastLine = LastLine.Split('-')[0];
                        dtLastDate = DateTime.ParseExact(LastLine, "dd/MM/yyyy", null);
                    }

                }
                else
                {
                    FileStream fs = File.Create("Schedule_Task_File.txt");
                    File.AppendAllText("Schedule_Task_File.txt", DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "-Initial\n");
                    fs.Close();
                    var LastLine = File.ReadLines("Schedule_Task_File.txt").Last();
                    LastLine = LastLine.Split('-')[0];
                    dtLastDate = DateTime.ParseExact(LastLine, "dd/MM/yyyy", null);
                }
                //var xy = dtLastDate.ToShortDateString();
                if (!dtLastDate.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                {
                    var list = await _taskModel.GetTodayActiveScheduleTasksAsync();
                    if (list.Count() > 0)
                    {
                        var TodayList = list.Where(x => x.Effectivedate <= DateTime.Now && x.EndDateTime > DateTime.Now && x.IsActive == true).ToList();

                        foreach (var item in TodayList)
                        {
                            OneTimeTasks taskEntity = new OneTimeTasks();
                            taskEntity.Duration = item.Duration;
                            taskEntity.Type = item.Type;
                            taskEntity.Comments = item.Comments;
                            taskEntity.ReferenceNumber = item.ReferenceNumber;
                            taskEntity.IsDelete = false;
                            taskEntity.CreatedDateTime = DateTime.Now;
                            taskEntity.Effectivedate = DateTime.Now;
                            await _taskModel.InsertTaskAsync(taskEntity, false);

                            //modifiying next date
                            if (item.RepeatType == ContentRepeatItemEnum.Daily.ToString())
                                dtNextDate = item.Effectivedate.AddDays(1);
                            if (item.RepeatType == ContentRepeatItemEnum.Weekly.ToString())
                                dtNextDate = item.Effectivedate.AddDays(7);
                            if (item.RepeatType == ContentRepeatItemEnum.Monthly.ToString())
                                dtNextDate = item.Effectivedate.AddDays(30);
                            if (item.RepeatType == ContentRepeatItemEnum.Yearly.ToString())
                                dtNextDate = item.Effectivedate.AddYears(1);

                            _taskModel.UpdateNextTransactionDate(item.Id, dtNextDate);

                        }
                        //file write 
                        File.AppendAllText("Schedule_Task_File.txt", DateTime.Now.ToString("dd/MM/yyyy") + "-Success\n");

                    }
                }

            }
            catch (Exception k)
            {
                File.AppendAllText("Schedule_Task_File.txt", DateTime.Now.ToString("dd/MM/yyyy") + "-Error\n");
            }
        }

        public IEnumerable<SheduledTransactionList> SheduledTransactions
        {
            get => _schtransactions;
            private set
            {
                _schtransactions = value?.OrderByDescending(tl => tl.NextTransactionDate).ToList() ?? new List<SheduledTransactionList>();
                ScheduleTransactionsOnChange?.Invoke(_schtransactions);
            }
        }

        public IEnumerable<OneTimeTasks> OneTimeTasks
        {
            get => _onetimetasks;
            private set
            {
                _onetimetasks = value?.OrderByDescending(tl => tl.Effectivedate).ToList() ?? new List<OneTimeTasks>();
                TasksOnChange?.Invoke(_onetimetasks);
            }
        }

        public IEnumerable<ScheduledTasks> ScheduledTasks
        {
            get => _schtasks;
            private set
            {
                _schtasks = value?.OrderByDescending(tl => tl.Effectivedate).ToList() ?? new List<ScheduledTasks>();
                ScheduledTasksOnChange?.Invoke(_schtasks);
            }
        }

    }
}
