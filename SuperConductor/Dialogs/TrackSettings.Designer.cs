namespace SuperConductor.Dialogs
{
    partial class TrackSettings
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbxInPort = new System.Windows.Forms.ComboBox();
            this.nudInChannel = new System.Windows.Forms.NumericUpDown();
            this.cbxOutPort = new System.Windows.Forms.ComboBox();
            this.nudOutChannel = new System.Windows.Forms.NumericUpDown();
            this.cbxPatch = new System.Windows.Forms.ComboBox();
            this.hsbVolume = new System.Windows.Forms.HScrollBar();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInPort = new System.Windows.Forms.Label();
            this.lblInChannel = new System.Windows.Forms.Label();
            this.lblOutPort = new System.Windows.Forms.Label();
            this.lblOutChannel = new System.Windows.Forms.Label();
            this.lblPatch = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudInChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 20);
            this.txtName.TabIndex = 0;            
            // 
            // cbxInPort
            // 
            this.cbxInPort.FormattingEnabled = true;
            this.cbxInPort.Location = new System.Drawing.Point(15, 83);
            this.cbxInPort.Name = "cbxInPort";
            this.cbxInPort.Size = new System.Drawing.Size(175, 21);
            this.cbxInPort.TabIndex = 1;            
            // 
            // nudInChannel
            // 
            this.nudInChannel.Location = new System.Drawing.Point(202, 84);
            this.nudInChannel.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudInChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInChannel.Name = "nudInChannel";
            this.nudInChannel.Size = new System.Drawing.Size(63, 20);
            this.nudInChannel.TabIndex = 2;
            this.nudInChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});            
            // 
            // cbxOutPort
            // 
            this.cbxOutPort.FormattingEnabled = true;
            this.cbxOutPort.Location = new System.Drawing.Point(15, 136);
            this.cbxOutPort.Name = "cbxOutPort";
            this.cbxOutPort.Size = new System.Drawing.Size(175, 21);
            this.cbxOutPort.TabIndex = 3;            
            // 
            // nudOutChannel
            // 
            this.nudOutChannel.Location = new System.Drawing.Point(202, 137);
            this.nudOutChannel.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudOutChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOutChannel.Name = "nudOutChannel";
            this.nudOutChannel.Size = new System.Drawing.Size(63, 20);
            this.nudOutChannel.TabIndex = 4;
            this.nudOutChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});            
            // 
            // cbxPatch
            // 
            this.cbxPatch.FormattingEnabled = true;
            this.cbxPatch.Location = new System.Drawing.Point(15, 190);
            this.cbxPatch.Name = "cbxPatch";
            this.cbxPatch.Size = new System.Drawing.Size(250, 21);
            this.cbxPatch.TabIndex = 5;            
            // 
            // hsbVolume
            // 
            this.hsbVolume.Location = new System.Drawing.Point(15, 242);
            this.hsbVolume.Maximum = 127;
            this.hsbVolume.Name = "hsbVolume";
            this.hsbVolume.Size = new System.Drawing.Size(250, 20);
            this.hsbVolume.TabIndex = 6;            
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Track name";
            // 
            // lblInPort
            // 
            this.lblInPort.AutoSize = true;
            this.lblInPort.Location = new System.Drawing.Point(15, 68);
            this.lblInPort.Name = "lblInPort";
            this.lblInPort.Size = new System.Drawing.Size(37, 13);
            this.lblInPort.TabIndex = 8;
            this.lblInPort.Text = "In port";
            // 
            // lblInChannel
            // 
            this.lblInChannel.AutoSize = true;
            this.lblInChannel.Location = new System.Drawing.Point(202, 69);
            this.lblInChannel.Name = "lblInChannel";
            this.lblInChannel.Size = new System.Drawing.Size(57, 13);
            this.lblInChannel.TabIndex = 9;
            this.lblInChannel.Text = "In channel";
            // 
            // lblOutPort
            // 
            this.lblOutPort.AutoSize = true;
            this.lblOutPort.Location = new System.Drawing.Point(15, 121);
            this.lblOutPort.Name = "lblOutPort";
            this.lblOutPort.Size = new System.Drawing.Size(45, 13);
            this.lblOutPort.TabIndex = 10;
            this.lblOutPort.Text = "Out port";
            // 
            // lblOutChannel
            // 
            this.lblOutChannel.AutoSize = true;
            this.lblOutChannel.Location = new System.Drawing.Point(202, 122);
            this.lblOutChannel.Name = "lblOutChannel";
            this.lblOutChannel.Size = new System.Drawing.Size(65, 13);
            this.lblOutChannel.TabIndex = 11;
            this.lblOutChannel.Text = "Out channel";
            // 
            // lblPatch
            // 
            this.lblPatch.AutoSize = true;
            this.lblPatch.Location = new System.Drawing.Point(15, 174);
            this.lblPatch.Name = "lblPatch";
            this.lblPatch.Size = new System.Drawing.Size(35, 13);
            this.lblPatch.TabIndex = 12;
            this.lblPatch.Text = "Patch";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(15, 226);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 13;
            this.lblVolume.Text = "Volume";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(190, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;            
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TrackSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 334);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblPatch);
            this.Controls.Add(this.lblOutChannel);
            this.Controls.Add(this.lblOutPort);
            this.Controls.Add(this.lblInChannel);
            this.Controls.Add(this.lblInPort);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.hsbVolume);
            this.Controls.Add(this.cbxPatch);
            this.Controls.Add(this.nudOutChannel);
            this.Controls.Add(this.cbxOutPort);
            this.Controls.Add(this.nudInChannel);
            this.Controls.Add(this.cbxInPort);
            this.Controls.Add(this.txtName);
            this.Name = "TrackSettings";
            this.Text = "TrackSettings";
            ((System.ComponentModel.ISupportInitialize)(this.nudInChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutChannel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbxInPort;
        private System.Windows.Forms.NumericUpDown nudInChannel;
        private System.Windows.Forms.ComboBox cbxOutPort;
        private System.Windows.Forms.NumericUpDown nudOutChannel;
        private System.Windows.Forms.ComboBox cbxPatch;
        private System.Windows.Forms.HScrollBar hsbVolume;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInPort;
        private System.Windows.Forms.Label lblInChannel;
        private System.Windows.Forms.Label lblOutPort;
        private System.Windows.Forms.Label lblOutChannel;
        private System.Windows.Forms.Label lblPatch;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}