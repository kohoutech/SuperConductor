/* ----------------------------------------------------------------------------
SuperConductor : a midi sequencer
Copyright (C) 1997-2017  George E Greaney

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
using Transonic.MIDI.Engine;
using SuperConductor.UI;
using SuperConductor.Widgets;

namespace SuperConductor
{
    public partial class SuperWindow : Form, IMidiView
    {
        public MidiSystem midiSystem;
        Transport transport;
        MidiFile currentFile;
        Sequence currentSeq;

        public ControlPanel controlPanel;
        public TrackView trackView;

        public SuperWindow()
        {
            midiSystem = new MidiSystem();
            transport = new Transport(this);
            currentFile = null;
            currentSeq = new Sequence(Sequence.DEFAULTDIVISION);

            trackView = new TrackView(this, currentSeq);
            trackView.Dock = DockStyle.Fill;
            this.Controls.Add(trackView);

            //control panel
            controlPanel = new ControlPanel(this);
            controlPanel.Dock = DockStyle.Top;
            this.Controls.Add(controlPanel);

            InitializeComponent();

            this.MinimumSize = new Size(this.Width, 250);
            this.MaximumSize = new Size(this.Width, int.MaxValue);
            trackView.setScrollbar(superStatus.Top - controlPanel.Bottom);
        }

        private void SuperWindow_Resize(object sender, EventArgs e)
        {
            trackView.setScrollbar(superStatus.Top - controlPanel.Bottom);
        }

//- actions -------------------------------------------------------------------

        public void openSequence(String filename) 
        {
            currentFile = new MidiFile(midiSystem, filename);

            currentSeq = currentFile.readMidiFile();
            this.Text = "SuperConductor [" + currentFile.filename + "]";
            transport.setSequence(currentSeq);
            controlPanel.setSequence(currentSeq);
            for (int trackNum = 1; trackNum <= currentSeq.lastTrack; trackNum++)
            {
                trackView.strips[trackNum - 1].setTrack(currentSeq.tracks[trackNum]);
            }
            //currentSeq.dump();
        }

        public bool saveSequence(bool newName)
        {
            if (newName || currentFile == null)
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
                currentFile = new MidiFile(midiSystem, filename);                
            }
            currentFile.writeMidiFile(currentSeq);
            String msg = "Current project has been saved as\n " + currentFile.filename;
            MessageBox.Show(msg, "Saved");
            return true;
        }

        public void playSequence()
        {
            transport.playSequence();
            masterTimer.Start();
            controlPanel.setPlaying(true);
        }

        public void stopSequence()
        {
            masterTimer.Stop();
            transport.stopSequence();
            controlPanel.setPlaying(false);
        }

        public void setSequencePos(int tick)
        {
            transport.setSequencePos(tick);
            int mstime = transport.getMilliSecTime();
            controlPanel.timerTick(tick, mstime);
        }

        public void panic()
        {
            currentSeq.allNotesOff();
        }


//- file events ---------------------------------------------------------------

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            String filename = "";
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.InitialDirectory = @"N:\midi";
            openFileDialog.DefaultExt = "*.mid";
            openFileDialog.Filter = "midi files|*.mid|All files|*.*";
            openFileDialog.ShowDialog();
            filename = openFileDialog.FileName;
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
            transport.stopSequence();
        }

//- help events ---------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "SuperConductor\nversion 1.0.0\n" + "\xA9 Transonic Software 1997-2017\n" + "http://transonic.kohoutech.com";
            MessageBox.Show(msg, "About");
        }

        private void masterTimer_Tick(object sender, EventArgs e)
        {
            int tick = transport.tickCount;
            int tempo = transport.curTempo.tempo;
            Timing timing = transport.curTempo.timing;
            float delta = (float)(tick - timing.tick);
            int time = (int)(((delta / currentSeq.division) * tempo) + timing.microsec) / 1000;

            controlPanel.timerTick(tick, time);
        }

        //iMidiView iface
        public void handleMessage(int track, Transonic.MIDI.Message message)
        {
        }

        public void sequenceDone()
        {
        }
    }
}

