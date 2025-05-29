namespace AttendanceManagementSystem.Views
{
    partial class DepartmentListForm
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
            dgvDepartment = new DataGridView();
            btnSearch = new Button();
            AddButton = new Button();
            txtDepartment = new TextBox();
            lblDepartment = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).BeginInit();
            SuspendLayout();
            // 
            // dgvDepartment
            // 
            dgvDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartment.Location = new Point(11, 60);
            dgvDepartment.Name = "dgvDepartment";
            dgvDepartment.ReadOnly = true;
            dgvDepartment.Size = new Size(449, 218);
            dgvDepartment.TabIndex = 0;
            dgvDepartment.CellContentClick += dgbDepartment_CellContentClick;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(219, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(385, 18);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 2;
            AddButton.Text = "登録";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(72, 19);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(131, 23);
            txtDepartment.TabIndex = 3;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(28, 22);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(43, 15);
            lblDepartment.TabIndex = 4;
            lblDepartment.Text = "部署名";
            // 
            // DepartmentListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 291);
            Controls.Add(lblDepartment);
            Controls.Add(txtDepartment);
            Controls.Add(AddButton);
            Controls.Add(btnSearch);
            Controls.Add(dgvDepartment);
            Name = "DepartmentListForm";
            Text = "部署一覧";
            Load += DepartmentListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDepartment;
        private Button btnSearch;
        private Button AddButton;
        private TextBox txtDepartment;
        private Label lblDepartment;
    }
}