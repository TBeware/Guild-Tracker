using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildTracker
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            logLocation.Text = Properties.Settings.Default.LogFolder;
        }

        private void SettingsSaveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LogFolder = folderFinder.SelectedPath;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void openFileDialogButton_Click(object sender, EventArgs e)
        {
            if (folderFinder.ShowDialog() == DialogResult.OK)
            {
                logLocation.Text = folderFinder.SelectedPath;
            }
        }
    }
}
