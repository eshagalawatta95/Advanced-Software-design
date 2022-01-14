using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BudgetMe.Views.UserControls
{
    public partial class ContentHeaderUserControl : UserControl
    {
        private ToolTip _toolTip;

        [Browsable(true)]
        [Description("Trigger when add button clicked"), Category("Action"),]
        public event EventHandler AddButtonOnClick;
        [Browsable(true)]
        [Description("Trigger when back button clicked"), Category("Action"),]
        public event EventHandler BackButtonOnClick;

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Add button visibility"), Category("Data")]
        public bool AddButtonVisible
        {
            get => addButton.Visible;
            set => addButton.Visible = value;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Back button visibility"), Category("Data")]
        public bool BackButtonVisible
        {
            get => backButton.Visible;
            set => backButton.Visible = value;
        }

        [Browsable(true)]
        [DefaultValue("Error Message...")]
        [Description("Error message text"), Category("Data"),]
        public string MainTitle
        {
            get => titleLabel.Text;
            set => titleLabel.Text = value;
        }

        [Browsable(true)]
        [DefaultValue("Back")]
        [Description("Tool tip of back button"), Category("Data"),]
        public string BackButtonToolTip
        {
            get => _toolTip.GetToolTip(backButton);
            set => _toolTip.SetToolTip(backButton, value);
        }

        [Browsable(true)]
        [DefaultValue("Add new")]
        [Description("Tool tip of back button"), Category("Data"),]
        public string AddButtonToolTip
        {
            get => _toolTip.GetToolTip(addButton);
            set => _toolTip.SetToolTip(addButton, value);
        }

        public ContentHeaderUserControl()
        {
            InitializeComponent();
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);

            _toolTip = new ToolTip();
            _toolTip.SetToolTip(this.backButton, "Back");
            _toolTip.SetToolTip(this.addButton, "Add new");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddButtonOnClick?.Invoke(sender, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BackButtonOnClick?.Invoke(sender, e);
        }
    }
}
