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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Transonic.MIDI;
using Transonic.MIDI.System;
using Transonic.MIDI.Engine;
using SuperConductor.UI.ViewTrack;
using SuperConductor.Widgets;

namespace SuperConductor
{
    public partial class SuperWindow : Form, IMidiView
    {
        public MidiSystem midiSystem;
        Transport transport;
        String currentFilename;
        Sequence currentSeq;

        public SuperWindow()
        {
            midiSystem = new MidiSystem();
            transport = new Transport(this);
            currentFilename = null;
            currentSeq = new Sequence();

            InitializeComponent();

            //wire up components
            controlPanel.superWindow = this;
            trackList.superWindow = this;
            trackList.trackSplit = TrackSplit;
            trackData.superWindow = this;
            trackData.trackList = trackList;
            trackData.vertScroll.Maximum = trackList.stripPanel.listHeight - trackList.stripPanel.Height + 9;
        }

        private void TrackSplit_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (TrackSplit.SplitterDistance > trackList.listWidth)
            {
                TrackSplit.SplitterDistance = trackList.listWidth;
            }
        }

//- actions -------------------------------------------------------------------

        public void openSequence(String filename) 
        {
            currentFilename = filename;

            currentSeq = MidiFile.readMidiFile(filename);
            this.Text = "SuperConductor [" + currentFilename + "]";
            transport.setSequence(currentSeq);
            controlPanel.setSequence(currentSeq);
            trackList.setSequence(currentSeq);
            setTrackOutput();
        }

        public void setTrackOutput()
        {
            for (int i = 0; i < currentSeq.tracks.Count; i++)
            {
                currentSeq.tracks[i].setOutputDevice(midiSystem.outputDevices[0]);
                currentSeq.tracks[i].setOutputChannel(i);
            }
        }

        public bool saveSequence(bool newName)
        {
            if (newName || currentFilename == null)
            {
                String filename = "";
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.DefaultExt = "*.mid";
                saveFileDialog.Filter = "midi files|*.mid|All files|*.*";
                saveFileDialog.ShowDialog();
                filename = saveFileDialog.FileName;
                if (filename.Length == 0) return false;

                //add default extention if filename doesn't have one
                if (!filename.Contains('.'))
                    filename = filename + ".mid";
                currentFilename = filename;
            }
            MidiFile.writeMidiFile(currentSeq, currentFilename);
            String msg = "Current project has been saved as\n " + currentFilename;
            MessageBox.Show(msg, "Saved");
            return true;
        }

        public void playSequence()
        {
            transport.play();
            masterTimer.Start();
            controlPanel.setPlaying(true);
        }

        public void stopSequence()
        {
            masterTimer.Stop();
            transport.stop();
            controlPanel.setPlaying(false);
        }

        public void setSequencePos(int tick)
        {
            transport.setCurrentPos(tick);
            int mstime = transport.getCurrentTime();
            int measure = 0;
            int beat = 0;
            int beatticks = 0;
            transport.getCurrentBeat(out measure, out beat, out beatticks);
            controlPanel.timerTick(tick, mstime, measure, beat, beatticks);
        }

        public void panic()
        {
            currentSeq.allNotesOff();
        }


//- file events ---------------------------------------------------------------

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            String filename = "";
            //openFileDialog.InitialDirectory = Application.StartupPath;
            //openFileDialog.InitialDirectory = @"N:\midi";
            //openFileDialog.DefaultExt = "*.mid";
            //openFileDialog.Filter = "midi files|*.mid|All files|*.*";
            //openFileDialog.ShowDialog();
            //filename = openFileDialog.FileName;
            filename = "testS.mid";
            if (filename.Length == 0) return;

            openSequence(filename);
        }

        private void newFileMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveFileMenuItem_Click(object sender, EventArgs e)
        {
            saveSequence(false);
        }

        private void saveAsFileMenuItem_Click(object sender, EventArgs e)
        {
            saveSequence(true);
        }

        private void exitFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

//- transport events ----------------------------------------------------------

        private void playTransportMenuItem_Click(object sender, EventArgs e)
        {
            playSequence();
        }

        private void stopTransportMenuItem_Click(object sender, EventArgs e)
        {
            transport.stop();
        }

//- help events ---------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "SuperConductor\nversion 1.1.0\n" + "\xA9 Transonic Software 1997-2018\n" + "http://transonic.kohoutech.com";
            MessageBox.Show(msg, "About");
        }

//- updating ------------------------------------------------------------------

        private void masterTimer_Tick(object sender, EventArgs e)
        {
            int tick = transport.getCurrentPos();
            int mstime = transport.getCurrentTime();
            int measure = 0;
            int beat = 0;
            int beatticks = 0;
            transport.getCurrentBeat(out measure, out beat, out beatticks);
            controlPanel.timerTick(tick, mstime, measure, beat, beatticks);
        }

        //iMidiView iface
        public void handleMessage(int track, Transonic.MIDI.Message message)
        {
        }

        public void sequenceDone()
        {
            masterTimer.Stop();
            controlPanel.setPlaying(false);
        }
    }
}

