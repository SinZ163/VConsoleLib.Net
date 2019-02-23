using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class FancyStream
    {
        public Stream stream;

        public FancyStream(Stream stream)
        {
            this.stream = stream;
        }
        public UInt32 ReadInt()
        {
            var a = (byte) stream.ReadByte();
            var b = (byte) stream.ReadByte();
            var c = (byte) stream.ReadByte();
            var d = (byte) stream.ReadByte();
            return BitConverter.ToUInt32(new byte[4] { d, c, b, a }, 0);
        }
        public UInt16 ReadShort()
        {
            var a = (byte)stream.ReadByte();
            var b = (byte)stream.ReadByte();
            return BitConverter.ToUInt16(new byte[2] { b, a }, 0);
        }
        public byte ReadByte()
        {
            return (byte)stream.ReadByte();
        }
        public float ReadFloat()
        {
            byte a = (byte)stream.ReadByte();
            byte b = (byte)stream.ReadByte();
            byte c = (byte)stream.ReadByte();
            byte d = (byte)stream.ReadByte();

            return BitConverter.ToSingle(new byte[4] { d, c, b, a }, 0);
        }
        public string ReadString()
        {
            var list = new List<byte>();
            while (true)
            {
                var character = (byte)stream.ReadByte();
                if (character == 0x00)
                {
                    break;
                }
                list.Add(character);
            }
            return Encoding.ASCII.GetString(list.ToArray());
        }

        public void WriteInt(UInt32 value)
        {
            byte[] bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
            stream.Write(bytes, 0, bytes.Length);
        }
        public void WriteShort(UInt16 value)
        {
            byte[] bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
            stream.Write(bytes, 0, bytes.Length);
        }
        public void WriteByte(byte value)
        {
            stream.WriteByte(value);
        }
        public void Flush()
        {
            stream.Flush();
        }
    }
}
