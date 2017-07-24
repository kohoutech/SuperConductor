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

namespace SuperConductor.UI
{
    public partial class TrackView : UserControl
    {
        public SuperWindow window;
        public Sequence currentSeq;
        public List<TrackStrip> strips;

        public TrackView(SuperWindow _window, Sequence seq)
        {
            window = _window;
            currentSeq = seq;

            InitializeComponent();

            strips = new List<TrackStrip>(256);
            for (int i = 1; i <= 256; i++)
            {
                TrackStrip strip = new TrackStrip(this, i);
                strip.setTrack(currentSeq.tracks[i]);
                strips.Add(strip);
                strip.Location = new Point(0, (i - 1) * 35 + 40);
                addTrackStrip(strip);
            }
        }

        public void addTrackStrip(TrackStrip strip) 
        {
            this.Controls.Add(strip);
        }

        public void setScrollbar(int height)
        {
            vsbTrackPos.Height = height - 40;
        }

        private void vsbTrackPos_Scroll(object sender, ScrollEventArgs e)
        {
            int topPos = -(vsbTrackPos.Value * 35) + 40;
            Point stripPos = new Point(0, topPos);
            for (int i = 0; i < 256; i++)
            {
                strips[i].Location = stripPos;
                stripPos.Offset(0, 35);
            }
            Invalidate();
        }

        public void setSoloTrack(TrackStrip strip)
        {
            for (int i = 1; i < 256; i++)
            {
                if (strips[i] != strip)
                {
                    strips[i].setMuted(strip.isSoloing);
                    strips[i].setSoloing(false);
                }
            }
        }

        public void unsetSoloTrack(TrackStrip strip)
        {
            for (int i = 0; i < 256; i++)
            {
                if (strips[i] != strip)
                {
                    strips[i].setSoloing(false);
                }
            }
        }

        public void setRecordingTrack(TrackStrip strip)
        {
            for (int i = 0; i < 256; i++)
            {
                if (strips[i] != strip)
                {
                    //strips[i].setRecording(false);
                    strips[i].setSoloing(false);
                    strips[i].muteLabel.Enabled = true;
                    strips[i].soloLabel.Enabled = false;
                }
            }
        }

        public void unsetRecordingTrack(TrackStrip strip)
        {
            for (int i = 0; i < 256; i++)
            {
                if (strips[i] != strip)
                {
                    strips[i].soloLabel.Enabled = true;
                }
            }
        }
    }
}
