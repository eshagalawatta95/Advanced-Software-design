using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetMe.Core.Service;
using BudgetMe.Entities;
using BudgetMe.Enums;
using System.Security.Principal;
using System.Collections;

namespace BudgetMe.Views.UserControls.Summary
{
    public partial class SummarizeUserControl : UserControl
    {
        private IApplicationService _applicationService;
        DateTime dtFrom = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
        DateTime dtTo = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday+7);

        public SummarizeUserControl()
        {
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionsOnChange += TransactionsOnChange;
            _applicationService.CurrentUserOnChange += CurrentUserOnChange;
            _applicationService.TransactionPartiesOnChange += TransactionPartiesOnChange;
            _applicationService.ScheduleTransactionsOnChange += schTransactionsOnChange;
        }

        private void TransactionPartiesOnChange(IEnumerable<TransactionPartyEntity> currentValueList)
        {
            UpdateTransactionBinders(dtFrom, dtTo);
        }

        private void CurrentUserOnChange(UserEntity userEntity)
        {
            greetingLabel.Text = $"Hello, {userEntity.FirstName}";
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
                    TransactionPartyEntity transactionParty = _applicationService.TransactionParties.First(tp => tp.Id == transaction.TransactionPartyId);
                    transactionBinders.Add(new TransactionBinder(transaction, transactionParty));
                }
            }
            foreach (TransactionBinder transaction in transactionBinders)
            {
                CommonTransactionBinder obj = new CommonTransactionBinder();
                obj.Amount = transaction.Amount;
                obj.ReferenceNumber = transaction.ReferenceNumber;
                obj.TransactionDateTime = transaction.TransactionDateTime;
                obj.TransactionPartyCode = transaction.TransactionPartyCode;
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
                    TransactionPartyEntity transactionParty = _applicationService.TransactionParties.First(tp => tp.Id == schtransaction.TransactionPartyId);
                    scheduletransactionBinders.Add(new ScheduleTransactionBinder(schtransaction, transactionParty));
                }
            }

            foreach (ScheduleTransactionBinder transaction in scheduletransactionBinders)
            {
                CommonTransactionBinder obj = new CommonTransactionBinder();
                obj.Amount = transaction.Amount;
                obj.ReferenceNumber = transaction.ReferenceNumber;
                obj.TransactionDateTime = transaction.TransactionDateTime;
                obj.TransactionPartyCode = transaction.TransactionPartyCode;
                obj.Type = transaction.Type;
                transdataobj.Add(obj);

            }
            dataGridView.DataSource = transdataobj;
        }


           
        public new void Dispose()
        {
            _applicationService.TransactionsOnChange -= TransactionsOnChange;
            _applicationService.CurrentUserOnChange -= CurrentUserOnChange;
            _applicationService.TransactionPartiesOnChange -= TransactionPartiesOnChange;
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
    }

    class TransactionBinder
    {
        public TransactionBinder()
        { }

        public TransactionBinder(TransactionEntity transactionEntity, TransactionPartyEntity transactionPartyEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionPartyCode = transactionPartyEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            TransactionDateTime = transactionEntity.TransactionDateTime.ToString("dd-MM-yyyy h:mm tt");
            Type = "One Time";
        }

        public string ReferenceNumber { get; set; }
        public string TransactionDateTime { get; set; }
        public string TransactionPartyCode { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
    }

    class ScheduleTransactionBinder
    {
        public ScheduleTransactionBinder()
        { }

        public ScheduleTransactionBinder(SheduledTransactionList transactionEntity, TransactionPartyEntity transactionPartyEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionPartyCode = transactionPartyEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            TransactionDateTime = transactionEntity.NextTransactionDate.ToString("dd-MM-yyyy h:mm tt");
            Type = "Scheduled";
        }

        public string ReferenceNumber { get; set; }
        public string TransactionDateTime { get; set; }
        public string TransactionPartyCode { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
    }


    class CommonTransactionBinder
    {
        public CommonTransactionBinder()
        { }
        public string ReferenceNumber { get; set; }
        public string TransactionDateTime { get; set; }
        public string TransactionPartyCode { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
    }

    class CommmonTaskBinder
    {
        public CommmonTaskBinder()
        { }
        public string ReferenceNumber { get; set; }
        public DateTime Effectivedate { get; set; }
        public string Task_Type { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }     
        public string Type { get; set; }
    }
}
