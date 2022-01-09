namespace MyFinance.Views.UserControls.Summary
{
    partial class PredictionUserControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.actionsUserControl = new MyFinance.Views.UserControls.ActionsUserControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.predictDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.predictDateErrorLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.previousDataComboBox = new System.Windows.Forms.ComboBox();
            this.previousDataErrorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resultGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label32 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.monInLabel = new System.Windows.Forms.Label();
            this.monOutLabel = new System.Windows.Forms.Label();
            this.tueInLabel = new System.Windows.Forms.Label();
            this.tueOutLabel = new System.Windows.Forms.Label();
            this.wedInLabel = new System.Windows.Forms.Label();
            this.wedOutLabel = new System.Windows.Forms.Label();
            this.thuInLabel = new System.Windows.Forms.Label();
            this.thuOutLabel = new System.Windows.Forms.Label();
            this.friInLabel = new System.Windows.Forms.Label();
            this.friOutLabel = new System.Windows.Forms.Label();
            this.satInLabel = new System.Windows.Forms.Label();
            this.satOutLabel = new System.Windows.Forms.Label();
            this.sunInLabel = new System.Windows.Forms.Label();
            this.sunOutLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.avgExpensesLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.avgIncomeLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.balanceOnTodayLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.balanceOnValueLabel = new System.Windows.Forms.Label();
            this.balanceOnIntroLabel = new System.Windows.Forms.Label();
            this.contentHeaderUserControl1 = new MyFinance.Views.UserControls.ContentHeaderUserControl();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.resultGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.actionsUserControl);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.MaximumSize = new System.Drawing.Size(2133, 2385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(27, 24, 27, 24);
            this.groupBox1.Size = new System.Drawing.Size(1274, 422);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter predict data";
            // 
            // actionsUserControl
            // 
            this.actionsUserControl.DeleteButtonToolTip = "Delete transaction party";
            this.actionsUserControl.DeleteButtonVisible = false;
            this.actionsUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionsUserControl.ErrorMessageText = "";
            this.actionsUserControl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionsUserControl.Location = new System.Drawing.Point(27, 262);
            this.actionsUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.actionsUserControl.Name = "actionsUserControl";
            this.actionsUserControl.PredictButtonToolTip = "Predict for selected date";
            this.actionsUserControl.PredictButtonVisible = true;
            this.actionsUserControl.ResetButtonToolTip = "Reset data";
            this.actionsUserControl.SaveButtonVisible = false;
            this.actionsUserControl.Size = new System.Drawing.Size(1220, 131);
            this.actionsUserControl.TabIndex = 7;
            this.actionsUserControl.ResetButtonOnClick += new System.EventHandler(this.actionsUserControl_ResetButtonOnClick);
            this.actionsUserControl.PredictButtonOnClick += new System.EventHandler(this.actionsUserControl_PredictButtonOnClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(27, 62);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1220, 200);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.predictDateDateTimePicker);
            this.panel4.Controls.Add(this.predictDateErrorLabel);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(610, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(27, 24, 27, 24);
            this.panel4.Size = new System.Drawing.Size(610, 200);
            this.panel4.TabIndex = 8;
            // 
            // predictDateDateTimePicker
            // 
            this.predictDateDateTimePicker.CustomFormat = "dd MMM, yyyy ";
            this.predictDateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.predictDateDateTimePicker.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.predictDateDateTimePicker.Location = new System.Drawing.Point(27, 69);
            this.predictDateDateTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.predictDateDateTimePicker.Name = "predictDateDateTimePicker";
            this.predictDateDateTimePicker.Size = new System.Drawing.Size(556, 62);
            this.predictDateDateTimePicker.TabIndex = 3;
            // 
            // predictDateErrorLabel
            // 
            this.predictDateErrorLabel.AutoSize = true;
            this.predictDateErrorLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictDateErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.predictDateErrorLabel.Location = new System.Drawing.Point(35, 145);
            this.predictDateErrorLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.predictDateErrorLabel.Name = "predictDateErrorLabel";
            this.predictDateErrorLabel.Size = new System.Drawing.Size(98, 38);
            this.predictDateErrorLabel.TabIndex = 2;
            this.predictDateErrorLabel.Text = "Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 45);
            this.label4.TabIndex = 0;
            this.label4.Text = "Predict Date";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.previousDataComboBox);
            this.panel3.Controls.Add(this.previousDataErrorLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(27, 24, 27, 24);
            this.panel3.Size = new System.Drawing.Size(610, 200);
            this.panel3.TabIndex = 7;
            // 
            // previousDataComboBox
            // 
            this.previousDataComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.previousDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.previousDataComboBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousDataComboBox.FormattingEnabled = true;
            this.previousDataComboBox.Location = new System.Drawing.Point(27, 69);
            this.previousDataComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.previousDataComboBox.Name = "previousDataComboBox";
            this.previousDataComboBox.Size = new System.Drawing.Size(556, 61);
            this.previousDataComboBox.TabIndex = 3;
            // 
            // previousDataErrorLabel
            // 
            this.previousDataErrorLabel.AutoSize = true;
            this.previousDataErrorLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousDataErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.previousDataErrorLabel.Location = new System.Drawing.Point(35, 145);
            this.previousDataErrorLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.previousDataErrorLabel.Name = "previousDataErrorLabel";
            this.previousDataErrorLabel.Size = new System.Drawing.Size(98, 38);
            this.previousDataErrorLabel.TabIndex = 2;
            this.previousDataErrorLabel.Text = "Error";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Previous Data";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resultGroup);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 128);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(27, 24, 27, 0);
            this.panel1.Size = new System.Drawing.Size(1328, 1179);
            this.panel1.TabIndex = 3;
            // 
            // resultGroup
            // 
            this.resultGroup.Controls.Add(this.tableLayoutPanel1);
            this.resultGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGroup.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultGroup.Location = new System.Drawing.Point(27, 446);
            this.resultGroup.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.resultGroup.Name = "resultGroup";
            this.resultGroup.Padding = new System.Windows.Forms.Padding(27, 24, 27, 24);
            this.resultGroup.Size = new System.Drawing.Size(1274, 733);
            this.resultGroup.TabIndex = 3;
            this.resultGroup.TabStop = false;
            this.resultGroup.Text = "Results";
            this.resultGroup.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 62);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1220, 647);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(496, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0, 24, 0, 24);
            this.groupBox4.Size = new System.Drawing.Size(716, 633);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "By Day";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label32, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.label29, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label23, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.monInLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.monOutLabel, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.tueInLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tueOutLabel, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.wedInLabel, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.wedOutLabel, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.thuInLabel, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.thuOutLabel, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.friInLabel, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.friOutLabel, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.satInLabel, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.satOutLabel, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.sunInLabel, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.sunOutLabel, 2, 7);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(716, 541);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(9, 470);
            this.label32.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(131, 70);
            this.label32.TabIndex = 21;
            this.label32.Text = "Sun";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(9, 403);
            this.label29.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(131, 66);
            this.label29.TabIndex = 18;
            this.label29.Text = "Sat";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(9, 336);
            this.label26.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(131, 66);
            this.label26.TabIndex = 15;
            this.label26.Text = "Fri";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(9, 269);
            this.label23.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(131, 66);
            this.label23.TabIndex = 12;
            this.label23.Text = "Thu";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(9, 202);
            this.label20.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(131, 66);
            this.label20.TabIndex = 9;
            this.label20.Text = "Wed";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 135);
            this.label17.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 66);
            this.label17.TabIndex = 6;
            this.label17.Text = "Tue";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 68);
            this.label14.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 66);
            this.label14.TabIndex = 3;
            this.label14.Text = "Mon";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(440, 1);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(267, 66);
            this.label13.TabIndex = 2;
            this.label13.Text = "Out";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(157, 1);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(266, 66);
            this.label12.TabIndex = 1;
            this.label12.Text = "In";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 66);
            this.label11.TabIndex = 0;
            this.label11.Text = "Day";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monInLabel
            // 
            this.monInLabel.AutoSize = true;
            this.monInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monInLabel.Location = new System.Drawing.Point(157, 68);
            this.monInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.monInLabel.Name = "monInLabel";
            this.monInLabel.Size = new System.Drawing.Size(266, 66);
            this.monInLabel.TabIndex = 22;
            this.monInLabel.Text = "--.--";
            this.monInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monOutLabel
            // 
            this.monOutLabel.AutoSize = true;
            this.monOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monOutLabel.Location = new System.Drawing.Point(440, 68);
            this.monOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.monOutLabel.Name = "monOutLabel";
            this.monOutLabel.Size = new System.Drawing.Size(267, 66);
            this.monOutLabel.TabIndex = 23;
            this.monOutLabel.Text = "--.--";
            this.monOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tueInLabel
            // 
            this.tueInLabel.AutoSize = true;
            this.tueInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tueInLabel.Location = new System.Drawing.Point(157, 135);
            this.tueInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tueInLabel.Name = "tueInLabel";
            this.tueInLabel.Size = new System.Drawing.Size(266, 66);
            this.tueInLabel.TabIndex = 24;
            this.tueInLabel.Text = "--.--";
            this.tueInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tueOutLabel
            // 
            this.tueOutLabel.AutoSize = true;
            this.tueOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tueOutLabel.Location = new System.Drawing.Point(440, 135);
            this.tueOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tueOutLabel.Name = "tueOutLabel";
            this.tueOutLabel.Size = new System.Drawing.Size(267, 66);
            this.tueOutLabel.TabIndex = 25;
            this.tueOutLabel.Text = "--.--";
            this.tueOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wedInLabel
            // 
            this.wedInLabel.AutoSize = true;
            this.wedInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wedInLabel.Location = new System.Drawing.Point(157, 202);
            this.wedInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.wedInLabel.Name = "wedInLabel";
            this.wedInLabel.Size = new System.Drawing.Size(266, 66);
            this.wedInLabel.TabIndex = 26;
            this.wedInLabel.Text = "--.--";
            this.wedInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wedOutLabel
            // 
            this.wedOutLabel.AutoSize = true;
            this.wedOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wedOutLabel.Location = new System.Drawing.Point(440, 202);
            this.wedOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.wedOutLabel.Name = "wedOutLabel";
            this.wedOutLabel.Size = new System.Drawing.Size(267, 66);
            this.wedOutLabel.TabIndex = 27;
            this.wedOutLabel.Text = "--.--";
            this.wedOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thuInLabel
            // 
            this.thuInLabel.AutoSize = true;
            this.thuInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thuInLabel.Location = new System.Drawing.Point(157, 269);
            this.thuInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.thuInLabel.Name = "thuInLabel";
            this.thuInLabel.Size = new System.Drawing.Size(266, 66);
            this.thuInLabel.TabIndex = 28;
            this.thuInLabel.Text = "--.--";
            this.thuInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thuOutLabel
            // 
            this.thuOutLabel.AutoSize = true;
            this.thuOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thuOutLabel.Location = new System.Drawing.Point(440, 269);
            this.thuOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.thuOutLabel.Name = "thuOutLabel";
            this.thuOutLabel.Size = new System.Drawing.Size(267, 66);
            this.thuOutLabel.TabIndex = 29;
            this.thuOutLabel.Text = "--.--";
            this.thuOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // friInLabel
            // 
            this.friInLabel.AutoSize = true;
            this.friInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friInLabel.Location = new System.Drawing.Point(157, 336);
            this.friInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.friInLabel.Name = "friInLabel";
            this.friInLabel.Size = new System.Drawing.Size(266, 66);
            this.friInLabel.TabIndex = 30;
            this.friInLabel.Text = "--.--";
            this.friInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // friOutLabel
            // 
            this.friOutLabel.AutoSize = true;
            this.friOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friOutLabel.Location = new System.Drawing.Point(440, 336);
            this.friOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.friOutLabel.Name = "friOutLabel";
            this.friOutLabel.Size = new System.Drawing.Size(267, 66);
            this.friOutLabel.TabIndex = 31;
            this.friOutLabel.Text = "--.--";
            this.friOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // satInLabel
            // 
            this.satInLabel.AutoSize = true;
            this.satInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satInLabel.Location = new System.Drawing.Point(157, 403);
            this.satInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.satInLabel.Name = "satInLabel";
            this.satInLabel.Size = new System.Drawing.Size(266, 66);
            this.satInLabel.TabIndex = 32;
            this.satInLabel.Text = "--.--";
            this.satInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // satOutLabel
            // 
            this.satOutLabel.AutoSize = true;
            this.satOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satOutLabel.Location = new System.Drawing.Point(440, 403);
            this.satOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.satOutLabel.Name = "satOutLabel";
            this.satOutLabel.Size = new System.Drawing.Size(267, 66);
            this.satOutLabel.TabIndex = 33;
            this.satOutLabel.Text = "--.--";
            this.satOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sunInLabel
            // 
            this.sunInLabel.AutoSize = true;
            this.sunInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sunInLabel.Location = new System.Drawing.Point(157, 470);
            this.sunInLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.sunInLabel.Name = "sunInLabel";
            this.sunInLabel.Size = new System.Drawing.Size(266, 70);
            this.sunInLabel.TabIndex = 34;
            this.sunInLabel.Text = "--.--";
            this.sunInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sunOutLabel
            // 
            this.sunOutLabel.AutoSize = true;
            this.sunOutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sunOutLabel.Location = new System.Drawing.Point(440, 470);
            this.sunOutLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.sunOutLabel.Name = "sunOutLabel";
            this.sunOutLabel.Size = new System.Drawing.Size(267, 70);
            this.sunOutLabel.TabIndex = 35;
            this.sunOutLabel.Text = "--.--";
            this.sunOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.avgExpensesLabel);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.avgIncomeLabel);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.balanceOnTodayLabel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.balanceOnValueLabel);
            this.groupBox3.Controls.Add(this.balanceOnIntroLabel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox3.Size = new System.Drawing.Size(472, 633);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Genaral";
            // 
            // avgExpensesLabel
            // 
            this.avgExpensesLabel.AutoSize = true;
            this.avgExpensesLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgExpensesLabel.Location = new System.Drawing.Point(24, 494);
            this.avgExpensesLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.avgExpensesLabel.Name = "avgExpensesLabel";
            this.avgExpensesLabel.Size = new System.Drawing.Size(101, 56);
            this.avgExpensesLabel.TabIndex = 7;
            this.avgExpensesLabel.Text = "--.--";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 455);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(419, 43);
            this.label10.TabIndex = 6;
            this.label10.Text = "Daily average expenses";
            // 
            // avgIncomeLabel
            // 
            this.avgIncomeLabel.AutoSize = true;
            this.avgIncomeLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgIncomeLabel.Location = new System.Drawing.Point(24, 370);
            this.avgIncomeLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.avgIncomeLabel.Name = "avgIncomeLabel";
            this.avgIncomeLabel.Size = new System.Drawing.Size(101, 56);
            this.avgIncomeLabel.TabIndex = 5;
            this.avgIncomeLabel.Text = "--.--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 331);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(384, 43);
            this.label8.TabIndex = 4;
            this.label8.Text = "Daily average income";
            // 
            // balanceOnTodayLabel
            // 
            this.balanceOnTodayLabel.AutoSize = true;
            this.balanceOnTodayLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceOnTodayLabel.Location = new System.Drawing.Point(24, 236);
            this.balanceOnTodayLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.balanceOnTodayLabel.Name = "balanceOnTodayLabel";
            this.balanceOnTodayLabel.Size = new System.Drawing.Size(101, 56);
            this.balanceOnTodayLabel.TabIndex = 3;
            this.balanceOnTodayLabel.Text = "--.--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 43);
            this.label6.TabIndex = 2;
            this.label6.Text = "Balance on today";
            // 
            // balanceOnValueLabel
            // 
            this.balanceOnValueLabel.AutoSize = true;
            this.balanceOnValueLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceOnValueLabel.Location = new System.Drawing.Point(24, 112);
            this.balanceOnValueLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.balanceOnValueLabel.Name = "balanceOnValueLabel";
            this.balanceOnValueLabel.Size = new System.Drawing.Size(101, 56);
            this.balanceOnValueLabel.TabIndex = 1;
            this.balanceOnValueLabel.Text = "--.--";
            // 
            // balanceOnIntroLabel
            // 
            this.balanceOnIntroLabel.AutoSize = true;
            this.balanceOnIntroLabel.Location = new System.Drawing.Point(16, 74);
            this.balanceOnIntroLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.balanceOnIntroLabel.Name = "balanceOnIntroLabel";
            this.balanceOnIntroLabel.Size = new System.Drawing.Size(463, 43);
            this.balanceOnIntroLabel.TabIndex = 0;
            this.balanceOnIntroLabel.Text = "Balance on XXXX-YYY-ZZ";
            // 
            // contentHeaderUserControl1
            // 
            this.contentHeaderUserControl1.AddButtonVisible = false;
            this.contentHeaderUserControl1.BackButtonVisible = false;
            this.contentHeaderUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl1.MainTitle = "Predictor";
            this.contentHeaderUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl1.Name = "contentHeaderUserControl1";
            this.contentHeaderUserControl1.Size = new System.Drawing.Size(1328, 128);
            this.contentHeaderUserControl1.TabIndex = 0;
            // 
            // PredictionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contentHeaderUserControl1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "PredictionUserControl";
            this.Size = new System.Drawing.Size(1328, 1307);
            this.Load += new System.EventHandler(this.PredictionUserControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.resultGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label predictDateErrorLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label previousDataErrorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox previousDataComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker predictDateDateTimePicker;
        private ActionsUserControl actionsUserControl;
        private System.Windows.Forms.GroupBox resultGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label avgExpensesLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label avgIncomeLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label balanceOnTodayLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label balanceOnValueLabel;
        private System.Windows.Forms.Label balanceOnIntroLabel;
        private System.Windows.Forms.Label monInLabel;
        private System.Windows.Forms.Label monOutLabel;
        private System.Windows.Forms.Label tueInLabel;
        private System.Windows.Forms.Label tueOutLabel;
        private System.Windows.Forms.Label wedInLabel;
        private System.Windows.Forms.Label wedOutLabel;
        private System.Windows.Forms.Label thuInLabel;
        private System.Windows.Forms.Label thuOutLabel;
        private System.Windows.Forms.Label friInLabel;
        private System.Windows.Forms.Label friOutLabel;
        private System.Windows.Forms.Label satInLabel;
        private System.Windows.Forms.Label satOutLabel;
        private System.Windows.Forms.Label sunInLabel;
        private System.Windows.Forms.Label sunOutLabel;
    }
}
