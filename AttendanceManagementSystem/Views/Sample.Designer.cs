namespace AttendanceManagementSystem.Views
{
    partial class Sample
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
            txtSearchEmployeeName = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            txtEditEmployeeName = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(12, 41);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(776, 272);
            dgvEmployees.TabIndex = 0;
            // 
            // txtSearchEmployeeName
            // 
            txtSearchEmployeeName.Location = new Point(79, 12);
            txtSearchEmployeeName.Name = "txtSearchEmployeeName";
            txtSearchEmployeeName.Size = new Size(100, 23);
            txtSearchEmployeeName.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(185, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 16);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "従業員名";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(266, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "新規作成";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(713, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtEditEmployeeName
            // 
            txtEditEmployeeName.Location = new Point(607, 12);
            txtEditEmployeeName.Name = "txtEditEmployeeName";
            txtEditEmployeeName.Size = new Size(100, 23);
            txtEditEmployeeName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(546, 15);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 7;
            label2.Text = "従業員名";
            // 
            // Sample
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 325);
            Controls.Add(label2);
            Controls.Add(txtEditEmployeeName);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchEmployeeName);
            Controls.Add(dgvEmployees);
            Name = "Sample";
            Text = "Sample";
            Load += Sample_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private TextBox txtSearchEmployeeName;
        private Button btnSearch;
        private Label label1;
        private Button btnAdd;
        private Button btnUpdate;
        private TextBox txtEditEmployeeName;
        private Label label2;
    }
}