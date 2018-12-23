using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    public class ClientUDP
    {
        private UdpClient UDP { get; set; }
        private IPEndPoint endPoint;// = new IPEndPoint(IPAddress.Any, 0); (server)

        public bool Connect(string RemoteIP, int RemotePort, int LocalPort)
        {
            IPAddress RemoteIPAdress;
            // Tenta converter a string 'RemoteIP' em um numero IP valido.
            if (IPAddress.TryParse(RemoteIP, out RemoteIPAdress))
            {
                // Endereço IP:Port do equipamento UDP Server (Remoto)
                endPoint = new IPEndPoint(RemoteIPAdress, RemotePort);
                // Instancia o client UDP definindo a porta local (na pratica não faz muita diferença a porta local)
                UDP = new UdpClient(LocalPort);
                // Conecta ao endpoint (Equipamento remoto - Server)
                UDP.Connect(endPoint);
                //
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Send(string Data)
        {

            byte[] byteData = Encoding.ASCII.GetBytes(Data);

            UDP.Send(byteData, byteData.Length);
        }




    }
}
