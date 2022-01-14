using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BudgetMe.Core.Service;
using BudgetMe.Entities;

namespace BudgetMe.Views.UserControls.Summary
{
    public partial class SummarizeUserControl : UserControl
    {
        private IApplicationService _applicationService;
        DateTime dtFrom = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
        DateTime dtTo = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday+7);
        string totalIncome = "0";
        string totalExpense = "0";

        public SummarizeUserControl()
        {
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionsOnChange += TransactionsOnChange;
            _applicationService.CurrentUserOnChange += CurrentUserOnChange;
            _applicationService.TransactionCategoriesOnChange += TransactionCategoriesOnChange;
            _applicationService.ScheduleTransactionsOnChange += schTransactionsOnChange;
            
        }

        private void TransactionCategoriesOnChange(IEnumerable<TransactionCategoryEntity> currentValueList)
        {
            UpdateTransactionBinders(dtFrom, dtTo);
        }

        private void CurrentUserOnChange(UserEntity userEntity)
        {
            totalExpense = _applicationService.Transactions.Where(x => !x.IsIncome && x.IsActive).Sum(x => x.Amount).ToString();
            totalIncome = _applicationService.Transactions.Where(x => x.IsIncome && x.IsActive).Sum(x => x.Amount).ToString();

            greetingLabel.Text = $"Hello, {userEntity.FirstName}. \nTotal income is {totalIncome} LKR. Total expense is {totalExpense} LKR";
            currentBalanceLabel.Text = userEntity.CurrentBalance.ToString("0.00")+" LKR";
        }

        private void TransactionsOnChange(IEnumerable<TransactionEntity> currentValueList)
        {
            UpdateTransactionBinders(dtFrom, dtTo);
        }
      
        private void schTransactionsOnChange(IEnumerable<SheduledTransactionList> currentValueList)
        {
            UpdateTransactionBinders(dtFrom, dtTo);
        }

        private void UpdateTransactionBinders(DateTime dtFrom, DateTime dtTo)
        {
            BindingList<TransactionBinder> transactionBinders = new BindingList<TransactionBinder>();
            BindingList<CommonTransactionBinder> transdataobj = new BindingList<CommonTransactionBinder>();
            
            IEnumerable<TransactionEntity> trans = _applicationService.Transactions.Where(x => x.TransactionDateTime >= dtFrom.AddDays(-1) && x.TransactionDateTime <= dtTo.AddDays(1)).OrderByDescending(t => t.TransactionDateTime);
            foreach (TransactionEntity transaction in trans)
            {
                if (transaction.IsActive)
                {
                    TransactionCategoryEntity transactionCategoryEntity = _applicationService.TransactionCategories.First(tp => tp.Id == transaction.TransactionCategoryId);
                    transactionBinders.Add(new TransactionBinder(transaction, transactionCategoryEntity));
                }
            }
            foreach (TransactionBinder transaction in transactionBinders)
            {
                CommonTransactionBinder obj = new CommonTransactionBinder();
                obj.Amount = transaction.Amount;
                obj.ReferenceNumber = transaction.ReferenceNumber;
                obj.TransactionDateTime = transaction.TransactionDateTime;
                obj.TransactionCategoryCode = transaction.TransactionCategoryCode;
                obj.Type = transaction.Type;
                transdataobj.Add(obj);

            }
            // schduled transactions to datagrid

            BindingList<ScheduleTransactionBinder> scheduletransactionBinders = new BindingList<ScheduleTransactionBinder>();

            IEnumerable<SheduledTransactionList> schtrans = _applicationService.SheduledTransactions.Where(x => x.NextTransactionDate >= dtFrom.AddDays(-1) && x.NextTransactionDate <= dtTo.AddDays(1) && x.IsDelete == false).OrderByDescending(t => t.NextTransactionDate);
            foreach (SheduledTransactionList schtransaction in schtrans)
            {
                if (schtransaction.IsActive)
                {
                    TransactionCategoryEntity transactionCategoryEntity = _applicationService.TransactionCategories.First(tp => tp.Id == schtransaction.TransactionCategoryId);
                    scheduletransactionBinders.Add(new ScheduleTransactionBinder(schtransaction, transactionCategoryEntity));
                }
            }

            foreach (ScheduleTransactionBinder transaction in scheduletransactionBinders)
            {
                CommonTransactionBinder obj = new CommonTransactionBinder();
                obj.Amount = transaction.Amount;
                obj.ReferenceNumber = transaction.ReferenceNumber;
                obj.TransactionDateTime = transaction.TransactionDateTime;
                obj.TransactionCategoryCode = transaction.TransactionCategoryCode;
                obj.Type = transaction.Type;
                transdataobj.Add(obj);

            }
            dataGridView.DataSource = transdataobj;
        }
           
        public new void Dispose()
        {
            _applicationService.TransactionsOnChange -= TransactionsOnChange;
            _applicationService.CurrentUserOnChange -= CurrentUserOnChange;
            _applicationService.TransactionCategoriesOnChange -= TransactionCategoriesOnChange;
            base.Dispose();
        }

        private void SummarizeUserControl_Load(object sender, EventArgs e)
        {
            CurrentUserOnChange(_applicationService.CurrentUser);
            UpdateTransactionBinders(dtFrom, dtTo);
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView.Rows)
                if (Myrow.Cells[3].Value.ToString().Contains("-"))
                {
                    Myrow.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    Myrow.DefaultCellStyle.ForeColor = Color.Green;
                }
        }

        private void dataGridView_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView.Rows)
                if (Myrow.Cells[3].Value.ToString().Contains("-"))
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
            TransactionCategoryCode = transactionCategoryEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            TransactionDateTime = transactionEntity.TransactionDateTime.ToString("dd-MM-yyyy h:mm tt");
            Type = "One Time";
        }

        public string ReferenceNumber { get; set; }
        public string TransactionDateTime { get; set; }
        public string TransactionCategoryCode { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
    }

    class ScheduleTransactionBinder
    {
        public ScheduleTransactionBinder()
        { }

        public ScheduleTransactionBinder(SheduledTransactionList transactionEntity, TransactionCategoryEntity transactionCategoryEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionCategoryCode = transactionCategoryEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            TransactionDateTime = transactionEntity.NextTransactionDate.ToString("dd-MM-yyyy h:mm tt");
            Type = "Scheduled";
        }

        public string ReferenceNumber { get; set; }
        public string TransactionDateTime { get; set; }
        public string TransactionCategoryCode { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
    }

    class CommonTransactionBinder
    {
        public CommonTransactionBinder()
        { }
        public string ReferenceNumber { get; set; }
        public string TransactionDateTime { get; set; }
        public string TransactionCategoryCode { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
    }
}
