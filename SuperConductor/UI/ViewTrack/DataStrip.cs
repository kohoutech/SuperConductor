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
    class DataStrip
    {
        public TrackDataPane trackData;     //parent widget
        public Track track;

        public List<Event>[] measureEvents;
        int noterange;
        int notemin;

        public float ypos;
        public float height;
        public float width;

        public DataStrip(TrackDataPane _trackData, Track _track)
        {
            trackData = _trackData;
            track = _track;
            noterange = track.hiNote - track.loNote;
            notemin = track.loNote;

            measureEvents = new List<Event>[track.measures];
            for (int i = 0; i < track.measures; i++)
            {
                measureEvents[i] = track.findMeasureEvents(i);
            }

            ypos = 0;
            height = TrackStrip.STRIPHEIGHT - 1;
            width = 0;
        }

        public void setPos(float _ypos)
        {
            ypos = _ypos;
        }

//- display -------------------------------------------------------------------

        public void paint(Graphics g)
        {
            //strip background
            float bottom = (ypos + height);
            g.FillRectangle(Brushes.Wheat, 0, ypos, width, TrackStrip.STRIPHEIGHT);
            g.DrawLine(Pens.Black, 0, bottom, width, bottom);

            //note data
            float noteHeight = ((float)(TrackStrip.STRIPHEIGHT - 1)) / noterange;
            for (int i = 0; i < measureEvents.Length; i++)      //for each measure
            {
                for (int j = 0; j < measureEvents[i].Count; j++)        //for each note in measure
                {
                    Event evt = measureEvents[i][j];
                    if ((evt is MessageEvent) && (((MessageEvent)evt).msg is NoteOnMessage))
                    {
                        NoteOnMessage noteOn = (NoteOnMessage)((MessageEvent)evt).msg;
                        float measpos = TrackDataPane.BEATWIDTH * (float)evt.beat;
                        float noteposX = trackData.measureOffsets[evt.measure] + measpos;
                        float noteposY = bottom - ((noteOn.noteNumber - notemin) * noteHeight) - 1;
                        g.FillRectangle(Brushes.Red, noteposX, noteposY, (TrackDataPane.BEATWIDTH / 2), 1);
                    }
                }
            }
        }
    }
}
