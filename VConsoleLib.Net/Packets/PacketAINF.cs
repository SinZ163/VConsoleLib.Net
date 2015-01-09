using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Packets
{
    class PacketAINF : IPacket
    {
        public string ID
        {
            get { return "AINF"; }
        }
        public UInt32 unknown1;
        public UInt32 unknown2;
        public UInt32 unknown3;
        public UInt32 unknown4;
        public UInt32 unknown5;
        public UInt32 unknown6;
        public UInt32 unknown7;
        public UInt32 unknown8;
        public UInt32 unknown9;
        public UInt32 unknown10;
        public UInt32 unknown11;
        public UInt32 unknown12;
        public UInt32 unknown13;
        public UInt32 unknown14;
        public UInt32 unknown15;
        public UInt32 unknown16;
        public UInt32 unknown17;
        public UInt32 unknown18;
        public UInt32 unknown19;
        public byte padding;


        public void ReadPacket(FancyStream stream)
        {
            unknown1   = stream.ReadInt();
            unknown2   = stream.ReadInt();
            unknown3   = stream.ReadInt();
            unknown4   = stream.ReadInt();
            unknown5   = stream.ReadInt();
            unknown6   = stream.ReadInt();
            unknown7   = stream.ReadInt();
            unknown8   = stream.ReadInt();
            unknown9   = stream.ReadInt();
            unknown10  = stream.ReadInt();
            unknown11  = stream.ReadInt();
            unknown12  = stream.ReadInt();
            unknown13  = stream.ReadInt();
            unknown14  = stream.ReadInt();
            unknown15  = stream.ReadInt();
            unknown16  = stream.ReadInt();
            unknown17  = stream.ReadInt();
            unknown18  = stream.ReadInt();
            unknown19  = stream.ReadInt();
            padding = stream.ReadByte();
        }
    }
}
