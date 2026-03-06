using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Launcher.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Launcher
{
    public partial class LoginForm : Form
    {

        private bool isPasswordVisible = false;

        public LoginForm()
        {
            
        InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Register_MouseLeave(object sender, EventArgs e)
        {
            BTN_Register.BackgroundImage = Resources.Register_Button;
            BTN_Register.Cursor = Cursors.Hand;
        }

        private void BTN_Register_MouseEnter(object sender, EventArgs e)
        {
            BTN_Register.BackgroundImage = Resources.Register_Button_Dark;
            BTN_Register.Cursor = Cursors.Hand;
        }

        private void BTN_Login_MouseEnter(object sender, EventArgs e)
        {
            BTN_Login.BackgroundImage = Resources.Login_Button_Dark;
            BTN_Login.Cursor = Cursors.Hand;
        }

        private void BTN_Login_MouseLeave(object sender, EventArgs e)
        {
            BTN_Login.BackgroundImage = Resources.Login_Button;
            BTN_Login.Cursor = Cursors.Hand;
        }

        private void BTN_Close_MouseLeave(object sender, EventArgs e)
        {
            BTN_Close.BackColor = Color.Transparent;
        }

        private void BTN_Close_MouseEnter(object sender, EventArgs e)
        {

            BTN_Close.Cursor = Cursors.Hand;
            BTN_Close.BackColor = Color.Transparent;
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Toggle_Password_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Sembunyikan password
                txtPassword.PasswordChar = '●';
                isPasswordVisible = false;
                BTN_Toggle_Password.Image = Properties.Resources.Hide_Icon; // ganti icon
            }
            else
            {
                // Tampilkan password
                txtPassword.PasswordChar = '\0'; // '\0' = tidak ada karakter pengganti
                isPasswordVisible = true;
                BTN_Toggle_Password.Image = Properties.Resources.View_Icon; // ganti icon
            }
        }

        private void BTN_Toggle_Password_MouseEnter(object sender, EventArgs e)
        {
            BTN_Close.Cursor = Cursors.Hand;
        }

        //private void BTN_Toggle_Password_MouseLeave(object sender, EventArgs e)
        //{

        //}

        private async void BTN_Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Cek apakah kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BTN_Login.Enabled = false;

            bool resultLoginAPI = await LoginAsync(username, password);

            if (!resultLoginAPI) {
                Logger.Log("[#] Gagal melakukan login ");
                MessageBox.Show("Gagal melakukan login.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            launchGame(username, password);

        }



        private void BTN_Register_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.google.com",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka browser: " + ex.Message);
            }
        }

        private async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                // Buat objek request
                var loginData = new
                {
                    username = username,
                    password = password
                };

                // Convert ke JSON
                string json = JsonConvert.SerializeObject(loginData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    // Set timeout
                    client.Timeout = TimeSpan.FromSeconds(30);

                    // Hit API
                    HttpResponseMessage response = await client.PostAsync(Infos.PBLAUNCHER_API_ADDRESS + "/api/auth/login-app", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize response
                        var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                        // Contoh ambil token jika ada
                        // string token = result.token;

                        MessageBox.Show("Login Berhasil!", "Info",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("Username atau Password salah!", "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Terjadi kesalahan! Status: " + response.StatusCode, "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Gagal konek ke server, periksa koneksi internet!", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timeout, server tidak merespons!", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void launchGame(string username, string password)
        {

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

            try
            {

                string exePath = Path.Combine(Application.StartupPath, "PointBlank.exe");

                if (!File.Exists(exePath))
                {
                    string Error = "Permainan tidak dapat dimulai. 'PointBlank.exe' tidak ditemukan.";
                    Logger.Log(Error);
                    //Notice.ShowNotice("File eksekusi game tidak dapat ditemukan.");
                    MessageBox.Show($"File eksekusi game tidak dapat ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = exePath;
                psi.Arguments = username + " " + password;
                psi.UseShellExecute = true;
                Process.Start(psi);

                Thread.Sleep(1000);
                Application.Exit();
            }
            catch (Exception ex)
            {
                Logger.Log("[#] Error launch game. ");
                MessageBox.Show($"Error launch game {ex.Message}.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
