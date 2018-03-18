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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using Transonic.MIDI;

namespace SuperConductor.UI.ViewTrack
{
    class TrackDataPanel : UserControl
    {
        public TrackDataPane trackData;     //parent widget
        public Sequence seq;

        public DataStrip[] strips;

        public int dataHeight;            
        public int vertOffset;

        public TrackDataPanel(TrackDataPane _trackData)
        {
            trackData = _trackData;

            //data strips
            strips = new DataStrip[TrackListPane.TRACKCOUNT];
            for (int i = 0; i < TrackListPane.TRACKCOUNT; i++)
            {
                strips[i] = null;                
            }

            this.BackColor = Color.Salmon;
            this.DoubleBuffered = true;
            vertOffset = 0;
        }

//- track management ----------------------------------------------------------

        public void setSequence(Sequence _seq)
        {
            seq = _seq;

            //create data strips for track in seq
            dataHeight = 0;
            for (int trackNum = 0; trackNum < seq.tracks.Count; trackNum++)
            {
                Track track = seq.tracks[trackNum];
                DataStrip strip = new DataStrip(trackData, track);          //create data strip from track
                strips[trackNum] = strip;
                strip.width = trackData.measureOffsets[track.measures-1] + trackData.measureWidths[track.measures-1];
                strip.setPos(dataHeight);
                dataHeight += TrackStrip.STRIPHEIGHT;
            }            
        }

//- display -------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(-trackData.horzOffset, -vertOffset);

            //draw measure lines for track data
            float xpos = 0;
            int measnum = 1;
            if (trackData.measureWidths != null)
            {
                for (int i = 0; i < trackData.measureWidths.Length; i++)
                {
                    xpos += trackData.measureWidths[i];
                    g.DrawLine(Pens.Green, xpos, 0, xpos, trackData.trackList.stripPanel.listHeight);
                    measnum++;
                }
            }

            //draw background measure lines
            while (xpos < this.Width)
            {
                xpos += TrackDataPane.BEATWIDTH * 4;
                g.DrawLine(Pens.Green, xpos, 0, xpos, this.Height);
                measnum++;
            }

            //draw track strips
            for (int i = 0; i < TrackListPane.TRACKCOUNT; i++)
            {
                if (strips[i] != null)
                {
                    strips[i].paint(g);
                }
            }

            //draw current pos marker
            g.DrawLine(Pens.Black, trackData.curDataPos, 0, trackData.curDataPos, trackData.trackList.stripPanel.listHeight);
        }

    }
}
