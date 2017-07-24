namespace SuperConductor.UI
{
    partial class TrackView
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
            this.pnlHeader = new System.Windows.Forms.Panel();
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
            this.vsbTrackPos = new System.Windows.Forms.VScrollBar();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.lblName);
            this.pnlHeader.Controls.Add(this.lblInChannel);
            this.pnlHeader.Controls.Add(this.lblOutPort);
            this.pnlHeader.Controls.Add(this.lblOutChannel);
            this.pnlHeader.Controls.Add(this.lblNumber);
            this.pnlHeader.Controls.Add(this.lblVolume);
            this.pnlHeader.Controls.Add(this.lblInPort);
            this.pnlHeader.Controls.Add(this.lblRecord);
            this.pnlHeader.Controls.Add(this.lblMute);
            this.pnlHeader.Controls.Add(this.lblSolo);
            this.pnlHeader.Controls.Add(this.lblPatch);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(720, 40);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Location = new System.Drawing.Point(26, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(192, 40);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInChannel
            // 
            this.lblInChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInChannel.Location = new System.Drawing.Point(373, 0);
            this.lblInChannel.Name = "lblInChannel";
            this.lblInChannel.Size = new System.Drawing.Size(56, 40);
            this.lblInChannel.TabIndex = 9;
            this.lblInChannel.Text = "In Channel";
            this.lblInChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutPort
            // 
            this.lblOutPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutPort.Location = new System.Drawing.Point(428, 0);
            this.lblOutPort.Name = "lblOutPort";
            this.lblOutPort.Size = new System.Drawing.Size(56, 40);
            this.lblOutPort.TabIndex = 8;
            this.lblOutPort.Text = "Out Port";
            this.lblOutPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutChannel
            // 
            this.lblOutChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutChannel.Location = new System.Drawing.Point(483, 0);
            this.lblOutChannel.Name = "lblOutChannel";
            this.lblOutChannel.Size = new System.Drawing.Size(56, 40);
            this.lblOutChannel.TabIndex = 7;
            this.lblOutChannel.Text = "Out Channel";
            this.lblOutChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber
            // 
            this.lblNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumber.Location = new System.Drawing.Point(0, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(27, 40);
            this.lblNumber.TabIndex = 6;
            this.lblNumber.Text = "#";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVolume
            // 
            this.lblVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVolume.Location = new System.Drawing.Point(665, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(35, 40);
            this.lblVolume.TabIndex = 5;
            this.lblVolume.Text = "Vol";
            this.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInPort
            // 
            this.lblInPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInPort.Location = new System.Drawing.Point(318, 0);
            this.lblInPort.Name = "lblInPort";
            this.lblInPort.Size = new System.Drawing.Size(56, 40);
            this.lblInPort.TabIndex = 4;
            this.lblInPort.Text = "In Port";
            this.lblInPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecord
            // 
            this.lblRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecord.Location = new System.Drawing.Point(284, 0);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(35, 40);
            this.lblRecord.TabIndex = 3;
            this.lblRecord.Text = "Rec";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMute
            // 
            this.lblMute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMute.Location = new System.Drawing.Point(250, 0);
            this.lblMute.Name = "lblMute";
            this.lblMute.Size = new System.Drawing.Size(35, 40);
            this.lblMute.TabIndex = 2;
            this.lblMute.Text = "Mute";
            this.lblMute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSolo
            // 
            this.lblSolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSolo.Location = new System.Drawing.Point(216, 0);
            this.lblSolo.Name = "lblSolo";
            this.lblSolo.Size = new System.Drawing.Size(35, 40);
            this.lblSolo.TabIndex = 1;
            this.lblSolo.Text = "Solo";
            this.lblSolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatch
            // 
            this.lblPatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatch.Location = new System.Drawing.Point(538, 0);
            this.lblPatch.Name = "lblPatch";
            this.lblPatch.Size = new System.Drawing.Size(128, 40);
            this.lblPatch.TabIndex = 0;
            this.lblPatch.Text = "Patch";
            this.lblPatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vsbTrackPos
            // 
            this.vsbTrackPos.Location = new System.Drawing.Point(700, 41);
            this.vsbTrackPos.Maximum = 255;
            this.vsbTrackPos.Name = "vsbTrackPos";
            this.vsbTrackPos.Size = new System.Drawing.Size(20, 357);
            this.vsbTrackPos.TabIndex = 1;
            this.vsbTrackPos.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbTrackPos_Scroll);
            // 
            // TrackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.vsbTrackPos);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Name = "TrackView";
            this.Size = new System.Drawing.Size(720, 400);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
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
        private System.Windows.Forms.VScrollBar vsbTrackPos;

    }
}
