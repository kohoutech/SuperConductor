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

namespace SuperConductor.UI.ViewTrack
{
    public class TrackStripPanel : UserControl
    {
        public TrackListPane trackList;

        public List<TrackStrip> strips;

        public int listHeight;            
        public int vertOffset;

        public TrackStripPanel(TrackListPane _trackList)
        {
            trackList = _trackList;

            //track strips
            listHeight = 0;
            strips = new List<TrackStrip>(TrackListPane.TRACKCOUNT);
            for (int i = 0; i < TrackListPane.TRACKCOUNT; i++)
            {
                TrackStrip strip = new TrackStrip(trackList, i + 1);
                strip.setPos(listHeight);
                strips.Add(strip);
                listHeight += TrackStrip.STRIPHEIGHT;
            }

            this.DoubleBuffered = true;
            vertOffset = 0;
        }

//- display -------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(-trackList.horzOffset, -vertOffset);

            //draw track strips
            for (int i = 0; i < strips.Count; i++)
            {
                strips[i].paint(g);
            }
        }
    }
}
