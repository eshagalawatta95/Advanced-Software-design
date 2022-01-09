using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFinance.Views.UserControls
{
    public partial class ActionsUserControl : UserControl
    {
        private ToolTip _toolTip;

        [Browsable(true)]
        [Description("Trigger when save button clicked"), Category("Action"),]
        public event EventHandler SaveButtonOnClick;
        [Browsable(true)]
        [Description("Trigger when delete button clicked"), Category("Action"),]
        public event EventHandler DeleteButtonOnClick;
        [Browsable(true)]
        [Description("Trigger when reset button clicked"), Category("Action"),]
        public event EventHandler ResetButtonOnClick;
        [Browsable(true)]
        [Description("Trigger when predict button clicked"), Category("Action"),]
        public event EventHandler PredictButtonOnClick;

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Save button visibility"), Category("Data")]
        public bool SaveButtonVisible
        {
            get => saveButton.Visible;
            set => saveButton.Visible = value;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Delete button visibility"), Category("Data")]
        public bool DeleteButtonVisible
        {
            get => deleteButton.Visible;
            set => deleteButton.Visible = value;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Reset button visibility"), Category("Data")]
        public bool ResetButtonVisible
        {
            get => resetButton.Visible;
            set => resetButton.Visible = value;
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Predict button visibility"), Category("Data")]
        public bool PredictButtonVisible
        {
            get => predictButton.Visible;
            set => predictButton.Visible = value;
        }

        [Browsable(true)]
        [DefaultValue("Not defined...")]
        [Description("Main title of the form"), Category("Data"),]
        public string ErrorMessageText
        {
            get => errorLabel.Text;
            set => errorLabel.Text = value;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Enable Disable buttons"), Category("Data"),]
        public bool IsEnabledButtons
        {
            get => saveButton.Enabled;
            set
            {
                saveButton.Enabled = value;
                deleteButton.Enabled = value;
                resetButton.Enabled = value;
                predictButton.Enabled = value;
            }
        }

        [Browsable(true)]
        [DefaultValue("Save")]
        [Description("Tool tip of save button"), Category("Data"),]
        public string SaveButtonToolTip
        {
            get => _toolTip.GetToolTip(saveButton);
            set => _toolTip.SetToolTip(saveButton, value);
        }

        [Browsable(true)]
        [DefaultValue("Delete")]
        [Description("Tool tip of delete button"), Category("Data"),]
        public string DeleteButtonToolTip
        {
            get => _toolTip.GetToolTip(deleteButton);
            set => _toolTip.SetToolTip(deleteButton, value);
        }

        [Browsable(true)]
        [DefaultValue("Delete")]
        [Description("Tool tip of reset button"), Category("Data"),]
        public string ResetButtonToolTip
        {
            get => _toolTip.GetToolTip(resetButton);
            set => _toolTip.SetToolTip(resetButton, value);
        }

        [Browsable(true)]
        [DefaultValue("Predict")]
        [Description("Tool tip of predict button"), Category("Data"),]
        public string PredictButtonToolTip
        {
            get => _toolTip.GetToolTip(predictButton);
            set => _toolTip.SetToolTip(predictButton, value);
        }

        public ActionsUserControl()
        {
            InitializeComponent();

            _toolTip = new ToolTip();
            _toolTip.SetToolTip(this.saveButton, "Save");
            _toolTip.SetToolTip(this.deleteButton, "Delete");
            _toolTip.SetToolTip(this.resetButton, "Reset");
            _toolTip.SetToolTip(this.predictButton, "Predict");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonOnClick?.Invoke(sender, e);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveButtonOnClick?.Invoke(sender, e);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetButtonOnClick?.Invoke(sender, e);
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            PredictButtonOnClick?.Invoke(sender, e);
        }
    }
}
