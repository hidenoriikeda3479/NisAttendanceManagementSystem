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
            lblStatus = new Label();
            SuspendLayout();
            // 
            // btnShiftManagement
            // 
            btnShiftManagement.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnShiftManagement.Location = new Point(224, 9);
            btnShiftManagement.Name = "btnShiftManagement";
            btnShiftManagement.Size = new Size(100, 50);
            btnShiftManagement.TabIndex = 0;
            btnShiftManagement.Text = "シフト";
            btnShiftManagement.UseVisualStyleBackColor = true;
            btnShiftManagement.Click += btnShiftManagement_Click;
            // 
            // btnSalaryManagement
            // 
            btnSalaryManagement.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnSalaryManagement.Location = new Point(118, 65);
            btnSalaryManagement.Name = "btnSalaryManagement";
            btnSalaryManagement.Size = new Size(100, 50);
            btnSalaryManagement.TabIndex = 1;
            btnSalaryManagement.Text = "給料";
            btnSalaryManagement.UseVisualStyleBackColor = true;
            btnSalaryManagement.Click += btnSalaryManagement_Click;
            // 
            // btnAttendanceManagement
            // 
            btnAttendanceManagement.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnAttendanceManagement.Location = new Point(12, 65);
            btnAttendanceManagement.Name = "btnAttendanceManagement";
            btnAttendanceManagement.Size = new Size(100, 50);
            btnAttendanceManagement.TabIndex = 2;
            btnAttendanceManagement.Text = "勤怠";
            btnAttendanceManagement.UseVisualStyleBackColor = true;
            btnAttendanceManagement.Click += btnAttendanceManagement_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnAdminMenu.Location = new Point(224, 65);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(100, 50);
            btnAdminMenu.TabIndex = 3;
            btnAdminMenu.Text = "管理";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Visible = false;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // btnAttendanceDeparture
            // 
            btnAttendanceDeparture.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnAttendanceDeparture.ImageAlign = ContentAlignment.MiddleLeft;
            btnAttendanceDeparture.Location = new Point(118, 9);
            btnAttendanceDeparture.Name = "btnAttendanceDeparture";
            btnAttendanceDeparture.Size = new Size(100, 50);
            btnAttendanceDeparture.TabIndex = 4;
            btnAttendanceDeparture.Text = "出勤/退勤";
            btnAttendanceDeparture.UseVisualStyleBackColor = true;
            btnAttendanceDeparture.Click += btnAttendanceDeparture_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = SystemColors.ActiveCaption;
            lblStatus.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 50);
            lblStatus.TabIndex = 5;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(334, 121);
            Controls.Add(lblStatus);
            Controls.Add(btnAttendanceDeparture);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnAttendanceManagement);
            Controls.Add(btnSalaryManagement);
            Controls.Add(btnShiftManagement);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnShiftManagement;
        private Button btnSalaryManagement;
        private Button btnAttendanceManagement;
        private Button btnAdminMenu;
        private Button btnAttendanceDeparture;
        private Label lblStatus;
    }
}