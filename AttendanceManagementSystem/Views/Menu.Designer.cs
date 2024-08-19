namespace AttendanceManagementSystem.Views
{
    partial class Menu
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
            btnShiftManagement = new Button();
            btnSalaryManagement = new Button();
            btnAttendanceManagement = new Button();
            btnAdminMenu = new Button();
            btnAttendanceDeparture = new Button();
            SuspendLayout();
            // 
            // btnShiftManagement
            // 
            btnShiftManagement.Location = new Point(12, 12);
            btnShiftManagement.Name = "btnShiftManagement";
            btnShiftManagement.Size = new Size(75, 23);
            btnShiftManagement.TabIndex = 0;
            btnShiftManagement.Text = "シフト";
            btnShiftManagement.UseVisualStyleBackColor = true;
            btnShiftManagement.Click += btnShiftManagement_Click;
            // 
            // btnSalaryManagement
            // 
            btnSalaryManagement.Location = new Point(12, 41);
            btnSalaryManagement.Name = "btnSalaryManagement";
            btnSalaryManagement.Size = new Size(75, 23);
            btnSalaryManagement.TabIndex = 1;
            btnSalaryManagement.Text = "給料";
            btnSalaryManagement.UseVisualStyleBackColor = true;
            btnSalaryManagement.Click += btnSalaryManagement_Click;
            // 
            // btnAttendanceManagement
            // 
            btnAttendanceManagement.Location = new Point(12, 70);
            btnAttendanceManagement.Name = "btnAttendanceManagement";
            btnAttendanceManagement.Size = new Size(75, 23);
            btnAttendanceManagement.TabIndex = 2;
            btnAttendanceManagement.Text = "勤怠";
            btnAttendanceManagement.UseVisualStyleBackColor = true;
            btnAttendanceManagement.Click += btnAttendanceManagement_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Location = new Point(12, 99);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(75, 23);
            btnAdminMenu.TabIndex = 3;
            btnAdminMenu.Text = "管理";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // btnAttendanceDeparture
            // 
            btnAttendanceDeparture.Location = new Point(93, 12);
            btnAttendanceDeparture.Name = "btnAttendanceDeparture";
            btnAttendanceDeparture.Size = new Size(75, 23);
            btnAttendanceDeparture.TabIndex = 4;
            btnAttendanceDeparture.Text = "出勤/退勤";
            btnAttendanceDeparture.UseVisualStyleBackColor = true;
            btnAttendanceDeparture.Click += btnAttendanceDeparture_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAttendanceDeparture);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnAttendanceManagement);
            Controls.Add(btnSalaryManagement);
            Controls.Add(btnShiftManagement);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnShiftManagement;
        private Button btnSalaryManagement;
        private Button btnAttendanceManagement;
        private Button btnAdminMenu;
        private Button btnAttendanceDeparture;
    }
}