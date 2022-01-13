using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BudgetMe.Entities;
using BudgetMe.Core.Service;
using BudgetMe.Views.Forms;
using System.Threading;
using BudgetMe.Methods;

namespace BudgetMe.Views.UserControls.TransactionCategory
{
    public partial class TransactionCategoryUserControl : UserControl
    {
        private SynchronizationContext _currentSynchronizationContext;
        private BindingList<TransactionCategoryBinder> _transactionCategoriesBinders;
        private IApplicationService _applicationService;
        private TransactionCategoryBinder _selectedTransactionCategoryBinder;


        public TransactionCategoryUserControl()
        {
            _currentSynchronizationContext = SynchronizationContext.Current;
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionCategoriesOnChange += TransactionCategoriesOnChange;
            TransactionCategoriesOnChange(_applicationService.TransactionCategories);
            SetSelectedTransactionCategoryBinder();

            dataGridView.Columns["Id"].HeaderText = "Category Id";
            dataGridView.Columns["Code"].HeaderText = "Category Code";
            dataGridView.Columns["AddedDateTime"].HeaderText = "Created Date";
        }

        private TransactionCategoryBinder GetSelectedTransactionCategoryBinder()
        {
            if (_selectedTransactionCategoryBinder == null)
            {
                SetSelectedTransactionCategoryBinder();
            }
            return _selectedTransactionCategoryBinder;
        }

        private void SetSelectedTransactionCategoryBinder(TransactionCategoryBinder value = null)
        {
            _selectedTransactionCategoryBinder = value ??
                new TransactionCategoryBinder()
                {
                    Code = "",
                    Description = "",
                    MaxAmount = 0,
                };

            codeTextBox.Text = _selectedTransactionCategoryBinder.Code;
            codeErrorLabel.Text = "";
            descriptionTextBox.Text = _selectedTransactionCategoryBinder.Description;
            descriptionErrorLabel.Text = "";
            textMax.Text = _selectedTransactionCategoryBinder.MaxAmount.ToString();
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

            int id = GetSelectedTransactionCategoryBinder().Id;
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
            SetSelectedTransactionCategoryBinder();
        }

        private async void actionsUserControl_SaveButtonOnClick(object sender, EventArgs e)
        {
            if (IsFormDataValid())
            {
                TransactionCategoryBinder bindedValue = GetSelectedTransactionCategoryBinder();
                TransactionCategoryEntity transactionCategoryEntity = new TransactionCategoryEntity()
                {
                    Id = bindedValue.Id,
                    Code = codeTextBox.Text,
                    Description = descriptionTextBox.Text,
                    MaxAmount=Math.Round(Convert.ToDouble(textMax.Text), 2),
                    CreatedDateTime = bindedValue.Id == 0 ? DateTime.Now : bindedValue.AddedDateTime
                };

                if (transactionCategoryEntity.Id == 0)
                {
                    await _applicationService.InsertTransactionCategoryAsync(transactionCategoryEntity);
                }
                else
                {
                    await _applicationService.UpdateTransactionCategoryAsync(transactionCategoryEntity);
                }
                SetSelectedTransactionCategoryBinder();
            }
        }

        private async void actionsUserControl_DeleteButtonOnClick(object sender, EventArgs e)
        {
            int id = GetSelectedTransactionCategoryBinder().Id;

            if (id > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this transaction category?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    await _applicationService.DeleteTransactionCategoryAsync(id);
                    SetSelectedTransactionCategoryBinder();
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetSelectedTransactionCategoryBinder(_transactionCategoriesBinders[e.RowIndex]);
            }
        }

        private void TransactionCategoryUserControl_Load(object sender, EventArgs e)
        {
            codeErrorLabel.Text = "";
            descriptionErrorLabel.Text = "";
            textMax.Text = "0";
        }

      
        private void textMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
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
