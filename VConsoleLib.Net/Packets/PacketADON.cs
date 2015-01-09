using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Packets
{
    class PacketADON : IPacket
    {
        public string ID
        {
            get { return "ADON"; }
        }

        public UInt16 unknown;
        public String name;

        public void ReadPacket(FancyStream stream)
        {
            unknown = stream.ReadShort();
            var len = stream.ReadShort();
            Console.WriteLine("LENGTH" + len);
            List<byte> msg = new List<byte>();
            for (int i = 0; i < len; i++)
            {
                msg.Add(stream.ReadByte());
            }
            name = Encoding.ASCII.GetString(msg.ToArray());
        }
    }
}
