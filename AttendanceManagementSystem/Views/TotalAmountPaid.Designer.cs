namespace AttendanceManagementSystem.Views
{
    partial class TotalAmountPaid
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            totallingLabel = new Label();
            labelyear = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            salaryDgv = new DataGridView();
            btnLastyear = new Button();
            btnNextyear = new Button();
            searchBtn = new Button();
            totalSalaryDgv = new DataGridView();
            totalJanuary = new DataGridViewTextBoxColumn();
            totalFebruary = new DataGridViewTextBoxColumn();
            totalMarch = new DataGridViewTextBoxColumn();
            totalApril = new DataGridViewTextBoxColumn();
            totalMay = new DataGridViewTextBoxColumn();
            totalJune = new DataGridViewTextBoxColumn();
            totalJuly = new DataGridViewTextBoxColumn();
            totalAugust = new DataGridViewTextBoxColumn();
            totalSeptember = new DataGridViewTextBoxColumn();
            totalOctober = new DataGridViewTextBoxColumn();
            totalNovember = new DataGridViewTextBoxColumn();
            totalDecember = new DataGridViewTextBoxColumn();
            mTotalsalary = new DataGridViewTextBoxColumn();
            monthlyTotalLabel = new Label();
            salaryConfirmationLabel = new Label();
            employeeColum = new DataGridViewTextBoxColumn();
            january = new DataGridViewTextBoxColumn();
            february = new DataGridViewTextBoxColumn();
            march = new DataGridViewTextBoxColumn();
            april = new DataGridViewTextBoxColumn();
            may = new DataGridViewTextBoxColumn();
            june = new DataGridViewTextBoxColumn();
            july = new DataGridViewTextBoxColumn();
            august = new DataGridViewTextBoxColumn();
            september = new DataGridViewTextBoxColumn();
            october = new DataGridViewTextBoxColumn();
            november = new DataGridViewTextBoxColumn();
            december = new DataGridViewTextBoxColumn();
            totalsalary = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)salaryDgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalSalaryDgv).BeginInit();
            SuspendLayout();
            // 
            // totallingLabel
            // 
            totallingLabel.AutoSize = true;
            totallingLabel.Font = new Font("Yu Gothic UI Semibold", 22F);
            totallingLabel.Location = new Point(437, 8);
            totallingLabel.Name = "totallingLabel";
            totallingLabel.Size = new Size(228, 41);
            totallingLabel.TabIndex = 0;
            totallingLabel.Text = "総支給額集計表\n";
            // 
            // labelyear
            // 
            labelyear.AutoSize = true;
            labelyear.Font = new Font("Yu Gothic UI Semibold", 20F);
            labelyear.Location = new Point(496, 60);
            labelyear.Name = "labelyear";
            labelyear.Size = new Size(112, 37);
            labelyear.TabIndex = 1;
            labelyear.Text = "XXXX年";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 10F);
            label3.Location = new Point(694, 72);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 2;
            label3.Text = "検索日";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Yu Gothic UI", 10F);
            dateTimePicker1.Location = new Point(750, 70);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.MaxDate = new DateTime(2024, 9, 9, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(61, 25);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.Value = new DateTime(2024, 9, 9, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // salaryDgv
            // 
            salaryDgv.AllowUserToAddRows = false;
            salaryDgv.AllowUserToDeleteRows = false;
            salaryDgv.AllowUserToResizeColumns = false;
            salaryDgv.AllowUserToResizeRows = false;
            salaryDgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            salaryDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            salaryDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salaryDgv.Columns.AddRange(new DataGridViewColumn[] { employeeColum, january, february, march, april, may, june, july, august, september, october, november, december, totalsalary });
            salaryDgv.Location = new Point(13, 100);
            salaryDgv.Margin = new Padding(3, 2, 3, 2);
            salaryDgv.Name = "salaryDgv";
            salaryDgv.ReadOnly = true;
            salaryDgv.RowHeadersVisible = false;
            salaryDgv.Size = new Size(1050, 391);
            salaryDgv.TabIndex = 5;
            salaryDgv.VisibleChanged += dateTimePicker1_ValueChanged;
            // 
            // btnLastyear
            // 
            btnLastyear.Font = new Font("Yu Gothic UI", 18F);
            btnLastyear.Location = new Point(13, 46);
            btnLastyear.Margin = new Padding(3, 2, 3, 2);
            btnLastyear.Name = "btnLastyear";
            btnLastyear.Size = new Size(35, 48);
            btnLastyear.TabIndex = 6;
            btnLastyear.Text = "◀";
            btnLastyear.UseVisualStyleBackColor = true;
            btnLastyear.Click += btnLastyear_Click;
            // 
            // btnNextyear
            // 
            btnNextyear.Font = new Font("Yu Gothic UI", 18F);
            btnNextyear.Location = new Point(1028, 47);
            btnNextyear.Margin = new Padding(3, 2, 3, 2);
            btnNextyear.Name = "btnNextyear";
            btnNextyear.Size = new Size(35, 48);
            btnNextyear.TabIndex = 7;
            btnNextyear.Text = "▶";
            btnNextyear.UseVisualStyleBackColor = true;
            btnNextyear.Click += btnNextyear_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(819, 70);
            searchBtn.Margin = new Padding(3, 2, 3, 2);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(56, 25);
            searchBtn.TabIndex = 8;
            searchBtn.Text = "検索";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // totalSalaryDgv
            // 
            totalSalaryDgv.AllowUserToAddRows = false;
            totalSalaryDgv.AllowUserToDeleteRows = false;
            totalSalaryDgv.AllowUserToResizeColumns = false;
            totalSalaryDgv.AllowUserToResizeRows = false;
            totalSalaryDgv.Anchor = AnchorStyles.Left;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            totalSalaryDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            totalSalaryDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            totalSalaryDgv.Columns.AddRange(new DataGridViewColumn[] { totalJanuary, totalFebruary, totalMarch, totalApril, totalMay, totalJune, totalJuly, totalAugust, totalSeptember, totalOctober, totalNovember, totalDecember, mTotalsalary });
            totalSalaryDgv.Location = new Point(112, 512);
            totalSalaryDgv.Margin = new Padding(3, 2, 3, 2);
            totalSalaryDgv.Name = "totalSalaryDgv";
            totalSalaryDgv.ReadOnly = true;
            totalSalaryDgv.RowHeadersVisible = false;
            totalSalaryDgv.Size = new Size(934, 50);
            totalSalaryDgv.TabIndex = 9;
            totalSalaryDgv.VisibleChanged += dateTimePicker2_ValueChanged;
            // 
            // totalJanuary
            // 
            totalJanuary.DataPropertyName = "January";
            totalJanuary.FillWeight = 95.25315F;
            totalJanuary.HeaderText = "１月";
            totalJanuary.Name = "totalJanuary";
            totalJanuary.ReadOnly = true;
            totalJanuary.Width = 70;
            // 
            // totalFebruary
            // 
            totalFebruary.DataPropertyName = "February";
            totalFebruary.FillWeight = 95.4237747F;
            totalFebruary.HeaderText = "２月";
            totalFebruary.Name = "totalFebruary";
            totalFebruary.ReadOnly = true;
            totalFebruary.Width = 70;
            // 
            // totalMarch
            // 
            totalMarch.DataPropertyName = "March";
            totalMarch.FillWeight = 95.5818F;
            totalMarch.HeaderText = "３月";
            totalMarch.Name = "totalMarch";
            totalMarch.ReadOnly = true;
            totalMarch.Width = 70;
            // 
            // totalApril
            // 
            totalApril.DataPropertyName = "April";
            totalApril.FillWeight = 95.7281342F;
            totalApril.HeaderText = "４月";
            totalApril.Name = "totalApril";
            totalApril.ReadOnly = true;
            totalApril.Width = 70;
            // 
            // totalMay
            // 
            totalMay.DataPropertyName = "May";
            totalMay.FillWeight = 95.86371F;
            totalMay.HeaderText = "５月";
            totalMay.Name = "totalMay";
            totalMay.ReadOnly = true;
            totalMay.Width = 70;
            // 
            // totalJune
            // 
            totalJune.DataPropertyName = "June";
            totalJune.FillWeight = 95.98924F;
            totalJune.HeaderText = "６月";
            totalJune.Name = "totalJune";
            totalJune.ReadOnly = true;
            totalJune.Width = 70;
            // 
            // totalJuly
            // 
            totalJuly.DataPropertyName = "July";
            totalJuly.FillWeight = 96.1055F;
            totalJuly.HeaderText = "７月";
            totalJuly.Name = "totalJuly";
            totalJuly.ReadOnly = true;
            totalJuly.Width = 70;
            // 
            // totalAugust
            // 
            totalAugust.DataPropertyName = "August";
            totalAugust.FillWeight = 96.2131958F;
            totalAugust.HeaderText = "８月";
            totalAugust.Name = "totalAugust";
            totalAugust.ReadOnly = true;
            totalAugust.Width = 70;
            // 
            // totalSeptember
            // 
            totalSeptember.DataPropertyName = "September";
            totalSeptember.FillWeight = 96.31292F;
            totalSeptember.HeaderText = "９月";
            totalSeptember.Name = "totalSeptember";
            totalSeptember.ReadOnly = true;
            totalSeptember.Width = 70;
            // 
            // totalOctober
            // 
            totalOctober.DataPropertyName = "October";
            totalOctober.FillWeight = 96.40531F;
            totalOctober.HeaderText = "１０月";
            totalOctober.Name = "totalOctober";
            totalOctober.ReadOnly = true;
            totalOctober.Width = 70;
            // 
            // totalNovember
            // 
            totalNovember.DataPropertyName = "November";
            totalNovember.FillWeight = 96.4908447F;
            totalNovember.HeaderText = "１１月";
            totalNovember.Name = "totalNovember";
            totalNovember.ReadOnly = true;
            totalNovember.Width = 70;
            // 
            // totalDecember
            // 
            totalDecember.DataPropertyName = "December";
            totalDecember.FillWeight = 96.57007F;
            totalDecember.HeaderText = "１２月";
            totalDecember.Name = "totalDecember";
            totalDecember.ReadOnly = true;
            totalDecember.Width = 70;
            // 
            // mTotalsalary
            // 
            mTotalsalary.DataPropertyName = "Totalsalary";
            mTotalsalary.FillWeight = 138.062073F;
            mTotalsalary.HeaderText = "年/合計";
            mTotalsalary.Name = "mTotalsalary";
            mTotalsalary.ReadOnly = true;
            mTotalsalary.Width = 90;
            // 
            // monthlyTotalLabel
            // 
            monthlyTotalLabel.AutoSize = true;
            monthlyTotalLabel.Font = new Font("Yu Gothic UI Semibold", 17F);
            monthlyTotalLabel.Location = new Point(12, 531);
            monthlyTotalLabel.Name = "monthlyTotalLabel";
            monthlyTotalLabel.Size = new Size(93, 31);
            monthlyTotalLabel.TabIndex = 10;
            monthlyTotalLabel.Text = "月/合計";
            // 
            // salaryConfirmationLabel
            // 
            salaryConfirmationLabel.AutoSize = true;
            salaryConfirmationLabel.Font = new Font("Yu Gothic UI Semibold", 22F);
            salaryConfirmationLabel.Location = new Point(112, 55);
            salaryConfirmationLabel.Name = "salaryConfirmationLabel";
            salaryConfirmationLabel.Size = new Size(138, 41);
            salaryConfirmationLabel.TabIndex = 11;
            salaryConfirmationLabel.Text = "給料確認";
            // 
            // employeeColum
            // 
            employeeColum.DataPropertyName = "EmployeeName";
            employeeColum.FillWeight = 133.715408F;
            employeeColum.HeaderText = "従業員名";
            employeeColum.Name = "employeeColum";
            employeeColum.ReadOnly = true;
            // 
            // january
            // 
            january.DataPropertyName = "January";
            january.FillWeight = 91.55962F;
            january.HeaderText = "１月";
            january.Name = "january";
            january.ReadOnly = true;
            january.Width = 70;
            // 
            // february
            // 
            february.DataPropertyName = "February";
            february.FillWeight = 92.3369141F;
            february.HeaderText = "２月";
            february.Name = "february";
            february.ReadOnly = true;
            february.Width = 70;
            // 
            // march
            // 
            march.DataPropertyName = "March";
            march.FillWeight = 93.0622253F;
            march.HeaderText = "３月";
            march.Name = "march";
            march.ReadOnly = true;
            march.Width = 70;
            // 
            // april
            // 
            april.DataPropertyName = "April";
            april.FillWeight = 93.7390747F;
            april.HeaderText = "４月";
            april.Name = "april";
            april.ReadOnly = true;
            april.Width = 70;
            // 
            // may
            // 
            may.DataPropertyName = "May";
            may.FillWeight = 94.37065F;
            may.HeaderText = "５月";
            may.Name = "may";
            may.ReadOnly = true;
            may.Width = 70;
            // 
            // june
            // 
            june.DataPropertyName = "June";
            june.FillWeight = 94.96F;
            june.HeaderText = "６月";
            june.Name = "june";
            june.ReadOnly = true;
            june.Width = 70;
            // 
            // july
            // 
            july.DataPropertyName = "July";
            july.FillWeight = 95.5099258F;
            july.HeaderText = "７月";
            july.Name = "july";
            july.ReadOnly = true;
            july.Width = 70;
            // 
            // august
            // 
            august.DataPropertyName = "August";
            august.FillWeight = 96.0231247F;
            august.HeaderText = "８月";
            august.Name = "august";
            august.ReadOnly = true;
            august.Width = 70;
            // 
            // september
            // 
            september.DataPropertyName = "September";
            september.FillWeight = 96.502F;
            september.HeaderText = "９月";
            september.Name = "september";
            september.ReadOnly = true;
            september.Width = 70;
            // 
            // october
            // 
            october.DataPropertyName = "October";
            october.FillWeight = 96.94887F;
            october.HeaderText = "１０月";
            october.Name = "october";
            october.ReadOnly = true;
            october.Width = 70;
            // 
            // november
            // 
            november.DataPropertyName = "November";
            november.FillWeight = 97.3658142F;
            november.HeaderText = "１１月";
            november.Name = "november";
            november.ReadOnly = true;
            november.Width = 70;
            // 
            // december
            // 
            december.DataPropertyName = "December";
            december.FillWeight = 97.7549057F;
            december.HeaderText = "１２月";
            december.Name = "december";
            december.ReadOnly = true;
            december.Width = 70;
            // 
            // totalsalary
            // 
            totalsalary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            totalsalary.DataPropertyName = "Totalsalary";
            totalsalary.FillWeight = 126.151733F;
            totalsalary.HeaderText = "年/合計";
            totalsalary.Name = "totalsalary";
            totalsalary.ReadOnly = true;
            // 
            // TotalAmountPaid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 576);
            Controls.Add(salaryConfirmationLabel);
            Controls.Add(monthlyTotalLabel);
            Controls.Add(totalSalaryDgv);
            Controls.Add(searchBtn);
            Controls.Add(btnNextyear);
            Controls.Add(btnLastyear);
            Controls.Add(salaryDgv);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(labelyear);
            Controls.Add(totallingLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TotalAmountPaid";
            Text = "TotalAmountPaid";
            Load += TotalAmountPaid_Load;
            ((System.ComponentModel.ISupportInitialize)salaryDgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalSalaryDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label totallingLabel;
        private Label labelyear;
        private Label label3;
        private Button btnSearch;
        private DataGridView salaryDgv;
        public DateTimePicker dateTimePicker1;
        private Button btnLastyear;
        private Button btnNextyear;
        private Button searchBtn;
        private DataGridView totalSalaryDgv;
        private Label monthlyTotalLabel;
        private DataGridViewTextBoxColumn totalJanuary;
        private DataGridViewTextBoxColumn totalFebruary;
        private DataGridViewTextBoxColumn totalMarch;
        private DataGridViewTextBoxColumn totalApril;
        private DataGridViewTextBoxColumn totalMay;
        private DataGridViewTextBoxColumn totalJune;
        private DataGridViewTextBoxColumn totalJuly;
        private DataGridViewTextBoxColumn totalAugust;
        private DataGridViewTextBoxColumn totalSeptember;
        private DataGridViewTextBoxColumn totalOctober;
        private DataGridViewTextBoxColumn totalNovember;
        private DataGridViewTextBoxColumn totalDecember;
        private DataGridViewTextBoxColumn mTotalsalary;
        private Label salaryConfirmationLabel;
        private DataGridViewTextBoxColumn employeeColum;
        private DataGridViewTextBoxColumn january;
        private DataGridViewTextBoxColumn february;
        private DataGridViewTextBoxColumn march;
        private DataGridViewTextBoxColumn april;
        private DataGridViewTextBoxColumn may;
        private DataGridViewTextBoxColumn june;
        private DataGridViewTextBoxColumn july;
        private DataGridViewTextBoxColumn august;
        private DataGridViewTextBoxColumn september;
        private DataGridViewTextBoxColumn october;
        private DataGridViewTextBoxColumn november;
        private DataGridViewTextBoxColumn december;
        private DataGridViewTextBoxColumn totalsalary;
    }
}