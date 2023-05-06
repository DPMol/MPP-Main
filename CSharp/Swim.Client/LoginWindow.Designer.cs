namespace chat.client
{
    partial class LoginWindow
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
            userText = new TextBox();
            label2 = new Label();
            passText = new TextBox();
            loginBut = new Button();
            clearBut = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 77);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 0;
            label1.Text = "User";
            // 
            // userText
            // 
            userText.Location = new Point(172, 71);
            userText.Margin = new Padding(5, 6, 5, 6);
            userText.Name = "userText";
            userText.Size = new Size(256, 31);
            userText.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 188);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // passText
            // 
            passText.Location = new Point(168, 185);
            passText.Margin = new Padding(5, 6, 5, 6);
            passText.Name = "passText";
            passText.PasswordChar = '*';
            passText.Size = new Size(257, 31);
            passText.TabIndex = 3;
            // 
            // loginBut
            // 
            loginBut.Location = new Point(58, 344);
            loginBut.Margin = new Padding(5, 6, 5, 6);
            loginBut.Name = "loginBut";
            loginBut.Size = new Size(138, 60);
            loginBut.TabIndex = 4;
            loginBut.Text = "Login";
            loginBut.UseVisualStyleBackColor = true;
            loginBut.Click += loginBut_Click;
            // 
            // clearBut
            // 
            clearBut.Location = new Point(262, 344);
            clearBut.Margin = new Padding(5, 6, 5, 6);
            clearBut.Name = "clearBut";
            clearBut.Size = new Size(135, 60);
            clearBut.TabIndex = 5;
            clearBut.Text = "Clear";
            clearBut.UseVisualStyleBackColor = true;
            clearBut.Click += clearBut_Click;
            // 
            // LoginWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 512);
            Controls.Add(clearBut);
            Controls.Add(loginBut);
            Controls.Add(passText);
            Controls.Add(label2);
            Controls.Add(userText);
            Controls.Add(label1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginWindow";
            Text = "Log In";
            Load += LoginWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Button loginBut;
        private System.Windows.Forms.Button clearBut;
    }
}

