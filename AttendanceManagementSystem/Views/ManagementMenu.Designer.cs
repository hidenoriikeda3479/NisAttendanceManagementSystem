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
            btnEmployeeRegistration = new Button();
            btnEmployeeList = new Button();
            btnSalaryList = new Button();
            SuspendLayout();
            // 
            // btnEmployeeRegistration
            // 
            btnEmployeeRegistration.Location = new Point(12, 12);
            btnEmployeeRegistration.Name = "btnEmployeeRegistration";
            btnEmployeeRegistration.Size = new Size(75, 23);
            btnEmployeeRegistration.TabIndex = 0;
            btnEmployeeRegistration.Text = "従業員登録";
            btnEmployeeRegistration.UseVisualStyleBackColor = true;
            btnEmployeeRegistration.Click += btnEmployeeRegistration_Click;
            // 
            // btnEmployeeList
            // 
            btnEmployeeList.Location = new Point(12, 41);
            btnEmployeeList.Name = "btnEmployeeList";
            btnEmployeeList.Size = new Size(75, 23);
            btnEmployeeList.TabIndex = 1;
            btnEmployeeList.Text = "従業員一覧";
            btnEmployeeList.UseVisualStyleBackColor = true;
            btnEmployeeList.Click += btnEmployeeList_Click;
            // 
            // btnSalaryList
            // 
            btnSalaryList.Location = new Point(12, 70);
            btnSalaryList.Name = "btnSalaryList";
            btnSalaryList.Size = new Size(75, 23);
            btnSalaryList.TabIndex = 2;
            btnSalaryList.Text = "給与一覧";
            btnSalaryList.UseVisualStyleBackColor = true;
            btnSalaryList.Click += btnSalaryList_Click;
            // 
            // ManagementMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalaryList);
            Controls.Add(btnEmployeeList);
            Controls.Add(btnEmployeeRegistration);
            Name = "ManagementMenu";
            Text = "ManagementMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEmployeeRegistration;
        private Button btnEmployeeList;
        private Button btnSalaryList;
    }
}