namespace MyFinance.Views.UserControls.Task
{
    partial class TaskUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.contentHeaderUserControl1 = new MyFinance.Views.UserControls.ContentHeaderUserControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewScheduled = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheduled)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1189, 809);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentHeaderUserControl1
            // 
            this.contentHeaderUserControl1.BackButtonVisible = false;
            this.contentHeaderUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl1.MainTitle = "Manage Tasks";
            this.contentHeaderUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl1.Name = "contentHeaderUserControl1";
            this.contentHeaderUserControl1.Size = new System.Drawing.Size(1189, 128);
            this.contentHeaderUserControl1.TabIndex = 0;
            this.contentHeaderUserControl1.AddButtonOnClick += new System.EventHandler(this.contentHeaderUserControl_AddButtonOnClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 128);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1189, 809);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(10, 59);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1169, 740);
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
            this.dataGridView.Size = new System.Drawing.Size(1163, 734);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewScheduled);
            this.tabPage2.Location = new System.Drawing.Point(10, 59);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1169, 740);
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
            this.dataGridViewScheduled.Size = new System.Drawing.Size(1163, 734);
            this.dataGridViewScheduled.TabIndex = 2;
            this.dataGridViewScheduled.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewScheduled_CellDoubleClick);
            // 
            // TaskUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contentHeaderUserControl1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "TaskUserControl";
            this.Size = new System.Drawing.Size(1189, 937);
            this.Load += new System.EventHandler(this.TransactionUserControl_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheduled)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewScheduled;
    }
}
