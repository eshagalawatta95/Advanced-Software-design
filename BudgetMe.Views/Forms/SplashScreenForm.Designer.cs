using BudgetMe.Views.UserControls;

namespace BudgetMe.Views.Forms
{
    partial class SplashScreenForm
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
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.pbarProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.userRegistrationPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userDetailsSaveButton = new System.Windows.Forms.Button();
            this.userStartingBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userRegistrationErrorLabel = new System.Windows.Forms.Label();
            this.finTimLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.userRegistrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finTimLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressStatus.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProgressStatus.Location = new System.Drawing.Point(42, 651);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(1143, 39);
            this.lblProgressStatus.TabIndex = 0;
            this.lblProgressStatus.Text = "Please wait...";
            this.lblProgressStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbarProgressBar
            // 
            this.pbarProgressBar.Location = new System.Drawing.Point(18, 627);
            this.pbarProgressBar.MarqueeAnimationSpeed = 10;
            this.pbarProgressBar.Name = "pbarProgressBar";
            this.pbarProgressBar.Size = new System.Drawing.Size(1164, 10);
            this.pbarProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarProgressBar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(348, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(486, 70);
            this.label2.TabIndex = 3;
            this.label2.Text = "BudgetMe v1.0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // userRegistrationPanel
            // 
            this.userRegistrationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.userRegistrationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userRegistrationPanel.Controls.Add(this.label7);
            this.userRegistrationPanel.Controls.Add(this.label3);
            this.userRegistrationPanel.Controls.Add(this.label1);
            this.userRegistrationPanel.Controls.Add(this.userDetailsSaveButton);
            this.userRegistrationPanel.Controls.Add(this.userStartingBalanceTextBox);
            this.userRegistrationPanel.Controls.Add(this.label6);
            this.userRegistrationPanel.Controls.Add(this.userLastNameTextBox);
            this.userRegistrationPanel.Controls.Add(this.label5);
            this.userRegistrationPanel.Controls.Add(this.userFirstNameTextBox);
            this.userRegistrationPanel.Controls.Add(this.label4);
            this.userRegistrationPanel.Controls.Add(this.userRegistrationErrorLabel);
            this.userRegistrationPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistrationPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userRegistrationPanel.Location = new System.Drawing.Point(165, 139);
            this.userRegistrationPanel.Name = "userRegistrationPanel";
            this.userRegistrationPanel.Size = new System.Drawing.Size(870, 447);
            this.userRegistrationPanel.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(722, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 32);
            this.label7.TabIndex = 12;
            this.label7.Tag = "LKR";
            this.label7.Text = "LKR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(825, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(276, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "User Registration";
            // 
            // userDetailsSaveButton
            // 
            this.userDetailsSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.userDetailsSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.userDetailsSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.userDetailsSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.userDetailsSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userDetailsSaveButton.ForeColor = System.Drawing.Color.LightGray;
            this.userDetailsSaveButton.Location = new System.Drawing.Point(609, 352);
            this.userDetailsSaveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.userDetailsSaveButton.Name = "userDetailsSaveButton";
            this.userDetailsSaveButton.Size = new System.Drawing.Size(187, 63);
            this.userDetailsSaveButton.TabIndex = 4;
            this.userDetailsSaveButton.Text = "SAVE";
            this.userDetailsSaveButton.UseVisualStyleBackColor = false;
            this.userDetailsSaveButton.Click += new System.EventHandler(this.userDetailsSaveButton_Click_2);
            // 
            // userStartingBalanceTextBox
            // 
            this.userStartingBalanceTextBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStartingBalanceTextBox.Location = new System.Drawing.Point(301, 273);
            this.userStartingBalanceTextBox.MaxLength = 10;
            this.userStartingBalanceTextBox.Name = "userStartingBalanceTextBox";
            this.userStartingBalanceTextBox.Size = new System.Drawing.Size(495, 42);
            this.userStartingBalanceTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(45, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 72);
            this.label6.TabIndex = 6;
            this.label6.Text = "Starting Balance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userLastNameTextBox
            // 
            this.userLastNameTextBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLastNameTextBox.Location = new System.Drawing.Point(301, 209);
            this.userLastNameTextBox.MaxLength = 100;
            this.userLastNameTextBox.Name = "userLastNameTextBox";
            this.userLastNameTextBox.Size = new System.Drawing.Size(495, 42);
            this.userLastNameTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(45, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 63);
            this.label5.TabIndex = 4;
            this.label5.Text = "Last Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userFirstNameTextBox
            // 
            this.userFirstNameTextBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userFirstNameTextBox.Location = new System.Drawing.Point(301, 147);
            this.userFirstNameTextBox.MaxLength = 100;
            this.userFirstNameTextBox.Name = "userFirstNameTextBox";
            this.userFirstNameTextBox.Size = new System.Drawing.Size(495, 42);
            this.userFirstNameTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(45, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 53);
            this.label4.TabIndex = 2;
            this.label4.Text = "First Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userRegistrationErrorLabel
            // 
            this.userRegistrationErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistrationErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.userRegistrationErrorLabel.Location = new System.Drawing.Point(-51, 352);
            this.userRegistrationErrorLabel.Name = "userRegistrationErrorLabel";
            this.userRegistrationErrorLabel.Size = new System.Drawing.Size(623, 50);
            this.userRegistrationErrorLabel.TabIndex = 8;
            this.userRegistrationErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // finTimLogoPictureBox
            // 
            this.finTimLogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.finTimLogoPictureBox.BackgroundImage = global::BudgetMe.Views.Properties.Resources.frontImageforapp;
            this.finTimLogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.finTimLogoPictureBox.Location = new System.Drawing.Point(323, 139);
            this.finTimLogoPictureBox.Name = "finTimLogoPictureBox";
            this.finTimLogoPictureBox.Size = new System.Drawing.Size(479, 431);
            this.finTimLogoPictureBox.TabIndex = 6;
            this.finTimLogoPictureBox.TabStop = false;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1197, 709);
            this.ControlBox = false;
            this.Controls.Add(this.userRegistrationPanel);
            this.Controls.Add(this.finTimLogoPictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbarProgressBar);
            this.Controls.Add(this.lblProgressStatus);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreenForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.SplashScreenForm_Load);
            this.Shown += new System.EventHandler(this.SplashScreenForm_Shown);
            this.userRegistrationPanel.ResumeLayout(false);
            this.userRegistrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finTimLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbarProgressBar;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox finTimLogoPictureBox;
        private System.Windows.Forms.Panel userRegistrationPanel;
        private System.Windows.Forms.TextBox userStartingBalanceTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userLastNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userFirstNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label userRegistrationErrorLabel;
        private System.Windows.Forms.Button userDetailsSaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}