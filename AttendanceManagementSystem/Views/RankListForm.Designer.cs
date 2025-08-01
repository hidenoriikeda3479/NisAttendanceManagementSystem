namespace AttendanceManagementSystem.Views
{
    partial class RankListForm
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
            btnDeleteRank = new Button();
            btnEditRank = new Button();
            btnAddRank = new Button();
            lblRank = new Label();
            txtRank = new TextBox();
            dgvRank = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRank).BeginInit();
            SuspendLayout();
            // 
            // btnDeleteRank
            // 
            btnDeleteRank.Location = new Point(380, 21);
            btnDeleteRank.Name = "btnDeleteRank";
            btnDeleteRank.Size = new Size(75, 23);
            btnDeleteRank.TabIndex = 14;
            btnDeleteRank.Text = "削除";
            btnDeleteRank.UseVisualStyleBackColor = true;
            btnDeleteRank.Click += btnDeleteRank_Click;
            // 
            // btnEditRank
            // 
            btnEditRank.Location = new Point(299, 21);
            btnEditRank.Name = "btnEditRank";
            btnEditRank.Size = new Size(75, 23);
            btnEditRank.TabIndex = 13;
            btnEditRank.Text = "編集";
            btnEditRank.UseVisualStyleBackColor = true;
            btnEditRank.Click += btnEditRank_Click;
            // 
            // btnAddRank
            // 
            btnAddRank.Location = new Point(218, 20);
            btnAddRank.Name = "btnAddRank";
            btnAddRank.Size = new Size(75, 23);
            btnAddRank.TabIndex = 12;
            btnAddRank.Text = "登録";
            btnAddRank.UseVisualStyleBackColor = true;
            btnAddRank.Click += btnAddRank_Click;
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Location = new Point(29, 24);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(43, 15);
            lblRank.TabIndex = 11;
            lblRank.Text = "時給名";
            // 
            // txtRank
            // 
            txtRank.Location = new Point(78, 21);
            txtRank.MaxLength = 255;
            txtRank.Name = "txtRank";
            txtRank.Size = new Size(134, 23);
            txtRank.TabIndex = 10;
            // 
            // dgvRank
            // 
            dgvRank.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRank.Location = new Point(12, 63);
            dgvRank.MultiSelect = false;
            dgvRank.Name = "dgvRank";
            dgvRank.Size = new Size(467, 231);
            dgvRank.TabIndex = 9;
            dgvRank.CellClick += dgvRank_CellClick;
            // 
            // RankListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 311);
            Controls.Add(btnDeleteRank);
            Controls.Add(btnEditRank);
            Controls.Add(btnAddRank);
            Controls.Add(lblRank);
            Controls.Add(txtRank);
            Controls.Add(dgvRank);
            Name = "RankListForm";
            Text = "時給一覧";
            Load += RankListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRank).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDeleteRank;
        private Button btnEditRank;
        private Button btnAddRank;
        private Label lblRank;
        private TextBox txtRank;
        private DataGridView dgvRank;
    }
}