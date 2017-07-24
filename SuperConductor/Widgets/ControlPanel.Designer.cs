namespace SuperConductor.Widgets
{
    partial class ControlPanel
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRec = new System.Windows.Forms.Button();
            this.hsbSeqPos = new System.Windows.Forms.HScrollBar();
            this.lblPosCounter = new System.Windows.Forms.Label();
            this.btnPanic = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(399, 11);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(445, 11);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(40, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRec
            // 
            this.btnRec.ForeColor = System.Drawing.Color.Red;
            this.btnRec.Location = new System.Drawing.Point(491, 11);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(40, 23);
            this.btnRec.TabIndex = 3;
            this.btnRec.Text = "Rec";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // hsbSeqPos
            // 
            this.hsbSeqPos.Location = new System.Drawing.Point(198, 11);
            this.hsbSeqPos.Name = "hsbSeqPos";
            this.hsbSeqPos.Size = new System.Drawing.Size(166, 23);
            this.hsbSeqPos.TabIndex = 4;
            this.hsbSeqPos.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbSeqPos_Scroll);
            // 
            // lblPosCounter
            // 
            this.lblPosCounter.BackColor = System.Drawing.Color.Black;
            this.lblPosCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosCounter.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblPosCounter.Location = new System.Drawing.Point(566, 11);
            this.lblPosCounter.Name = "lblPosCounter";
            this.lblPosCounter.Size = new System.Drawing.Size(134, 23);
            this.lblPosCounter.TabIndex = 5;
            this.lblPosCounter.Text = "00:00:00:000";
            this.lblPosCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPanic
            // 
            this.btnPanic.Location = new System.Drawing.Point(118, 11);
            this.btnPanic.Name = "btnPanic";
            this.btnPanic.Size = new System.Drawing.Size(43, 23);
            this.btnPanic.TabIndex = 12;
            this.btnPanic.Text = "Panic";
            this.btnPanic.UseVisualStyleBackColor = true;
            this.btnPanic.Click += new System.EventHandler(this.btnPanic_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(20, 11);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(43, 23);
            this.btnStep.TabIndex = 13;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(69, 11);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(43, 23);
            this.btnLoop.TabIndex = 15;
            this.btnLoop.Text = "Loop";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnPanic);
            this.Controls.Add(this.lblPosCounter);
            this.Controls.Add(this.hsbSeqPos);
            this.Controls.Add(this.btnRec);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(720, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRec;
        private System.Windows.Forms.HScrollBar hsbSeqPos;
        private System.Windows.Forms.Label lblPosCounter;
        private System.Windows.Forms.Button btnPanic;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnLoop;
    }
}
