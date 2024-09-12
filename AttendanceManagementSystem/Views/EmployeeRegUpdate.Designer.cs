namespace AttendanceManagementSystem.Views
{
    partial class EmployeeRegUpdate
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            labelRePswrd = new Label();
            labelPswrd = new Label();
            label5 = new Label();
            label6 = new Label();
            labelUpdate = new Label();
            txtName = new TextBox();
            txtPswrd = new TextBox();
            txtRepswrd = new TextBox();
            txtPost = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtAddress = new TextBox();
            txtBuilding = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtPhone = new TextBox();
            label13 = new Label();
            menRadio = new RadioButton();
            womRadio = new RadioButton();
            btnUpdate = new Button();
            btnLeaving = new Button();
            groupBox1 = new GroupBox();
            errorProvider1 = new ErrorProvider(components);
            labelBirth = new Label();
            labelRank = new Label();
            labelShift = new Label();
            dateTimePicker1 = new DateTimePicker();
            cmbRank = new ComboBox();
            cmbShift = new ComboBox();
            btnRegistration = new Button();
            labelRegistration = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 13F);
            label1.Location = new Point(93, 62);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 0;
            label1.Text = "名前";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 13F);
            label2.Location = new Point(48, 248);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 1;
            label2.Text = "住所・番地";
            // 
            // labelRePswrd
            // 
            labelRePswrd.AutoSize = true;
            labelRePswrd.Font = new Font("Yu Gothic UI", 13F);
            labelRePswrd.Location = new Point(8, 174);
            labelRePswrd.Name = "labelRePswrd";
            labelRePswrd.Size = new Size(133, 25);
            labelRePswrd.TabIndex = 2;
            labelRePswrd.Text = "パスワード再入力";
            // 
            // labelPswrd
            // 
            labelPswrd.AutoSize = true;
            labelPswrd.Font = new Font("Yu Gothic UI", 13F);
            labelPswrd.Location = new Point(62, 138);
            labelPswrd.Name = "labelPswrd";
            labelPswrd.Size = new Size(79, 25);
            labelPswrd.TabIndex = 3;
            labelPswrd.Text = "パスワード";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 13F);
            label5.Location = new Point(57, 214);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 4;
            label5.Text = "郵便番号";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 13F);
            label6.Location = new Point(414, 247);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 5;
            label6.Text = "建物名";
            // 
            // labelUpdate
            // 
            labelUpdate.AutoSize = true;
            labelUpdate.Font = new Font("Yu Gothic UI Semibold", 18F);
            labelUpdate.Location = new Point(273, 9);
            labelUpdate.Name = "labelUpdate";
            labelUpdate.Size = new Size(182, 32);
            labelUpdate.TabIndex = 6;
            labelUpdate.Text = "従業員情報更新";
            // 
            // txtName
            // 
            txtName.Font = new Font("Yu Gothic UI", 12F);
            txtName.Location = new Point(147, 58);
            txtName.MaxLength = 15;
            txtName.Name = "txtName";
            txtName.Size = new Size(177, 29);
            txtName.TabIndex = 7;
            // 
            // txtPswrd
            // 
            txtPswrd.Font = new Font("Yu Gothic UI", 11F);
            txtPswrd.ImeMode = ImeMode.Disable;
            txtPswrd.Location = new Point(147, 137);
            txtPswrd.MaxLength = 12;
            txtPswrd.Name = "txtPswrd";
            txtPswrd.Size = new Size(107, 27);
            txtPswrd.TabIndex = 8;
            // 
            // txtRepswrd
            // 
            txtRepswrd.Font = new Font("Yu Gothic UI", 11F);
            txtRepswrd.Location = new Point(147, 172);
            txtRepswrd.MaxLength = 12;
            txtRepswrd.Name = "txtRepswrd";
            txtRepswrd.Size = new Size(107, 27);
            txtRepswrd.TabIndex = 9;
            // 
            // txtPost
            // 
            txtPost.Font = new Font("Yu Gothic UI", 11F);
            txtPost.ImeMode = ImeMode.Disable;
            txtPost.Location = new Point(180, 212);
            txtPost.MaxLength = 7;
            txtPost.Name = "txtPost";
            txtPost.ShortcutsEnabled = false;
            txtPost.Size = new Size(74, 27);
            txtPost.TabIndex = 10;
            txtPost.KeyPress += OnlyNumbers_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F);
            label8.ForeColor = Color.DimGray;
            label8.Location = new Point(118, 104);
            label8.Name = "label8";
            label8.Size = new Size(161, 30);
            label8.TabIndex = 11;
            label8.Text = "※大文字・小文字を組み合わせ\n　    ６～１２文字で入力";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 13F);
            label9.Location = new Point(147, 214);
            label9.Name = "label9";
            label9.Size = new Size(30, 25);
            label9.TabIndex = 12;
            label9.Text = "〒";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 9F);
            label10.ForeColor = Color.DimGray;
            label10.Location = new Point(260, 219);
            label10.Name = "label10";
            label10.Size = new Size(117, 15);
            label10.TabIndex = 13;
            label10.Text = "※半角入力・ﾊｲﾌﾝ無し";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Yu Gothic UI", 11F);
            txtAddress.Location = new Point(147, 246);
            txtAddress.MaxLength = 20;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(230, 27);
            txtAddress.TabIndex = 14;
            // 
            // txtBuilding
            // 
            txtBuilding.Font = new Font("Yu Gothic UI", 11F);
            txtBuilding.Location = new Point(486, 246);
            txtBuilding.MaxLength = 20;
            txtBuilding.Name = "txtBuilding";
            txtBuilding.Size = new Size(202, 27);
            txtBuilding.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 13F);
            label11.Location = new Point(414, 57);
            label11.Name = "label11";
            label11.Size = new Size(48, 25);
            label11.TabIndex = 16;
            label11.Text = "性別";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 13F);
            label12.Location = new Point(396, 125);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 17;
            label12.Text = "電話番号";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Yu Gothic UI", 12F);
            txtPhone.ImeMode = ImeMode.Disable;
            txtPhone.Location = new Point(486, 121);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.ShortcutsEnabled = false;
            txtPhone.Size = new Size(117, 29);
            txtPhone.TabIndex = 18;
            txtPhone.KeyPress += OnlyNumbers_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 9F);
            label13.ForeColor = Color.DimGray;
            label13.Location = new Point(486, 103);
            label13.Name = "label13";
            label13.Size = new Size(117, 15);
            label13.TabIndex = 19;
            label13.Text = "※半角入力・ﾊｲﾌﾝ無し";
            // 
            // menRadio
            // 
            menRadio.AutoSize = true;
            menRadio.Checked = true;
            menRadio.Font = new Font("Yu Gothic UI", 12F);
            menRadio.Location = new Point(13, 18);
            menRadio.Name = "menRadio";
            menRadio.Size = new Size(44, 25);
            menRadio.TabIndex = 20;
            menRadio.TabStop = true;
            menRadio.Text = "男";
            menRadio.UseVisualStyleBackColor = true;
            // 
            // womRadio
            // 
            womRadio.AutoSize = true;
            womRadio.Font = new Font("Yu Gothic UI", 12F);
            womRadio.Location = new Point(63, 17);
            womRadio.Name = "womRadio";
            womRadio.Size = new Size(44, 25);
            womRadio.TabIndex = 21;
            womRadio.Text = "女";
            womRadio.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Yu Gothic UI", 13F);
            btnUpdate.Location = new Point(312, 318);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 37);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnLeaving
            // 
            btnLeaving.Font = new Font("Yu Gothic UI", 13F);
            btnLeaving.Location = new Point(648, 318);
            btnLeaving.Name = "btnLeaving";
            btnLeaving.Size = new Size(56, 37);
            btnLeaving.TabIndex = 23;
            btnLeaving.Text = "退社";
            btnLeaving.UseVisualStyleBackColor = true;
            btnLeaving.Click += btnLeaving_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(menRadio);
            groupBox1.Controls.Add(womRadio);
            groupBox1.Font = new Font("Yu Gothic UI", 10F);
            groupBox1.Location = new Point(486, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(117, 55);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "選択";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // labelBirth
            // 
            labelBirth.AutoSize = true;
            labelBirth.Font = new Font("Yu Gothic UI", 13F);
            labelBirth.Location = new Point(396, 174);
            labelBirth.Name = "labelBirth";
            labelBirth.Size = new Size(84, 25);
            labelBirth.TabIndex = 25;
            labelBirth.Text = "生年月日";
            // 
            // labelRank
            // 
            labelRank.AutoSize = true;
            labelRank.Font = new Font("Yu Gothic UI", 13F);
            labelRank.Location = new Point(90, 301);
            labelRank.Name = "labelRank";
            labelRank.Size = new Size(51, 25);
            labelRank.TabIndex = 26;
            labelRank.Text = "ランク";
            // 
            // labelShift
            // 
            labelShift.AutoSize = true;
            labelShift.Font = new Font("Yu Gothic UI", 13F);
            labelShift.Location = new Point(430, 301);
            labelShift.Name = "labelShift";
            labelShift.Size = new Size(50, 25);
            labelShift.TabIndex = 27;
            labelShift.Text = "シフト";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(486, 174);
            dateTimePicker1.MaxDate = new DateTime(2024, 8, 24, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(1950, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(144, 23);
            dateTimePicker1.TabIndex = 29;
            dateTimePicker1.Value = new DateTime(2024, 8, 24, 0, 0, 0, 0);
            // 
            // cmbRank
            // 
            cmbRank.FormattingEnabled = true;
            cmbRank.Items.AddRange(new object[] { "選択して下さい", "★1：1100円", "★2：1200円", "★3：1300円", "★4：1400円", "★5：1500円" });
            cmbRank.Location = new Point(147, 301);
            cmbRank.Name = "cmbRank";
            cmbRank.Size = new Size(121, 23);
            cmbRank.TabIndex = 30;
            // 
            // cmbShift
            // 
            cmbShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShift.FormattingEnabled = true;
            cmbShift.Items.AddRange(new object[] { "選択して下さい", "早番：7:00~16:00", "中番：9:00~18:00", "遅番：11:00~20:00" });
            cmbShift.Location = new Point(486, 301);
            cmbShift.Name = "cmbShift";
            cmbShift.Size = new Size(130, 23);
            cmbShift.TabIndex = 31;
            // 
            // btnRegistration
            // 
            btnRegistration.Font = new Font("Yu Gothic UI", 13F);
            btnRegistration.Location = new Point(312, 318);
            btnRegistration.Name = "btnRegistration";
            btnRegistration.Size = new Size(94, 37);
            btnRegistration.TabIndex = 32;
            btnRegistration.Text = "登録";
            btnRegistration.UseVisualStyleBackColor = true;
            btnRegistration.Click += btnRegistration_Click;
            // 
            // labelRegistration
            // 
            labelRegistration.AutoSize = true;
            labelRegistration.Font = new Font("Yu Gothic UI Semibold", 18F);
            labelRegistration.Location = new Point(273, 9);
            labelRegistration.Name = "labelRegistration";
            labelRegistration.Size = new Size(182, 32);
            labelRegistration.TabIndex = 33;
            labelRegistration.Text = "従業員情報登録";
            // 
            // EmployeeRegUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 371);
            Controls.Add(labelRegistration);
            Controls.Add(btnRegistration);
            Controls.Add(cmbShift);
            Controls.Add(cmbRank);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelShift);
            Controls.Add(labelRank);
            Controls.Add(labelBirth);
            Controls.Add(groupBox1);
            Controls.Add(btnLeaving);
            Controls.Add(btnUpdate);
            Controls.Add(label13);
            Controls.Add(txtPhone);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtBuilding);
            Controls.Add(txtAddress);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtPost);
            Controls.Add(txtRepswrd);
            Controls.Add(txtPswrd);
            Controls.Add(txtName);
            Controls.Add(labelUpdate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(labelPswrd);
            Controls.Add(labelRePswrd);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeRegUpdate";
            Load += EmployeeUpdate_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label labelRePswrd;
        private Label labelPswrd;
        private Label label5;
        private Label label6;
        private Label labelUpdate;
        private TextBox txtName;
        private TextBox txtPswrd;
        private TextBox txtRepswrd;
        private TextBox txtPost;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtAddress;
        private TextBox txtBuilding;
        private Label label11;
        private Label label12;
        private TextBox txtPhone;
        private Label label13;
        private RadioButton menRadio;
        private RadioButton womRadio;
        private Button btnUpdate;
        private Button btnLeaving;
        private GroupBox groupBox1;
        private ErrorProvider errorProvider1;
        private Label labelShift;
        private Label labelRank;
        private Label labelBirth;
        private DateTimePicker dateTimePicker1;
        private ComboBox cmbShift;
        private ComboBox cmbRank;
        private Button btnRegistration;
        private Label labelRegistration;
    }
}