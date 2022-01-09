namespace MyFinance.Views.Forms
{
    partial class MainScreenForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuButton = new System.Windows.Forms.Button();
            this.headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.menuFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.menuFlowLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.mainContentPanel, 1, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 55);
            this.contentTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.RowCount = 1;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(1593, 731);
            this.contentTableLayoutPanel.TabIndex = 1;
            // 
            // menuButton
            // 
            this.menuButton.BackgroundImage = global::MyFinance.Views.Properties.Resources.hamburger_icon;
            this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton.FlatAppearance.BorderSize = 0;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Location = new System.Drawing.Point(0, 0);
            this.menuButton.Margin = new System.Windows.Forms.Padding(0);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(55, 55);
            this.menuButton.TabIndex = 0;
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // headerTableLayoutPanel
            // 
            this.headerTableLayoutPanel.BackColor = System.Drawing.Color.Silver;
            this.headerTableLayoutPanel.ColumnCount = 3;
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.headerTableLayoutPanel.Controls.Add(this.menuButton, 0, 0);
            this.headerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.headerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerTableLayoutPanel.Name = "headerTableLayoutPanel";
            this.headerTableLayoutPanel.RowCount = 1;
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayoutPanel.Size = new System.Drawing.Size(1593, 55);
            this.headerTableLayoutPanel.TabIndex = 0;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.Silver;
            this.mainContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(300, 0);
            this.mainContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1293, 731);
            this.mainContentPanel.TabIndex = 1;
            // 
            // menuFlowLayoutPanel
            // 
            this.menuFlowLayoutPanel.AutoScroll = true;
            this.menuFlowLayoutPanel.BackColor = System.Drawing.Color.Silver;
            this.menuFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.menuFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.menuFlowLayoutPanel.Name = "menuFlowLayoutPanel";
            this.menuFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.menuFlowLayoutPanel.Size = new System.Drawing.Size(300, 731);
            this.menuFlowLayoutPanel.TabIndex = 4;
            // 
            // MainScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1593, 786);
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Controls.Add(this.headerTableLayoutPanel);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(850, 650);
            this.Name = "MainScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainScreenForm_FormClosed);
            this.Load += new System.EventHandler(this.MainScreenForm_Load);
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.headerTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel menuFlowLayoutPanel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
    }
}