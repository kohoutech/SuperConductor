namespace SuperConductor
{
    partial class SuperWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperWindow));
            this.superMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playTransportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTransportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superStatus = new System.Windows.Forms.StatusStrip();
            this.masterTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TrackSplit = new System.Windows.Forms.SplitContainer();
            this.trackList = new SuperConductor.UI.ViewTrack.TrackList();
            this.trackData = new SuperConductor.UI.ViewTrack.TrackData();
            this.controlPanel = new SuperConductor.Widgets.ControlPanel();
            this.superMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSplit)).BeginInit();
            this.TrackSplit.Panel1.SuspendLayout();
            this.TrackSplit.Panel2.SuspendLayout();
            this.TrackSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // superMenu
            // 
            this.superMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.superMenu.Location = new System.Drawing.Point(0, 0);
            this.superMenu.Name = "superMenu";
            this.superMenu.Size = new System.Drawing.Size(719, 24);
            this.superMenu.TabIndex = 4;
            this.superMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileMenuItem,
            this.openFileMenuItem,
            this.toolStripSeparator,
            this.saveFileMenuItem,
            this.saveAsFileMenuItem,
            this.toolStripSeparator1,
            this.exitFileMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFileMenuItem.Image")));
            this.newFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newFileMenuItem.Text = "&New";
            this.newFileMenuItem.Click += new System.EventHandler(this.newFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openFileMenuItem.Text = "&Open";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFileMenuItem.Image")));
            this.saveFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveFileMenuItem.Text = "&Save";
            this.saveFileMenuItem.Click += new System.EventHandler(this.saveFileMenuItem_Click);
            // 
            // saveAsFileMenuItem
            // 
            this.saveAsFileMenuItem.Name = "saveAsFileMenuItem";
            this.saveAsFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsFileMenuItem.Text = "Save &As";
            this.saveAsFileMenuItem.Click += new System.EventHandler(this.saveAsFileMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitFileMenuItem
            // 
            this.exitFileMenuItem.Name = "exitFileMenuItem";
            this.exitFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitFileMenuItem.Text = "E&xit";
            this.exitFileMenuItem.Click += new System.EventHandler(this.exitFileMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playTransportMenuItem,
            this.stopTransportMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.toolsToolStripMenuItem.Text = "&Transport";
            // 
            // playTransportMenuItem
            // 
            this.playTransportMenuItem.Name = "playTransportMenuItem";
            this.playTransportMenuItem.Size = new System.Drawing.Size(98, 22);
            this.playTransportMenuItem.Text = "&Play";
            this.playTransportMenuItem.Click += new System.EventHandler(this.playTransportMenuItem_Click);
            // 
            // stopTransportMenuItem
            // 
            this.stopTransportMenuItem.Name = "stopTransportMenuItem";
            this.stopTransportMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopTransportMenuItem.Text = "&Stop";
            this.stopTransportMenuItem.Click += new System.EventHandler(this.stopTransportMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutHelpMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutHelpMenuItem
            // 
            this.aboutHelpMenuItem.Name = "aboutHelpMenuItem";
            this.aboutHelpMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutHelpMenuItem.Text = "&About...";
            this.aboutHelpMenuItem.Click += new System.EventHandler(this.aboutHelpMenuItem_Click);
            // 
            // superStatus
            // 
            this.superStatus.Location = new System.Drawing.Point(0, 389);
            this.superStatus.Name = "superStatus";
            this.superStatus.Size = new System.Drawing.Size(719, 22);
            this.superStatus.TabIndex = 5;
            this.superStatus.Text = "statusStrip1";
            // 
            // masterTimer
            // 
            this.masterTimer.Tick += new System.EventHandler(this.masterTimer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // TrackSplit
            // 
            this.TrackSplit.BackColor = System.Drawing.Color.Crimson;
            this.TrackSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackSplit.Location = new System.Drawing.Point(0, 74);
            this.TrackSplit.Name = "TrackSplit";
            // 
            // TrackSplit.Panel1
            // 
            this.TrackSplit.Panel1.Controls.Add(this.trackList);
            this.TrackSplit.Panel1MinSize = 50;
            // 
            // TrackSplit.Panel2
            // 
            this.TrackSplit.Panel2.Controls.Add(this.trackData);
            this.TrackSplit.Size = new System.Drawing.Size(719, 315);
            this.TrackSplit.SplitterDistance = 362;
            this.TrackSplit.SplitterWidth = 6;
            this.TrackSplit.TabIndex = 7;
            this.TrackSplit.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.TrackSplit_SplitterMoved);
            // 
            // trackList
            // 
            this.trackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackList.Location = new System.Drawing.Point(0, 0);
            this.trackList.MaximumSize = new System.Drawing.Size(835, 6447);
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(362, 315);
            this.trackList.TabIndex = 0;
            // 
            // trackData
            // 
            this.trackData.BackColor = System.Drawing.Color.LightBlue;
            this.trackData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackData.Location = new System.Drawing.Point(0, 0);
            this.trackData.Name = "trackData";
            this.trackData.Size = new System.Drawing.Size(351, 315);
            this.trackData.TabIndex = 0;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Crimson;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 24);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(719, 50);
            this.controlPanel.TabIndex = 6;
            // 
            // SuperWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 411);
            this.Controls.Add(this.TrackSplit);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.superStatus);
            this.Controls.Add(this.superMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.superMenu;
            this.Name = "SuperWindow";
            this.Text = "SuperConductor";
            this.superMenu.ResumeLayout(false);
            this.superMenu.PerformLayout();
            this.TrackSplit.Panel1.ResumeLayout(false);
            this.TrackSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrackSplit)).EndInit();
            this.TrackSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Widgets.ControlPanel controlPanel1;
        private System.Windows.Forms.MenuStrip superMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playTransportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTransportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHelpMenuItem;
        private System.Windows.Forms.StatusStrip superStatus;
        private System.Windows.Forms.Timer masterTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Widgets.ControlPanel controlPanel;
        private System.Windows.Forms.SplitContainer TrackSplit;
        private UI.ViewTrack.TrackData trackData;
        private UI.ViewTrack.TrackList trackList;
    }
}

