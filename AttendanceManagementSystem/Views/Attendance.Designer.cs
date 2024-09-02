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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button2 = new Button();
            button1 = new Button();
            dataGridView2 = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 24F);
            label2.Location = new Point(166, 22);
            label2.Name = "label2";
            label2.Size = new Size(148, 45);
            label2.TabIndex = 1;
            label2.Text = "従業員名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 24F);
            label3.Location = new Point(320, 22);
            label3.Name = "label3";
            label3.Size = new Size(148, 45);
            label3.TabIndex = 1;
            label3.Text = "年月検索";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(474, 40);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(172, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1.DropDown += dateTimePicker1_DropDown;
            // 
            // button2
            // 
            button2.Location = new Point(716, 25);
            button2.Name = "button2";
            button2.Size = new Size(49, 42);
            button2.TabIndex = 4;
            button2.Text = "更新";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(661, 25);
            button1.Name = "button1";
            button1.Size = new Size(49, 42);
            button1.TabIndex = 4;
            button1.Text = "検索";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { AttendanceIdColumn10, DateColumn1, DayOfWeekColumn2, WorkStartTimeHourColumn3, WorkStartTimeMinutesColumn4, WorkEndTimeHourColumn5, WorkEndTimeMinutesColumn6, BreakTimeHourColumn7, BreakTimeMinutesColumn8, WorkinghoursColumn9, RemarksColumn10 });
            dataGridView2.Location = new Point(-1, 84);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(1529, 885);
            dataGridView2.TabIndex = 6;
            dataGridView2.CellFormatting += dataGridView2_CellFormatting;
            dataGridView2.CellPainting += dataGridView2_CellPainting;
            // 
            // AttendanceIdColumn10
            // 
            AttendanceIdColumn10.DataPropertyName = "AttendanceId";
            AttendanceIdColumn10.HeaderText = "ID";
            AttendanceIdColumn10.Name = "AttendanceIdColumn10";
            // 
            // DateColumn1
            // 
            DateColumn1.DataPropertyName = "Date";
            DateColumn1.HeaderText = "日付";
            DateColumn1.Name = "DateColumn1";
            // 
            // DayOfWeekColumn2
            // 
            DayOfWeekColumn2.DataPropertyName = "DayOfWeek";
            DayOfWeekColumn2.HeaderText = "曜日";
            DayOfWeekColumn2.Name = "DayOfWeekColumn2";
            // 
            // WorkStartTimeHourColumn3
            // 
            WorkStartTimeHourColumn3.DataPropertyName = "WorkStartTimeHour";
            WorkStartTimeHourColumn3.HeaderText = "出社時間(時)";
            WorkStartTimeHourColumn3.Items.AddRange(new object[] { "", "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            WorkStartTimeHourColumn3.Name = "WorkStartTimeHourColumn3";
            // 
            // WorkStartTimeMinutesColumn4
            // 
            WorkStartTimeMinutesColumn4.DataPropertyName = "WorkStartTimeMinutes";
            WorkStartTimeMinutesColumn4.HeaderText = "出社時間(分)";
            WorkStartTimeMinutesColumn4.Items.AddRange(new object[] { "", "0", "10", "20", "30", "40", "50" });
            WorkStartTimeMinutesColumn4.Name = "WorkStartTimeMinutesColumn4";
            // 
            // WorkEndTimeHourColumn5
            // 
            WorkEndTimeHourColumn5.DataPropertyName = "WorkEndTimeHour";
            WorkEndTimeHourColumn5.HeaderText = "退社時間(時)";
            WorkEndTimeHourColumn5.Items.AddRange(new object[] { "", "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            WorkEndTimeHourColumn5.Name = "WorkEndTimeHourColumn5";
            // 
            // WorkEndTimeMinutesColumn6
            // 
            WorkEndTimeMinutesColumn6.DataPropertyName = "WorkEndTimeMinutes";
            WorkEndTimeMinutesColumn6.HeaderText = "退社時間(分)";
            WorkEndTimeMinutesColumn6.Items.AddRange(new object[] { "", "0", "10", "20", "30", "40", "50" });
            WorkEndTimeMinutesColumn6.Name = "WorkEndTimeMinutesColumn6";
            // 
            // BreakTimeHourColumn7
            // 
            BreakTimeHourColumn7.DataPropertyName = "BreakTimeHour";
            BreakTimeHourColumn7.HeaderText = "休憩時間(時)";
            BreakTimeHourColumn7.Items.AddRange(new object[] { "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            BreakTimeHourColumn7.Name = "BreakTimeHourColumn7";
            // 
            // BreakTimeMinutesColumn8
            // 
            BreakTimeMinutesColumn8.DataPropertyName = "BreakTimeMinutes";
            BreakTimeMinutesColumn8.HeaderText = "休憩時間(分)";
            BreakTimeMinutesColumn8.Items.AddRange(new object[] { "", "0", "10", "20", "30", "40", "50", "60" });
            BreakTimeMinutesColumn8.Name = "BreakTimeMinutesColumn8";
            // 
            // WorkinghoursColumn9
            // 
            WorkinghoursColumn9.DataPropertyName = "Workinghours";
            WorkinghoursColumn9.HeaderText = "勤務時間";
            WorkinghoursColumn9.Name = "WorkinghoursColumn9";
            // 
            // RemarksColumn10
            // 
            RemarksColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RemarksColumn10.DataPropertyName = "Remarks";
            RemarksColumn10.HeaderText = "備考";
            RemarksColumn10.Name = "RemarksColumn10";
            // 
            // Attendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 981);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Attendance";
            Text = "Form1";
            Load += Attendance_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView2;
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