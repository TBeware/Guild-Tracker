namespace GuildTracker
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.logLocation = new System.Windows.Forms.TextBox();
            this.openFileDialogButton = new System.Windows.Forms.Button();
            this.folderFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.SettingsSaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Everquest Log Folder:";
            // 
            // logLocation
            // 
            this.logLocation.Location = new System.Drawing.Point(130, 8);
            this.logLocation.Name = "logLocation";
            this.logLocation.Size = new System.Drawing.Size(100, 20);
            this.logLocation.TabIndex = 1;
            // 
            // openFileDialogButton
            // 
            this.openFileDialogButton.Location = new System.Drawing.Point(236, 6);
            this.openFileDialogButton.Name = "openFileDialogButton";
            this.openFileDialogButton.Size = new System.Drawing.Size(29, 23);
            this.openFileDialogButton.TabIndex = 2;
            this.openFileDialogButton.Text = "...";
            this.openFileDialogButton.UseVisualStyleBackColor = true;
            this.openFileDialogButton.Click += new System.EventHandler(this.openFileDialogButton_Click);
            // 
            // folderFinder
            // 
            this.folderFinder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // SettingsSaveBtn
            // 
            this.SettingsSaveBtn.Location = new System.Drawing.Point(190, 45);
            this.SettingsSaveBtn.Name = "SettingsSaveBtn";
            this.SettingsSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SettingsSaveBtn.TabIndex = 3;
            this.SettingsSaveBtn.Text = "Save";
            this.SettingsSaveBtn.UseVisualStyleBackColor = true;
            this.SettingsSaveBtn.Click += new System.EventHandler(this.SettingsSaveBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 80);
            this.Controls.Add(this.SettingsSaveBtn);
            this.Controls.Add(this.openFileDialogButton);
            this.Controls.Add(this.logLocation);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logLocation;
        private System.Windows.Forms.Button openFileDialogButton;
        private System.Windows.Forms.FolderBrowserDialog folderFinder;
        private System.Windows.Forms.Button SettingsSaveBtn;
    }
}