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
    class TrackDataPanel : UserControl
    {

        public TrackDataPane trackData;

        public DataStrip[] strips;

        public int listHeight;            
        public int vertOffset;

        public TrackDataPanel(TrackDataPane _trackData)
        {
            trackData = _trackData;

            //data strips
            listHeight = 0;
            strips = new DataStrip[TrackListPane.TRACKCOUNT];
            for (int i = 0; i < TrackListPane.TRACKCOUNT; i++)
            {
                strips[i] = null;                
            }

            this.DoubleBuffered = true;
            vertOffset = 0;
        }

//- display -------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(-trackData.horzOffset, -vertOffset);

            //draw track strips
            for (int i = 0; i < TrackListPane.TRACKCOUNT; i++)
            {
                if (strips[i] != null) {
                    strips[i].paint(g);
                }
            }
        }

    }
}
