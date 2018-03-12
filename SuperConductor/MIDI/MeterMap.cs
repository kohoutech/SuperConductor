/* ----------------------------------------------------------------------------
Transonic MIDI Library
Copyright (C) 1995-2018  George E Greaney

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

namespace Transonic.MIDI
{
    public class MeterMap
    {
        public List<Meter> meters;
        public int count;

        public MeterMap()
        {
            meters = new List<Meter>();
            Meter meter = new Meter(0, 6, 8, 0);
            meters.Add(meter);
            count = 1;
        }
    }

//-----------------------------------------------------------------------------

    public class Meter
    {
        public int tick;        //tick which the meter change occurs at
        public int numer;
        public int denom;
        public int keysig;
        public int measure;

        public Meter(int _tick, int _numer, int _denom, int _keysig)
        {
            tick = _tick;
            numer = _numer;
            denom = _denom;
            keysig = _keysig;
            measure = 0;
        }
    }
}
