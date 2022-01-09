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

namespace MyFinance.Views.UserControls.Transaction
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
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionPartiesOnChange += TransactionPartiesOnChange;
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

        private void TransactionPartiesOnChange(IEnumerable<TransactionPartyEntity> currentValueList)
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
                    TransactionPartyEntity transactionParty = _applicationService.TransactionParties.First(tp => tp.Id == transaction.TransactionPartyId);
                    transactionBinders.Add(new TransactionBinder(transaction, transactionParty));
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
                    TransactionPartyEntity transactionParty = _applicationService.TransactionParties.First(tp => tp.Id == schtransaction.TransactionPartyId);
                    scheduletransactionBinders.Add(new ScheduleTransactionBinder(schtransaction, transactionParty));
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
            _applicationService.TransactionPartiesOnChange -= TransactionPartiesOnChange;
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

    }

    class TransactionBinder
    {
        public TransactionBinder()
        { }

        public TransactionBinder(TransactionEntity transactionEntity, TransactionPartyEntity transactionPartyEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionParty = transactionPartyEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            IsScheduledTransaction = transactionEntity.ScheduledTransactionId == null ? "No" : "Yes";
            TransactionDateTime = transactionEntity.TransactionDateTime;
            Remarks = transactionEntity.Remarks;
            PerformedBy = transactionEntity.IsUserPerformed ? "User" : "System";
        }

        public string ReferenceNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionParty { get; set; }
        public string IsScheduledTransaction { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string PerformedBy { get; set; }
    }

    class ScheduleTransactionBinder
    {
        public ScheduleTransactionBinder()
        { }

        public ScheduleTransactionBinder(SheduledTransactionList transactionEntity, TransactionPartyEntity transactionPartyEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionParty = transactionPartyEntity.Code;
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
        public string TransactionParty { get; set; }
        public string RepeatType { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
