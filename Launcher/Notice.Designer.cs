namespace Launcher
{
    partial class Notice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notice));
            this.OK_Button = new System.Windows.Forms.PictureBox();
            this.NOTICE_LABEL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OK_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.BackColor = System.Drawing.Color.Transparent;
            this.OK_Button.Location = new System.Drawing.Point(129, 146);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(121, 33);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.TabStop = false;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            this.OK_Button.MouseEnter += new System.EventHandler(this.OK_Button_MouseEnter);
            this.OK_Button.MouseLeave += new System.EventHandler(this.OK_Button_MouseLeave);
            // 
            // NOTICE_LABEL
            // 
            this.NOTICE_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.NOTICE_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.NOTICE_LABEL.ForeColor = System.Drawing.Color.White;
            this.NOTICE_LABEL.Location = new System.Drawing.Point(13, 86);
            this.NOTICE_LABEL.Name = "NOTICE_LABEL";
            this.NOTICE_LABEL.Size = new System.Drawing.Size(344, 16);
            this.NOTICE_LABEL.TabIndex = 1;
            this.NOTICE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(155, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "NOTICE";
            // 
            // Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(368, 191);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NOTICE_LABEL);
            this.Controls.Add(this.OK_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Notice_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.OK_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OK_Button;
        private System.Windows.Forms.Label NOTICE_LABEL;
        private System.Windows.Forms.Label label2;
    }
}