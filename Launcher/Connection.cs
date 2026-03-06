using Launcher.Utils;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{

    public partial class Connection : Form
    {
        private NpgsqlConnection ConDB;
        bool start = false;
        string Patch = Application.StartupPath;
        public Connection()
        {
            InitializeComponent();
            Infos.PGSQL_CONNECTION = "Server=10.1.28.24;" + "Port=5432;" + "User Id=postgres;" + "Password=297b5b41;" + "Database=postgres;";
            ConDB = new NpgsqlConnection(Infos.PGSQL_CONNECTION);
        }
        private async void Connection_Load(object sender, EventArgs e)
        {

            if (CheckFiles())
            {
                if (OpenDatabase() && CheckStatus())
                {
                    if (start == true)
                    {
                        Visible = true;
                        ShowInTaskbar = false;
                        await Task.Delay(1000);
                        Hide();
                        Opacity = 1;
                        new Launcher().Show();
                    }
                    else
                    {
                        Logger.Log("Tidak dapat terhubung ke server DB.");
                        MessageBox.Show("Tidak dapat terhubung ke server DB.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
        }
        public bool OpenDatabase()
        {
            try
            {
                ConDB.Open();
            }
            catch
            {
                ConDB.Close();
                MessageBox.Show($"Kami tidak dapat terhubung ke basis data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Log("Kami tidak dapat terhubung ke basis data.");
                Application.Exit();
            }
            if (ConDB.State == ConnectionState.Open)
            {
                try
                {
                    LoadTables();
                    start = true;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Application.Exit();
                    return false;
                }
            }
            ConDB.Close();
            return false;
        }
        public void LoadTables()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from connection", ConDB);
                NpgsqlDataReader leitor = cmd.ExecuteReader();
                while (leitor.Read())
                {
                    Infos.PBLAUNCHER_CONNECTION_TYPE = leitor["CONNECTION_TYPE"].ToString();
                    Infos.PBLAUNCHER_API_ADDRESS = leitor["URL_API"].ToString();
                    Infos.PBLAUNCHER_VERSION_CLIENT_ATT = int.Parse(leitor["LAST_CLIENT_VERSION"].ToString());
                    Infos.PBLAUNCHER_VERSION = int.Parse(leitor["LAST_PBLAUNCHER_VERSION"].ToString());
                    Infos.PBLAUNCHER_ADDRESS = leitor["IP_ADDRESS"].ToString();
                    Infos.PBLAUNCHER_USERFILELIST = leitor["USER_FILE_LIST"].ToString();
                }
                leitor.Close();
            }
            catch (Exception ex) { Mensagem.Error(ex.ToString(), Application.ProductName);}
            string configPath = Path.Combine(Application.StartupPath, "config.json");
            long publicVersion = 0;
            if (File.Exists(configPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(configPath);
                    JObject config = JObject.Parse(jsonContent);
                    publicVersion = (long?)config["PBLauncher"]?["Public_Version"] ?? 0;
                }
                catch (Exception ex)
                {
                    Logger.Log($"Terjadi kesalahan saat membaca config.json: {ex.Message}");
                    return;
                }
            }
            else
            {
                Logger.Log("File config.json tidak dapat ditemukan.");
                return;
            }
            string ConnectionDB = "Server=10.1.28.24;"+"Port=5432;"+"User Id=postgres;"+"Password=297b5b41;"+"Database=postgres;";
            using (NpgsqlConnection bdConn = new NpgsqlConnection(ConnectionDB))
            {
                try
                {
                    bdConn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM update_client", bdConn))
                    using (NpgsqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            int dbVersion = int.Parse(leitor["version"].ToString());
                            if (dbVersion > publicVersion)
                            {
                                string patch = leitor["patch"].ToString();
                                string url = leitor["url"].ToString();

                                if (!PatchFiles.Patch_Files.ContainsKey(patch))
                                {
                                    PatchFiles.Patch_Files.Add(patch, url);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Terjadi kesalahan saat menghubungkan ke basis data atau menjalankan kueri: {ex.Message}");
                }
            }
        }
        public bool CheckStatus()
        {
            switch (Infos.PBLAUNCHER_CONNECTION_TYPE)
            {
                case "ONLINE":
                    {
                        return true;
                    }
                case "OFFLINE":
                    {
                        Logger.Log("[#] Tidak dapat terhubung ke server DB.");
                        MessageBox.Show("Tidak dapat terhubung ke server DB.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return false;
                    }
                default:
                    {
                        Logger.Log("[#] Tidak dapat terhubung ke server DB.");
                        MessageBox.Show("Tidak dapat terhubung ke server DB.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return false;
                    }
            }
        }
        public bool CheckFiles()
        {
            Logger.Log("Memeriksa file-file penting.");
            if (!File.Exists($"{Patch}//Config.json"))
            {
                MessageBox.Show($"File Config.json tidak ditemukan. {Patch}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Log("[>>] Berkas hilang:Config.json");
                Application.Exit();
                return false;
            }
            Logger.Log("[#] Config.json.");
            if (!File.Exists($"{Patch}//Newtonsoft.Json.dll"))
            {
                MessageBox.Show($"Newtonsoft.Json.dll Tidak ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Log("[>>] Berkas hilang: Newtonsoft.Json.dll");
                Application.Exit();
                return false;
            }
            Logger.Log("[#] Newtonsoft.Json.dll.");
            if (!File.Exists($"{Patch}//Npgsql.dll"))
            {
                MessageBox.Show($"Npgsql.dll Tidak ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Log("[>>] Berkas hilang: Npgsql.dll");
                Application.Exit();
                return false;
            }
            Logger.Log("[#] System.ValueTuple.dll.");
            if (!File.Exists($"{Patch}//System.ValueTuple.dll"))
            {
                MessageBox.Show($"Berkas konfigurasi tidak ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Log("[>>] Berkas hilang: System.ValueTuple.dll.");
                Application.Exit();
                return false;
            }
            Logger.Log("[#] System.Threading.Tasks.Extensions.dll.");
            if (!File.Exists($"{Patch}//System.Threading.Tasks.Extensions.dll"))
            {
                MessageBox.Show($"Berkas UserFileList.dat tidak ditemukan.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Log("[>>] Berkas hilang: System.Threading.Tasks.Extensions.dll.");
                Application.Exit();
                return false;
            }
            Logger.Log("[#] System.Runtime.CompilerServices.Unsafe.dll.");
            if (!File.Exists($"{Patch}//System.Runtime.CompilerServices.Unsafe.dll"))
            {
                Logger.Log("[>>] Berkas hilang:System.Runtime.CompilerServices.Unsafe.dll.");

                Application.Exit();
                return false;
            }
            Logger.Log("Berkas telah diverifikasi.");
            return true;
        }

        private void STATUS_LABEL_Click(object sender, EventArgs e)
        {

        }
    }
}
