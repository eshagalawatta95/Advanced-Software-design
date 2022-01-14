using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetMe.Core.Views.UserControls;
using BudgetMe.Enums;
using BudgetMe.Entities;
using BudgetMe.Core.Service;
using BudgetMe.Core.Models;

namespace BudgetMe.Views.UserControls.Transaction
{
    public partial class TransactionUserControl : UserControl, ITransactionUserControl
    {
        private Action<ContentItemEnum, object> _changeContentMainFormAction;
        private IApplicationService _applicationService;
        private BindingList<TransactionBinder> _transactionBinders;
        private BindingList<ScheduleTransactionBinder> _scheduletransactionBinders;

        public TransactionUserControl(Action<ContentItemEnum, object> changeContentMainFormAction)
        {
            _changeContentMainFormAction = changeContentMainFormAction;
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionCategoriesOnChange += TransactionCategoriesOnChange;
            _applicationService.TransactionsOnChange += TransactionsOnChange;
            _applicationService.ScheduleTransactionsOnChange += schTransactionsOnChange;
        }

        private void TransactionsOnChange(IEnumerable<TransactionEntity> currentValueList)
        {
            UpdateTransactionBinders();
        }
        private void schTransactionsOnChange(IEnumerable<SheduledTransactionList> currentValueList)
        {
            UpdateTransactionBinders();
        }

        private void TransactionCategoriesOnChange(IEnumerable<TransactionCategoryEntity> currentValueList)
        {
            UpdateTransactionBinders();
        }

        private void UpdateTransactionBinders()
        {
            //bind single transactions to datagrid

            BindingList<TransactionBinder> transactionBinders = new BindingList<TransactionBinder>();

            IEnumerable<TransactionEntity> trans = _applicationService.Transactions.OrderByDescending(t => t.TransactionDateTime);
            foreach (TransactionEntity transaction in trans)
            {
                if (transaction.IsActive)
                {
                    TransactionCategoryEntity transactionCategory = _applicationService.TransactionCategories.First(tp => tp.Id == transaction.TransactionCategoryId);
                    transactionBinders.Add(new TransactionBinder(transaction, transactionCategory));
                }
            }

            _transactionBinders = transactionBinders;
            dataGridView.DataSource = _transactionBinders;
            dataGridView.Update();
            dataGridView.Refresh();

            //bind schduled transactions to datagrid

            BindingList<ScheduleTransactionBinder> scheduletransactionBinders = new BindingList<ScheduleTransactionBinder>();

            IEnumerable<SheduledTransactionList> schtrans = _applicationService.SheduledTransactions.OrderByDescending(t => t.NextTransactionDate);
            foreach (SheduledTransactionList schtransaction in schtrans)
            {
                if (!schtransaction.IsDelete)
                {
                    TransactionCategoryEntity transactionCategory = _applicationService.TransactionCategories.First(tp => tp.Id == schtransaction.TransactionCategoryId);
                    scheduletransactionBinders.Add(new ScheduleTransactionBinder(schtransaction, transactionCategory));
                }
            }

            _scheduletransactionBinders = scheduletransactionBinders;
            dataGridViewScheduled.DataSource = _scheduletransactionBinders;
            dataGridViewScheduled.Update();
            dataGridViewScheduled.Refresh();

        }

        private void contentHeaderUserControl_AddButtonOnClick(object sender, EventArgs e)
        {
            _changeContentMainFormAction(ContentItemEnum.ManageTransaction, null);
        }
     
        public new void Dispose()
        {
            _applicationService.TransactionCategoriesOnChange -= TransactionCategoriesOnChange;
            _applicationService.TransactionsOnChange -= TransactionsOnChange;
            base.Dispose();
        }

        private void TransactionUserControl_Load(object sender, EventArgs e)
        {
            UpdateTransactionBinders();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TransactionBinder transactionBinder = _transactionBinders[e.RowIndex];
                TransactionEntity transaction = _applicationService.Transactions.First(t => t.ReferenceNumber == transactionBinder.ReferenceNumber);
                _changeContentMainFormAction(ContentItemEnum.ManageTransaction, transaction);
            }
        }

        private void dataGridViewScheduled_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ScheduleTransactionBinder ScheduleTransactionBinder = _scheduletransactionBinders[e.RowIndex];
                SheduledTransactionList schtransaction = _applicationService.SheduledTransactions.First(t => t.ReferenceNumber == ScheduleTransactionBinder.ReferenceNumber);
                _changeContentMainFormAction(ContentItemEnum.ManageTransaction, schtransaction);
            }
        }

        private void dataGridView_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView.Rows)
                if (Myrow.Cells[4].Value.ToString().Contains("-"))
                {
                    Myrow.Cells["Amount"].Style.ForeColor = Color.Red;
                }
                else
                {
                    Myrow.Cells["Amount"].Style.ForeColor = Color.Green;
                }
        }

        private void dataGridViewScheduled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView.Rows)
                if (Myrow.Cells[5].Value.ToString().Contains("-"))
                {
                    Myrow.Cells["Amount"].Style.ForeColor = Color.Red;
                }
                else
                {
                    Myrow.Cells["Amount"].Style.ForeColor = Color.Green;
                }
        }
    }

    class TransactionBinder
    {
        public TransactionBinder()
        { }

        public TransactionBinder(TransactionEntity transactionEntity, TransactionCategoryEntity transactionCategoryEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionCategory = transactionCategoryEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            IsScheduledTransaction = transactionEntity.ScheduledTransactionId == null ? "No" : "Yes";
            TransactionDateTime = transactionEntity.TransactionDateTime;
            Remarks = transactionEntity.Remarks;
            PerformedBy = transactionEntity.IsUserPerformed ? "User" : "System";
        }

        public string ReferenceNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionCategory { get; set; }
        public string IsScheduledTransaction { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string PerformedBy { get; set; }
    }

    class ScheduleTransactionBinder
    {
        public ScheduleTransactionBinder()
        { }

        public ScheduleTransactionBinder(SheduledTransactionList transactionEntity, TransactionCategoryEntity transactionCategoryEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionCategory = transactionCategoryEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            RepeatType = transactionEntity.RepeatType;
            NextTransactionDate = transactionEntity.NextTransactionDate;
            Remarks = transactionEntity.Remarks;
            EndTransactionDate = transactionEntity.InfiniteSchedule ? "Never" :transactionEntity.EndDateTime.ToString();
            Status= transactionEntity.IsActive ? "Active" : "Disabled";
        }

        public string ReferenceNumber { get; set; }
        public DateTime NextTransactionDate { get; set; }
        public string EndTransactionDate { get; set; }
        public string TransactionCategory { get; set; }
        public string RepeatType { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
