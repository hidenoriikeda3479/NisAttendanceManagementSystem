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
            btnEmployeeRegUpdate = new Button();
            btnEmployeeInformation = new Button();
            btnTotalAmountPaid = new Button();
            SuspendLayout();
            // 
            // btnEmployeeRegUpdate
            // 
            btnEmployeeRegUpdate.Location = new Point(12, 12);
            btnEmployeeRegUpdate.Name = "btnEmployeeRegUpdate";
            btnEmployeeRegUpdate.Size = new Size(218, 89);
            btnEmployeeRegUpdate.TabIndex = 0;
            btnEmployeeRegUpdate.Text = "従業員登録";
            btnEmployeeRegUpdate.UseVisualStyleBackColor = true;
            btnEmployeeRegUpdate.Click += btnEmployeeRegUpdate_Click;
            // 
            // btnEmployeeInformation
            // 
            btnEmployeeInformation.Location = new Point(12, 124);
            btnEmployeeInformation.Name = "btnEmployeeInformation";
            btnEmployeeInformation.Size = new Size(218, 90);
            btnEmployeeInformation.TabIndex = 1;
            btnEmployeeInformation.Text = "従業員一覧";
            btnEmployeeInformation.UseVisualStyleBackColor = true;
            btnEmployeeInformation.Click += btnEmployeeInformation_Click;
            // 
            // btnTotalAmountPaid
            // 
            btnTotalAmountPaid.Location = new Point(12, 238);
            btnTotalAmountPaid.Name = "btnTotalAmountPaid";
            btnTotalAmountPaid.Size = new Size(218, 90);
            btnTotalAmountPaid.TabIndex = 2;
            btnTotalAmountPaid.Text = "総支給額集計";
            btnTotalAmountPaid.UseVisualStyleBackColor = true;
            btnTotalAmountPaid.Click += btnTotalAmountPaid_Click_1;
            // 
            // ManagementMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 340);
            Controls.Add(btnTotalAmountPaid);
            Controls.Add(btnEmployeeInformation);
            Controls.Add(btnEmployeeRegUpdate);
            Name = "ManagementMenu";
            Text = "ManagementMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEmployeeRegUpdate;
        private Button btnEmployeeInformation;
        private Button btnTotalAmountPaid;
    }
}