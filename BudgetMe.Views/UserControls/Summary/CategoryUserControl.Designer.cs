namespace BudgetMe.Views.UserControls.Summary
{
    partial class CategoryUserControl
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
            this.contentHeaderUserControl1 = new BudgetMe.Views.UserControls.ContentHeaderUserControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewCat = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCat)).BeginInit();
            this.SuspendLayout();
            // 
            // contentHeaderUserControl1
            // 
            this.contentHeaderUserControl1.AddButtonVisible = false;
            this.contentHeaderUserControl1.BackButtonVisible = false;
            this.contentHeaderUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentHeaderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl1.MainTitle = "";
            this.contentHeaderUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl1.Name = "contentHeaderUserControl1";
            this.contentHeaderUserControl1.Size = new System.Drawing.Size(498, 55);
            this.contentHeaderUserControl1.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 55);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(498, 493);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewCat);
            this.tabPage1.Location = new System.Drawing.Point(10, 53);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(478, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Summery of Categories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCat
            // 
            this.dataGridViewCat.AllowUserToAddRows = false;
            this.dataGridViewCat.AllowUserToDeleteRows = false;
            this.dataGridViewCat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCat.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCat.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCat.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewCat.Name = "dataGridViewCat";
            this.dataGridViewCat.ReadOnly = true;
            this.dataGridViewCat.RowHeadersWidth = 102;
            this.dataGridViewCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCat.ShowEditingIcon = false;
            this.dataGridViewCat.Size = new System.Drawing.Size(472, 424);
            this.dataGridViewCat.TabIndex = 6;
            this.dataGridViewCat.RowHeadersWidth = 25;
            // 
            // CategoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.contentHeaderUserControl1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CategoryUserControl";
            this.Size = new System.Drawing.Size(498, 548);
            this.Load += new System.EventHandler(this.CategoryUserControl_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private ContentHeaderUserControl contentHeaderUserControl1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewCat;
    }
}
