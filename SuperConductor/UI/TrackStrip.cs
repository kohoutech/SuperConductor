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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Transonic.MIDI;
using Transonic.MIDI.Engine;
using SuperConductor.Dialogs;

namespace SuperConductor.UI
{
    public partial class TrackStrip : UserControl
    {
        public SuperWindow window;
        public TrackView trackView;
        public Track track;

        public int trackNum;
        public String name;
        List<String> inDevNames;
        List<String> outDevNames;

        public int inPort;
        public int inChannel;
        public int outPort;
        public int outChannel;
        public int patch;
        public int volume;

        public bool isMuted;
        public bool isSoloing;
        public bool isRecording;

        public Label muteLabel;
        public Label soloLabel;

        public TrackStrip(TrackView _trackView, int _trackNum)
        {
            trackView = _trackView;
            window = trackView.window;
            trackNum = _trackNum;
            inDevNames = window.midiSystem.getInDevNameList();
            outDevNames = window.midiSystem.getOutDevNameList();

            InitializeComponent();
            lblNumber.Text = trackNum.ToString();

            name = "";
            inPort = 0;
            inChannel = 1;
            outPort = 0;
            outChannel = 1;
            patch = 0;
            volume = 127;

            isMuted = false;
            isSoloing = false;
            isRecording = false;
            muteLabel = lblMute;
            soloLabel = lblSolo;
        }

        public void setTrack(Track _track)
        {
            track = _track;
            trackNum = track.number;
            name = track.name;
            outPort = 0;
            outChannel = track.outputChannel;
            patch = track.patchNum;
            volume = track.volume;

            updateDisplay();
        }

        public void showTrackSettingsDialog(object sender, EventArgs e)
        {
            TrackSettings trackdialog = new TrackSettings(window.midiSystem);
            trackdialog.setValues(name, inPort, inChannel, outPort, outChannel, patch, volume);
            trackdialog.ShowDialog();
            if (trackdialog.DialogResult == DialogResult.OK)
            {
                name = trackdialog.name;
                inPort = trackdialog.inPort;
                track.setInputDevice(window.midiSystem.inputDevices[inPort]);
                inChannel = trackdialog.inChannel;
                track.setInputChannel(inChannel);
                outPort = trackdialog.outPort;
                track.setOutputDevice(window.midiSystem.outputDevices[outPort]);
                outChannel = trackdialog.outChannel;
                track.setOutputChannel(outChannel);
                patch = trackdialog.patch;
                track.setPatch(patch);
                volume = trackdialog.volume;
                track.setVolume(volume);
                updateDisplay();
            }
        }

        public void updateDisplay()
        {
            lblName.Text = name;
            lblInPort.Text = inDevNames[inPort];
            lblInChannel.Text = inChannel.ToString();
            lblOutPort.Text = outDevNames[outPort];
            lblOutChannel.Text = outChannel.ToString();
            lblPatch.Text = MidiSystem.GMNames[patch];
            lblVolume.Text = volume.ToString();
            Invalidate();
        }

//-----------------------------------------------------------------------------

        public void setSoloing(bool on) {

            isSoloing = on;
            track.setSoloing(on);
            lblSolo.Text = isSoloing ? "X" : "";
            lblSolo.Invalidate();
        }

        private void lblSolo_Click(object sender, EventArgs e)
        {
            bool turnOn = !isSoloing;
            setSoloing(turnOn);
            if (turnOn) setMuted(false);
            trackView.setSoloTrack(this);
        }

        public void setMuted(bool on)
        {
            isMuted = on;
            track.setMuted(on);
            lblMute.Text = isMuted ? "X" : "";
            lblMute.Invalidate();
        }

        private void lblMute_Click(object sender, EventArgs e)
        {
            bool turnOn = !isMuted;
            setMuted(turnOn);
            if (turnOn) setSoloing(false);
            trackView.unsetSoloTrack(this);
        }

        public void setRecording(bool on)
        {
            isRecording = on;
            track.setRecording(on);
            lblRecord.Text = isRecording ? "X" : "";
            lblRecord.Invalidate();
        }

        private void lblRecord_Click(object sender, EventArgs e)
        {
            bool turnOn = !isRecording;
            setRecording(turnOn);
            if (turnOn)
            {
                setMuted(false);
                setSoloing(false);
                trackView.setRecordingTrack(this);
            }
            else
            {
                trackView.unsetRecordingTrack(this);
            }
            lblMute.Enabled = !turnOn;
            lblSolo.Enabled = !turnOn;            
        }
    }
}
