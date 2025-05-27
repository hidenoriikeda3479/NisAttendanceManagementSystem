namespace AttendanceManagementSystem
{
    partial class UpdateEmployeeForm
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
            txbPass = new TextBox();
            lblPass = new Label();
            cbGender = new ComboBox();
            btnRegister = new Button();
            lblSearchBirthDate = new Label();
            dtpSearchBirthDate = new DateTimePicker();
            txtBuildingName = new TextBox();
            lblBuildingName = new Label();
            txtMailingAddress = new TextBox();
            lblMailingAddress = new Label();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtSearchContactNumber = new TextBox();
            lblSearchContactNumber = new Label();
            lblGender = new Label();
            txtEmployeeName = new TextBox();
            lblEmployee = new Label();
            SuspendLayout();
            // 
            // txbPass
            // 
            txbPass.Location = new Point(94, 83);
            txbPass.Name = "txbPass";
            txbPass.Size = new Size(173, 23);
            txbPass.TabIndex = 34;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(33, 88);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(51, 15);
            lblPass.TabIndex = 33;
            lblPass.Text = "パスワード";
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "男性", "女性" });
            cbGender.Location = new Point(94, 54);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(121, 23);
            cbGender.TabIndex = 32;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(192, 285);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 31;
            btnRegister.Text = "編集";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblSearchBirthDate
            // 
            lblSearchBirthDate.AutoSize = true;
            lblSearchBirthDate.Location = new Point(33, 247);
            lblSearchBirthDate.Name = "lblSearchBirthDate";
            lblSearchBirthDate.Size = new Size(55, 15);
            lblSearchBirthDate.TabIndex = 30;
            lblSearchBirthDate.Text = "生年月日";
            // 
            // dtpSearchBirthDate
            // 
            dtpSearchBirthDate.Location = new Point(94, 247);
            dtpSearchBirthDate.Name = "dtpSearchBirthDate";
            dtpSearchBirthDate.Size = new Size(173, 23);
            dtpSearchBirthDate.TabIndex = 29;
            // 
            // txtBuildingName
            // 
            txtBuildingName.Location = new Point(94, 209);
            txtBuildingName.MaxLength = 225;
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.Size = new Size(173, 23);
            txtBuildingName.TabIndex = 28;
            // 
            // lblBuildingName
            // 
            lblBuildingName.AutoSize = true;
            lblBuildingName.Location = new Point(45, 212);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new Size(43, 15);
            lblBuildingName.TabIndex = 27;
            lblBuildingName.Text = "建物名";
            // 
            // txtMailingAddress
            // 
            txtMailingAddress.Location = new Point(94, 176);
            txtMailingAddress.MaxLength = 225;
            txtMailingAddress.Name = "txtMailingAddress";
            txtMailingAddress.Size = new Size(173, 23);
            txtMailingAddress.TabIndex = 26;
            // 
            // lblMailingAddress
            // 
            lblMailingAddress.AutoSize = true;
            lblMailingAddress.Location = new Point(57, 179);
            lblMailingAddress.Name = "lblMailingAddress";
            lblMailingAddress.Size = new Size(31, 15);
            lblMailingAddress.TabIndex = 25;
            lblMailingAddress.Text = "住所";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(94, 143);
            txtPhoneNumber.MaxLength = 7;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(173, 23);
            txtPhoneNumber.TabIndex = 24;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(33, 146);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(55, 15);
            lblPhoneNumber.TabIndex = 23;
            lblPhoneNumber.Text = "郵便番号";
            // 
            // txtSearchContactNumber
            // 
            txtSearchContactNumber.Location = new Point(94, 114);
            txtSearchContactNumber.MaxLength = 11;
            txtSearchContactNumber.Name = "txtSearchContactNumber";
            txtSearchContactNumber.Size = new Size(173, 23);
            txtSearchContactNumber.TabIndex = 22;
            // 
            // lblSearchContactNumber
            // 
            lblSearchContactNumber.AutoSize = true;
            lblSearchContactNumber.Location = new Point(33, 117);
            lblSearchContactNumber.Name = "lblSearchContactNumber";
            lblSearchContactNumber.Size = new Size(55, 15);
            lblSearchContactNumber.TabIndex = 21;
            lblSearchContactNumber.Text = "電話番号";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(57, 60);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(31, 15);
            lblGender.TabIndex = 20;
            lblGender.Text = "性別";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(94, 25);
            txtEmployeeName.MaxLength = 255;
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(127, 23);
            txtEmployeeName.TabIndex = 19;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(33, 28);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(55, 15);
            lblEmployee.TabIndex = 18;
            lblEmployee.Text = "従業員名";
            // 
            // UpdateEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 333);
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
            Name = "UpdateEmployeeForm";
            Text = "従業員情報編集";
            Load += UpdateEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbPass;
        private Label lblPass;
        private ComboBox cbGender;
        private Button btnRegister;
        private Label lblSearchBirthDate;
        private DateTimePicker dtpSearchBirthDate;
        private TextBox txtBuildingName;
        private Label lblBuildingName;
        private TextBox txtMailingAddress;
        private Label lblMailingAddress;
        private TextBox txtPhoneNumber;
        private Label lblPhoneNumber;
        private TextBox txtSearchContactNumber;
        private Label lblSearchContactNumber;
        private Label lblGender;
        private TextBox txtEmployeeName;
        private Label lblEmployee;
    }
}