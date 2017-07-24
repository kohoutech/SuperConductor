/* ----------------------------------------------------------------------------
SuperConductor : a midi sequencer
Copyright (C) 1997-2017  George E Greaney

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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Transonic.MIDI;

namespace SuperConductor.Widgets
{
    public partial class ControlPanel : UserControl
    {
        public SuperWindow superWindow;
        public Sequence curSequence;

        bool isPlaying;

        public ControlPanel(SuperWindow _superWindow)
        {
            superWindow = _superWindow;
            InitializeComponent();
            isPlaying = false;
        }

        public void setSequence(Sequence seq) 
        {
            curSequence = seq;
            hsbSeqPos.Maximum = seq.duration;
        }

        public void setPlaying(bool on)
        {
            isPlaying = on;
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

        public void timerTick(int tick, int msTime)
        {
            int msVal = msTime % 1000;
            int secPos = msTime / 1000;
            int secVal = secPos % 60;
            int minPos = secPos / 60;
            int minVal = minPos % 60;
            int hrVal = minPos / 60;
            lblPosCounter.Text = hrVal.ToString("D2") + ":" + minVal.ToString("D2") + ":" +
                secVal.ToString("D2") + "." + msVal.ToString("D3");

            hsbSeqPos.Value = tick;

            lblPosCounter.Invalidate();
            hsbSeqPos.Invalidate(); 
        }

    }
}
