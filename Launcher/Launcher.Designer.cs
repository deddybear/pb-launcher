namespace Launcher
{
    partial class Launcher
    {
        /// <ringkasan>
        /// Variabel perancang yang diperlukan.
        /// </ringkasan>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Bersihkan sumber daya yang sedang digunakan.
        // </summary>
        // <param name="disposing">true jika perlu membuang sumber daya yang dikelola; jika tidak, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kode yang dihasilkan oleh Windows Form Designer

        /// <summary>
        /// Metode yang diperlukan untuk dukungan Designer - 
        /// jangan memodifikasi isi metode ini dengan editor kode.

        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.BTN_Start = new System.Windows.Forms.PictureBox();
            this.BTN_Check = new System.Windows.Forms.PictureBox();
            this.BTN_Minimize = new System.Windows.Forms.PictureBox();
            this.BTN_Close = new System.Windows.Forms.PictureBox();
            this.FileBar = new System.Windows.Forms.PictureBox();
            this.TotalBar = new System.Windows.Forms.PictureBox();
            this.FILE_LABEL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.STATUS_LABEL = new System.Windows.Forms.Label();
            this.BTN_Update = new System.Windows.Forms.PictureBox();
            this.NEWS_UPDATE = new System.Windows.Forms.Timer(this.components);
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Update)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Start
            // 
            this.BTN_Start.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Start.BackgroundImage = global::Launcher.Properties.Resources.Start_Enter1;
            this.BTN_Start.Location = new System.Drawing.Point(617, 446);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(166, 76);
            this.BTN_Start.TabIndex = 0;
            this.BTN_Start.TabStop = false;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            this.BTN_Start.MouseEnter += new System.EventHandler(this.BTN_Start_MouseEnter);
            this.BTN_Start.MouseLeave += new System.EventHandler(this.BTN_Start_MouseLeave);
            // 
            // BTN_Check
            // 
            this.BTN_Check.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Check.BackgroundImage = global::Launcher.Properties.Resources.Check_Enter1;
            this.BTN_Check.Location = new System.Drawing.Point(505, 447);
            this.BTN_Check.Name = "BTN_Check";
            this.BTN_Check.Size = new System.Drawing.Size(106, 76);
            this.BTN_Check.TabIndex = 1;
            this.BTN_Check.TabStop = false;
            this.BTN_Check.Click += new System.EventHandler(this.BTN_Check_Click);
            this.BTN_Check.MouseEnter += new System.EventHandler(this.BTN_Check_MouseEnter);
            this.BTN_Check.MouseLeave += new System.EventHandler(this.BTN_Check_MouseLeave);
            // 
            // BTN_Minimize
            // 
            this.BTN_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Minimize.BackgroundImage = global::Launcher.Properties.Resources.Minimize_Leave___Copia;
            this.BTN_Minimize.Location = new System.Drawing.Point(737, 1);
            this.BTN_Minimize.Name = "BTN_Minimize";
            this.BTN_Minimize.Size = new System.Drawing.Size(25, 25);
            this.BTN_Minimize.TabIndex = 2;
            this.BTN_Minimize.TabStop = false;
            this.BTN_Minimize.Click += new System.EventHandler(this.BTN_Minimize_Click);
            this.BTN_Minimize.MouseEnter += new System.EventHandler(this.BTN_Minimize_MouseEnter);
            this.BTN_Minimize.MouseLeave += new System.EventHandler(this.BTN_Minimize_MouseLeave);
            // 
            // BTN_Close
            // 
            this.BTN_Close.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Close.BackgroundImage = global::Launcher.Properties.Resources.Fechar_Enter;
            this.BTN_Close.Location = new System.Drawing.Point(765, 1);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(25, 25);
            this.BTN_Close.TabIndex = 3;
            this.BTN_Close.TabStop = false;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            this.BTN_Close.MouseEnter += new System.EventHandler(this.BTN_Close_MouseEnter);
            this.BTN_Close.MouseLeave += new System.EventHandler(this.BTN_Close_MouseLeave);
            // 
            // FileBar
            // 
            this.FileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(172)))), ((int)(((byte)(240)))));
            this.FileBar.Location = new System.Drawing.Point(14, 481);
            this.FileBar.Name = "FileBar";
            this.FileBar.Size = new System.Drawing.Size(463, 9);
            this.FileBar.TabIndex = 5;
            this.FileBar.TabStop = false;
            // 
            // TotalBar
            // 
            this.TotalBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(172)))), ((int)(((byte)(240)))));
            this.TotalBar.Location = new System.Drawing.Point(14, 513);
            this.TotalBar.Name = "TotalBar";
            this.TotalBar.Size = new System.Drawing.Size(463, 9);
            this.TotalBar.TabIndex = 6;
            this.TotalBar.TabStop = false;
            // 
            // FILE_LABEL
            // 
            this.FILE_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.FILE_LABEL.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.FILE_LABEL.ForeColor = System.Drawing.Color.White;
            this.FILE_LABEL.Location = new System.Drawing.Point(10, 463);
            this.FILE_LABEL.Name = "FILE_LABEL";
            this.FILE_LABEL.Size = new System.Drawing.Size(467, 16);
            this.FILE_LABEL.TabIndex = 7;
            this.FILE_LABEL.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total";
            // 
            // STATUS_LABEL
            // 
            this.STATUS_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.STATUS_LABEL.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.STATUS_LABEL.ForeColor = System.Drawing.Color.White;
            this.STATUS_LABEL.Location = new System.Drawing.Point(10, 443);
            this.STATUS_LABEL.Name = "STATUS_LABEL";
            this.STATUS_LABEL.Size = new System.Drawing.Size(466, 16);
            this.STATUS_LABEL.TabIndex = 9;
            this.STATUS_LABEL.Text = "Non String";
            // 
            // BTN_Update
            // 
            this.BTN_Update.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Update.BackgroundImage = global::Launcher.Properties.Resources.Update_Enter1;
            this.BTN_Update.Location = new System.Drawing.Point(617, 446);
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.Size = new System.Drawing.Size(166, 76);
            this.BTN_Update.TabIndex = 10;
            this.BTN_Update.TabStop = false;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click);
            this.BTN_Update.MouseEnter += new System.EventHandler(this.BTN_Update_MouseEnter);
            this.BTN_Update.MouseLeave += new System.EventHandler(this.BTN_Update_MouseLeave);
            // 
            // NEWS_UPDATE
            // 
            this.NEWS_UPDATE.Tick += new System.EventHandler(this.NEWS_UPDATE_Tick);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(243, 160);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(519, 270);
            this.webView21.TabIndex = 11;
            this.webView21.ZoomFactor = 1D;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Launcher.Properties.Resources.Background_3;
            this.ClientSize = new System.Drawing.Size(793, 574);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.STATUS_LABEL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FILE_LABEL);
            this.Controls.Add(this.TotalBar);
            this.Controls.Add(this.FileBar);
            this.Controls.Add(this.BTN_Close);
            this.Controls.Add(this.BTN_Minimize);
            this.Controls.Add(this.BTN_Check);
            this.Controls.Add(this.BTN_Update);
            this.Controls.Add(this.BTN_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Update)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BTN_Start;
        private System.Windows.Forms.PictureBox BTN_Check;
        private System.Windows.Forms.PictureBox BTN_Minimize;
        private System.Windows.Forms.PictureBox BTN_Close;
        private System.Windows.Forms.PictureBox FileBar;
        private System.Windows.Forms.PictureBox TotalBar;
        private System.Windows.Forms.Label FILE_LABEL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label STATUS_LABEL;
        private System.Windows.Forms.PictureBox BTN_Update;
        private System.Windows.Forms.Timer NEWS_UPDATE;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}

