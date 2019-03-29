using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace GuildTracker
{
    public partial class Form1 : Form
    {
        private string zone;
        private string toonName = null;
        private Font font;
        Dictionary<string, string> zoneAssociations = null;

        public Form1()
        {
            InitializeComponent();
            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               6,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            LoadMapZoneAssociations();
        }

        private void LoadMapZoneAssociations()
        {
            if (File.Exists(".\\maps\\zones.json"))
            {
                FileStream fs = new FileStream(".\\maps\\zones.json", FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    string readBlock = sr.ReadToEnd();
                    zoneAssociations = (Dictionary<string, string>)new JavaScriptSerializer().Deserialize(readBlock, typeof(Dictionary<string, string>));
                }
                fs.Close();
            }
            else
                zoneAssociations = new Dictionary<string, string>();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            P99LogMonitor.StopMonitering();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            P99LogMonitor.OnNewFileCaptured += P99LogMonitor_OnNewFileCaptured;
            P99LogMonitor.OnNewLineCaptured += P99LogMonitor_OnNewLineCaptured;
            PlayerManagement.OnLocationChanged += PlayerManagement_OnLocationChanged;
            PlayerManagement.OnPlayerAadded += PlayerManagement_OnPlayerAadded;
            PlayerManagement.OnPlayerRemoved += PlayerManagement_OnPlayerRemoved;
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            aMap.OnDraw += AMap_OnDraw;
            if ((Properties.Settings.Default.LogFolder == "c:\\") || (Properties.Settings.Default.LogFolder == ""))
            {
                logMonitorStatus.Text = "Moniter Status: Not running. Please set a log directory to monitor.";
            }
            else
            {
                logMonitorStatus.Text = "Moniter Status: Watching " + Properties.Settings.Default.LogFolder + ".";
                connectionInfo.Text = Properties.Settings.Default.DefaultConnection;
                P99LogMonitor.StartMoniteringAtLocation(Properties.Settings.Default.LogFolder);
            }
        }

        private void PlayerManagement_OnPlayerRemoved(PlayerManagement.Player aPlayer)
        {
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            aMap.Invalidate();
        }

        private void PlayerManagement_OnPlayerAadded(PlayerManagement.Player aPlayer)
        {
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            aMap.Invalidate();
        }

        private void PlayerManagement_OnLocationChanged(string name, PlayerManagement.Location aLocation)
        {
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            aMap.Invalidate();
        }

        private void P99LogMonitor_OnNewFileCaptured(string filename)
        {
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            string[] fileSplit = filename.Split('_');

            if (toonName != null)
            {
                PlayerManagement.RemovePlayer(toonName);
                PlayerLoggingUDPClient.Send('R', PlayerManagement.GetPlayer(toonName));
            }

            toonName = fileSplit[fileSplit.Length - 2];

            //  Open a stream using the changed file.
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //  We need to read in reverse to find the "Welcome to Everquest!" session start key;
            string line = "";
            string[] splitDelim = { "] " };
            string lookFor = "You have entered ";
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line == "")
                        continue;
                    line = line.Split(splitDelim, StringSplitOptions.None)[1];

                    if (line.StartsWith(lookFor))
                    {
                        zone = line.Remove(0, lookFor.Length);
                        zone = zone.TrimEnd('.');
                    }
                }
                //  Load map based on zone name.
                Invoke(new MethodInvoker(delegate () { LoadMap(); }));
                logMonitorStatus.Text = "Monitor Status: Can't find zone map " + zone;
                fs.Seek(0, SeekOrigin.End);
            }
            PlayerManagement.AddPlayer(toonName, zone);
            PlayerLoggingUDPClient.Send('A', PlayerManagement.GetPlayer(toonName));
        }

        private void LoadMap()
        {
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            if (zoneAssociations.ContainsKey(zone))
            {
                aMap.MapData = MapData.FromFile(zoneAssociations[zone]);
            }
            else
            {
                MessageBox.Show(this, "Could not associate zone to a map filename because EQ is duuuuuumb. Please select the appropriate map file.", "Guild Tracker",MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (openMapFileDialog.ShowDialog() == DialogResult.OK)
                {
                    zoneAssociations[zone] = ".\\maps\\" + openMapFileDialog.SafeFileName;
                    aMap.MapData = MapData.FromFile(zoneAssociations[zone]);
                    string json = new JavaScriptSerializer().Serialize(zoneAssociations);
                    FileStream fs = new FileStream(".\\maps\\zones.json", FileMode.OpenOrCreate, FileAccess.Write);
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.Write(json);
                    }
                    fs.Close();
                }
            }
        }

        private void P99LogMonitor_OnNewLineCaptured(string text)
        {
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];

            string line;
            string[] blockDelim = { "\n\0" };
            string[] splitDelim = { "] " };
            string newZone = "You have entered ";
            string location = "Your Location is ";

            string[] tempLocation;
            foreach (string split in text.Split(blockDelim, StringSplitOptions.None))
            {
                line = split.Split(splitDelim, StringSplitOptions.None)[1];
                if (line.StartsWith(newZone))
                {
                    zone = line.Remove(0, newZone.Length);
                    zone = zone.TrimEnd('.');
                    PlayerManagement.GetPlayer(toonName).Zone = zone;
                    //  Load map using zone
                    Invoke(new MethodInvoker(delegate () { LoadMap(); }));
                }
                else if (line.StartsWith(location))
                {
                    if (toonName == null)
                        return;
                    tempLocation = line.Remove(0, location.Length).Split(',');
                    PlayerManagement.GetPlayer(toonName).SetLocation(double.Parse(tempLocation[1]), double.Parse(tempLocation[0]));
                    PlayerLoggingUDPClient.Send('L', PlayerManagement.GetPlayer(toonName));
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingDlg = new SettingsForm();
            settingDlg.ShowDialog();

            P99LogMonitor.StopMonitering();
            logMonitorStatus.Text = "Moniter Status: Watching " + Properties.Settings.Default.LogFolder + ".";
            P99LogMonitor.StartMoniteringAtLocation(Properties.Settings.Default.LogFolder);
        }

        private void AMap_OnDraw(Graphics g)
        {
            //  Draw players.
            Map aMap = (Map)mapTabs.TabPages["youTab"].Controls["zoneMap"];
            float X, Y;
            foreach (PlayerManagement.Player aPlayer in PlayerManagement.GetPlayers())
            {
                if (PlayerManagement.GetPlayer(aPlayer.Name).Location != null)
                {
                    X = aMap.ConvertCoordXToPanel((float)PlayerManagement.GetPlayer(aPlayer.Name).Location.X + 8);
                    Y = aMap.ConvertCoordYToPanel((float)PlayerManagement.GetPlayer(aPlayer.Name).Location.Y + 8);

                    if (aPlayer.Zone == zone)
                    {
                        g.FillEllipse(PlayerManagement.GetBrush(aPlayer.Name),
                                  X,
                                  Y,
                                  2,
                                  2);

                        g.DrawString(aPlayer.Name, font, PlayerManagement.GetBrush(aPlayer.Name), X, Y + 1);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void shareLocationBox_Click(object sender, EventArgs e)
        {
            if (!shareLocationBox.Checked)
            {
                //  Connect to server
                string[] hostandport = connectionInfo.Text.Split(':');

                try
                {
                    PlayerLoggingUDPClient.StartClient(hostandport[0], int.Parse(hostandport[1]));
                    shareLocationBox.Checked = true;
                    connectionStatus.Text = "Connection Status: Connected";

                    if (toonName != null)
                    {
                        if (PlayerManagement.GetPlayer(toonName) != null)
                        {
                            PlayerLoggingUDPClient.Send('A', PlayerManagement.GetPlayer(toonName));
                        }
                    }
                }
                catch (Exception)
                {
                    shareLocationBox.Checked = false;
                    connectionStatus.Text = "Connection Status: Connection Refused.";
                }
            }
            else
            {
                if (toonName != null)
                {
                    if (PlayerManagement.GetPlayer(toonName) != null)
                    {
                        PlayerLoggingUDPClient.Send('R', PlayerManagement.GetPlayer(toonName));
                    }
                }
                PlayerLoggingUDPClient.StopClient();
                shareLocationBox.Checked = false;
                connectionStatus.Text = "Connection Status: Disconnected.";
            }
        }
    }
}

