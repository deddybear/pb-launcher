namespace Launcher
{
    partial class Connection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection));
            this.STATUS_LABEL = new System.Windows.Forms.Label();
            this.LAUNCHER_UPDATE = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // STATUS_LABEL
            // 
            this.STATUS_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.STATUS_LABEL.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.STATUS_LABEL.ForeColor = System.Drawing.Color.Black;
            this.STATUS_LABEL.Location = new System.Drawing.Point(-5, 13);
            this.STATUS_LABEL.Name = "STATUS_LABEL";
            this.STATUS_LABEL.Size = new System.Drawing.Size(273, 16);
            this.STATUS_LABEL.TabIndex = 2;
            this.STATUS_LABEL.Text = "Harap tunggu.";
            this.STATUS_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.STATUS_LABEL.Click += new System.EventHandler(this.STATUS_LABEL_Click);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(266, 41);
            this.ControlBox = false;
            this.Controls.Add(this.STATUS_LABEL);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Connection_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label STATUS_LABEL;
        private System.Windows.Forms.Timer LAUNCHER_UPDATE;
    }
}