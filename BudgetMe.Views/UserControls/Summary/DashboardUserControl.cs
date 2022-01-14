using System.Windows.Forms;

namespace BudgetMe.Views.UserControls.Summary
{
    public partial class DashboardUserControl : UserControl
    {
        private SummarizeUserControl _summarizeUserControl;
        private CategoryUserControl _categoryUserControl;

        public DashboardUserControl()
        {
            InitializeComponent();
            InitilizeCustomComponents();
        }

        private void InitilizeCustomComponents()
        {
            _summarizeUserControl = new SummarizeUserControl();
            _summarizeUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _summarizeUserControl.Location = new System.Drawing.Point(0, 0);
            _summarizeUserControl.Margin = new System.Windows.Forms.Padding(0);
            _summarizeUserControl.Name = "summarizeUserControl";
            _summarizeUserControl.Size = new System.Drawing.Size(498, 548);
            _summarizeUserControl.TabIndex = 0;
            panel1.Controls.Add(this._summarizeUserControl);

            _categoryUserControl = new CategoryUserControl();
            _categoryUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _categoryUserControl.Location = new System.Drawing.Point(0, 0);
            _categoryUserControl.Margin = new System.Windows.Forms.Padding(0);
            _categoryUserControl.Name = "CategoryUserControl";
            _categoryUserControl.Size = new System.Drawing.Size(498, 548);
            _categoryUserControl.TabIndex = 0;
            panel2.Controls.Add(this._categoryUserControl);


        }
    }
}
