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

namespace SuperConductor.UI.ViewTrack
{
    class TrackData : UserControl
    {
        public SuperWindow superWindow;
        public TrackList trackList;
        public HScrollBar horzScroll;
        public VScrollBar vertScroll;

        public TrackData()
        {
            BackColor = Color.LightBlue;

            superWindow = null;
            trackList = null;

            vertScroll = new VScrollBar();
            vertScroll.Size = new Size(vertScroll.Width, this.Height);
            vertScroll.Location = new Point(this.Right - vertScroll.Width, 0);
            vertScroll.ValueChanged += new EventHandler(vertScroll_ValueChanged);
            vertScroll.Value = 0;
            vertScroll.Maximum = 100;
            Controls.Add(vertScroll);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            vertScroll.Size = new Size(vertScroll.Width, this.Height);
            vertScroll.Location = new Point(this.Right - vertScroll.Width, 0);
            if (trackList != null)
            {
                vertScroll.Maximum = trackList.stripPanel.listHeight - trackList.stripPanel.Height + 9;
            }
        }

        private void vertScroll_ValueChanged(Object sender, EventArgs e)
        {
            trackList.stripPanel.vertOffset = vertScroll.Value;
            trackList.Invalidate(true);
        }
    }
}
