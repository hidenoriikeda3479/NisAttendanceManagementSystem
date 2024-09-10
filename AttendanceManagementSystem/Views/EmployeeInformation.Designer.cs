namespace AttendanceManagementSystem.Views
{
    partial class EmployeeInformation
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
            Updatebtn = new Button();
            label1 = new Label();
            Employeedgv = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Ateendbtn = new Button();
            label2 = new Label();
            Searchtxt = new TextBox();
            comboBox1 = new ComboBox();
            Searchbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)Employeedgv).BeginInit();
            SuspendLayout();
            // 
            // Updatebtn
            // 
            Updatebtn.Font = new Font("Yu Gothic UI", 11F);
            Updatebtn.Location = new Point(12, 63);
            Updatebtn.Name = "Updatebtn";
            Updatebtn.Size = new Size(81, 29);
            Updatebtn.TabIndex = 0;
            Updatebtn.Text = "更新";
            Updatebtn.UseVisualStyleBackColor = true;
            Updatebtn.Click += Ateendbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(206, 37);
            label1.TabIndex = 1;
            label1.Text = "従業員情報一覧";
            // 
            // Employeedgv
            // 
            Employeedgv.AllowUserToDeleteRows = false;
            Employeedgv.AllowUserToResizeColumns = false;
            Employeedgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Employeedgv.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column9, Column6, Column7, Column8 });
            Employeedgv.Location = new Point(12, 98);
            Employeedgv.Name = "Employeedgv";
            Employeedgv.ReadOnly = true;
            Employeedgv.Size = new Size(977, 340);
            Employeedgv.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "EmployeeId";
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "EmployeeName";
            Column2.HeaderText = "従業員名";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Address";
            Column3.HeaderText = "住所";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 250;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Gender";
            Column4.HeaderText = "性別";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 55;
            // 
            // Column9
            // 
            Column9.DataPropertyName = "PhoneNumber";
            Column9.HeaderText = "電話番号";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 150;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "HireDate";
            Column6.HeaderText = "入社日";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "ResignDate";
            Column7.HeaderText = "退社日";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.DataPropertyName = "UpdatedAt";
            Column8.HeaderText = "更新日時";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Ateendbtn
            // 
            Ateendbtn.Font = new Font("Yu Gothic UI", 11F);
            Ateendbtn.Location = new Point(99, 63);
            Ateendbtn.Name = "Ateendbtn";
            Ateendbtn.Size = new Size(81, 29);
            Ateendbtn.TabIndex = 3;
            Ateendbtn.Text = "勤怠確認";
            Ateendbtn.UseVisualStyleBackColor = true;
            Ateendbtn.Click += Ateendbtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 14F);
            label2.Location = new Point(326, 17);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 4;
            label2.Text = "従業員名";
            // 
            // Searchtxt
            // 
            Searchtxt.Location = new Point(420, 19);
            Searchtxt.Name = "Searchtxt";
            Searchtxt.Size = new Size(225, 23);
            Searchtxt.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "", "男", "女" });
            comboBox1.Location = new Point(651, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(51, 23);
            comboBox1.TabIndex = 6;
            // 
            // Searchbtn
            // 
            Searchbtn.Font = new Font("Yu Gothic UI", 11F);
            Searchbtn.Location = new Point(708, 14);
            Searchbtn.Name = "Searchbtn";
            Searchbtn.Size = new Size(81, 29);
            Searchbtn.TabIndex = 7;
            Searchbtn.Text = "検索";
            Searchbtn.UseVisualStyleBackColor = true;
            Searchbtn.Click += Searchbtn_Click;
            // 
            // EmployeeInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 450);
            Controls.Add(Searchbtn);
            Controls.Add(comboBox1);
            Controls.Add(Searchtxt);
            Controls.Add(label2);
            Controls.Add(Ateendbtn);
            Controls.Add(Employeedgv);
            Controls.Add(label1);
            Controls.Add(Updatebtn);
            Name = "EmployeeInformation";
            Text = "EmployeeInformation";
            Load += EmployeeInformation_Load;
            ((System.ComponentModel.ISupportInitialize)Employeedgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Updatebtn;
        private Label label1;
        private DataGridView Employeedgv;
        private Button Ateendbtn;
        private Label label2;
        private TextBox Searchtxt;
        private ComboBox comboBox1;
        private Button Searchbtn;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
    }
}