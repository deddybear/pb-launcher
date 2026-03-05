using System;
using System.Windows.Forms;

namespace Launcher
{
    public class Mensagem
    {
        public static void Info(string Message, string title)
        {
            MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Error(string Message, string title)
        {
            MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void Warning(string Message, string title)
        {
            MessageBox.Show(Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Question(string Message, string title)
        {
            MessageBox.Show(Message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void Exception(Exception Message)
        {
            MessageBox.Show(Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
