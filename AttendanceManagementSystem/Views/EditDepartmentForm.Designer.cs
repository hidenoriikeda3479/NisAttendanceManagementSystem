namespace AttendanceManagementSystem.Views
{
    partial class EditDepartmentForm
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
            btnEditDepartment = new Button();
            txtEditingDepartment = new TextBox();
            lblEditingDepartment = new Label();
            SuspendLayout();
            // 
            // btnEditDepartment
            // 
            btnEditDepartment.Location = new Point(167, 90);
            btnEditDepartment.Name = "btnEditDepartment";
            btnEditDepartment.Size = new Size(75, 23);
            btnEditDepartment.TabIndex = 5;
            btnEditDepartment.Text = "編集";
            btnEditDepartment.UseVisualStyleBackColor = true;
            btnEditDepartment.Click += btnEditDepartment_Click;
            // 
            // txtEditingDepartment
            // 
            txtEditingDepartment.Location = new Point(92, 52);
            txtEditingDepartment.Name = "txtEditingDepartment";
            txtEditingDepartment.Size = new Size(150, 23);
            txtEditingDepartment.TabIndex = 4;
            // 
            // lblEditingDepartment
            // 
            lblEditingDepartment.AutoSize = true;
            lblEditingDepartment.Location = new Point(43, 55);
            lblEditingDepartment.Name = "lblEditingDepartment";
            lblEditingDepartment.Size = new Size(43, 15);
            lblEditingDepartment.TabIndex = 3;
            lblEditingDepartment.Text = "部署名";
            // 
            // EditDepartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 160);
            Controls.Add(btnEditDepartment);
            Controls.Add(txtEditingDepartment);
            Controls.Add(lblEditingDepartment);
            Name = "EditDepartmentForm";
            Text = "部署編集";
            Load += EditDepartmentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditDepartment;
        private TextBox txtEditingDepartment;
        private Label lblEditingDepartment;
    }
}