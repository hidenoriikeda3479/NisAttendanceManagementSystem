namespace AttendanceManagementSystem.Views
{
    partial class DepartmentScreenForm
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
            lblRegisterDepartment = new Label();
            txtRegisterDepartment = new TextBox();
            btnRegisterDepartment = new Button();
            SuspendLayout();
            // 
            // lblRegisterDepartment
            // 
            lblRegisterDepartment.AutoSize = true;
            lblRegisterDepartment.Location = new Point(39, 49);
            lblRegisterDepartment.Name = "lblRegisterDepartment";
            lblRegisterDepartment.Size = new Size(43, 15);
            lblRegisterDepartment.TabIndex = 0;
            lblRegisterDepartment.Text = "部署名";
            // 
            // txtRegisterDepartment
            // 
            txtRegisterDepartment.Location = new Point(88, 46);
            txtRegisterDepartment.Name = "txtRegisterDepartment";
            txtRegisterDepartment.Size = new Size(150, 23);
            txtRegisterDepartment.TabIndex = 1;
            // 
            // btnRegisterDepartment
            // 
            btnRegisterDepartment.Location = new Point(163, 84);
            btnRegisterDepartment.Name = "btnRegisterDepartment";
            btnRegisterDepartment.Size = new Size(75, 23);
            btnRegisterDepartment.TabIndex = 2;
            btnRegisterDepartment.Text = "登録";
            btnRegisterDepartment.UseVisualStyleBackColor = true;
            btnRegisterDepartment.Click += btnRegisterDepartment_Click;
            // 
            // DepartmentScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 157);
            Controls.Add(btnRegisterDepartment);
            Controls.Add(txtRegisterDepartment);
            Controls.Add(lblRegisterDepartment);
            Name = "DepartmentScreenForm";
            Text = "部署登録";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl;
        private Label lblRegisterDepartment;
        private TextBox txtRegisterDepartment;
        private Button btnRegisterDepartment;
    }
}