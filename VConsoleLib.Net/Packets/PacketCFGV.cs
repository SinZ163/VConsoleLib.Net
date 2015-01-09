using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Packets
{
    class PacketCFGV : IPacket
    {
        public string ID
        {
            get { return "CFGV"; }
        }

        public byte[] unknown;

        public void ReadPacket(FancyStream stream)
        {
            var info = new List<byte>();
            for (int i = 0; i < 129; i++)
            {
                info.Add(stream.ReadByte());
            }
            unknown = info.ToArray();
        }
    }
}
