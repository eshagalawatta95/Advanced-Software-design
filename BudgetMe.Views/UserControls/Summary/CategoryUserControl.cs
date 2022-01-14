using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BudgetMe.Core.Models;
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
            dataGridViewCat.Columns["MaxAmount"].HeaderText = "Max Amount/Budget(LKR)";
            dataGridViewCat.Columns["CurrentAmount"].HeaderText = "Current Cost(LKR)";
            dataGridViewCat.Columns["AddedDateTime"].HeaderText = "Created Date";
            dataGridViewCat.Columns["Id"].Visible = false;
            dataGridViewCat.Update();
            dataGridViewCat.Refresh();

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
            Loadchart(_transactionCategoriesBinders);

            TransactionCategoryBinder newRow = new TransactionCategoryBinder();
            newRow.Code=("Total");
            newRow.CurrentAmount = _transactionCategoriesBinders.Sum(x => x.CurrentAmount);
            newRow.MaxAmount= _transactionCategoriesBinders.Sum(x => x.MaxAmount);
            _transactionCategoriesBinders.Add(newRow);
            dataGridViewCat.DataSource = _transactionCategoriesBinders;
            dataGridViewCat.Rows[dataGridViewCat.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            dataGridViewCat.Rows[dataGridViewCat.Rows.Count - 1].Cells[1].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            dataGridViewCat.Rows[dataGridViewCat.Rows.Count - 1].Cells[4].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            dataGridViewCat.Rows[dataGridViewCat.Rows.Count - 1].Cells[3].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);

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
        private void Loadchart(BindingList<TransactionCategoryBinder> list)
        {
            this.chart.Series.Clear();
            var mainArray = list.ToArray();
  
            // Add series.
            for (int i = 0; i < mainArray.Length; i++)
            {
                Series series = this.chart.Series.Add(mainArray[i].Code);
                series.Points.Add(mainArray[i].CurrentAmount);
            }
           
        }

    }
}
