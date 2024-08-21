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
            upbtn = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            atabtn = new Button();
            label2 = new Label();
            searchTxt = new TextBox();
            comboBox1 = new ComboBox();
            searchbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // upbtn
            // 
            upbtn.Font = new Font("Yu Gothic UI", 11F);
            upbtn.Location = new Point(12, 63);
            upbtn.Name = "upbtn";
            upbtn.Size = new Size(81, 29);
            upbtn.TabIndex = 0;
            upbtn.Text = "更新";
            upbtn.UseVisualStyleBackColor = true;
            upbtn.Click += upbtn_Click;
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column9, Column6, Column7, Column8 });
            dataGridView1.Location = new Point(12, 98);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(977, 340);
            dataGridView1.TabIndex = 2;
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
            // atabtn
            // 
            atabtn.Font = new Font("Yu Gothic UI", 11F);
            atabtn.Location = new Point(99, 63);
            atabtn.Name = "atabtn";
            atabtn.Size = new Size(81, 29);
            atabtn.TabIndex = 3;
            atabtn.Text = "勤怠確認";
            atabtn.UseVisualStyleBackColor = true;
            atabtn.Click += atabtn_Click;
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
            // searchTxt
            // 
            searchTxt.Location = new Point(420, 19);
            searchTxt.Name = "searchTxt";
            searchTxt.Size = new Size(225, 23);
            searchTxt.TabIndex = 5;
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
            // searchbtn
            // 
            searchbtn.Font = new Font("Yu Gothic UI", 11F);
            searchbtn.Location = new Point(708, 14);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(81, 29);
            searchbtn.TabIndex = 7;
            searchbtn.Text = "検索";
            searchbtn.UseVisualStyleBackColor = true;
            searchbtn.Click += searchbtn_Click;
            // 
            // EmployeeInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 450);
            Controls.Add(searchbtn);
            Controls.Add(comboBox1);
            Controls.Add(searchTxt);
            Controls.Add(label2);
            Controls.Add(atabtn);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(upbtn);
            Name = "EmployeeInformation";
            Text = "EmployeeInformation";
            Load += EmployeeInformation_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button upbtn;
        private Label label1;
        private DataGridView dataGridView1;
        private Button atabtn;
        private Label label2;
        private TextBox searchTxt;
        private ComboBox comboBox1;
        private Button searchbtn;
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