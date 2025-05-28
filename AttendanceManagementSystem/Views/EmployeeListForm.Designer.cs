namespace AttendanceManagementSystem
{
    partial class EmployeeListForm
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
            dgvEmployees = new DataGridView();
            lblSearchEmployeeName = new Label();
            lblBirthDate = new Label();
            lblcontactNumber = new Label();
            txtSearchEmployeeName = new TextBox();
            txtSearchContactNumber = new TextBox();
            btnSearch = new Button();
            dtpSearchBirthDate = new DateTimePicker();
            chbBirthday = new CheckBox();
            AddButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(25, 64);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.Size = new Size(773, 334);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // lblSearchEmployeeName
            // 
            lblSearchEmployeeName.AutoSize = true;
            lblSearchEmployeeName.Location = new Point(12, 18);
            lblSearchEmployeeName.Name = "lblSearchEmployeeName";
            lblSearchEmployeeName.Size = new Size(55, 15);
            lblSearchEmployeeName.TabIndex = 1;
            lblSearchEmployeeName.Text = "従業員名";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(431, 18);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(55, 15);
            lblBirthDate.TabIndex = 2;
            lblBirthDate.Text = "生年月日";
            // 
            // lblcontactNumber
            // 
            lblcontactNumber.AutoSize = true;
            lblcontactNumber.Location = new Point(218, 18);
            lblcontactNumber.Name = "lblcontactNumber";
            lblcontactNumber.Size = new Size(55, 15);
            lblcontactNumber.TabIndex = 3;
            lblcontactNumber.Text = "電話番号";
            // 
            // txtSearchEmployeeName
            // 
            txtSearchEmployeeName.Location = new Point(73, 15);
            txtSearchEmployeeName.Name = "txtSearchEmployeeName";
            txtSearchEmployeeName.Size = new Size(125, 23);
            txtSearchEmployeeName.TabIndex = 4;
            // 
            // txtSearchContactNumber
            // 
            txtSearchContactNumber.Location = new Point(279, 15);
            txtSearchContactNumber.Name = "txtSearchContactNumber";
            txtSearchContactNumber.Size = new Size(125, 23);
            txtSearchContactNumber.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(642, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += getEmployeeButton_Click;
            // 
            // dtpSearchBirthDate
            // 
            dtpSearchBirthDate.Enabled = false;
            dtpSearchBirthDate.Format = DateTimePickerFormat.Short;
            dtpSearchBirthDate.Location = new Point(513, 12);
            dtpSearchBirthDate.Name = "dtpSearchBirthDate";
            dtpSearchBirthDate.Size = new Size(104, 23);
            dtpSearchBirthDate.TabIndex = 8;
            // 
            // chbBirthday
            // 
            chbBirthday.AutoSize = true;
            chbBirthday.Location = new Point(492, 19);
            chbBirthday.Name = "chbBirthday";
            chbBirthday.Size = new Size(15, 14);
            chbBirthday.TabIndex = 9;
            chbBirthday.UseVisualStyleBackColor = true;
            chbBirthday.CheckedChanged += chbBirthday_CheckedChanged;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(723, 10);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 10;
            AddButton.Text = "登録";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EmployeeListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 410);
            Controls.Add(AddButton);
            Controls.Add(chbBirthday);
            Controls.Add(dtpSearchBirthDate);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchContactNumber);
            Controls.Add(txtSearchEmployeeName);
            Controls.Add(lblcontactNumber);
            Controls.Add(lblBirthDate);
            Controls.Add(lblSearchEmployeeName);
            Controls.Add(dgvEmployees);
            Name = "EmployeeListForm";
            Text = "従業員一覧";
            Load += EmployeeListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private Label lblSearchEmployeeName;
        private Label lblBirthDate;
        private Label lblcontactNumber;
        private TextBox txtSearchEmployeeName;
        private TextBox txtSearchContactNumber;
        private Button btnSearch;
        private DateTimePicker dtpSearchBirthDate;
        private CheckBox chbBirthday;
        private Button AddButton;
    }
}