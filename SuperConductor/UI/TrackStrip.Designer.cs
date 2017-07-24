namespace SuperConductor.UI
{
    partial class TrackStrip
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblInChannel = new System.Windows.Forms.Label();
            this.lblOutPort = new System.Windows.Forms.Label();
            this.lblOutChannel = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblInPort = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblMute = new System.Windows.Forms.Label();
            this.lblSolo = new System.Windows.Forms.Label();
            this.lblPatch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Snow;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Location = new System.Drawing.Point(26, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(192, 35);
            this.lblName.TabIndex = 1;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // lblInChannel
            // 
            this.lblInChannel.BackColor = System.Drawing.Color.Snow;
            this.lblInChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInChannel.Location = new System.Drawing.Point(373, 0);
            this.lblInChannel.Name = "lblInChannel";
            this.lblInChannel.Size = new System.Drawing.Size(56, 35);
            this.lblInChannel.TabIndex = 6;
            this.lblInChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInChannel.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // lblOutPort
            // 
            this.lblOutPort.BackColor = System.Drawing.Color.Snow;
            this.lblOutPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutPort.Location = new System.Drawing.Point(428, 0);
            this.lblOutPort.Name = "lblOutPort";
            this.lblOutPort.Size = new System.Drawing.Size(56, 35);
            this.lblOutPort.TabIndex = 7;
            this.lblOutPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOutPort.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // lblOutChannel
            // 
            this.lblOutChannel.BackColor = System.Drawing.Color.Snow;
            this.lblOutChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutChannel.Location = new System.Drawing.Point(483, 0);
            this.lblOutChannel.Name = "lblOutChannel";
            this.lblOutChannel.Size = new System.Drawing.Size(56, 35);
            this.lblOutChannel.TabIndex = 8;
            this.lblOutChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOutChannel.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // lblNumber
            // 
            this.lblNumber.BackColor = System.Drawing.Color.Snow;
            this.lblNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumber.Location = new System.Drawing.Point(0, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(27, 35);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "#";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVolume
            // 
            this.lblVolume.BackColor = System.Drawing.Color.Snow;
            this.lblVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVolume.Location = new System.Drawing.Point(665, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(35, 35);
            this.lblVolume.TabIndex = 10;
            this.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVolume.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // lblInPort
            // 
            this.lblInPort.BackColor = System.Drawing.Color.Snow;
            this.lblInPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInPort.Location = new System.Drawing.Point(318, 0);
            this.lblInPort.Name = "lblInPort";
            this.lblInPort.Size = new System.Drawing.Size(56, 35);
            this.lblInPort.TabIndex = 5;
            this.lblInPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInPort.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.Snow;
            this.lblRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecord.ForeColor = System.Drawing.Color.Red;
            this.lblRecord.Location = new System.Drawing.Point(284, 0);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(35, 35);
            this.lblRecord.TabIndex = 4;
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecord.Click += new System.EventHandler(this.lblRecord_Click);
            // 
            // lblMute
            // 
            this.lblMute.BackColor = System.Drawing.Color.Snow;
            this.lblMute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMute.Location = new System.Drawing.Point(250, 0);
            this.lblMute.Name = "lblMute";
            this.lblMute.Size = new System.Drawing.Size(35, 35);
            this.lblMute.TabIndex = 3;
            this.lblMute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMute.Click += new System.EventHandler(this.lblMute_Click);
            // 
            // lblSolo
            // 
            this.lblSolo.BackColor = System.Drawing.Color.Snow;
            this.lblSolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSolo.Location = new System.Drawing.Point(216, 0);
            this.lblSolo.Name = "lblSolo";
            this.lblSolo.Size = new System.Drawing.Size(35, 35);
            this.lblSolo.TabIndex = 2;
            this.lblSolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSolo.Click += new System.EventHandler(this.lblSolo_Click);
            // 
            // lblPatch
            // 
            this.lblPatch.BackColor = System.Drawing.Color.Snow;
            this.lblPatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatch.Location = new System.Drawing.Point(538, 0);
            this.lblPatch.Name = "lblPatch";
            this.lblPatch.Size = new System.Drawing.Size(128, 35);
            this.lblPatch.TabIndex = 9;
            this.lblPatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatch.DoubleClick += new System.EventHandler(this.showTrackSettingsDialog);
            // 
            // TrackStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblInChannel);
            this.Controls.Add(this.lblOutPort);
            this.Controls.Add(this.lblOutChannel);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblInPort);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lblMute);
            this.Controls.Add(this.lblSolo);
            this.Controls.Add(this.lblPatch);
            this.DoubleBuffered = true;
            this.Name = "TrackStrip";
            this.Size = new System.Drawing.Size(700, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInChannel;
        private System.Windows.Forms.Label lblOutPort;
        private System.Windows.Forms.Label lblOutChannel;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label lblInPort;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblMute;
        private System.Windows.Forms.Label lblSolo;
        private System.Windows.Forms.Label lblPatch;

    }
}
