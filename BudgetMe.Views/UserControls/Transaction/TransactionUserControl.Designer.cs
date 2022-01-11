namespace BudgetMe.Views.UserControls.Transaction
{
    partial class TransactionUserControl
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
            this.contentHeaderUserControl = new BudgetMe.Views.UserControls.ContentHeaderUserControl();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewScheduled = new System.Windows.Forms.DataGridView();
            this.contentPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheduled)).BeginInit();
            this.SuspendLayout();
            // 
            // contentHeaderUserControl
            // 
            this.contentHeaderUserControl.AddButtonToolTip = "Add Transaction";
            this.contentHeaderUserControl.BackButtonVisible = false;
            this.contentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl.MainTitle = "Transactions";
            this.contentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl.Name = "contentHeaderUserControl";
            this.contentHeaderUserControl.Size = new System.Drawing.Size(1755, 128);
            this.contentHeaderUserControl.TabIndex = 0;
            this.contentHeaderUserControl.AddButtonOnClick += new System.EventHandler(this.contentHeaderUserControl_AddButtonOnClick);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.tabControl);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentPanel.Location = new System.Drawing.Point(0, 128);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(27, 24, 27, 0);
            this.contentPanel.Size = new System.Drawing.Size(1755, 1153);
            this.contentPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(27, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1701, 1129);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(10, 62);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1681, 1057);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Single Time";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.dataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
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
            this.dataGridViewScheduled.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewScheduled_CellDoubleClick);
            // 
            // TransactionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.contentHeaderUserControl);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "TransactionUserControl";
            this.Size = new System.Drawing.Size(1755, 1281);
            this.Load += new System.EventHandler(this.TransactionUserControl_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheduled)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewScheduled;
    }
}
