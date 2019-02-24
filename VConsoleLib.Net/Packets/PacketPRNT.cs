using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Packets
{
    class PacketPRNT : IPacket
    {
        public string ID
        {
            get { return "PRNT"; }
        }

        public UInt32 channelID;
        public byte[] unknown;
        public String message;

        public void ReadPacket(FancyStream stream)
        {
            channelID = stream.ReadInt();
            var info = new List<byte>();
            for (int i = 0; i < 24; i++)
            {
                info.Add(stream.ReadByte());
            }
            unknown = info.ToArray();
            message = stream.ReadString();
        }
    }
}
