using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public UInt32 colour;

        public Colour()
        {
            colour = 0;
        }
        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            colour = 0;
        }
        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24); //
            UInt32 value = colour & 0xff000000;
        }
        public void SetRed(byte red)
        {
            colour = colour & 0x00ffffff;//clear red colour
            colour |= (UInt32)red << 24;
        }

        public byte GetGreen()
        {
            return (byte)((colour & 0xFF0000) >> 16);
            UInt32 value = colour & 0xFF0000;
        }
        public void SetGreen(byte green)
        {
            colour = colour & 0xFF00FFFF;//clear green colour
            colour |= (UInt32)green << 16;
        }
        public byte GetBlue()
        {
            return (byte)((colour & 0xFF00) >> 8);
            UInt32 value = colour & 0xff000000;
        }
        public void SetBlue(byte blue)
        {
            colour = colour & 0xFFFF00FF;//clear blue colour
            colour |= (UInt32)blue << 8;
        }
        public byte GetAlpha()
        {
            return (byte)((colour & 0xFF));
            UInt32 value = colour & 0xFF;
        }
        public void SetAlpha(byte alpha)
        {
            colour = colour & 0xFFFFFF00;//clear alpha colour
            colour |= (UInt32)alpha;
        }
    }
}
