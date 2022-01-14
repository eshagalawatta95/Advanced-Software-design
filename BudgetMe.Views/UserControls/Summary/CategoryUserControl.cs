using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BudgetMe.Core.Service;
using BudgetMe.Entities;
using BudgetMe.Views.UserControls.TransactionCategory;

namespace BudgetMe.Views.UserControls.Summary
{
    public partial class CategoryUserControl : UserControl
    {
        private IApplicationService _applicationService;
        private BindingList<TransactionCategoryBinder> _transactionCategoriesBinders;

        public CategoryUserControl()
        {
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();
            _applicationService.TransactionCategoriesOnChange += TransactionCategoriesOnChange;
            TransactionCategoriesOnChange(_applicationService.TransactionCategories);

            dataGridViewCat.Columns["Id"].HeaderText = "Category Id";
            dataGridViewCat.Columns["Code"].HeaderText = "Category Code";
            dataGridViewCat.Columns["MaxAmount"].HeaderText = "Max Amount";
            dataGridViewCat.Columns["CurrentAmount"].HeaderText = "Current Amount";
            dataGridViewCat.Columns["AddedDateTime"].HeaderText = "Created Date";
            dataGridViewCat.Columns["Id"].Visible = false;

        }   
        private void TransactionCategoriesOnChange(IEnumerable<TransactionCategoryEntity> transactionCategories)
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
            dataGridViewCat.DataSource = _transactionCategoriesBinders;
        }          
        public new void Dispose()
        {
            _applicationService.TransactionCategoriesOnChange -= TransactionCategoriesOnChange;
            base.Dispose();
        }
        private void CategoryUserControl_Load(object sender, EventArgs e)
        {
            TransactionCategoriesOnChange(_applicationService.TransactionCategories);
        }
    }
}
