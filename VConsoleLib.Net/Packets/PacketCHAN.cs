using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Packets
{
    class PacketCHAN : IPacket
    {
        public string ID
        {
            get { return "CHAN"; }
        }

        public List<Types.Channel> channels;

        public void ReadPacket(FancyStream stream)
        {
            channels = new List<Types.Channel>();
            var len = stream.ReadShort();
            for (int i = 0; i < len; i++)
            {
                var id = stream.ReadInt();
                var unknown1 = stream.ReadInt();
                var unknown2 = stream.ReadInt();
                var verbosity_default = stream.ReadInt();
                var verbosity_current = stream.ReadInt();
                var RGBA_Override = stream.ReadInt();

                List<byte> msg = new List<byte>();
                for (int j = 0; j < 34; j++)
                {
                    msg.Add(stream.ReadByte());
                }
                var name = Encoding.ASCII.GetString(msg.ToArray());

                channels.Add(new Types.Channel(id, unknown1, unknown2, verbosity_default, verbosity_current, RGBA_Override, name));
            }
        }
    }
}
