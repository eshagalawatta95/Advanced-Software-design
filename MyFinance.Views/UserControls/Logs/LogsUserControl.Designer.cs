namespace MyFinance.Views.UserControls.Logs
{
    partial class LogsUserControl
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
            this.contentHeaderUserControl = new MyFinance.Views.UserControls.ContentHeaderUserControl();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridHolderPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.dataGridHolderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentHeaderUserControl
            // 
            this.contentHeaderUserControl.AddButtonVisible = false;
            this.contentHeaderUserControl.BackButtonVisible = false;
            this.contentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl.MainTitle = "Transaction Logs";
            this.contentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl.Name = "contentHeaderUserControl";
            this.contentHeaderUserControl.Size = new System.Drawing.Size(1600, 128);
            this.contentHeaderUserControl.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(27, 24);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1546, 1307);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // dataGridHolderPanel
            // 
            this.dataGridHolderPanel.AutoScroll = true;
            this.dataGridHolderPanel.Controls.Add(this.dataGridView);
            this.dataGridHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHolderPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridHolderPanel.Location = new System.Drawing.Point(0, 128);
            this.dataGridHolderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridHolderPanel.Name = "dataGridHolderPanel";
            this.dataGridHolderPanel.Padding = new System.Windows.Forms.Padding(27, 24, 27, 0);
            this.dataGridHolderPanel.Size = new System.Drawing.Size(1600, 1331);
            this.dataGridHolderPanel.TabIndex = 3;
            // 
            // LogsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridHolderPanel);
            this.Controls.Add(this.contentHeaderUserControl);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "LogsUserControl";
            this.Size = new System.Drawing.Size(1600, 1459);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.dataGridHolderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel dataGridHolderPanel;
    }
}
