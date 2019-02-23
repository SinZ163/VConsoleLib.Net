using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ReadThread
    {

        public void Thread(object obj) {
            var stream = (FancyStream)obj;
            while (true)
            {
                String packetID = Encoding.ASCII.GetString(new byte[] { stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte() });
                UInt32 version = stream.ReadInt();
                UInt16 length = stream.ReadShort();
                UInt16 handle = stream.ReadShort();
                byte[] payload = new byte[length - 12];
                stream.stream.Read(payload, 0, length - 12);
                var payloadStream = new MemoryStream(payload);
                //Console.WriteLine($"{packetID} {version} {length} {handle}");
                //Console.WriteLine("Received packet: " + packetID);
                switch (packetID)
                {
                    case "AINF":
                        var packetAINF = new Packets.PacketAINF();
                        packetAINF.ReadPacket(new FancyStream(payloadStream));
                        //Console.WriteLine(packetAINF.unknown1 + " | " + packetAINF.unknown2);
                        //Console.WriteLine(packetAINF.unknown3 + " | " + packetAINF.unknown4);
                        //Console.WriteLine(packetAINF.unknown5 + " | " + packetAINF.unknown6);
                        //Console.WriteLine(packetAINF.unknown7 + " | " + packetAINF.unknown8);
                        //Console.WriteLine(packetAINF.unknown9 + " | " + packetAINF.unknown10);
                        //Console.WriteLine(packetAINF.unknown11 + " | " + packetAINF.unknown12);
                        //Console.WriteLine(packetAINF.unknown13 + " | " + packetAINF.unknown14);
                        //Console.WriteLine(packetAINF.unknown15 + " | " + packetAINF.unknown16);
                        //Console.WriteLine(packetAINF.unknown17 + " | " + packetAINF.unknown18);
                        //Console.WriteLine(packetAINF.unknown19 + " | " + packetAINF.padding);
                        break;
                    case "ADON":
                        var packetADON = new Packets.PacketADON();
                        packetADON.ReadPacket(new FancyStream(payloadStream));
                        Console.WriteLine(packetADON.unknown);
                        Console.WriteLine(packetADON.name);
                        break;
                    case "CHAN":
                        var packetCHAN = new Packets.PacketCHAN();
                        packetCHAN.ReadPacket(new FancyStream(payloadStream));
                        foreach (Types.Channel channel in packetCHAN.channels) {
                            //This is too spammy
                            //Console.WriteLine("Channel \"" + channel.name + "\" (" + channel.ID + ")");
                        }
                        break;
                    case "PRNT":
                        var packetPRNT = new Packets.PacketPRNT(length);
                        packetPRNT.ReadPacket(new FancyStream(payloadStream));
                        Console.WriteLine("["+packetPRNT.channelID+"] "+packetPRNT.message);    
                        break;
                    case "CVAR":
                        var packetCVAR = new Packets.PacketCVAR();
                        packetCVAR.ReadPacket(new FancyStream(payloadStream));
                        //This is too spammy
                        Console.WriteLine("\"" + packetCVAR.name + "\" with range [" + packetCVAR.rangemin + ", " + packetCVAR.rangemax + "] and flags " + packetCVAR.flags);
                        break;
                    case "CFGV":
                        var packetCFGV = new Packets.PacketCFGV();
                        packetCFGV.ReadPacket(new FancyStream(payloadStream));
                        Console.WriteLine(packetCFGV.unknown);
                        break;
                    default:
                        Console.WriteLine("UNKNOWN PACKET "+ packetID + ", PANIC!!");
                        for (int i = 0; i < (length - 12); i++)
                        {
                            Console.Write(new FancyStream(payloadStream).ReadByte() + "|");
                        }
                        Console.WriteLine();
                        System.Threading.Thread.Sleep(5000);
                        break;
                }
            }      
        }
    }
}
