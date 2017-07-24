/* ----------------------------------------------------------------------------
Transonic MIDI Library
Copyright (C) 1995-2017  George E Greaney

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

//J Glatt's Midi page: http://midi.teragonaudio.com/tech/midispec.htm

namespace Transonic.MIDI
{
    public class Message
    {
        public enum MESSAGECLASS { 
            CHANNEL, 
            SYSTEM, 
            META 
        }; 

        public int status;
        public MESSAGECLASS msgClass;

        public static Message getMessage(MidiFile midiFile, int status) 
        {
            Message msg = null;
            if (status >= 0x80 && status < 0xf0)
            {
                msg = getChannelMessage(midiFile, status);
            }
            else if (status >= 0xf0 && status < 0xff)
            {
                msg = getSystemMessage(midiFile, status);
            }
            else if (status == 0xff)
            {
                msg = getMetaMessage(midiFile);
            }

            return msg;
        }

        static Message getChannelMessage(MidiFile midiFile, int status)
        {

            Message msg = null;
            int msgtype = status / 16;
            int channel = status % 16;
            switch (msgtype)
            {
                case 0x8 :
                    msg = new NoteOffMessage(midiFile, channel);
                    break;
                case 0x9:
                    msg = new NoteOnMessage(midiFile, channel);
                    break;
                case 0xa:
                    msg = new AftertouchMessage(midiFile, channel);
                    break;
                case 0xb:
                    msg = new ControllerMessage(midiFile, channel);
                    break;
                case 0xc:
                    msg = new PatchChangeMessage(midiFile, channel);
                    break;
                case 0xd:
                    msg = new ChannelPressureMessage(midiFile, channel);
                    break;
                case 0xe:
                    msg = new PitchWheelMessage(midiFile, channel);
                    break;
                default :
                    break;
            }
            msg.msgClass = MESSAGECLASS.CHANNEL;
            return msg;
        }

        static Message getSystemMessage(MidiFile midiFile, int status)
        {
            Message msg = null;
            if (status == 0xF0)
            {
                msg = new SysExMessage(midiFile);
            }
            else
            {
                msg = new SystemMessage(midiFile, status);
            }
            msg.msgClass = MESSAGECLASS.SYSTEM;
            return msg;
        }

        static Message getMetaMessage(MidiFile midiFile)
        {
            Message msg = null;
            int msgtype = (int)midiFile.getOne();
            int length = (int)midiFile.getVariableLengthVal();
            switch (msgtype) 
            {
                case 0x00:
                    msg = new SequenceNumberMessage(midiFile, length);
                    break;
                case 0x01:
                    msg = new TextMessage(midiFile, length);
                    break;
                case 0x02:
                    msg = new CopyrightMessage(midiFile, length);
                    break;
                case 0x03:
                    msg = new TrackNameMessage(midiFile, length);
                    break;
                case 0x04:
                    msg = new InstrumentMessage(midiFile, length);
                    break;
                case 0x05:
                    msg = new LyricMessage(midiFile, length);
                    break;
                case 0x06:
                    msg = new MarkerMessage(midiFile, length);
                    break;
                case 0x07:
                    msg = new CuePointMessage(midiFile, length);
                    break;
                case 0x08:
                    msg = new PatchNameMessage(midiFile, length);
                    break;
                case 0x09:
                    msg = new DeviceNameMessage(midiFile, length);
                    break;
                case 0x20:
                    msg = new MidiChannelMessage(midiFile, length);
                    break;
                case 0x21:
                    msg = new MidiPortMessage(midiFile, length);
                    break;
                case 0x2f:
                    msg = new EndofTrackMessage(midiFile, length);
                    break;
                case 0x51:
                    msg = new TempoMessage(midiFile, length);
                    break;
                case 0x54:
                    msg = new SMPTEOffsetMessage(midiFile, length);
                    break;
                case 0x58:
                    msg = new TimeSignatureMessage(midiFile, length);
                    break;
                case 0x59:
                    msg = new KeySignatureMessage(midiFile, length);
                    break;
                default:
                    msg = new UnknownMetaMessage(midiFile, length, msgtype);
                    break;
            }
            msg.msgClass = MESSAGECLASS.META;
            return msg;
        }


//- base class ----------------------------------------------------------------

        public Message(int _status)
        {
            status = _status;
        }

        virtual public byte[] getDataBytes() 
        {
            return null;
        }

        protected String getMessageText(MidiFile midiFile, int len)
        {
            StringBuilder str = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                byte ch = (byte)midiFile.getOne();
                str.Append(Convert.ToChar(ch));
            }
            return str.ToString();
        }
    }

//- subclasses ----------------------------------------------------------------

//-----------------------------------------------------------------------------
//  CHANNEL MESSAGES
//-----------------------------------------------------------------------------

    public class NoteOffMessage : Message
    {
        public int channel;
        public int noteNumber;
        public int velocity;

        public NoteOffMessage(MidiFile midiFile, int _channel) : base(0x80)
        {
            channel = _channel;
            noteNumber = (int)midiFile.getOne();
            velocity = (int)midiFile.getOne();
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0x80 + channel);
            bytes[1] = (byte)noteNumber;
            bytes[2] = (byte)velocity;
            return bytes;
        }

        public override string ToString()
        {
            return "Note Off (" + channel + ") note = " + noteNumber;
        }
    }

    public class NoteOnMessage : Message
    {
        public int channel;
        public int noteNumber;
        public int velocity;

        public NoteOnMessage(MidiFile midiFile, int _channel) : base(0x90)
        {
            channel = _channel;
            noteNumber = (int)midiFile.getOne();
            velocity = (int)midiFile.getOne();
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0x90 + channel);
            bytes[1] = (byte)noteNumber;
            bytes[2] = (byte)velocity;
            return bytes;
        }

        public override string ToString()
        {
            return "Note On (" + channel + ") note = " + noteNumber + ", velocity = " + velocity;
        }
    }

    public class AftertouchMessage : Message
    {
        public int channel;
        public int noteNumber;
        public int pressure;

        public AftertouchMessage(MidiFile midiFile, int _channel)
            : base(0xa0)
        {
            channel = _channel;
            noteNumber = (int)midiFile.getOne();
            pressure = (int)midiFile.getOne();
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0xa0 + channel);
            bytes[1] = (byte)noteNumber;
            bytes[2] = (byte)pressure;
            return bytes;
        }
    }

    public class ControllerMessage : Message
    {
        public int channel;
        public int controllerNumber;
        public int controllerValue;

        public ControllerMessage(MidiFile midiFile, int _channel)
            : base(0xb0)
        {
            channel = _channel;
            controllerNumber = (int)midiFile.getOne();
            controllerValue = (int)midiFile.getOne();
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0xb0 + channel);
            bytes[1] = (byte)controllerNumber;
            bytes[2] = (byte)controllerValue;
            return bytes;
        }

        public override string ToString()
        {
            return "Controller (" + channel + ") number = " + controllerNumber + ", value = " + controllerValue;
        }

    }

    public class PatchChangeMessage : Message
    {
        public int channel;
        public int patchNumber;

        public PatchChangeMessage(MidiFile midiFile, int _channel)
            : base(0xc0)
        {
            channel = _channel;
            patchNumber = (int)midiFile.getOne();
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[2];
            bytes[0] = (byte)(0xc0 + channel);
            bytes[1] = (byte)patchNumber;
            return bytes;
        }

        public override string ToString()
        {
            return "Patch Change (" + channel + ") number = " + patchNumber;
        }
    }

    public class ChannelPressureMessage : Message
    {
        public int channel;
        public int pressure;

        public ChannelPressureMessage(MidiFile midiFile, int _channel)
            : base(0xd0)
        {
            channel = _channel;
            pressure = (int)midiFile.getOne();
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[2];
            bytes[0] = (byte)(0xd0 + channel);
            bytes[1] = (byte)pressure;
            return bytes;
        }
    }

    public class PitchWheelMessage : Message
    {
        public int channel;
        public int wheel;

        public PitchWheelMessage(MidiFile midiFile, int _channel)
            : base(0xe0)
        {
            channel = _channel;
            int b1 = (int)midiFile.getOne();
            int b2 = (int)midiFile.getOne();
            wheel = b1 * 128 + b2;
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0xe0 + channel);
            bytes[1] = (byte)(wheel / 128);
            bytes[2] = (byte)(wheel % 128);
            return bytes;
        }
    }

//-----------------------------------------------------------------------------
//  SYSTEM MESSAGES
//-----------------------------------------------------------------------------

    public class SysExMessage : Message
    {
        List<int> sysExData;

        public SysExMessage(MidiFile midiFile)
            : base(0xF0)
        {
            sysExData = new List<int>();
            int b1 = (int)midiFile.getOne();
            while (b1 != 0xf7)
            {
                sysExData.Add(b1);
                b1 = (int)midiFile.getOne();
            }            
        }
    }

    public enum SYSTEMMESSAGE { 
        QUARTERFRAME = 0Xf1, 
        SONGPOSITION, 
        SONGSELECT, 
        UNKNOWN1,
        UNKNOWN2,
        TUNEREQUEST,
        SYSEXEND,
        MIDICLOCK,
        MIDITICK, 
        MIDISTART, 
        MIDICONTINUE, 
        MIDISTOP,
        UNKNOWN3,
        ACTIVESENSE = 0xfe
    }; 

    public class SystemMessage : Message
    {
        SYSTEMMESSAGE msgtype;
        int value;

        public SystemMessage(MidiFile midiFile, int status)
            : base(status)
        {
            msgtype = (SYSTEMMESSAGE)status;
            value = 0;
            switch (msgtype)
            {
                case SYSTEMMESSAGE.QUARTERFRAME :
                case SYSTEMMESSAGE.SONGSELECT :
                    value = (int)midiFile.getOne();
                    break;
                case SYSTEMMESSAGE.SONGPOSITION:
                    int b1 = (int)midiFile.getOne();
                    int b2 = (int)midiFile.getOne();
                    value = b1 * 128 + b2;
                    break;
                default :
                    break;
            }        
        }
    }

//-----------------------------------------------------------------------------
//  META MESSAGES
//-----------------------------------------------------------------------------

    public class SequenceNumberMessage : Message    //0xff 0x00
    {
        int b1, b2;

        public SequenceNumberMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            b1 = 0;
            b2 = 0;
            if (length > 0)
            {
                b1 = (int)midiFile.getOne();
                b2 = (int)midiFile.getOne();
            }
        }
    }

    public class TextMessage : Message
    {
        String text;

        public TextMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            text = getMessageText(midiFile, length);
        }
    }

    public class CopyrightMessage : Message
    {
        String copyright;

        public CopyrightMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            copyright = getMessageText(midiFile, length);
        }
    }

    public class TrackNameMessage : Message
    {
        public String trackName;

        public TrackNameMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            trackName = getMessageText(midiFile, length);
        }
    }

    public class InstrumentMessage : Message
    {
        public String instrumentName;

        public InstrumentMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            instrumentName = getMessageText(midiFile, length);
        }
    }

    public class LyricMessage : Message
    {
        public String lyric;

        public LyricMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            lyric = getMessageText(midiFile, length);
        }
    }

    public class MarkerMessage : Message
    {
        public String marker;

        public MarkerMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            marker = getMessageText(midiFile, length);
        }
    }

    public class CuePointMessage : Message
    {
        public String cuePoint;

        public CuePointMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            cuePoint = getMessageText(midiFile, length);
        }
    }

    public class PatchNameMessage : Message        //0xff 0x08
    {
        public String patchName;

        public PatchNameMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            patchName = getMessageText(midiFile, length);
        }
    }

    public class DeviceNameMessage : Message        //0xff 0x09
    {
        public String deviceName;

        public DeviceNameMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            deviceName = getMessageText(midiFile, length);
        }
    }

    //obsolete
    public class MidiChannelMessage : Message       //0xff 0x20
    {
        int cc;

        public MidiChannelMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            cc = (int)midiFile.getOne();
        }
    }

    //obsolete
    public class MidiPortMessage : Message          //0xff 0x21
    {
        int pp;

        public MidiPortMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            pp = (int)midiFile.getOne();
        }
    }

    public class EndofTrackMessage : Message        //0xff 0x2f
    {

        public EndofTrackMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            //length should be 0
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[3];
            bytes[0] = 0xff;
            bytes[1] = 0x2f;
            bytes[2] = 0x00;
            return bytes;
        }

        public override string ToString()
        {
            return "End of Track";
        }
    }

    public class TempoMessage : Message             //0xff 0x51
    {
        public int tempo;
        public Timing timing;

        public TempoMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            int b1 = (int)midiFile.getTwo();
            int b2 = (int)midiFile.getOne();
            tempo = b1 * 256 + b2;
            timing = null;
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[6];
            bytes[0] = 0xff;
            bytes[1] = 0x51;
            bytes[2] = 0x03;
            int _tempo = tempo;
            bytes[5] = (byte)(_tempo % 0x100);
            _tempo = _tempo / 0x100;
            bytes[4] = (byte)(_tempo % 0x100);
            _tempo = _tempo / 0x100;
            bytes[3] = (byte)(_tempo % 0x100);
            return bytes;
        }

        public override string ToString()
        {
            return "Tempo = " + tempo + " at time = " + timing.microsec;
        }
    }

    public class SMPTEOffsetMessage : Message       //0xff 0x54
    {
        int hour, min, sec, frame, frame100;

        public SMPTEOffsetMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            hour = (int)midiFile.getOne();
            min = (int)midiFile.getOne();
            sec = (int)midiFile.getOne();
            frame = (int)midiFile.getOne();
            frame100 = (int)midiFile.getOne();
        }
    }

    public class TimeSignatureMessage : Message         //0xff 0x58
    {
        int numerator;
        int denominator;
        int clicks;
        int clocksPerQuarter;

        public TimeSignatureMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            numerator = (int)midiFile.getOne();
            int b1 = (int)midiFile.getOne();
            denominator = (int)Math.Pow(2.0, b1);
            clicks = (int)midiFile.getOne();
            clocksPerQuarter = (int)midiFile.getOne();            
        }

        override public byte[] getDataBytes()
        {
            byte[] bytes = new byte[7];
            bytes[0] = 0xff;
            bytes[1] = 0x58;
            bytes[2] = 0x04;
            bytes[3] = (byte)numerator;
            bytes[4] = (byte)(Math.Log(denominator, 2.0));
            bytes[5] = (byte)clicks;
            bytes[6] = (byte)clocksPerQuarter;
            return bytes;
        }

        public override string ToString()
        {
            return "Time Signature = " + numerator + "/" + denominator + " clicks = " + clicks + " clocks/quarter = " + clocksPerQuarter;
        }

    }

    public class KeySignatureMessage : Message          //0xff 0x59
    {
        int sf;
        int mi;

        public KeySignatureMessage(MidiFile midiFile, int length)
            : base(0xFF)
        {
            sf = (int)midiFile.getOne();
            mi = (int)midiFile.getOne();
        }
    }

    public class UnknownMetaMessage : Message
    {
        int msgtype;

        public UnknownMetaMessage(MidiFile midiFile, int length, int _msgtype)
            : base(0xFF)
        {
            msgtype = _msgtype;
            Console.WriteLine("got unknown meta message type = {0}", msgtype.ToString("X2"));
            midiFile.skipBytes(length);
        }
    }

}

//Console.WriteLine("there's no sun in the shadow of the wizard");
