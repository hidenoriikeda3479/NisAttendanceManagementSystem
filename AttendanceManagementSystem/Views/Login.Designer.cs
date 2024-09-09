namespace AttendanceManagementSystem
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            employeeIdTextBox1 = new TextBox();
            passwordTextBox2 = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(126, 173);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "ログイン";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 14F);
            label1.Location = new Point(62, 55);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 14F);
            label2.Location = new Point(12, 113);
            label2.Name = "label2";
            label2.Size = new Size(80, 25);
            label2.TabIndex = 2;
            label2.Text = "パスワード";
            // 
            // employeeIdTextBox1
            // 
            employeeIdTextBox1.ImeMode = ImeMode.Disable;
            employeeIdTextBox1.Location = new Point(106, 57);
            employeeIdTextBox1.MaxLength = 2;
            employeeIdTextBox1.Name = "employeeIdTextBox1";
            employeeIdTextBox1.ShortcutsEnabled = false;
            employeeIdTextBox1.Size = new Size(221, 23);
            employeeIdTextBox1.TabIndex = 3;
            employeeIdTextBox1.KeyPress += employeeIdTextBox1_KeyPress;
            // 
            // passwordTextBox2
            // 
            passwordTextBox2.Location = new Point(106, 113);
            passwordTextBox2.MaxLength = 12;
            passwordTextBox2.Name = "passwordTextBox2";
            passwordTextBox2.PasswordChar = '*';
            passwordTextBox2.Size = new Size(221, 23);
            passwordTextBox2.TabIndex = 3;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 208);
            Controls.Add(passwordTextBox2);
            Controls.Add(employeeIdTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Name = "Login";
            Text = "ログイン画面";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private Label label2;
        private TextBox employeeIdTextBox1;
        private TextBox passwordTextBox2;
    }
}
