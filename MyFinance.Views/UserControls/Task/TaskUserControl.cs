using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinance.Core.Views.UserControls;
using MyFinance.Enums;
using MyFinance.Entities;
using MyFinance.Core.Service;

namespace MyFinance.Views.UserControls.Task
{
    public partial class TaskUserControl : UserControl, ITaskUserControl
    {
        private Action<ContentItemEnum, object> _changeContentMainFormAction;
        private IApplicationService _applicationService;
        private BindingList<OneTImeTaskBinder> _OneTImeTaskBinder;
        private BindingList<ScheduleTaskBinder> _ScheduleTaskBinder;

        public TaskUserControl(Action<ContentItemEnum, object> changeContentMainFormAction)
        {
            _changeContentMainFormAction = changeContentMainFormAction;
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();
            _applicationService.TasksOnChange += TasksOnChange;
            _applicationService.ScheduledTasksOnChange += schTasksOnChange;
        }

        private void TasksOnChange(IEnumerable<OneTimeTasks> currentValueList)
        {
            UpdateTaskBinders();
        }
        private void schTasksOnChange(IEnumerable<ScheduledTasks> currentValueList)
        {
            UpdateTaskBinders();
        }

        private void UpdateTaskBinders()
        {
            //bind single task to datagrid

            BindingList<OneTImeTaskBinder> taskBinders = new BindingList<OneTImeTaskBinder>();
            IEnumerable<OneTimeTasks> task = _applicationService.OneTimeTasks.Where(x=>x.IsDelete==false).OrderByDescending(t => t.Effectivedate);
            //IEnumerable<OneTimeTasks> task = _applicationService.OneTimeTasks;

            foreach (OneTimeTasks itemtask in task)
            {           
                    taskBinders.Add(new OneTImeTaskBinder(itemtask));
            }
            _OneTImeTaskBinder = taskBinders;
            dataGridView.DataSource = _OneTImeTaskBinder;

            //bind schduled task to datagrid

            BindingList<ScheduleTaskBinder> scheduletaskBinders = new BindingList<ScheduleTaskBinder>();

            IEnumerable<ScheduledTasks> schtask = _applicationService.ScheduledTasks.Where(x => x.IsDelete == false).OrderByDescending(t => t.Effectivedate);

            foreach (ScheduledTasks itemtask in schtask)
            {
              scheduletaskBinders.Add(new ScheduleTaskBinder(itemtask));
            }

            _ScheduleTaskBinder = scheduletaskBinders;
            dataGridViewScheduled.DataSource = _ScheduleTaskBinder;


        }

        private void contentHeaderUserControl_AddButtonOnClick(object sender, EventArgs e)
        {
            _changeContentMainFormAction(ContentItemEnum.ManageTask, null);
        }

        public new void Dispose()
        {
            _applicationService.TasksOnChange -= TasksOnChange;
            base.Dispose();
        }

        private void TransactionUserControl_Load(object sender, EventArgs e)
        {
            UpdateTaskBinders();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OneTImeTaskBinder transactionBinder = _OneTImeTaskBinder[e.RowIndex];
                OneTimeTasks onetimetasks = _applicationService.OneTimeTasks.First(t => t.ReferenceNumber == transactionBinder.ReferenceNumber);
                _changeContentMainFormAction(ContentItemEnum.ManageTask, onetimetasks);
            }
        }

        private void dataGridViewScheduled_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ScheduleTaskBinder ScheduleTaskBinder = _ScheduleTaskBinder[e.RowIndex];
                ScheduledTasks schtasks = _applicationService.ScheduledTasks.First(t => t.ReferenceNumber == ScheduleTaskBinder.ReferenceNumber);
                _changeContentMainFormAction(ContentItemEnum.ManageTask, schtasks);
            }
        }

    }

    class OneTImeTaskBinder
    {
        public OneTImeTaskBinder()
        { }

        public OneTImeTaskBinder(OneTimeTasks taskEntity)
        {
            ReferenceNumber = taskEntity.ReferenceNumber;
            Comments = taskEntity.Comments;
            Duration = taskEntity.Duration.ToString();
            Effectivedate = taskEntity.Effectivedate;
            Type = taskEntity.Type == 1 ? ContentTaskTypesEnum.Appointment.ToString() : ContentTaskTypesEnum.Task.ToString();
        }

        public string ReferenceNumber { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string Duration { get; set; }
        public DateTime Effectivedate { get; set; }
    }

    class ScheduleTaskBinder
    {
        public ScheduleTaskBinder()
        { }

        public ScheduleTaskBinder(ScheduledTasks taskEntity)
        {
            ReferenceNumber = taskEntity.ReferenceNumber;
            Comments = taskEntity.Comments;
            Duration = taskEntity.Duration.ToString();
            Effectivedate = taskEntity.Effectivedate;
            RepeatType = taskEntity.RepeatType;
            Type = taskEntity.Type == 1 ? ContentTaskTypesEnum.Appointment.ToString() : ContentTaskTypesEnum.Task.ToString();
            Status = taskEntity.IsActive ? "Active" : "Disabled";
        }

        public string ReferenceNumber { get; set; }
        public string RepeatType { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public DateTime Effectivedate { get; set; }
    }
}
