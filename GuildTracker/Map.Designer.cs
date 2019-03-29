using System.Windows.Forms;

namespace GuildTracker
{
    partial class Map
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapPanel = new System.Windows.Forms.Panel();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.ZoomFactor = new System.Windows.Forms.TextBox();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.lblZone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.coordinates = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.focusPointLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelPointLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelWidthlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelHeightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(682, 331);
            this.mapPanel.TabIndex = 0;
            this.mapPanel.Click += new System.EventHandler(this.mapPanel_Click);
            this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanel_Paint);
            this.mapPanel.DoubleClick += new System.EventHandler(this.mapPanel_DoubleClick);
            this.mapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseDown);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
            this.mapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseUp);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomOut.Location = new System.Drawing.Point(588, 332);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(22, 30);
            this.ZoomOut.TabIndex = 1;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomFactor
            // 
            this.ZoomFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomFactor.Location = new System.Drawing.Point(616, 338);
            this.ZoomFactor.Name = "ZoomFactor";
            this.ZoomFactor.ReadOnly = true;
            this.ZoomFactor.Size = new System.Drawing.Size(38, 20);
            this.ZoomFactor.TabIndex = 3;
            // 
            // ZoomIn
            // 
            this.ZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomIn.Location = new System.Drawing.Point(660, 332);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(22, 30);
            this.ZoomIn.TabIndex = 4;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // lblZone
            // 
            this.lblZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZone.Location = new System.Drawing.Point(3, 341);
            this.lblZone.Name = "lblZone";
            this.lblZone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblZone.Size = new System.Drawing.Size(240, 13);
            this.lblZone.TabIndex = 5;
            this.lblZone.Text = "Zone:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zoom:";
            // 
            // coordinates
            // 
            this.coordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coordinates.AutoSize = true;
            this.coordinates.Location = new System.Drawing.Point(259, 341);
            this.coordinates.Name = "coordinates";
            this.coordinates.Size = new System.Drawing.Size(66, 13);
            this.coordinates.TabIndex = 7;
            this.coordinates.Text = "Coordinates:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.focusPointLabel,
            this.panelPointLabel,
            this.panelWidthlabel,
            this.panelHeightLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // focusPointLabel
            // 
            this.focusPointLabel.Name = "focusPointLabel";
            this.focusPointLabel.Size = new System.Drawing.Size(72, 17);
            this.focusPointLabel.Text = "Focus Point:";
            // 
            // panelPointLabel
            // 
            this.panelPointLabel.Name = "panelPointLabel";
            this.panelPointLabel.Size = new System.Drawing.Size(70, 17);
            this.panelPointLabel.Text = "Panel Point:";
            // 
            // panelWidthlabel
            // 
            this.panelWidthlabel.Name = "panelWidthlabel";
            this.panelWidthlabel.Size = new System.Drawing.Size(74, 17);
            this.panelWidthlabel.Text = "Panel Width:";
            // 
            // panelHeightLabel
            // 
            this.panelHeightLabel.Name = "panelHeightLabel";
            this.panelHeightLabel.Size = new System.Drawing.Size(78, 17);
            this.panelHeightLabel.Text = "Panel Height:";
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.ZoomFactor);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.mapPanel);
            this.Name = "Map";
            this.Size = new System.Drawing.Size(686, 386);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel mapPanel;
        private Button ZoomOut;
        private TextBox ZoomFactor;
        private Button ZoomIn;
        private Label lblZone;
        private Label label2;
        private Label coordinates;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel focusPointLabel;
        private ToolStripStatusLabel panelPointLabel;
        private ToolStripStatusLabel panelWidthlabel;
        private ToolStripStatusLabel panelHeightLabel;
    }
}
