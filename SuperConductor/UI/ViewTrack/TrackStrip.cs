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

        TrackListPane trackList;        //parent widget
        int trackNum;
        Track track;

        float ypos;
        float height;

        public TrackStrip(TrackListPane _trackList, int num) 
        {
            trackList = _trackList;
            trackNum = num;
            track = null;
            ypos = 0;
            height = STRIPHEIGHT - 1;
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
            int[] colwidths = trackList.colWidths;
            int width = trackList.listWidth;

            //strip background
            float bottom = (ypos + height);
            g.FillRectangle(Brushes.White, 0, ypos, width, height);
            g.DrawLine(Pens.Black, 0, bottom, width, bottom);

            StringFormat titleFormat = new StringFormat();
            titleFormat.LineAlignment = StringAlignment.Center;
            titleFormat.Alignment = StringAlignment.Center;
            titleFormat.FormatFlags = StringFormatFlags.NoWrap;

            //track number
            RectangleF rect = new RectangleF(0, ypos, colwidths[0], height);
            g.DrawString(trackNum.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

            //other track data
            float xpos = 0;
            if (track != null)
            {
                //track name
                xpos = colwidths[0];
                rect = new RectangleF(xpos, ypos, colwidths[1], height);
                g.DrawString(track.name, SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

                //track mute/solo/record
                xpos += colwidths[1];
                rect = new RectangleF(xpos, ypos, colwidths[2], height);
                g.DrawString(track.muted ? "m" : " ", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[2];
                rect = new RectangleF(xpos, ypos, colwidths[3], height);
                g.DrawString(track.soloing ? "s" : " ", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[3];
                rect = new RectangleF(xpos, ypos, colwidths[4], height);
                g.DrawString(track.recording ? "r" : " ", SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

                //track input
                xpos += colwidths[4];
                rect = new RectangleF(xpos, ypos, colwidths[5], height);
                g.DrawString(track.inDev != null ? track.inDev.devName : "---", 
                    SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[5];
                rect = new RectangleF(xpos, ypos, colwidths[6], height);
                g.DrawString(track.inDev != null ? (track.inputChannel + 1).ToString()  : "--", 
                    SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

                //track output
                xpos += colwidths[6];
                rect = new RectangleF(xpos, ypos, colwidths[7], height);
                g.DrawString(track.outDev != null ? track.outDev.devName : "---", 
                    SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[7];
                rect = new RectangleF(xpos, ypos, colwidths[8], height);
                g.DrawString(track.outDev != null ? (track.outputChannel + 1).ToString() : "--", 
                    SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

                //track patchname
                xpos += colwidths[8];
                rect = new RectangleF(xpos, ypos, colwidths[9], height);
                g.DrawString(track.patchname != null ? track.patchname : track.defPatchname, 
                    SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

                //track time/key/vel adjust
                xpos += colwidths[9];
                rect = new RectangleF(xpos, ypos, colwidths[10], height);
                g.DrawString(track.keyOfs.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[10];
                rect = new RectangleF(xpos, ypos, colwidths[11], height);
                g.DrawString(track.velOfs.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[11];
                rect = new RectangleF(xpos, ypos, colwidths[12], height);
                g.DrawString(track.timeOfs.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);

                //track vol/pan/size
                xpos += colwidths[12];
                rect = new RectangleF(xpos, ypos, colwidths[13], height);
                g.DrawString(track.volume.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[13];
                rect = new RectangleF(xpos, ypos, colwidths[14], height);
                g.DrawString(track.pan.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
                xpos += colwidths[14];
                rect = new RectangleF(xpos, ypos, colwidths[15], height);
                g.DrawString(track.events.Count.ToString(), SystemFonts.DefaultFont, Brushes.Black, rect, titleFormat);
            }

            //track col separator lines
            xpos = 0;
            for (int i = 0; i < 16; i++)
            {
                xpos += colwidths[i];
                g.DrawLine(Pens.Green, xpos, ypos, xpos, (ypos + height));
            }
        }
    }
}
