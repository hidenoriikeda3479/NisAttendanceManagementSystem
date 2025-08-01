namespace AttendanceManagementSystem.Views
{
    partial class PermissionListForm
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
            dgvPermission = new DataGridView();
            txtPermission = new TextBox();
            lblPermission = new Label();
            btnAddPermission = new Button();
            btnEditPermission = new Button();
            btnDeletePermission = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPermission).BeginInit();
            SuspendLayout();
            // 
            // dgvPermission
            // 
            dgvPermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermission.Location = new Point(15, 56);
            dgvPermission.MultiSelect = false;
            dgvPermission.Name = "dgvPermission";
            dgvPermission.Size = new Size(463, 213);
            dgvPermission.TabIndex = 0;
            dgvPermission.CellClick += dgvPermission_CellClick;
            // 
            // txtPermission
            // 
            txtPermission.Location = new Point(64, 17);
            txtPermission.MaxLength = 255;
            txtPermission.Name = "txtPermission";
            txtPermission.Size = new Size(134, 23);
            txtPermission.TabIndex = 1;
            // 
            // lblPermission
            // 
            lblPermission.AutoSize = true;
            lblPermission.Location = new Point(15, 20);
            lblPermission.Name = "lblPermission";
            lblPermission.Size = new Size(43, 15);
            lblPermission.TabIndex = 2;
            lblPermission.Text = "権限名";
            // 
            // btnAddPermission
            // 
            btnAddPermission.Location = new Point(204, 17);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(75, 23);
            btnAddPermission.TabIndex = 4;
            btnAddPermission.Text = "登録";
            btnAddPermission.UseVisualStyleBackColor = true;
            btnAddPermission.Click += btnRegister_Click;
            // 
            // btnEditPermission
            // 
            btnEditPermission.Location = new Point(285, 17);
            btnEditPermission.Name = "btnEditPermission";
            btnEditPermission.Size = new Size(75, 23);
            btnEditPermission.TabIndex = 5;
            btnEditPermission.Text = "編集";
            btnEditPermission.UseVisualStyleBackColor = true;
            btnEditPermission.Click += btnEdit_Click;
            // 
            // btnDeletePermission
            // 
            btnDeletePermission.Location = new Point(366, 17);
            btnDeletePermission.Name = "btnDeletePermission";
            btnDeletePermission.Size = new Size(75, 23);
            btnDeletePermission.TabIndex = 6;
            btnDeletePermission.Text = "削除";
            btnDeletePermission.UseVisualStyleBackColor = true;
            btnDeletePermission.Click += btnDeletePermissions_Click;
            // 
            // PermissionListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 292);
            Controls.Add(btnDeletePermission);
            Controls.Add(btnEditPermission);
            Controls.Add(btnAddPermission);
            Controls.Add(lblPermission);
            Controls.Add(txtPermission);
            Controls.Add(dgvPermission);
            Name = "PermissionListForm";
            Text = "権限一覧";
            Load += PermissionListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPermission).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPermission;
        private TextBox txtPermission;
        private Label lblPermission;
        private Button btnAddPermission;
        private Button btnEditPermission;
        private Button btnDeletePermission;
    }
}