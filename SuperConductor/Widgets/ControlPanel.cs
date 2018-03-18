/* ----------------------------------------------------------------------------
SuperConductor : a midi sequencer
Copyright (C) 1997-2018  George E Greaney

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using Transonic.MIDI;

namespace SuperConductor.Widgets
{
    public partial class ControlPanel : UserControl
    {
        public SuperWindow superWindow;
        public Sequence curSequence;

        bool isPlaying;

        int timeSigNumer;
        int timeSigDenom;
        int keySig;
        int tempoRate;
        int bmpVal;

        public ControlPanel()
        {
            InitializeComponent();
            isPlaying = false;
            timeSigNumer = 4;
            timeSigDenom = 4;
            keySig = 0;
            tempoRate = 500000;         //default - 120 bpm, 4/4, key of C
        }

        public void setSequence(Sequence seq) 
        {
            curSequence = seq;
            hsbSeqPos.Maximum = seq.length;
        }

        public void setPlaying(bool on)
        {
            isPlaying = on;
        }

        public void setTempo(int rate)
        {
            tempoRate = rate;
            bmpVal = (int)(60000000.0 / tempoRate);
            Invalidate();
        }

        public void setMeter(int numer, int denom, int keysig)
        {
            timeSigNumer = numer;
            timeSigDenom = denom;
            keySig = keysig;
            Invalidate();
        }

//-----------------------------------------------------------------------------

        private void btnStep_Click(object sender, EventArgs e)
        {
            String msg = "the step recording feature is still in the works!\nHave patience, O Pilgrim!";
            MessageBox.Show(msg, "Under Construction");
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            String msg = "the looping feature is still in the works!\nHave patience, O Pilgrim!";
            MessageBox.Show(msg, "Under Construction");
        }

        private void btnPanic_Click(object sender, EventArgs e)
        {
            superWindow.panic();
        }

        private void hsbSeqPos_Scroll(object sender, ScrollEventArgs e)
        {
            if (!isPlaying)
            {
                superWindow.setSequencePos(hsbSeqPos.Value);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                superWindow.playSequence();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            superWindow.stopSequence();
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            String msg = "the recording feature is still in the works!\nHave patience, O Pilgrim!";
            MessageBox.Show(msg, "Under Construction");
        }

//-----------------------------------------------------------------------------

        public void timerTick(int tick, int msTime, int measure, decimal beat)
        {
            int msVal = msTime % 1000;
            int secPos = msTime / 1000;
            int secVal = secPos % 60;
            int minPos = secPos / 60;
            int minVal = minPos % 60;
            int hrVal = minPos / 60;
            lblPosCounter.Text = hrVal.ToString("D2") + ":" + minVal.ToString("D2") + ":" +
                secVal.ToString("D2") + "." + msVal.ToString("D3");

            int wholebeat = ((int)beat);
            int partbeat = (int)((beat - wholebeat) * 1000);
            lblBeatCounter.Text = (measure + 1).ToString("D3") + ":" + wholebeat.ToString("D2") + ":" + partbeat.ToString("D3");

            hsbSeqPos.Value = tick;

            lblPosCounter.Invalidate();
            hsbSeqPos.Invalidate(); 
        }

//- painting ------------------------------------------------------------------

        public const float STAFFX = 840;
        public const float STAFFY = 10;
        public const float STAFFLEN = 75;
        public const float STAFFSPACING = 8;

        float[] sharpYPos = { 0.0f, 1.5f, -0.5f, 1.0f, 2.5f, 0.5f };
        float[] flatYPos = { 2.0f, 0.5f, 2.5f, 1.0f, 3.0f, 1.5f };

        public void drawStaff(Graphics g)
        {
            float right = STAFFX + STAFFLEN;
            float ypos = STAFFY;
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(Pens.LightGray, STAFFX, ypos, right, ypos);
                ypos += STAFFSPACING;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            drawStaff(g);

            Font bmpfont = new Font("Arial", 11);
            Font meterfont = new Font("Arial", 14);

            //bmp string
            g.DrawString(bmpVal.ToString("D3") + " BPM", bmpfont, Brushes.White, 770, STAFFY + 4);
            

            //time sig
            g.DrawString(timeSigNumer.ToString(), meterfont, Brushes.White, STAFFX, STAFFY - 2);
            g.DrawString(timeSigDenom.ToString(), meterfont, Brushes.White, STAFFX, STAFFY + (STAFFSPACING * 2) - 2);

            //key sig
            float y = STAFFY - 12;
            float x = STAFFX + 16;
            if (keySig > 0)
            {
                for (int i = 0; i < keySig; i++)
                {
                    g.DrawString("\u266f", meterfont, Brushes.White, x, y + (sharpYPos[i] * STAFFSPACING));
                    x += STAFFSPACING;
                }
            }
            else
            {
                int count = -keySig;
                for (int i = 0; i < count; i++)
                {
                    g.DrawString("\u266d", meterfont, Brushes.White, x, y + (flatYPos[i] * STAFFSPACING));
                    x += STAFFSPACING;
                }
            }

            bmpfont.Dispose();
            meterfont.Dispose();
        }


    }
}
