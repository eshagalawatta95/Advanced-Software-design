using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MyFinance.Entities;
using MyFinance.Core.Service;
using MyFinance.Views.Forms;
using System.Threading;
using MyFinance.Methods;

namespace MyFinance.Views.UserControls.TransactionParty
{
    public partial class TransactionPartyUserControl : UserControl
    {
        private SynchronizationContext _currentSynchronizationContext;
        private BindingList<TransactionPartyBinder> _transactionPartiesBinders;
        private IApplicationService _applicationService;
        private TransactionPartyBinder _selectedTransactionPartyBinder;


        public TransactionPartyUserControl()
        {
            _currentSynchronizationContext = SynchronizationContext.Current;
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionPartiesOnChange += TransactionPartiesOnChange;
            TransactionPartiesOnChange(_applicationService.TransactionParties);
            SetSelectedTransactionPartyBinder();

            dataGridView.Columns["Id"].HeaderText = "Party Id";
            dataGridView.Columns["Code"].HeaderText = "Party Code";
            dataGridView.Columns["AddedDateTime"].HeaderText = "Created Date";
        }

        private TransactionPartyBinder GetSelectedTransactionPartyBinder()
        {
            if (_selectedTransactionPartyBinder == null)
            {
                SetSelectedTransactionPartyBinder();
            }
            return _selectedTransactionPartyBinder;
        }

        private void SetSelectedTransactionPartyBinder(TransactionPartyBinder value = null)
        {
            _selectedTransactionPartyBinder = value ??
                new TransactionPartyBinder()
                {
                    Code = "",
                    Description = ""
                };

            codeTextBox.Text = _selectedTransactionPartyBinder.Code;
            codeErrorLabel.Text = "";
            descriptionTextBox.Text = _selectedTransactionPartyBinder.Description;
            descriptionErrorLabel.Text = "";

            actionsUserControl.DeleteButtonVisible = _selectedTransactionPartyBinder.Id > 0;
        }

        public void TransactionPartiesOnChange(IEnumerable<TransactionPartyEntity> transactionParties)
        {
            IList<TransactionPartyBinder> transactionPartyBinder = new List<TransactionPartyBinder>();

            foreach (TransactionPartyEntity transactionParty in transactionParties)
            {
                if (transactionParty.IsActive)
                {
                    transactionPartyBinder.Add(new TransactionPartyBinder(transactionParty));
                }
            }

            _transactionPartiesBinders = new BindingList<TransactionPartyBinder>(transactionPartyBinder);
            dataGridView.DataSource = _transactionPartiesBinders;
        }

        public new void Dispose()
        {
            _applicationService.TransactionPartiesOnChange -= TransactionPartiesOnChange;
            base.Dispose();
        }

        private bool IsFormDataValid()
        {
            bool isValid = true;

            int id = GetSelectedTransactionPartyBinder().Id;
            string code = codeTextBox.Text;
            string description = descriptionTextBox.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                isValid = false;
                codeErrorLabel.Text = "Code is required";
            }
            else if (id == 0 && _applicationService.IsTransactionPartyCodeUsed(code))
            {
                isValid = false;
                codeErrorLabel.Text = "Code is already used";
            }
            else if (id > 0 && _applicationService.IsTransactionPartyCodeUsedWithoutCurrent(code, id))
            {
                isValid = false;
                codeErrorLabel.Text = "Code is already used";
            }
            else
            {
                codeErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                isValid = false;
                descriptionErrorLabel.Text = "Description is required";
            }
            else
            {
                descriptionErrorLabel.Text = "";
            }

            return isValid;
        }

        private void actionsUserControl_ResetButtonOnClick(object sender, EventArgs e)
        {
            SetSelectedTransactionPartyBinder();
        }

        private async void actionsUserControl_SaveButtonOnClick(object sender, EventArgs e)
        {
            if (IsFormDataValid())
            {
                TransactionPartyBinder bindedValue = GetSelectedTransactionPartyBinder();
                TransactionPartyEntity transactionPartyEntity = new TransactionPartyEntity()
                {
                    Id = bindedValue.Id,
                    Code = codeTextBox.Text,
                    Description = descriptionTextBox.Text,
                    CreatedDateTime = bindedValue.Id == 0 ? DateTime.Now : bindedValue.AddedDateTime
                };

                if (transactionPartyEntity.Id == 0)
                {
                    await _applicationService.InsertTransactionPartyAsync(transactionPartyEntity);
                }
                else
                {
                    await _applicationService.UpdateTransactionPartyAsync(transactionPartyEntity);
                }
                SetSelectedTransactionPartyBinder();
            }
        }

        private async void actionsUserControl_DeleteButtonOnClick(object sender, EventArgs e)
        {
            int id = GetSelectedTransactionPartyBinder().Id;

            if (id > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this transaction party?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    await _applicationService.DeleteTransactionPartyAsync(id);
                    SetSelectedTransactionPartyBinder();
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetSelectedTransactionPartyBinder(_transactionPartiesBinders[e.RowIndex]);
            }
        }

        private void TransactionPartyUserControl_Load(object sender, EventArgs e)
        {
            codeErrorLabel.Text = "";
            descriptionErrorLabel.Text = "";
        }   
    }

    class TransactionPartyBinder
    {
        public TransactionPartyBinder()
        { }

        public TransactionPartyBinder(TransactionPartyEntity transactionPartyEntity)
        {
            Id = transactionPartyEntity.Id;
            Code = transactionPartyEntity.Code;
            Description = transactionPartyEntity.Description;
            AddedDateTime = transactionPartyEntity.CreatedDateTime;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
