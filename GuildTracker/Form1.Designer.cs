namespace GuildTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.youTab = new System.Windows.Forms.TabPage();
            this.mapTabs = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.logMonitorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shareLocationBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridPlayers = new System.Windows.Forms.DataGridView();
            this.ToonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.openMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.connectionInfo = new System.Windows.Forms.TextBox();
            this.zoneMap = new GuildTracker.Map();
            this.youTab.SuspendLayout();
            this.mapTabs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // youTab
            // 
            this.youTab.Controls.Add(this.zoneMap);
            this.youTab.Location = new System.Drawing.Point(4, 22);
            this.youTab.Name = "youTab";
            this.youTab.Padding = new System.Windows.Forms.Padding(3);
            this.youTab.Size = new System.Drawing.Size(813, 630);
            this.youTab.TabIndex = 0;
            this.youTab.Text = "You";
            this.youTab.UseVisualStyleBackColor = true;
            // 
            // mapTabs
            // 
            this.mapTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapTabs.Controls.Add(this.youTab);
            this.mapTabs.Location = new System.Drawing.Point(13, 37);
            this.mapTabs.Name = "mapTabs";
            this.mapTabs.SelectedIndex = 0;
            this.mapTabs.Size = new System.Drawing.Size(821, 656);
            this.mapTabs.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Players:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logMonitorStatus,
            this.connectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 696);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1058, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // logMonitorStatus
            // 
            this.logMonitorStatus.Name = "logMonitorStatus";
            this.logMonitorStatus.Size = new System.Drawing.Size(88, 17);
            this.logMonitorStatus.Text = "Monitor Status:";
            // 
            // connectionStatus
            // 
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(107, 17);
            this.connectionStatus.Text = "Connection Status:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.connectionInfo);
            this.groupBox1.Controls.Add(this.shareLocationBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataGridPlayers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(846, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 627);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Info";
            // 
            // shareLocationBox
            // 
            this.shareLocationBox.AutoCheck = false;
            this.shareLocationBox.AutoSize = true;
            this.shareLocationBox.Location = new System.Drawing.Point(12, 60);
            this.shareLocationBox.Name = "shareLocationBox";
            this.shareLocationBox.Size = new System.Drawing.Size(98, 17);
            this.shareLocationBox.TabIndex = 13;
            this.shareLocationBox.Text = "Share Location";
            this.shareLocationBox.UseVisualStyleBackColor = true;
            this.shareLocationBox.Click += new System.EventHandler(this.shareLocationBox_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 55);
            this.label3.TabIndex = 12;
            this.label3.Text = "Perform a /who in game to include people not using the location service.  Select " +
    "a character to put \"/tar <character>\" in your clip board.";
            // 
            // dataGridPlayers
            // 
            this.dataGridPlayers.AllowUserToAddRows = false;
            this.dataGridPlayers.AllowUserToDeleteRows = false;
            this.dataGridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToonName,
            this.Class});
            this.dataGridPlayers.Location = new System.Drawing.Point(6, 165);
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.ReadOnly = true;
            this.dataGridPlayers.Size = new System.Drawing.Size(188, 456);
            this.dataGridPlayers.TabIndex = 11;
            // 
            // ToonName
            // 
            this.ToonName.HeaderText = "Name";
            this.ToonName.Name = "ToonName";
            this.ToonName.ReadOnly = true;
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Server: (<address>:<port>)";
            // 
            // openMapFileDialog
            // 
            this.openMapFileDialog.Filter = "EQ Maps|*.map";
            this.openMapFileDialog.InitialDirectory = ".";
            // 
            // connectionInfo
            // 
            this.connectionInfo.Location = new System.Drawing.Point(12, 34);
            this.connectionInfo.Name = "connectionInfo";
            this.connectionInfo.Size = new System.Drawing.Size(182, 20);
            this.connectionInfo.TabIndex = 14;
            // 
            // zoneMap
            // 
            this.zoneMap.BackColor = System.Drawing.SystemColors.Control;
            this.zoneMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoneMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneMap.Location = new System.Drawing.Point(3, 3);
            this.zoneMap.MapData = null;
            this.zoneMap.Name = "zoneMap";
            this.zoneMap.Size = new System.Drawing.Size(807, 624);
            this.zoneMap.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 718);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mapTabs);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Guild Tracker";
            this.youTab.ResumeLayout(false);
            this.mapTabs.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage youTab;
        private Map zoneMap;
        private System.Windows.Forms.TabControl mapTabs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel logMonitorStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridPlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.OpenFileDialog openMapFileDialog;
        private System.Windows.Forms.CheckBox shareLocationBox;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        private System.Windows.Forms.TextBox connectionInfo;
    }
}

