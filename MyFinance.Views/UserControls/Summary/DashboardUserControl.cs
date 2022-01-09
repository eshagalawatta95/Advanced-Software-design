using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFinance.Views.UserControls.Summary
{
    public partial class DashboardUserControl : UserControl
    {
        private PredictionUserControl _predictionUserControl;
        private SummarizeUserControl _summarizeUserControl;

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

            _predictionUserControl = new PredictionUserControl();

            _predictionUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _predictionUserControl.Location = new System.Drawing.Point(0, 0);
            _predictionUserControl.Margin = new System.Windows.Forms.Padding(0);
            _predictionUserControl.Name = "predictionUserControl";
            _predictionUserControl.Size = new System.Drawing.Size(498, 548);
            _predictionUserControl.TabIndex = 0;
            panel2.Controls.Add(this._predictionUserControl);
        }
    }
}
