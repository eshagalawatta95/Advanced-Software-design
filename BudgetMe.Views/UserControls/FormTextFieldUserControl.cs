using System.ComponentModel;
using System.Windows.Forms;

namespace BudgetMe.Views.UserControls
{
    public partial class FormTextFieldUserControl : UserControl
    {
        public FormTextFieldUserControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [DefaultValue(250F)]
        [Description("Description Coulmn Width"), Category("Data")]
        public float DescriptionColumnWidth
        {
            get => tableLayoutPanel.ColumnStyles[0].Width;
            set => tableLayoutPanel.ColumnStyles[0].Width = value;
        }

        [Browsable(true)]
        [DefaultValue(SizeType.Absolute)]
        [Description("Description Coulmn SizeType"), Category("Data")]
        public SizeType DescriptionColumnSizeType
        {
            get => tableLayoutPanel.ColumnStyles[0].SizeType;
            set => tableLayoutPanel.ColumnStyles[0].SizeType = value;
        }

        [Browsable(true)]
        [DefaultValue("Description")]
        [Description("Description Text"), Category("Data")]
        public string DescriptionColumnText
        {
            get => descriptionLabel.Text;
            set => descriptionLabel.Text = value;
        }

        [Browsable(true)]
        [DefaultValue(100F)]
        [Description("Data Coulmn Width"), Category("Data")]
        public float DataColumnWidth
        {
            get => tableLayoutPanel.ColumnStyles[1].Width;
            set => tableLayoutPanel.ColumnStyles[1].Width = value;
        }

        [Browsable(true)]
        [DefaultValue(SizeType.Percent)]
        [Description("Data Coulmn SizeType"), Category("Data")]
        public SizeType DataColumnSizeType
        {
            get => tableLayoutPanel.ColumnStyles[1].SizeType;
            set => tableLayoutPanel.ColumnStyles[1].SizeType = value;
        }

        [Browsable(true)]
        [DefaultValue("Data")]
        [Description("Data Text"), Category("Data")]
        public string DataColumnText
        {
            get => dataTextBox.Text;
            set => dataTextBox.Text = value;
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Data Is Readonly"), Category("Data")]
        public bool DataColumnIsReadOnly
        {
            get => dataTextBox.ReadOnly;
            set => dataTextBox.ReadOnly = value;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Data Is Enable"), Category("Data")]
        public bool DataColumnIsEnable
        {
            get => dataTextBox.Enabled;
            set => dataTextBox.Enabled = value;
        }

        [Browsable(true)]
        [DefaultValue("Error")]
        [Description("Error Message"), Category("Data")]
        public string ErrorMessageText
        {
            get => errorLabel.Text;
            set => errorLabel.Text = value;
        }
    }
}
