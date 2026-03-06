using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Launcher.Properties;
using Launcher.Utils;
using Newtonsoft.Json.Linq;

namespace Launcher
{
    public partial class Launcher : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public bool LoadingStart;
        public bool LoadingCheck;
        public string startupPath = Application.StartupPath;
        List<string> NOT_FOUND = new List<string>();
        public int CountNotFound;
        public static WebClient CHECK_UPDATE = new WebClient();
        readonly List<string> EXTRACT_FILES = new List<string>();
        public string GameConection = $"http://{Infos.PBLAUNCHER_ADDRESS}";
        public bool LoadingUpdate;
        public int LastVersion = -1;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Launcher()
        {
            InitializeComponent();
        }
        #region mouse events
        private void BTN_Start_MouseEnter(object sender, EventArgs e)
        {
            BTN_Start.Cursor = Cursors.Hand;
            BTN_Start.BackgroundImage = Resources.Start_Leave1;
            BTN_Start.BackColor = Color.Transparent;
        }
        private void BTN_Start_MouseLeave(object sender, EventArgs e)
        {
            BTN_Start.BackgroundImage = Resources.Start_Enter1;
            BTN_Start.BackColor = Color.Transparent;
        }
        private void BTN_Check_MouseEnter(object sender, EventArgs e)
        {
            BTN_Check.Cursor = Cursors.Hand;
            BTN_Check.BackgroundImage = Resources.Check_Leave1;
            BTN_Check.BackColor = Color.Transparent;
        }
        private void BTN_Check_MouseLeave(object sender, EventArgs e)
        {
            BTN_Check.BackgroundImage = Resources.Check_Enter1;
            BTN_Check.BackColor = Color.Transparent;
        }
        private void BTN_Close_MouseEnter(object sender, EventArgs e)
        {
            BTN_Close.Cursor = Cursors.Hand;
            BTN_Close.BackgroundImage = Resources.Fechar_Leave___Copia;
            BTN_Close.BackColor = Color.Transparent;
        }
        private void BTN_Close_MouseLeave(object sender, EventArgs e)
        {
            BTN_Close.BackgroundImage = Resources.Fechar_Enter;
            BTN_Close.BackColor = Color.Transparent;
        }
        private void BTN_Minimize_MouseEnter(object sender, EventArgs e)
        {
            BTN_Minimize.Cursor = Cursors.Hand;
            BTN_Minimize.BackgroundImage = Resources.Minimize_Leave___Copia;
            BTN_Minimize.BackColor = Color.Transparent;
        }
        private void BTN_Minimize_MouseLeave(object sender, EventArgs e)
        {
            BTN_Minimize.BackgroundImage = Resources.Minimize_Enter;
            BTN_Minimize.BackColor = Color.Transparent;
        }
        private void BTN_Update_MouseEnter(object sender, EventArgs e)
        {
            BTN_Update.Cursor = Cursors.Hand;
            BTN_Update.BackgroundImage = Resources.Update_Leave1;
            BTN_Update.BackColor = Color.Transparent;
        }
        private void BTN_Update_MouseLeave(object sender, EventArgs e)
        {
            BTN_Update.BackgroundImage = Resources.Update_Enter1;
            BTN_Update.BackColor = Color.Transparent;
        }
        private void BTN_Close_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("COK NANDI ??", "PBLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void BTN_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Launcher_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
       #endregion
        private void Launcher_Load(object sender, EventArgs e)
        {
            MouseDown += new MouseEventHandler(Launcher_MouseDown);
            CheckNewsUpdate();
        }
        public void ButtonsVisible(bool start, bool check, bool update)
        {
            BTN_Start.Visible = start;
            BTN_Check.Visible = check;
            BTN_Update.Visible = update;
        }
        public void ButtonsEnable(bool start, bool check, bool update)
        {
            BTN_Start.Enabled = start;
            BTN_Check.Enabled = check;
            BTN_Update.Enabled = update;
        }
        public void SetFileBar(ulong received, ulong maximum)
        {
            if (FileBar.Width <= 463)
            {
                FileBar.Width = (int)(received * 463 / maximum);
            }
        }
        public void SetTotalBar(ulong received, ulong maximum)
        {
            if (TotalBar.Width <= 463)
            {
                TotalBar.Width = (int)(received * 463 / maximum);
            }
        }
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            try
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();

                //string gamePath = Path.Combine(Application.StartupPath, "PointBlank.exe");

                //if (File.Exists(gamePath))
                //{
                //    Process.Start(gamePath);
                //    Application.Exit();
                //}
                //else
                //{
                //    string Error = "Permainan tidak dapat dimulai. 'PointBlank.exe' tidak ditemukan.";
                //    Logger.Log(Error);
                //    //Notice.ShowNotice("File eksekusi game tidak dapat ditemukan.");
                //    MessageBox.Show($"File eksekusi game tidak dapat ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            catch (Exception ex)
            {
                string Error = $"Tidak dapat memulai permainan : {ex.Message}";
                Logger.Log(Error);
                Notice.ShowNotice("File eksekusi game tidak dapat ditemukan.");
            }
        }
        private void BTN_Check_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Client sudah versi terbaru", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //StartCheck();
        }
        public void CheckNewsUpdate()
        {
            LastVersion = Infos.PBLAUNCHER_VERSION_CLIENT_ATT;
            Update();

            string configPath = Path.Combine(Application.StartupPath, "config.json");
            int publicVersion = 0;

            if (File.Exists(configPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(configPath);
                    JObject config = JObject.Parse(jsonContent);
                    publicVersion = (int)config["PBLauncher"]["Public_Version"];
                }
                catch (Exception ex)
                {
                    Logger.Log($"Terjadi kesalahan saat membaca config.json: {ex.Message}");
                    MessageBox.Show("Gagal membaca file konfigurasi.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Logger.Log("File config.json tidak dapat ditemukan.");
                MessageBox.Show("Berkas konfigurasi tidak ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LastVersion == publicVersion)
            {
                LoadingUpdate = false;
                DirectoryDelete();
                Update();
                FILE_LABEL.Text = "File";
                FILE_LABEL.Visible = true;
                STATUS_LABEL.Text = "Anda bisa memulai permainan.";
                BTN_Start.BackgroundImage = Resources.Start_Leave1;
                BTN_Check.BackgroundImage = Resources.Check_Leave1;
                BTN_Update.BackgroundImage = Resources.Update_Leave1;
                ButtonsEnable(true, true, false);
                ButtonsVisible(true, true, false);
                NEWS_UPDATE.Stop();
            }
            else if (LastVersion > publicVersion)
            {
                LoadingUpdate = true;
                Update();
                FileBar.Width = 0;
                TotalBar.Width = 0;
                STATUS_LABEL.Text = "Pembaruan tersedia.";
                BTN_Update.BringToFront();
                BTN_Start.BackgroundImage = Resources.Start_Disable1;
                BTN_Check.BackgroundImage = Resources.Check_Disable1;
                BTN_Update.BackgroundImage = Resources.Update_Leave1;
                ButtonsEnable(false, false, true);
                ButtonsVisible(false, true, true);
            }
            else
            {
                FILE_LABEL.Text = "Menunggu verifikasi berkas.";
                ButtonsEnable(false, true, false);
                ButtonsVisible(true, true, false);
                Logger.Log("Versi launcher lebih tinggi dari versi server.");
                MessageBox.Show("Perubahan yang tidak valid terdeteksi.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
        public async void StartCheck()
        {
            await CheckClientAsync();
        }
        private int Speed = 1;
        private async Task CheckClientAsync()
        {
            Dictionary<string, string> USER_FILES = LoadUserFile($"{Application.StartupPath}\\UserFileList.dat");
            STATUS_LABEL.Text = $"Check";
            Logger.Log("[#] Memeriksa integritas file.");
            FILE_LABEL.Visible = true;
            ButtonsEnable(false, false, false);

            int count = 0;
            foreach (var item in USER_FILES.Keys)
            {
                count++;
                string fileName = Path.GetFileName(item);
                string relativePath = GetRelativePath(item);

                FILE_LABEL.Text = $"File {relativePath}";
                FileBar.Width = 0;

                if (USER_FILES.TryGetValue(item, out string expectedHash))
                {
                    string filePath = Path.Combine(startupPath, item);
                    if (!File.Exists(filePath))
                    {
                        FileBar.Width = 168;
                        NOT_FOUND.Add(item);
                        Logger.Log($"Berkas tidak ditemukan: {item}");
                    }
                    else if (GetHashFile(filePath) != expectedHash)
                    {
                        FileBar.Width = 242;
                        NOT_FOUND.Add(item);
                        Logger.Log($"Berkas rusak: {item}");
                    }
                }

                for (int i = 0; i <= 45; i += 9)
                {
                    FileBar.Width = (int)(463 * (i / 45.0));
                    Application.DoEvents();
                    Thread.Sleep(Speed);
                }

                SetTotalBar((ulong)count, (ulong)USER_FILES.Count);
                Update();
            }

            if (NOT_FOUND.Count > 0)
            {
                await DownloadMissingFilesAsync();
            }
            else
            {
                FinalizeVerification();
            }
        }

        private async Task DownloadMissingFilesAsync()
        {
            CountNotFound = NOT_FOUND.Count;
            FileBar.Width = 0;
            TotalBar.Width = 463;

            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "_DownloadPatchFiles"));
            Logger.Log($"Mengunduh [{CountNotFound}] Berkas tidak valid.");
            MessageBox.Show($"Terdeteksi. [{CountNotFound}] berkas tidak valid.", "PBLauncher", MessageBoxButtons.OK, MessageBoxIcon.Question);
            STATUS_LABEL.Text = "Mengunduh file patch.";

            int countCheck = 0;
            foreach (var item in NOT_FOUND)
            {
                countCheck++;
                string fileName = Path.GetFileName(item);
                string relativePath = GetRelativePath(item);
                string folderPath = Path.GetDirectoryName(item);

                FILE_LABEL.Text = $"File {relativePath}";

                try
                {
                    Uri URL = new Uri($"{GameConection}/check/client/{item}.zip");
                    string downloadPath = Path.Combine(Application.StartupPath, "_DownloadPatchFiles", item + ".zip");

                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "_DownloadPatchFiles", folderPath));
                    await CHECK_UPDATE.DownloadFileTaskAsync(URL, downloadPath);

                    if (File.Exists(downloadPath))
                    {
                        EXTRACT_FILES.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Berkas [{fileName}] Tidak ditemukan di server. Silakan coba lagi nanti.");
                    Mensagem.Warning($"Berkas [{fileName}] Tidak ditemukan di server. Silakan coba lagi nanti. \n\n {ex}", Application.ProductName);
                }

                for (int i = 0; i <= 45; i += 4)
                {
                    FileBar.Width = (int)(463 * (i / 45.0));
                    Application.DoEvents();
                    Thread.Sleep(Speed);
                }

                SetTotalBar((ulong)countCheck, (ulong)CountNotFound);
                Update();
            }

            FinalizeVerification();
        }


        private void FinalizeVerification()
        {
            FILE_LABEL.Visible = true;
            LoadingCheck = false;
            Logger.Log("Verifikasi selesai.");

            FILE_LABEL.Visible = true;
            ButtonsEnable(false, false, false);

            FileBar.Width = 463;
            TotalBar.Width = 463;
            FILE_LABEL.Text = "File";
            STATUS_LABEL.Text = "Verifikasi selesai. Anda sekarang dapat bermain.";
            Logger.Log($"Terdeteksi [{CountNotFound}] Berkas tidak valid.");

            EXTRACT_FILES.Clear();
            NOT_FOUND.Clear();
        }
        private string GetRelativePath(string path)
        {
            int index = path.LastIndexOf(startupPath);
            if (index == -1)
            {
                Logger.Log($"Terjadi kesalahan saat mengambil jalur relatif. Jalur: {path} tidak mengandung {startupPath}");
                return path;
            }

            return path.Substring(index + startupPath.Length + 1);
        }

        public static Dictionary<string, string> LoadUserFile(string path)
        {
            Dictionary<string, string> strs = new Dictionary<string, string>();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    if (fileStream.Length > 0)
                    {
                        xmlDocument.Load(fileStream);
                        foreach (XmlNode node in xmlDocument.ChildNodes)
                        {
                            if (string.Equals(node.Name, "list", StringComparison.OrdinalIgnoreCase))
                            {
                                foreach (XmlNode childNode in node.ChildNodes)
                                {
                                    if (string.Equals(childNode.Name, "file", StringComparison.OrdinalIgnoreCase))
                                    {
                                        XmlAttribute localAttr = childNode.Attributes?["local"];
                                        XmlAttribute hashAttr = childNode.Attributes?["hash"];

                                        if (localAttr != null && hashAttr != null)
                                        {
                                            string local = localAttr.Value;
                                            string hash = hashAttr.Value;
                                            if (!strs.ContainsKey(local))
                                            {
                                                strs.Add(local, hash);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (XmlException ex)
            {
                Logger.Log($"Kesalahan XML: {ex.Message}\r\n");
                Mensagem.Error("Terjadi kesalahan dengan Berkas XML", Application.ProductName);
            }
            catch (IOException ex)
            {
                Logger.Log($"Kesalahan I/O: {ex.Message}\r\n");
                Mensagem.Error("Terjadi kesalahan saat mengakses Berkas", Application.ProductName);
            }
            catch (Exception ex)
            {
                Logger.Log($"Kesalahan yang tidak terduga: {ex.Message}\r\n");
                Mensagem.Error("Terjadi kesalahan tak terduga saat memproses XML Berkas", Application.ProductName);
            }
            return strs;
        }
        public string GetHashFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Nama Berkas Tidak Valid");
                return string.Empty;
            }
            try
            {
                if (File.Exists(fileName))
                {
                    using (var fs = File.OpenRead(fileName))
                    {
                        using (var md5 = MD5.Create())
                        {
                            byte[] hash = md5.ComputeHash(fs);
                            return BitConverter.ToString(hash).Replace("-", string.Empty);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Berkas tidak ditemukan.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log("Berkas ditolak masuk.\n" + ex);
                MessageBox.Show("Akses ke Berkas ditolak.");
            }
            catch (IOException ex)
            {
                Logger.Log("Terjadi kesalahan I/O saat memproses Berkas:\n" + ex);
                MessageBox.Show("Terjadi kesalahan saat mengakses Berkas.");
            }
            catch (Exception ex)
            {
                Logger.Log("Pengecualian yang tidak terduga:\n" + ex);
                MessageBox.Show("Terjadi kesalahan yang tidak diketahui.");
            }
            return string.Empty;
        }
        private async void BTN_Update_Click(object sender, EventArgs e)
        {
            string FileExtract = "";
            try
            {
                LoadingUpdate = true;
                int count = 0;
                using (HttpClient client = new HttpClient())
                {
                    foreach (string Patch in PatchFiles.Patch_Files.Keys)
                    {
                        count++;
                        if (PatchFiles.Patch_Files.TryGetValue(Patch, out string URL))
                        {
                            int num = int.Parse(LerArquivo(
                                Path.Combine(Application.StartupPath, "config.json"),
                                "PBLauncher",
                                "Public_Version",
                                "0")) + 1;

                            string downloadDir = Path.Combine(Application.StartupPath, "_DownloadPatchFiles");
                            Directory.CreateDirectory(downloadDir);
                            string filePath = Path.Combine(downloadDir, Patch);
                            FileExtract = filePath;

                            try
                            {
                                Uri uri = new Uri(URL);
                                HttpResponseMessage response = await client.GetAsync(uri);
                                response.EnsureSuccessStatusCode();
                                byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                                await WriteAllBytesAsync(filePath, fileBytes);

                                PatchFiles.Patch_Files.Remove(Patch);
                                PatchFiles.Patch_Files.Remove(URL);

                                Logger.Log($"[Patch] Unduhan selesai: {Patch}");
                            }
                            catch (Exception ex)
                            {
                                Logger.Log($"Terjadi kesalahan saat mengunduh. Berkas: [{Patch}] - {ex.Message}");
                                Mensagem.Error($"Terjadi kesalahan saat mengunduh. Berkas: {Patch}", Application.ProductName);
                            }

                            ButtonsEnable(false, false, false);
                            BTN_Check.Enabled = false;
                            FILE_LABEL.Visible = true;
                            SetFileBar(0, (ulong)count);
                            Refresh();
                            Update();
                            STATUS_LABEL.Text = "Mengunduh file patch.";
                            FILE_LABEL.Text = $"File {Patch}";
                            return;
                        }
                    }
                }
                count = 0;
            }
            catch (Exception ex)
            {
                Logger.Log("[#] Terjadi pengecualian saat mencoba memperbarui file klien. ");
                MessageBox.Show("Terjadi pengecualian saat mencoba memperbarui file klien. \n" + ex.Message);
            }
        }
        public void DirectoryDelete()
        {
            if (Directory.Exists(string.Concat(Application.StartupPath, "\\_DownloadPatchFiles")))
            {
                Directory.Delete(string.Concat(Application.StartupPath, "\\_DownloadPatchFiles"), true);
            }
        }
        private async Task<string> ReadAllTextAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return await reader.ReadToEndAsync();
            }
        }
        private async Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }
        public static string LerArquivo(string path, string section, string key, string defaultValue)
        {

            if (!File.Exists(path))
            {
                return defaultValue;
            }

            try
            {
                string jsonContent = File.ReadAllText(path);
                JObject config = JObject.Parse(jsonContent);
                string value = (string)config[section]?[key];

                return value ?? defaultValue;
            }
            catch (Exception ex)
            {
                Logger.Log($"Terjadi kesalahan saat membaca config.json: {ex.Message}");
                return defaultValue;
            }
        }
        private async void NEWS_UPDATE_Tick(object sender, EventArgs e)
        {
            LastVersion = Infos.PBLAUNCHER_VERSION_CLIENT_ATT;
            string configPath = Path.Combine(Application.StartupPath, "config.json");
            int publicVersion = 0;

            if (File.Exists(configPath))
            {
                try
                {
                    string jsonContent = await ReadAllTextAsync(configPath);
                    JObject config = JObject.Parse(jsonContent);
                    publicVersion = (int)config["PBLauncher"]["Public_Version"];
                }
                catch (Exception ex)
                {
                    Logger.Log($"Terjadi kesalahan saat membaca config.json: {ex.Message}");
                    MessageBox.Show("Gagal membaca file konfigurasi.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Logger.Log("File config.json tidak dapat ditemukan.");
                MessageBox.Show("Berkas konfigurasi tidak ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LastVersion == publicVersion)
            {
                LoadingUpdate = false;
                DirectoryDelete();
                FileBar.Width = 463;
                TotalBar.Width = 463;
                ButtonsEnable(false, true, false);
                ButtonsVisible(true, true, false);
                FILE_LABEL.Text = "File";
                FILE_LABEL.Visible = true;
                NEWS_UPDATE.Stop();
                await Task.Delay(500);
                STATUS_LABEL.Text = "Periksa file-file tersebut.";
                Logger.Log("[+] Menunggu verifikasi setelah pembaruan.");
                BTN_Start.BackgroundImage = Resources.Start_Disable1;
                BTN_Check.BackgroundImage = Resources.Check_Leave1;
                BTN_Update.BackgroundImage = Resources.Update_Leave1;
            }
            else if (LastVersion > publicVersion)
            {
                LoadingUpdate = true;
                int count = 0;

                using (HttpClient client = new HttpClient())
                {
                    foreach (string Patch in PatchFiles.Patch_Files.Keys)
                    {
                        count++;
                        if (PatchFiles.Patch_Files.TryGetValue(Patch, out string URL))
                        {
                            string downloadPath = Path.Combine(Application.StartupPath, "_DownloadPatchFiles", Patch);
                            Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));

                            try
                            {
                                HttpResponseMessage response = await client.GetAsync(URL);
                                response.EnsureSuccessStatusCode();
                                byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                                await WriteAllBytesAsync(downloadPath, fileBytes);

                                PatchFiles.Patch_Files.Remove(Patch);
                                PatchFiles.Patch_Files.Remove(URL);
                            }
                            catch (Exception ex)
                            {
                                Mensagem.Error("Terjadi kesalahan saat mengunduh. pembaruan tersebut.", Application.ProductName);
                                Logger.Log($"[#] Terjadi kesalahan saat mengunduh pembaruan.: {Patch} - {ex.Message}");
                            }

                            ButtonsEnable(false, false, false);
                            SetFileBar(0, (ulong)count);
                            STATUS_LABEL.Text = "Mengunduh file patch.";
                            FILE_LABEL.Text = $"File {Patch}";
                            NEWS_UPDATE.Stop();
                            return;
                        }
                    }
                }
            }
            else
            {
                STATUS_LABEL.Text = "Menunggu verifikasi berkas.";
                ButtonsEnable(false, true, false);
                ButtonsVisible(true, true, false);
                Logger.Log("Launcher version greater than the server's version.");
                MessageBox.Show("Perubahan tidak valid terdeteksi.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
