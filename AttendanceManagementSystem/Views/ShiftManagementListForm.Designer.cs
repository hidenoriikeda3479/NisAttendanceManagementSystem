namespace AttendanceManagementSystem.Views
{
    partial class ShiftManagementListForm
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
            dgvShift = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvShift).BeginInit();
            SuspendLayout();
            // 
            // dgvShift
            // 
            dgvShift.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShift.Location = new Point(12, 12);
            dgvShift.Name = "dgvShift";
            dgvShift.Size = new Size(607, 348);
            dgvShift.TabIndex = 2;
            dgvShift.CellContentClick += dgvShift_CellContentClick;
            // 
            // ShiftManagementListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 373);
            Controls.Add(dgvShift);
            Name = "ShiftManagementListForm";
            Text = "シフト管理一覧";
            Load += ShiftManagementListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvShift).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvShift;
    }
}