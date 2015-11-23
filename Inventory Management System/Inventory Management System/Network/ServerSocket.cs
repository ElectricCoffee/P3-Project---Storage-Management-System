using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;

namespace Inventory_Management_System.Network
{
    public class ServerSocket
    {
        private byte[] _buffer = new byte[1024];
        private Socket _socket;

        public ServerSocket() 
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void vind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));  // ipendpoint er hvilken ip der skal arbejdet på og port er den port der er i brug
        }

        public void Listen(int backlog)
        {
            _socket.Listen(500);
        }

        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallBack, null);
        }

        private void AcceptedCallBack(IAsyncResult AR)
        {
            Socket clientSocket = _socket.EndAccept(AR);
            if (clientSocket != null)
            {
                _buffer = new byte[1024];
                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, RecievedCallback, clientSocket); //Venter på at recieve information - og ligger data modtaget i "buffer",; 0 er hvor i bufferen dataren skal ligges.
                Accept();                
            }
        }

        private void RecievedCallback(IAsyncResult AR)
        {
            Socket clientsocket = AR.AsyncState as Socket;
            int buffersize = clientsocket.EndReceive(AR);

            byte[] packet = new byte[buffersize];
            Array.Copy(_buffer, packet, packet.Length);

            PacketHandler.handle(packet, clientsocket);

            _buffer = new byte[1024];
            clientsocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, RecievedCallback, clientsocket);
        }
    }
}