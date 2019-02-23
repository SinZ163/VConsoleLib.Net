using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Packets
{
    class PacketCVAR : IPacket
    {

        public string ID
        {
            get { return "CVAR"; }
        }

        public String name;
        public UInt32 unknown;
        public UInt32 flags;
        public float rangemin;
        public float rangemax;
        public byte padding;

        public void ReadPacket(FancyStream stream)
        {
            name = stream.ReadString();
            unknown = stream.ReadInt();
            flags = stream.ReadInt();
            rangemin = stream.ReadFloat();
            rangemax = stream.ReadFloat();
            padding = stream.ReadByte();
        }
    }
}
