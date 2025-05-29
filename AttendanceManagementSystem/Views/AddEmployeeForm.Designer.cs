namespace AttendanceManagementSystem
{
    partial class AddEmployeeForm
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
            lblEmployee = new Label();
            txtEmployeeName = new TextBox();
            lblGender = new Label();
            lblSearchContactNumber = new Label();
            txtSearchContactNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblMailingAddress = new Label();
            txtMailingAddress = new TextBox();
            lblBuildingName = new Label();
            txtBuildingName = new TextBox();
            dtpSearchBirthDate = new DateTimePicker();
            lblSearchBirthDate = new Label();
            btnRegister = new Button();
            cbGender = new ComboBox();
            lblPass = new Label();
            txbPass = new TextBox();
            cobRank = new ComboBox();
            cbxAuthorized = new ComboBox();
            lblRank = new Label();
            lblAuthorized = new Label();
            SuspendLayout();
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(30, 35);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(55, 15);
            lblEmployee.TabIndex = 0;
            lblEmployee.Text = "従業員名";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(91, 32);
            txtEmployeeName.MaxLength = 255;
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(127, 23);
            txtEmployeeName.TabIndex = 1;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(54, 67);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(31, 15);
            lblGender.TabIndex = 2;
            lblGender.Text = "性別";
            // 
            // lblSearchContactNumber
            // 
            lblSearchContactNumber.AutoSize = true;
            lblSearchContactNumber.Location = new Point(30, 124);
            lblSearchContactNumber.Name = "lblSearchContactNumber";
            lblSearchContactNumber.Size = new Size(55, 15);
            lblSearchContactNumber.TabIndex = 4;
            lblSearchContactNumber.Text = "電話番号";
            // 
            // txtSearchContactNumber
            // 
            txtSearchContactNumber.Location = new Point(91, 121);
            txtSearchContactNumber.MaxLength = 11;
            txtSearchContactNumber.Name = "txtSearchContactNumber";
            txtSearchContactNumber.Size = new Size(173, 23);
            txtSearchContactNumber.TabIndex = 5;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(30, 153);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(55, 15);
            lblPhoneNumber.TabIndex = 6;
            lblPhoneNumber.Text = "郵便番号";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(91, 150);
            txtPhoneNumber.MaxLength = 7;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(173, 23);
            txtPhoneNumber.TabIndex = 7;
            // 
            // lblMailingAddress
            // 
            lblMailingAddress.AutoSize = true;
            lblMailingAddress.Location = new Point(54, 186);
            lblMailingAddress.Name = "lblMailingAddress";
            lblMailingAddress.Size = new Size(31, 15);
            lblMailingAddress.TabIndex = 8;
            lblMailingAddress.Text = "住所";
            // 
            // txtMailingAddress
            // 
            txtMailingAddress.Location = new Point(91, 183);
            txtMailingAddress.MaxLength = 225;
            txtMailingAddress.Name = "txtMailingAddress";
            txtMailingAddress.Size = new Size(173, 23);
            txtMailingAddress.TabIndex = 9;
            // 
            // lblBuildingName
            // 
            lblBuildingName.AutoSize = true;
            lblBuildingName.Location = new Point(42, 219);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new Size(43, 15);
            lblBuildingName.TabIndex = 10;
            lblBuildingName.Text = "建物名";
            // 
            // txtBuildingName
            // 
            txtBuildingName.Location = new Point(91, 216);
            txtBuildingName.MaxLength = 225;
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.Size = new Size(173, 23);
            txtBuildingName.TabIndex = 11;
            // 
            // dtpSearchBirthDate
            // 
            dtpSearchBirthDate.Location = new Point(91, 254);
            dtpSearchBirthDate.Name = "dtpSearchBirthDate";
            dtpSearchBirthDate.Size = new Size(173, 23);
            dtpSearchBirthDate.TabIndex = 12;
            // 
            // lblSearchBirthDate
            // 
            lblSearchBirthDate.AutoSize = true;
            lblSearchBirthDate.Location = new Point(30, 254);
            lblSearchBirthDate.Name = "lblSearchBirthDate";
            lblSearchBirthDate.Size = new Size(55, 15);
            lblSearchBirthDate.TabIndex = 13;
            lblSearchBirthDate.Text = "生年月日";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(189, 373);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 14;
            btnRegister.Text = "登録";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "男性", "女性" });
            cbGender.Location = new Point(91, 61);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(121, 23);
            cbGender.TabIndex = 15;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(30, 95);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(51, 15);
            lblPass.TabIndex = 16;
            lblPass.Text = "パスワード";
            // 
            // txbPass
            // 
            txbPass.Location = new Point(91, 90);
            txbPass.Name = "txbPass";
            txbPass.Size = new Size(173, 23);
            txbPass.TabIndex = 17;
            // 
            // cobRank
            // 
            cobRank.FormattingEnabled = true;
            cobRank.Items.AddRange(new object[] { "1000", "1200" });
            cobRank.Location = new Point(91, 292);
            cobRank.Name = "cobRank";
            cobRank.Size = new Size(121, 23);
            cobRank.TabIndex = 18;
            // 
            // cbxAuthorized
            // 
            cbxAuthorized.FormattingEnabled = true;
            cbxAuthorized.Items.AddRange(new object[] { "管理者", "一般" });
            cbxAuthorized.Location = new Point(91, 331);
            cbxAuthorized.Name = "cbxAuthorized";
            cbxAuthorized.Size = new Size(121, 23);
            cbxAuthorized.TabIndex = 19;
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Location = new Point(54, 295);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(31, 15);
            lblRank.TabIndex = 20;
            lblRank.Text = "時給";
            // 
            // lblAuthorized
            // 
            lblAuthorized.AutoSize = true;
            lblAuthorized.Location = new Point(54, 334);
            lblAuthorized.Name = "lblAuthorized";
            lblAuthorized.Size = new Size(31, 15);
            lblAuthorized.TabIndex = 21;
            lblAuthorized.Text = "権限";
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 415);
            Controls.Add(lblAuthorized);
            Controls.Add(lblRank);
            Controls.Add(cbxAuthorized);
            Controls.Add(cobRank);
            Controls.Add(txbPass);
            Controls.Add(lblPass);
            Controls.Add(cbGender);
            Controls.Add(btnRegister);
            Controls.Add(lblSearchBirthDate);
            Controls.Add(dtpSearchBirthDate);
            Controls.Add(txtBuildingName);
            Controls.Add(lblBuildingName);
            Controls.Add(txtMailingAddress);
            Controls.Add(lblMailingAddress);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtSearchContactNumber);
            Controls.Add(lblSearchContactNumber);
            Controls.Add(lblGender);
            Controls.Add(txtEmployeeName);
            Controls.Add(lblEmployee);
            Name = "AddEmployeeForm";
            Text = "従業員情報登録";
            Load += AddEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmployee;
        private TextBox txtEmployeeName;
        private Label lblGender;
        private Label lblSearchContactNumber;
        private TextBox txtSearchContactNumber;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblMailingAddress;
        private TextBox txtMailingAddress;
        private Label lblBuildingName;
        private TextBox txtBuildingName;
        private DateTimePicker dtpSearchBirthDate;
        private Label lblSearchBirthDate;
        private Button btnRegister;
        private ComboBox cbGender;
        private Label lblPass;
        private TextBox txbPass;
        private ComboBox cobRank;
        private ComboBox cbxAuthorized;
        private Label lblRank;
        private Label lblAuthorized;
    }
}