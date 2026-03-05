using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Notice : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Notice()
        {
            InitializeComponent();
            MouseDown += new MouseEventHandler(Notice_MouseDown);
        }
        public DialogResult Resultado { get; private set; }
        public static DialogResult ShowNotice(string mensagem)
        {
            var Menssagem = new Notice();
            Menssagem.NOTICE_LABEL.Text = mensagem.Replace("\\n", Environment.NewLine);
            Menssagem.NOTICE_LABEL.ForeColor = Color.White;
            Menssagem.ShowDialog();
            return Menssagem.Resultado;
        }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            Resultado = DialogResult.Yes;
            Environment.Exit(0);
        }
        #region Mouse Events
        private void OK_Button_MouseEnter(object sender, EventArgs e)
        {
            OK_Button.BackColor = Color.Transparent;
        }
        private void OK_Button_MouseLeave(object sender, EventArgs e)
        {
            OK_Button.BackColor = Color.Transparent;
        }
        #endregion
        private void Notice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
