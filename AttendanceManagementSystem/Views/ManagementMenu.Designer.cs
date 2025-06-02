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
            btnPermission = new Button();
            btnRank = new Button();
            SuspendLayout();
            // 
            // btnEmployeeList
            // 
            btnEmployeeList.Location = new Point(12, 21);
            btnEmployeeList.Name = "btnEmployeeList";
            btnEmployeeList.Size = new Size(75, 23);
            btnEmployeeList.TabIndex = 1;
            btnEmployeeList.Text = "従業員一覧";
            btnEmployeeList.UseVisualStyleBackColor = true;
            btnEmployeeList.Click += btnEmployeeList_Click;
            // 
            // btnDepartment
            // 
            btnDepartment.Location = new Point(12, 50);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Size = new Size(75, 23);
            btnDepartment.TabIndex = 2;
            btnDepartment.Text = "部署一覧";
            btnDepartment.UseVisualStyleBackColor = true;
            btnDepartment.Click += btnDepartment_Click;
            // 
            // btnPermission
            // 
            btnPermission.Location = new Point(12, 79);
            btnPermission.Name = "btnPermission";
            btnPermission.Size = new Size(75, 23);
            btnPermission.TabIndex = 3;
            btnPermission.Text = "権限一覧";
            btnPermission.UseVisualStyleBackColor = true;
            btnPermission.Click += btnPermission_Click;
            // 
            // btnRank
            // 
            btnRank.Location = new Point(12, 108);
            btnRank.Name = "btnRank";
            btnRank.Size = new Size(75, 23);
            btnRank.TabIndex = 4;
            btnRank.Text = "給料一覧";
            btnRank.UseVisualStyleBackColor = true;
            btnRank.Click += btnRank_Click;
            // 
            // ManagementMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(213, 168);
            Controls.Add(btnRank);
            Controls.Add(btnPermission);
            Controls.Add(btnDepartment);
            Controls.Add(btnEmployeeList);
            Name = "ManagementMenu";
            Text = "ManagementMenu";
            ResumeLayout(false);
        }

        #endregion
        private Button btnEmployeeList;
        private Button btnDepartment;
        private Button btnPermission;
        private Button btnRank;
    }
}