using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    public class ServerUDP
    {



        //private Socket UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //private IPAddress Target_IP;
        //private int Target_Port;
        //public static int bPause;

        //public ServerUDP()
        //{
        //    Target_IP = IPAddress.Parse("192.168.1.255");
        //    Target_Port = 1901;

        //    try
        //    {
        //        IPEndPoint LocalHostIPEnd = new
        //        IPEndPoint(IPAddress.Any, Target_Port);
        //        UDPSocket.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, 1);
        //        UDPSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
        //        UDPSocket.Bind(LocalHostIPEnd);
        //        UDPSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 0);
        //        UDPSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new
        //        MulticastOption(Target_IP));
        //        Console.WriteLine("Starting Recieve");
        //        Recieve();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message + " " + e.StackTrace);
        //    }
        //}

        //private void Recieve()
        //{
        //    try
        //    {
        //        IPEndPoint LocalIPEndPoint = new
        //        IPEndPoint(IPAddress.Any, Target_Port);
        //        EndPoint LocalEndPoint = (EndPoint)LocalIPEndPoint;
        //        StateObject state = new StateObject();
        //        state.workSocket = UDPSocket;
        //        Console.WriteLine("Begin Recieve");
        //        UDPSocket.BeginReceiveFrom(state.buffer, 0, state.BufferSize, 0, ref LocalEndPoint, new AsyncCallback(ReceiveCallback), state);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        //private void ReceiveCallback(IAsyncResult ar)
        //{

        //    IPEndPoint LocalIPEndPoint = new
        //    IPEndPoint(IPAddress.Any, Target_Port);
        //    EndPoint LocalEndPoint = (EndPoint)LocalIPEndPoint;
        //    StateObject state = (StateObject)ar.AsyncState;
        //    Socket client = state.workSocket;
        //    int bytesRead = client.EndReceiveFrom(ar, ref LocalEndPoint);



        //    client.BeginReceiveFrom(state.buffer, 0, state.BufferSize, 0, ref LocalEndPoint, new AsyncCallback(ReceiveCallback), state);
        //}


        //public class StateObject
        //{
        //    public int BufferSize = 512;
        //    public Socket workSocket;
        //    public byte[] buffer;

        //    public StateObject()
        //    {
        //        buffer = new byte[BufferSize];
        //    }
        //}





        public static string SendUdp(int srcPort, string dstIp, int dstPort, byte[] data)
        {
            byte[] read;
            StringBuilder retorno = new StringBuilder();

            using (UdpClient c = new UdpClient(srcPort))
            {
                c.Send(data, data.Length, dstIp, dstPort);

                var IEP = new IPEndPoint(IPAddress.Broadcast, dstPort);


                read = c.Receive(ref IEP);

            }


            foreach (var item in read)
            {
                retorno.AppendFormat("{0:X2} ", item);
            }


            return retorno.ToString();

        }



        public static string ReceiveUdp(int srcPort)
        {
            byte[] read;
            StringBuilder retorno = new StringBuilder();

            using (UdpClient c = new UdpClient(srcPort))
            {
                c.EnableBroadcast = true;
                var IEP = new IPEndPoint(IPAddress.Broadcast, 0);

                read = c.Receive(ref IEP);

            }


            foreach (var item in read)
            {
                retorno.AppendFormat("{0:X2} ", item);
            }


            return retorno.ToString();

        }



    }
}
