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

        public string unknown;

        public void ReadPacket(FancyStream stream)
        {
            unknown = stream.ReadString();
        }
    }
}
