namespace AttendanceManagementSystem.Views
{
    partial class ManagementMenu
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
            btnEmployeeList = new Button();
            btnDepartment = new Button();
            SuspendLayout();
            // 
            // btnEmployeeList
            // 
            btnEmployeeList.Location = new Point(12, 28);
            btnEmployeeList.Name = "btnEmployeeList";
            btnEmployeeList.Size = new Size(75, 23);
            btnEmployeeList.TabIndex = 1;
            btnEmployeeList.Text = "従業員一覧";
            btnEmployeeList.UseVisualStyleBackColor = true;
            btnEmployeeList.Click += btnEmployeeList_Click;
            // 
            // btnDepartment
            // 
            btnDepartment.Location = new Point(12, 66);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Size = new Size(75, 23);
            btnDepartment.TabIndex = 2;
            btnDepartment.Text = "部署一覧";
            btnDepartment.UseVisualStyleBackColor = true;
            btnDepartment.Click += btnDepartment_Click;
            // 
            // ManagementMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(213, 168);
            Controls.Add(btnDepartment);
            Controls.Add(btnEmployeeList);
            Name = "ManagementMenu";
            Text = "ManagementMenu";
            ResumeLayout(false);
        }

        #endregion
        private Button btnEmployeeList;
        private Button btnDepartment;
    }
}