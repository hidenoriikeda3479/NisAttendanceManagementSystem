namespace AttendanceManagementSystem.Views
{
    partial class Shift
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
            shiftDataGridView = new DataGridView();
            titleLabel = new Label();
            btnPastMonth = new Button();
            btnNextMonth = new Button();
            labelMorning = new Label();
            labelEvening = new Label();
            labelNight = new Label();
            ((System.ComponentModel.ISupportInitialize)shiftDataGridView).BeginInit();
            SuspendLayout();
            // 
            // shiftDataGridView
            // 
            shiftDataGridView.AllowUserToAddRows = false;
            shiftDataGridView.AllowUserToResizeColumns = false;
            shiftDataGridView.AllowUserToResizeRows = false;
            shiftDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            shiftDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            shiftDataGridView.Location = new Point(12, 99);
            shiftDataGridView.Name = "shiftDataGridView";
            shiftDataGridView.ReadOnly = true;
            shiftDataGridView.RowHeadersVisible = false;
            shiftDataGridView.Size = new Size(960, 450);
            shiftDataGridView.TabIndex = 0;
            shiftDataGridView.CellClick += shiftDaraGridView_CellClick;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            titleLabel.Location = new Point(425, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(150, 50);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "シフト一覧";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPastMonth
            // 
            btnPastMonth.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnPastMonth.Location = new Point(12, 62);
            btnPastMonth.Name = "btnPastMonth";
            btnPastMonth.Size = new Size(85, 31);
            btnPastMonth.TabIndex = 2;
            btnPastMonth.Text = "◀先月";
            btnPastMonth.UseVisualStyleBackColor = true;
            btnPastMonth.Click += btnChangeMonth_Click;
            // 
            // btnNextMonth
            // 
            btnNextMonth.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnNextMonth.Location = new Point(887, 62);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(85, 31);
            btnNextMonth.TabIndex = 3;
            btnNextMonth.Text = "来月▶";
            btnNextMonth.UseVisualStyleBackColor = true;
            btnNextMonth.Click += btnChangeMonth_Click;
            // 
            // labelMorning
            // 
            labelMorning.BackColor = Color.Yellow;
            labelMorning.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            labelMorning.Location = new Point(208, 62);
            labelMorning.Name = "labelMorning";
            labelMorning.Size = new Size(101, 31);
            labelMorning.TabIndex = 4;
            labelMorning.Text = "早番";
            labelMorning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEvening
            // 
            labelEvening.BackColor = Color.DodgerBlue;
            labelEvening.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            labelEvening.Location = new Point(442, 59);
            labelEvening.Name = "labelEvening";
            labelEvening.Size = new Size(101, 31);
            labelEvening.TabIndex = 5;
            labelEvening.Text = "中番";
            labelEvening.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelNight
            // 
            labelNight.BackColor = Color.ForestGreen;
            labelNight.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            labelNight.Location = new Point(702, 62);
            labelNight.Name = "labelNight";
            labelNight.Size = new Size(101, 31);
            labelNight.TabIndex = 6;
            labelNight.Text = "遅番";
            labelNight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Shift
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(labelNight);
            Controls.Add(labelEvening);
            Controls.Add(labelMorning);
            Controls.Add(btnNextMonth);
            Controls.Add(btnPastMonth);
            Controls.Add(titleLabel);
            Controls.Add(shiftDataGridView);
            Name = "Shift";
            Text = "Shift";
            ((System.ComponentModel.ISupportInitialize)shiftDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView shiftDataGridView;
        private Label titleLabel;
        private Button btnPastMonth;
        private Button btnNextMonth;
        private Label labelMorning;
        private Label labelEvening;
        private Label labelNight;
    }
}