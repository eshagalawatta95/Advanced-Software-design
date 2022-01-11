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
using MyFinance.Views.UserControls.Transaction;

namespace MyFinance.Views.UserControls.Report
{
    public partial class ReportUserControl : UserControl, ITransactionUserControl
    {
        private IApplicationService _applicationService;
        private BindingList<TransactionBinder> _transactionBinders;

        public ReportUserControl()
        {
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();
            comboBoxType.DataSource = Enum.GetValues(typeof(ContentReportsTypesEnum));
            dateTimePickerForm.Value= new DateTime(DateTime.Now.Year, 1, 1); 
        }

        private void UpdateTransactionBinders(DateTime dtFrom, DateTime dtTo)
        {
            BindingList<TransactionBinder> transactionBinders = new BindingList<TransactionBinder>();

            IEnumerable<TransactionEntity> trans = _applicationService.Transactions.Where(x => x.TransactionDateTime >= dtFrom && x.TransactionDateTime <= dtTo && x.IsActive == true).OrderByDescending(t => t.TransactionDateTime);
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

          
        }


        private void contentHeaderUserControl_AddButtonOnClick(object sender, EventArgs e)
        {
            panelTools.Visible = true;
            tabControlReports.SelectedIndex = 0;
            dataGridView.DataSource = null;
            dataGridViewScheduled.DataSource = null;

        }
 
        private void btnOk_Click(object sender, EventArgs e)
        {
            panelTools.Visible = false;
         
            DateTime dtFrom = dateTimePickerForm.Value;
            DateTime dtTo = dateTimePickerTo.Value;
            int ReportVal = comboBoxType.SelectedIndex;

            if (ReportVal == 0)
            {
                UpdateTransactionBinders(dtFrom, dtTo);
            }
  
            tabControlReports.Visible = true;
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
            EndTransactionDate = transactionEntity.EndDateTime.ToString();
        }

        public string ReferenceNumber { get; set; }
        public DateTime NextTransactionDate { get; set; }
        public string EndTransactionDate { get; set; }
        public string TransactionParty { get; set; }
        public string RepeatType { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}
