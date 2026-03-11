using System.Resources;
using System.Windows.Forms;
using Launcher.Properties;

namespace Launcher
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox BTN_Close;
        private System.Windows.Forms.PictureBox BTN_Login;
        private System.Windows.Forms.PictureBox BTN_Register;
        private System.Windows.Forms.PictureBox BTN_Toggle_Password;
        private System.Windows.Forms.PictureBox IconAccount;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.BTN_Close = new System.Windows.Forms.PictureBox();
            this.BTN_Login = new System.Windows.Forms.PictureBox();
            this.BTN_Register = new System.Windows.Forms.PictureBox();
            this.BTN_Toggle_Password = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.IconAccount = new System.Windows.Forms.PictureBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Register)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Toggle_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Close
            // 
            this.BTN_Close.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Close.Location = new System.Drawing.Point(740, 12);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(32, 41);
            this.BTN_Close.TabIndex = 3;
            this.BTN_Close.TabStop = false;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            this.BTN_Close.MouseEnter += new System.EventHandler(this.BTN_Close_MouseEnter);
            this.BTN_Close.MouseLeave += new System.EventHandler(this.BTN_Close_MouseLeave);
            // 
            // BTN_Login
            // 
            this.BTN_Login.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Login.BackgroundImage = global::Launcher.Properties.Resources.Login_Button_Dark;
            this.BTN_Login.Location = new System.Drawing.Point(468, 290);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(105, 73);
            this.BTN_Login.TabIndex = 0;
            this.BTN_Login.TabStop = false;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            this.BTN_Login.MouseEnter += new System.EventHandler(this.BTN_Login_MouseEnter);
            this.BTN_Login.MouseLeave += new System.EventHandler(this.BTN_Login_MouseLeave);
            // 
            // BTN_Register
            // 
            this.BTN_Register.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Register.BackgroundImage = global::Launcher.Properties.Resources.Register_Button_Dark;
            this.BTN_Register.Location = new System.Drawing.Point(598, 290);
            this.BTN_Register.Name = "BTN_Register";
            this.BTN_Register.Size = new System.Drawing.Size(105, 73);
            this.BTN_Register.TabIndex = 0;
            this.BTN_Register.TabStop = false;
            this.BTN_Register.Click += new System.EventHandler(this.BTN_Register_Click);
            this.BTN_Register.MouseEnter += new System.EventHandler(this.BTN_Register_MouseEnter);
            this.BTN_Register.MouseLeave += new System.EventHandler(this.BTN_Register_MouseLeave);
            // 
            // BTN_Toggle_Password
            // 
            this.BTN_Toggle_Password.Image = global::Launcher.Properties.Resources.Hide_Icon;
            this.BTN_Toggle_Password.Location = new System.Drawing.Point(679, 246);
            this.BTN_Toggle_Password.Name = "BTN_Toggle_Password";
            this.BTN_Toggle_Password.Size = new System.Drawing.Size(24, 20);
            this.BTN_Toggle_Password.TabIndex = 0;
            this.BTN_Toggle_Password.TabStop = false;
            this.BTN_Toggle_Password.Click += new System.EventHandler(this.BTN_Toggle_Password_Click);
            this.BTN_Toggle_Password.MouseEnter += new System.EventHandler(this.BTN_Toggle_Password_MouseEnter);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsername.Location = new System.Drawing.Point(465, 153);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // IconAccount
            // 
            this.IconAccount.Image = global::Launcher.Properties.Resources.Account_Icon;
            this.IconAccount.Location = new System.Drawing.Point(679, 169);
            this.IconAccount.Name = "IconAccount";
            this.IconAccount.Size = new System.Drawing.Size(24, 20);
            this.IconAccount.TabIndex = 0;
            this.IconAccount.TabStop = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPassword.Location = new System.Drawing.Point(467, 230);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(470, 169);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(233, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += Txt_Username_KeyDown;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(470, 246);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(233, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.KeyDown += Txt_Password_KeyDown;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Launcher.Properties.Resources.BGLogin;
            this.ClientSize = new System.Drawing.Size(790, 532);
            this.Controls.Add(this.BTN_Login);
            this.Controls.Add(this.BTN_Close);
            this.Controls.Add(this.BTN_Register);
            this.Controls.Add(this.BTN_Toggle_Password);
            this.Controls.Add(this.IconAccount);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login Form";
            //this.Load += new System.EventHandler(this.LoginForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Register)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Toggle_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

    }
}