namespace AttendanceManagementSystem.Views
{
    partial class Attendance
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            label1 = new Label();
            label3 = new Label();
            SearchDate = new DateTimePicker();
            btnUpdate = new Button();
            btnSearch = new Button();
            attendanceDataGridView = new DataGridView();
            AttendanceIdColumn10 = new DataGridViewTextBoxColumn();
            DateColumn1 = new DataGridViewTextBoxColumn();
            DayOfWeekColumn2 = new DataGridViewTextBoxColumn();
            WorkStartTimeHourColumn3 = new DataGridViewComboBoxColumn();
            WorkStartTimeMinutesColumn4 = new DataGridViewComboBoxColumn();
            WorkEndTimeHourColumn5 = new DataGridViewComboBoxColumn();
            WorkEndTimeMinutesColumn6 = new DataGridViewComboBoxColumn();
            BreakTimeHourColumn7 = new DataGridViewComboBoxColumn();
            BreakTimeMinutesColumn8 = new DataGridViewComboBoxColumn();
            WorkinghoursColumn9 = new DataGridViewTextBoxColumn();
            RemarksColumn10 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)attendanceDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 24F);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(148, 45);
            label1.TabIndex = 0;
            label1.Text = "勤怠確認";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 24F);
            label3.Location = new Point(166, 22);
            label3.Name = "label3";
            label3.Size = new Size(148, 45);
            label3.TabIndex = 1;
            label3.Text = "年月検索";
            // 
            // SearchDate
            // 
            SearchDate.Location = new Point(320, 40);
            SearchDate.Name = "SearchDate";
            SearchDate.Size = new Size(172, 23);
            SearchDate.TabIndex = 2;
            SearchDate.ValueChanged += SearchDate_ValueChanged;
            SearchDate.DropDown += SearchDate_DropDown;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(562, 25);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(49, 42);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(507, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(49, 42);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // attendanceDataGridView
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            attendanceDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            attendanceDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attendanceDataGridView.Columns.AddRange(new DataGridViewColumn[] { AttendanceIdColumn10, DateColumn1, DayOfWeekColumn2, WorkStartTimeHourColumn3, WorkStartTimeMinutesColumn4, WorkEndTimeHourColumn5, WorkEndTimeMinutesColumn6, BreakTimeHourColumn7, BreakTimeMinutesColumn8, WorkinghoursColumn9, RemarksColumn10 });
            attendanceDataGridView.Location = new Point(-1, 84);
            attendanceDataGridView.Name = "attendanceDataGridView";
            attendanceDataGridView.Size = new Size(1529, 885);
            attendanceDataGridView.TabIndex = 6;
            attendanceDataGridView.CellFormatting += attendanceDataGridView_CellFormatting;
            attendanceDataGridView.CellPainting += attendanceDataGridView_CellPainting;
            // 
            // AttendanceIdColumn10
            // 
            AttendanceIdColumn10.DataPropertyName = "AttendanceId";
            AttendanceIdColumn10.HeaderText = "ID";
            AttendanceIdColumn10.Name = "AttendanceIdColumn10";
            AttendanceIdColumn10.Visible = false;
            // 
            // DateColumn1
            // 
            DateColumn1.DataPropertyName = "Date";
            dataGridViewCellStyle2.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            DateColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            DateColumn1.HeaderText = "日付";
            DateColumn1.Name = "DateColumn1";
            DateColumn1.Width = 50;
            // 
            // DayOfWeekColumn2
            // 
            DayOfWeekColumn2.DataPropertyName = "DayOfWeek";
            dataGridViewCellStyle3.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            DayOfWeekColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            DayOfWeekColumn2.HeaderText = "曜日";
            DayOfWeekColumn2.Name = "DayOfWeekColumn2";
            DayOfWeekColumn2.Width = 50;
            // 
            // WorkStartTimeHourColumn3
            // 
            WorkStartTimeHourColumn3.DataPropertyName = "WorkStartTimeHour";
            dataGridViewCellStyle4.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkStartTimeHourColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            WorkStartTimeHourColumn3.HeaderText = "出社時間(時)";
            WorkStartTimeHourColumn3.Items.AddRange(new object[] { "", "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            WorkStartTimeHourColumn3.Name = "WorkStartTimeHourColumn3";
            WorkStartTimeHourColumn3.Width = 80;
            // 
            // WorkStartTimeMinutesColumn4
            // 
            WorkStartTimeMinutesColumn4.DataPropertyName = "WorkStartTimeMinutes";
            dataGridViewCellStyle5.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkStartTimeMinutesColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            WorkStartTimeMinutesColumn4.HeaderText = "出社時間(分)";
            WorkStartTimeMinutesColumn4.Items.AddRange(new object[] { "", "00", "10", "20", "30", "40", "50" });
            WorkStartTimeMinutesColumn4.Name = "WorkStartTimeMinutesColumn4";
            WorkStartTimeMinutesColumn4.Width = 80;
            // 
            // WorkEndTimeHourColumn5
            // 
            WorkEndTimeHourColumn5.DataPropertyName = "WorkEndTimeHour";
            dataGridViewCellStyle6.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkEndTimeHourColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            WorkEndTimeHourColumn5.HeaderText = "退社時間(時)";
            WorkEndTimeHourColumn5.Items.AddRange(new object[] { "", "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            WorkEndTimeHourColumn5.Name = "WorkEndTimeHourColumn5";
            WorkEndTimeHourColumn5.Width = 80;
            // 
            // WorkEndTimeMinutesColumn6
            // 
            WorkEndTimeMinutesColumn6.DataPropertyName = "WorkEndTimeMinutes";
            dataGridViewCellStyle7.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkEndTimeMinutesColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            WorkEndTimeMinutesColumn6.HeaderText = "退社時間(分)";
            WorkEndTimeMinutesColumn6.Items.AddRange(new object[] { "", "00", "10", "20", "30", "40", "50" });
            WorkEndTimeMinutesColumn6.Name = "WorkEndTimeMinutesColumn6";
            WorkEndTimeMinutesColumn6.Width = 80;
            // 
            // BreakTimeHourColumn7
            // 
            BreakTimeHourColumn7.DataPropertyName = "BreakTimeHour";
            dataGridViewCellStyle8.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BreakTimeHourColumn7.DefaultCellStyle = dataGridViewCellStyle8;
            BreakTimeHourColumn7.HeaderText = "休憩時間(時)";
            BreakTimeHourColumn7.Items.AddRange(new object[] { "", "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            BreakTimeHourColumn7.Name = "BreakTimeHourColumn7";
            BreakTimeHourColumn7.Width = 80;
            // 
            // BreakTimeMinutesColumn8
            // 
            BreakTimeMinutesColumn8.DataPropertyName = "BreakTimeMinutes";
            dataGridViewCellStyle9.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BreakTimeMinutesColumn8.DefaultCellStyle = dataGridViewCellStyle9;
            BreakTimeMinutesColumn8.HeaderText = "休憩時間(分)";
            BreakTimeMinutesColumn8.Items.AddRange(new object[] { "", "00", "10", "20", "30", "40", "50", "60" });
            BreakTimeMinutesColumn8.Name = "BreakTimeMinutesColumn8";
            BreakTimeMinutesColumn8.Width = 80;
            // 
            // WorkinghoursColumn9
            // 
            WorkinghoursColumn9.DataPropertyName = "Workinghours";
            dataGridViewCellStyle10.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkinghoursColumn9.DefaultCellStyle = dataGridViewCellStyle10;
            WorkinghoursColumn9.HeaderText = "勤務時間";
            WorkinghoursColumn9.Name = "WorkinghoursColumn9";
            // 
            // RemarksColumn10
            // 
            RemarksColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RemarksColumn10.DataPropertyName = "Remarks";
            dataGridViewCellStyle11.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RemarksColumn10.DefaultCellStyle = dataGridViewCellStyle11;
            RemarksColumn10.HeaderText = "備考";
            RemarksColumn10.Name = "RemarksColumn10";
            // 
            // Attendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 981);
            Controls.Add(attendanceDataGridView);
            Controls.Add(btnSearch);
            Controls.Add(btnUpdate);
            Controls.Add(SearchDate);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Attendance";
            Text = "Form1";
            Load += Attendance_Load;
            ((System.ComponentModel.ISupportInitialize)attendanceDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private DateTimePicker SearchDate;
        private Button btnUpdate;
        private Button btnSearch;
        private DataGridView attendanceDataGridView;
        private DataGridViewTextBoxColumn AttendanceIdColumn10;
        private DataGridViewTextBoxColumn DateColumn1;
        private DataGridViewTextBoxColumn DayOfWeekColumn2;
        private DataGridViewComboBoxColumn WorkStartTimeHourColumn3;
        private DataGridViewComboBoxColumn WorkStartTimeMinutesColumn4;
        private DataGridViewComboBoxColumn WorkEndTimeHourColumn5;
        private DataGridViewComboBoxColumn WorkEndTimeMinutesColumn6;
        private DataGridViewComboBoxColumn BreakTimeHourColumn7;
        private DataGridViewComboBoxColumn BreakTimeMinutesColumn8;
        private DataGridViewTextBoxColumn WorkinghoursColumn9;
        private DataGridViewTextBoxColumn RemarksColumn10;
    }
}