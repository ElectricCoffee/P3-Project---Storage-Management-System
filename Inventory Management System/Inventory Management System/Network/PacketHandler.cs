using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Network
{
    public static class PacketHandler
    {
        public static void handle(byte[] packet, Socket ClientSocket)
        {

            ushort packetlength = BitConverter.ToUInt16(packet, 0); 
            ushort packetType = BitConverter.ToUInt16(packet, 2);

            Console.WriteLine("Received packet! Length: {0} | type: {1}", packetlength, packetType);

        }
    }
}
