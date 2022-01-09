namespace MyFinance.Views.UserControls.Report
{
    partial class ReportUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportUserControl));
            this.contentPanel = new System.Windows.Forms.Panel();
            this.tabControlReports = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelTools = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerForm = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewScheduled = new System.Windows.Forms.DataGridView();
            this.contentHeaderUserControl = new MyFinance.Views.UserControls.ContentHeaderUserControl();
            this.contentPanel.SuspendLayout();
            this.tabControlReports.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheduled)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.tabControlReports);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentPanel.Location = new System.Drawing.Point(0, 128);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(27, 24, 27, 0);
            this.contentPanel.Size = new System.Drawing.Size(1755, 1153);
            this.contentPanel.TabIndex = 1;
            // 
            // tabControlReports
            // 
            this.tabControlReports.Controls.Add(this.tabPage1);
            this.tabControlReports.Controls.Add(this.tabPage2);
            this.tabControlReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReports.Location = new System.Drawing.Point(27, 24);
            this.tabControlReports.Name = "tabControlReports";
            this.tabControlReports.SelectedIndex = 0;
            this.tabControlReports.Size = new System.Drawing.Size(1701, 1129);
            this.tabControlReports.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelTools);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(10, 62);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1681, 1057);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Single Time";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTools.Controls.Add(this.label3);
            this.panelTools.Controls.Add(this.label2);
            this.panelTools.Controls.Add(this.label1);
            this.panelTools.Controls.Add(this.btnOk);
            this.panelTools.Controls.Add(this.comboBoxType);
            this.panelTools.Controls.Add(this.dateTimePickerTo);
            this.panelTools.Controls.Add(this.dateTimePickerForm);
            this.panelTools.Location = new System.Drawing.Point(27, 42);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(1620, 241);
            this.panelTools.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 45);
            this.label3.TabIndex = 19;
            this.label3.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(976, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 45);
            this.label2.TabIndex = 19;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 45);
            this.label1.TabIndex = 18;
            this.label1.Text = "Type";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.Location = new System.Drawing.Point(1428, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 79);
            this.btnOk.TabIndex = 17;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(28, 83);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(428, 53);
            this.comboBoxType.TabIndex = 16;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(974, 83);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(372, 53);
            this.dateTimePickerTo.TabIndex = 15;
            // 
            // dateTimePickerForm
            // 
            this.dateTimePickerForm.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerForm.Location = new System.Drawing.Point(535, 80);
            this.dateTimePickerForm.Name = "dateTimePickerForm";
            this.dateTimePickerForm.Size = new System.Drawing.Size(372, 53);
            this.dateTimePickerForm.TabIndex = 14;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(1675, 1051);
            this.dataGridView.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewScheduled);
            this.tabPage2.Location = new System.Drawing.Point(10, 62);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1681, 1057);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scheduled";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewScheduled
            // 
            this.dataGridViewScheduled.AllowUserToAddRows = false;
            this.dataGridViewScheduled.AllowUserToDeleteRows = false;
            this.dataGridViewScheduled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScheduled.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScheduled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScheduled.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewScheduled.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridViewScheduled.Name = "dataGridViewScheduled";
            this.dataGridViewScheduled.ReadOnly = true;
            this.dataGridViewScheduled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScheduled.ShowEditingIcon = false;
            this.dataGridViewScheduled.Size = new System.Drawing.Size(1675, 1051);
            this.dataGridViewScheduled.TabIndex = 2;
            // 
            // contentHeaderUserControl
            // 
            this.contentHeaderUserControl.AddButtonToolTip = "";
            this.contentHeaderUserControl.BackButtonVisible = false;
            this.contentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl.MainTitle = "Reports";
            this.contentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl.Name = "contentHeaderUserControl";
            this.contentHeaderUserControl.Size = new System.Drawing.Size(1755, 128);
            this.contentHeaderUserControl.TabIndex = 0;
            this.contentHeaderUserControl.AddButtonOnClick += new System.EventHandler(this.contentHeaderUserControl_AddButtonOnClick);
            // 
            // ReportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.contentHeaderUserControl);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ReportUserControl";
            this.Size = new System.Drawing.Size(1755, 1281);
            this.contentPanel.ResumeLayout(false);
            this.tabControlReports.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheduled)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TabControl tabControlReports;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewScheduled;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerForm;
    }
}
