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
using System.Drawing;
using System.Drawing.Drawing2D;

using Transonic.MIDI;

namespace SuperConductor.UI.ViewTrack
{
    public class TrackStrip
    {
        public const int STRIPHEIGHT = 25;

        TrackListPane trackList;
        int trackNum;
        Track track;

        float ypos;
        float height;
        float[] colwidth;
        float width;

        public TrackStrip(TrackListPane _trackList, int num) 
        {
            trackList = _trackList;
            trackNum = num;
            track = null;
            ypos = 0;
            height = STRIPHEIGHT - 1;

            //column layout
            colwidth = new float[14];
            width = 0;
            for (int i = 0; i < 14; i++)
            {
                colwidth[i] = trackList.colwidth[i];
                width += colwidth[i];
            }
        }

        public void setPos(float _ypos)
        {
            ypos = _ypos;
        }

//- track management ----------------------------------------------------------

        public void setTrack(Track _track)
        {
            track = _track;
        }

//- display -------------------------------------------------------------------

        public void paint(Graphics g)
        {
            float bottom = (ypos + height);
            g.FillRectangle(Brushes.White, 0, ypos, width, height);
            g.DrawLine(Pens.Black, 0, bottom, width, bottom);

            StringFormat titleFormat = new StringFormat();
            titleFormat.LineAlignment = StringAlignment.Center;
            titleFormat.Alignment = StringAlignment.Center;
            titleFormat.FormatFlags = StringFormatFlags.NoWrap;

            RectangleF rect = new RectangleF(0, ypos, colwidth[0], height);
            g.DrawString(trackNum.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

            float xpos = 0;
            if (track != null)
            {
                xpos = colwidth[0];
                rect = new RectangleF(xpos, ypos, colwidth[1], height);
                g.DrawString(track.name, SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[1];
                rect = new RectangleF(xpos, ypos, colwidth[2], height);
                g.DrawString("x", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[2];
                rect = new RectangleF(xpos, ypos, colwidth[3], height);
                g.DrawString("x", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[3];
                rect = new RectangleF(xpos, ypos, colwidth[4], height);
                g.DrawString("x", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[4];
                rect = new RectangleF(xpos, ypos, colwidth[5], height);
                g.DrawString("x", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[5];
                rect = new RectangleF(xpos, ypos, colwidth[6], height);
                g.DrawString("x", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[6];
                rect = new RectangleF(xpos, ypos, colwidth[7], height);
                g.DrawString("x", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[7];
                rect = new RectangleF(xpos, ypos, colwidth[8], height);
                g.DrawString(track.keyOfs.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[8];
                rect = new RectangleF(xpos, ypos, colwidth[9], height);
                g.DrawString(track.velOfs.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[9];
                rect = new RectangleF(xpos, ypos, colwidth[10], height);
                g.DrawString(track.timeOfs.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[10];
                rect = new RectangleF(xpos, ypos, colwidth[11], height);
                g.DrawString(track.volume.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[11];
                rect = new RectangleF(xpos, ypos, colwidth[12], height);
                g.DrawString(track.pan.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidth[12];
                rect = new RectangleF(xpos, ypos, colwidth[13], height);
                g.DrawString(track.events.Count.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
            }

            xpos = 0;
            for (int i = 0; i < 14; i++)
            {
                xpos += colwidth[i];
                g.DrawLine(Pens.Green, xpos, ypos, xpos, (ypos + height));
            }

        }
    }
}
