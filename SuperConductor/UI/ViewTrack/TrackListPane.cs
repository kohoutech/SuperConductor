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

using Transonic.MIDI;

namespace SuperConductor.UI.ViewTrack
{
    public class TrackListPane : UserControl
    {
        public const int TRACKCOUNT = 256;
        public const int HEADERHEIGHT = 30;
        public readonly string[] colTitles = {"", "Name", "I/O", "In Port", "In Channel", "Out Port", "Out Channel",
                                              "Patch", "Key+", "Vel+", "Time+", "Vol", "Pan", "Size"};

        public readonly int[] colWidths = { 27, 150, 35, 56, 60, 56, 68, 127, 40, 40, 40, 36, 36, 60 };

        public SuperWindow superWindow;
        public SplitContainer trackSplit;
        public Sequence seq;
        public TrackStripPanel stripPanel;

        public int[] colwidth;
        public int listWidth;

        public HScrollBar horzScroll;
        public int horzOffset;

        public TrackListPane()
        {
            superWindow = null;
            trackSplit = null;
            seq = null;

            //header layout
            colwidth = new int[14];
            listWidth = 0;
            for (int i = 0; i < 14; i++)
            {
                colwidth[i] = colWidths[i];
                listWidth += colwidth[i];
            }            

            //scrollbar
            horzScroll = new HScrollBar();
            horzScroll.Location = new Point(0, this.Height - horzScroll.Height);
            horzScroll.Size = new Size(this.Width, horzScroll.Height);
            horzScroll.ValueChanged += new EventHandler(horzScroll_ValueChanged);
            horzScroll.Value = 0;
            horzScroll.Maximum = listWidth - this.Width;
            Controls.Add(horzScroll);

            //strip panel
            stripPanel = new TrackStripPanel(this);
            stripPanel.Location = new Point(0, HEADERHEIGHT);
            stripPanel.Size = new Size(this.Width, this.Height - HEADERHEIGHT - horzScroll.Height);
            Controls.Add(stripPanel);

            this.MaximumSize = new Size(listWidth, stripPanel.listHeight + HEADERHEIGHT + horzScroll.Height);
            this.DoubleBuffered = true;

            horzOffset = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            stripPanel.Size = new Size(this.Width, this.Height - HEADERHEIGHT - horzScroll.Height);
            horzScroll.Location = new Point(0, this.Height - horzScroll.Height);
            horzScroll.Size = new Size(this.Width, horzScroll.Height);
            int delta = listWidth - this.Width;
            horzScroll.Maximum = delta;
        }

        private void horzScroll_ValueChanged(Object sender, EventArgs e)
        {
            horzOffset = horzScroll.Value;
            this.Invalidate(true);
        }

//- track management ----------------------------------------------------------

        public void setSequence(Sequence _seq)
        {
            seq = _seq;
            for (int trackNum = 0; trackNum < seq.tracks.Count; trackNum++)
            {
                stripPanel.strips[trackNum].setTrack(seq.tracks[trackNum]);                
            }
            this.Invalidate(true);
        }

//- painting ------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(-horzOffset, 0);

            //draw track header
            g.FillRectangle(Brushes.White, 0, 0, listWidth, HEADERHEIGHT);
            g.DrawLine(Pens.Black, 0, (HEADERHEIGHT - 1), listWidth, (HEADERHEIGHT - 1));

            float xpos = 0;
            StringFormat titleFormat = new StringFormat();
            titleFormat.LineAlignment = StringAlignment.Center;
            titleFormat.Alignment = StringAlignment.Center;
            titleFormat.FormatFlags = StringFormatFlags.NoWrap;

            for (int i = 0; i < 14; i++)
            {
                RectangleF titleRect = new RectangleF(xpos, 0, colwidth[i], HEADERHEIGHT);
                g.DrawString(colTitles[i], SystemFonts.DefaultFont, Brushes.Black, titleRect, titleFormat); 
                xpos += colwidth[i];
                g.DrawLine(Pens.Green, xpos, 0, xpos, (HEADERHEIGHT - 1));                
            }
        }
    }
}
