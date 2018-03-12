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

using Transonic.MIDI.System;
using Transonic.MIDI.Engine;

namespace SuperConductor.Dialogs
{
    public partial class TrackSettings : Form
    {
        MidiSystem midiSystem;        
        public String name;
        public int inPort;
        public int inChannel;
        public int outPort;
        public int outChannel;
        public int patch;
        public int volume;

        public TrackSettings(MidiSystem _midiSystem)
        {
            InitializeComponent();

            midiSystem = _midiSystem;
            cbxInPort.DataSource = midiSystem.getInDevNameList();
            cbxOutPort.DataSource = midiSystem.getOutDevNameList();
            cbxPatch.DataSource = MidiSystem.GMNames;
        }

        public void setValues(String _name, int _inPort, int _inChannel, int _outPort, int _outChannel, int _patch, int _volume)
        {
            txtName.Text = _name;
            cbxInPort.SelectedIndex = _inPort;
            nudInChannel.Value = _inChannel;
            cbxOutPort.SelectedIndex = _outPort;
            nudOutChannel.Value = _outChannel;
            cbxPatch.SelectedIndex = _patch;
            hsbVolume.Value = _volume;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            inPort = cbxInPort.SelectedIndex;
            inChannel = (int)nudInChannel.Value;
            outPort = cbxOutPort.SelectedIndex;
            outChannel = (int)nudOutChannel.Value;
            patch = cbxPatch.SelectedIndex;
            volume = hsbVolume.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
