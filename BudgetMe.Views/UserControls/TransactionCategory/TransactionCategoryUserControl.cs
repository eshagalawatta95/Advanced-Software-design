using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BudgetMe.Entities;
using BudgetMe.Core.Service;
using BudgetMe.Views.Forms;
using System.Threading;
using BudgetMe.Methods;

namespace BudgetMe.Views.UserControls.TransactionParty
{
    public partial class TransactionPartyUserControl : UserControl
    {
        private SynchronizationContext _currentSynchronizationContext;
        private BindingList<TransactionCategoryBinder> _transactionCategoriesBinders;
        private IApplicationService _applicationService;
        private TransactionCategoryBinder _selectedTransactionCategoryBinder;


        public TransactionPartyUserControl()
        {
            _currentSynchronizationContext = SynchronizationContext.Current;
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionCategoriesOnChange += TransactionCategoriesOnChange;
            TransactionCategoriesOnChange(_applicationService.TransactionCategories);
            SetSelectedTransactionPartyBinder();

            dataGridView.Columns["Id"].HeaderText = "Party Id";
            dataGridView.Columns["Code"].HeaderText = "Party Code";
            dataGridView.Columns["AddedDateTime"].HeaderText = "Created Date";
        }

        private TransactionCategoryBinder GetSelectedTransactionPartyBinder()
        {
            if (_selectedTransactionCategoryBinder == null)
            {
                SetSelectedTransactionPartyBinder();
            }
            return _selectedTransactionCategoryBinder;
        }

        private void SetSelectedTransactionPartyBinder(TransactionCategoryBinder value = null)
        {
            _selectedTransactionCategoryBinder = value ??
                new TransactionCategoryBinder()
                {
                    Code = "",
                    Description = ""
                };

            codeTextBox.Text = _selectedTransactionCategoryBinder.Code;
            codeErrorLabel.Text = "";
            descriptionTextBox.Text = _selectedTransactionCategoryBinder.Description;
            descriptionErrorLabel.Text = "";

            actionsUserControl.DeleteButtonVisible = _selectedTransactionCategoryBinder.Id > 0;
        }

        public void TransactionCategoriesOnChange(IEnumerable<TransactionCategoryEntity> transactionCategories)
        {
            IList<TransactionCategoryBinder> transactionCategoryBinder = new List<TransactionCategoryBinder>();

            foreach (TransactionCategoryEntity transactionCategory in transactionCategories)
            {
                if (transactionCategory.IsActive)
                {
                    transactionCategoryBinder.Add(new TransactionCategoryBinder(transactionCategory));
                }
            }

            _transactionCategoriesBinders = new BindingList<TransactionCategoryBinder>(transactionCategoryBinder);
            dataGridView.DataSource = _transactionCategoriesBinders;
        }

        public new void Dispose()
        {
            _applicationService.TransactionCategoriesOnChange -= TransactionCategoriesOnChange;
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
            else if (id == 0 && _applicationService.IsTransactionCategoryCodeUsed(code))
            {
                isValid = false;
                codeErrorLabel.Text = "Code is already used";
            }
            else if (id > 0 && _applicationService.IsTransactionCategoryCodeUsedWithoutCurrent(code, id))
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
                TransactionCategoryBinder bindedValue = GetSelectedTransactionPartyBinder();
                TransactionCategoryEntity transactionPartyEntity = new TransactionCategoryEntity()
                {
                    Id = bindedValue.Id,
                    Code = codeTextBox.Text,
                    Description = descriptionTextBox.Text,
                    CreatedDateTime = bindedValue.Id == 0 ? DateTime.Now : bindedValue.AddedDateTime
                };

                if (transactionPartyEntity.Id == 0)
                {
                    await _applicationService.InsertTransactionCategoryAsync(transactionPartyEntity);
                }
                else
                {
                    await _applicationService.UpdateTransactionCategoryAsync(transactionPartyEntity);
                }
                SetSelectedTransactionPartyBinder();
            }
        }

        private async void actionsUserControl_DeleteButtonOnClick(object sender, EventArgs e)
        {
            int id = GetSelectedTransactionPartyBinder().Id;

            if (id > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this transaction category?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    await _applicationService.DeleteTransactionCategoryAsync(id);
                    SetSelectedTransactionPartyBinder();
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetSelectedTransactionPartyBinder(_transactionCategoriesBinders[e.RowIndex]);
            }
        }

        private void TransactionPartyUserControl_Load(object sender, EventArgs e)
        {
            codeErrorLabel.Text = "";
            descriptionErrorLabel.Text = "";
        }   
    }

    class TransactionCategoryBinder
    {
        public TransactionCategoryBinder()
        { }

        public TransactionCategoryBinder(TransactionCategoryEntity transactionCategoryEntity)
        {
            Id = transactionCategoryEntity.Id;
            Code = transactionCategoryEntity.Code;
            Description = transactionCategoryEntity.Description;
            AddedDateTime = transactionCategoryEntity.CreatedDateTime;
            MaxAmount = transactionCategoryEntity.MaxAmount;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double MaxAmount { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
