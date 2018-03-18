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
    class TrackDataPane : UserControl
    {
        public const int HEADERHEIGHT = 30;
        public const float BEATWIDTH = 16;
        public const float BLANKMEASUREWIDTH = BEATWIDTH * 4;
        
        public SuperWindow superWindow;         //parent widget
        public TrackListPane trackList;         //sibling widget
        public TrackDataPanel dataPanel;        //child widget
        public Sequence seq;

        public HScrollBar horzScroll;
        public int horzOffset;

        public VScrollBar vertScroll;

        public float[] measureOffsets;
        public float[] measureWidths;
        public float measureWidth;

        public int curMeasure;
        public decimal curBeat;
        public float curDataPos;

        public TrackDataPane()
        {
            superWindow = null;
            trackList = null;

            vertScroll = new VScrollBar();
            horzScroll = new HScrollBar();

            //vert scrollbar
            vertScroll.Location = new Point(this.Right - vertScroll.Width, 0);
            vertScroll.Size = new Size(vertScroll.Width, this.Height - horzScroll.Height);
            vertScroll.ValueChanged += new EventHandler(vertScroll_ValueChanged);
            vertScroll.Value = 0;
            vertScroll.Maximum = 100;            
            Controls.Add(vertScroll);

            //horz scrollbar
            horzScroll.Location = new Point(0, this.Height - horzScroll.Height);
            horzScroll.Size = new Size(this.Width - vertScroll.Width, horzScroll.Height);
            horzScroll.ValueChanged += new EventHandler(horzScroll_ValueChanged);
            horzScroll.Value = 0;
            horzScroll.Maximum = 100;
            Controls.Add(horzScroll);

            //strip panel
            dataPanel = new TrackDataPanel(this);
            dataPanel.Location = new Point(0, HEADERHEIGHT);
            dataPanel.Size = new Size(this.Width, this.Height - HEADERHEIGHT - horzScroll.Height);
            Controls.Add(dataPanel);

            this.DoubleBuffered = true;

            horzOffset = 0;

            measureOffsets = null;
            measureWidths = null;
            measureWidth = 0;

            curMeasure = 0;
            curBeat = 0;
            curDataPos = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            dataPanel.Location = new Point(0, HEADERHEIGHT);
            dataPanel.Size = new Size(this.Width, this.Height - HEADERHEIGHT - horzScroll.Height);

            vertScroll.Location = new Point(this.Right - vertScroll.Width, 0);
            vertScroll.Size = new Size(vertScroll.Width, this.Height - horzScroll.Height);

            horzScroll.Location = new Point(0, this.Height - horzScroll.Height);
            horzScroll.Size = new Size(this.Width - vertScroll.Width, horzScroll.Height);

            if (trackList != null)
            {
                vertScroll.Maximum = trackList.stripPanel.listHeight - trackList.stripPanel.Height + 9;
            }

            horzScroll.Maximum = (measureWidths != null) ? (int)measureWidth - (this.Width - vertScroll.Width) + 10 : 0;
        }

        private void vertScroll_ValueChanged(Object sender, EventArgs e)
        {
            trackList.stripPanel.vertOffset = vertScroll.Value;
            trackList.Invalidate(true);

            dataPanel.vertOffset = vertScroll.Value;
            dataPanel.Invalidate(true);
        }

        private void horzScroll_ValueChanged(Object sender, EventArgs e)
        {

            horzOffset = (measureWidths != null) ? horzScroll.Value : 0;            
            this.Invalidate(true);
        }

//- track management ----------------------------------------------------------

        public void setSequence(Sequence _seq)
        {
            seq = _seq;
            measureOffsets = new float[seq.measures];
            measureWidths = new float[seq.measures];

            int meternum = 0;
            measureWidth = 0;
            Meter meter = seq.meterMap.meters[meternum++];
            for (int measNum = 0; measNum < seq.measures; measNum++)
            {
                measureOffsets[measNum] = measureWidth;
                measureWidths[measNum] =  ((meter.numer * BEATWIDTH * 4) / (meter.denom));
                measureWidth += measureWidths[measNum];
                if ((meternum < seq.meterMap.meters.Count) && (measNum == seq.meterMap.meters[meternum].measure))
                {
                    meter = seq.meterMap.meters[meternum++];
                }
            }

            horzScroll.Maximum = (int)measureWidth - (this.Width - vertScroll.Width) + 10;
            horzScroll.Value = 0;
            horzOffset = 0;

            //now that we have laid out our measures, get the data strips for each track
            dataPanel.setSequence(seq);

            this.Invalidate(true);
        }

        public void setCurrentPos(int measure, decimal beat)
        {
            curMeasure = measure;
            curBeat = beat;
            curDataPos = 0;
            if ((measureOffsets != null) && (measure < measureOffsets.Length))
            {
                curDataPos = measureOffsets[measure] + ((float)beat * BEATWIDTH);
            }

            //if we've passed the left side of the window
            if (curDataPos < (horzScroll.Value))
            {
                int newofs = (int)curDataPos;
                horzScroll.Value = (newofs > horzScroll.Minimum) ? newofs : horzScroll.Minimum;
            }

            //if we've passed the right side of the window
            if ((int)curDataPos > (horzScroll.Value + this.Width - vertScroll.Width))
            {
                int newofs = (int)curDataPos;
                horzScroll.Value = (newofs < horzScroll.Maximum) ? newofs : horzScroll.Maximum;
            }
            
            this.Invalidate(true);
        }

//- painting ------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(-horzOffset, 0);

            //draw measure header
            float headerWidth = (measureWidths != null) ? measureWidth : this.Width;
            g.FillRectangle(Brushes.White, 0, 0, headerWidth, HEADERHEIGHT);
            g.DrawLine(Pens.Black, 0, (HEADERHEIGHT - 1), headerWidth, (HEADERHEIGHT - 1));

            StringFormat titleFormat = new StringFormat();
            titleFormat.LineAlignment = StringAlignment.Center;
            titleFormat.Alignment = StringAlignment.Center;
            titleFormat.FormatFlags = StringFormatFlags.NoWrap;

            float xpos = 0;
            int measnum = 1;
            if (measureWidths != null)
            {
                for (int i = 0; i < measureWidths.Length; i++) 
                {
                    RectangleF titleRect = new RectangleF(xpos, 0, measureWidths[i], HEADERHEIGHT);
                    g.DrawString(measnum.ToString(), SystemFonts.DefaultFont, Brushes.Black, titleRect, titleFormat);
                    xpos += measureWidths[i];
                    g.DrawLine(Pens.Green, xpos, 0, xpos, this.Height - horzScroll.Height);
                    measnum++;
                }
            }

            while (xpos < this.Width)
            {
                RectangleF titleRect = new RectangleF(xpos, 0, BLANKMEASUREWIDTH, HEADERHEIGHT);
                g.DrawString(measnum.ToString(), SystemFonts.DefaultFont, Brushes.Black, titleRect, titleFormat);
                xpos += BEATWIDTH * 4;
                g.DrawLine(Pens.Green, xpos, 0, xpos, this.Height - horzScroll.Height);
                measnum++;
            }
        }
    }
}
