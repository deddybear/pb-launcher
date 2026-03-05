using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Launcher
{
    internal static class Program
    {
        /// <ringkasan>
        /// Titik masuk utama untuk aplikasi.
        /// </ringkasan>
        [STAThread]
        static void Main()
        {
            try
            {
                string aProcName = Process.GetCurrentProcess().ProcessName;

                if (Process.GetProcessesByName(aProcName).Skip(1).Any())
                {
                    MessageBox.Show("Anda tidak diperbolehkan membuka dua program secara bersamaan.", "PBLauncher", MessageBoxButtons.OK);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Connection());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan yang tidak terduga: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
