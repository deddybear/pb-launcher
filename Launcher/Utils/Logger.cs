using System;
using System.IO;
using System.Windows.Forms;

namespace Launcher
{
    public class Logger
    {
        public static void Log(string texto)
        {
            try
            {
                string logFilePath = Path.Combine(Application.StartupPath, "PBLauncher.log");
                string logMessage = $"[{DateTime.Now:yyyy.MM.dd} - {DateTime.Now:HH:mm}] {texto}";

                string directory = Path.GetDirectoryName(logFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
                {
                    streamWriter.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
