using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetMe.Entities;
using BudgetMe.Core.Service;

namespace BudgetMe.Views.UserControls.Logs
{
    public partial class LogsUserControl : UserControl, IDisposable
    {
        private BindingList<TransactionLogBinder> _transactionLogs;
        private IApplicationService _applicationService;

        public LogsUserControl()
        {
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionLogsOnChange += TransactionLogsOnChange;
            _applicationService.TransactionCategoriesOnChange += TransactionCategoriesOnChange; 
            UpdateTransactionLogBinders();
            dataGridView.Columns["Amount"].HeaderText = "Amount (LKR)";
            dataGridView.Columns["Balance"].HeaderText = "Balance (LKR)";

        }

        private void TransactionCategoriesOnChange(IEnumerable<TransactionCategoryEntity> currentValueList)
        {
            UpdateTransactionLogBinders();
        }

        public void TransactionLogsOnChange(IEnumerable<TransactionLogEntity> transactionLogEntities)
        {
            UpdateTransactionLogBinders();
        }

        public void UpdateTransactionLogBinders()
        {
            IList<TransactionLogBinder> transactionLogBinders = new List<TransactionLogBinder>();

            IEnumerable<TransactionLogEntity> tranLogs = _applicationService.TransactionLogs.OrderBy(t => t.TransactionDateTime);
            foreach (TransactionLogEntity transactionLog in tranLogs)
            {
                TransactionCategoryEntity transactionCategory = _applicationService.TransactionCategories.First(tp => tp.Id == transactionLog.TransactionCategoryId);
                transactionLogBinders.Add(new TransactionLogBinder(transactionLog, transactionCategory));
            }

            _transactionLogs = new BindingList<TransactionLogBinder>(transactionLogBinders);
            dataGridView.DataSource = _transactionLogs;
        }


        public new void Dispose()
        {
            _applicationService.TransactionLogsOnChange -= TransactionLogsOnChange;
            base.Dispose();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView.Columns[3].Width = 370;
            foreach (DataGridViewRow Myrow in dataGridView.Rows)
            {

                if (Myrow.Cells[3].Value.ToString().Contains("Diff: 0"))
                {
                    Myrow.Cells["Amount"].Value = "-";
                }

                if (Myrow.Cells[3].Value.ToString().Contains("Deleted"))
                {
                    Myrow.DefaultCellStyle.ForeColor = Color.Red;
                }

                else if (Myrow.Cells[5].Value.ToString().Contains("-"))
                {
                    Myrow.Cells["Amount"].Style.ForeColor = Color.Red;
                }
                else
                {
                    Myrow.Cells["Amount"].Style.ForeColor = Color.Green;
                }
            }
        }


        class TransactionLogBinder
        {
            public TransactionLogBinder()
            { }

            public TransactionLogBinder(TransactionLogEntity transactionLog, TransactionCategoryEntity transactionCategory)
            {
                TransactionDate = transactionLog.TransactionDateTime.ToString("dd-MM-yyyy h:mm tt");
                Remarks = transactionLog.Remarks;
                Amount = (transactionLog.IsIncome ? transactionLog.Amount : -1.0 * transactionLog.Amount).ToString("0.00");
                Balance = (transactionLog.FinalBalance).ToString("0.00");
                TransactionCategory = transactionCategory.Code;
                isDeleted = transactionLog.IsDeletedTransaction == true ? "Yes" : "No";
                Type = transactionLog.ScheduledTransactionId == null ? "One Time" : "Scheduled";
                CreatedDate = transactionLog.CreatedDateTime.ToString("dd-MM-yyyy h:mm tt");
                PerformedBy = transactionLog.IsUserPerformed ? "User" : "System";

            }

            public string TransactionDate { get; set; }
            public string CreatedDate { get; set; }
            public string Type { get; set; }
            public string Remarks { get; set; }
            public string TransactionCategory { get; set; }
            public string Amount { get; set; }
            public string Balance { get; set; }
            public string isDeleted { get; set; }
            public string PerformedBy { get; set; }
        }
    }
}

