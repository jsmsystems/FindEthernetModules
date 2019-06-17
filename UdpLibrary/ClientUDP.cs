using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpLibrary
{
    //Usada na recepçao assincrona chamada por rotina que nao precisa aguardar!!!
    public delegate void DadosRecebidosEventHandler(object source, EventArgs e);

    public class ClientUDP
    {


        private UdpClient udpClient { get; set; }
        private IPEndPoint remoteEndPoint;// = new IPEndPoint(IPAddress.Any, 0); (server)
        public UdpReceiveResult result = new UdpReceiveResult();


        private bool connected;
        private int remotePort;
        private int localPort;


        /// <summary>
        /// Retorna True se a rotina de "Connect()" foi executada com sucesso.
        /// OBS: Lembrar a UDP não mantem uma "Conexão" aberta, trata-se apenas de configurar o acesso.
        /// </summary>
        public bool Connected
        {
            get { return connected; }
        }

        public int RemotePort
        {
            get { return remotePort; }
        }

        public int LocalPort
        {
            get { return localPort; }
        }

        /// <summary>
        /// Faz a "conexão" UDP com o Servidor Remoto. 
        /// </summary>
        /// <param name="RemoteIP"></param>
        /// <param name="RemotePort"></param>
        /// <param name="LocalPort"></param>
        /// <returns></returns>
        public virtual bool Connect(string RemoteIP, int RemotePort, int LocalPort)
        {
            //
            remotePort = RemotePort;
            localPort = LocalPort;
            //
            IPAddress RemoteIPAdress;
            // Tenta converter a string 'RemoteIP' em um numero IP valido.
            if (IPAddress.TryParse(RemoteIP, out RemoteIPAdress) && RemotePort < 0xFFFF && LocalPort < 0xFFFF)
            {
                // Endereço IP:Port do equipamento UDP Server (Remoto)
                remoteEndPoint = new IPEndPoint(RemoteIPAdress, RemotePort);
                // Instancia o client UDP definindo a porta local (na pratica não faz muita diferença a porta local)
                udpClient = new UdpClient(LocalPort);
                // Conecta ao endpoint (Equipamento remoto - Server)
                udpClient.Connect(remoteEndPoint);
                // Seta flag para indicar que está conectado.
                connected = true;
                // Inicia rotina de recepção em Loop
                StartReceive();
                
                //
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Conecta de forma a mandar mensagens em BroadCast, ou seja, não tem IP Remoto definidio, envia para todos na rede.
        /// </summary>
        /// <param name="RemotePort"></param>
        /// <param name="LocalPort"></param>
        /// <returns></returns>
        public virtual bool Connect(IPAddress IPAddress, int RemotePort, int LocalPort)
        {
            if (RemotePort < 0xFFFF && LocalPort < 0xFFFF)
            {
                // Endereço IP:Port do equipamento UDP Server (Remoto)
                remoteEndPoint = new IPEndPoint(IPAddress, RemotePort);
                // Instancia o client UDP definindo a porta local (na pratica não faz muita diferença a porta local)
                udpClient = new UdpClient(LocalPort);
                //
                udpClient.EnableBroadcast = true;
                // Conecta ao endpoint (Equipamento remoto - Server)
                udpClient.Connect(remoteEndPoint);
                // Seta flag para indicar que está conectado.
                connected = true;
                //
                StartReceive();             
                //
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Faz desconexão do Client UDP.
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            //
            StopReceive();
            //
            udpClient.Close();
            // Marca como desconectado antes de interromper a recepção.
            connected = false;
            //
            
            //
            return true;

        }



        /// <summary>
        /// Rotina simples de envio de dados pela UDP.
        /// </summary>
        /// <param name="Data"></param>
        public virtual void Send(string Data)
        {
            if (connected)
            {
                // Converte a string em bytes brutos
                byte[] byteData = Encoding.ASCII.GetBytes(Data);
                // Faz o envio dos bytes
                udpClient.Send(byteData, byteData.Length);
            }
        }

        /// <summary>
        /// Envia pela UDP um array de bytes.
        /// </summary>
        /// <param name="byteData"></param>
        public virtual void Send(byte[] byteData)
        {
            if (connected)
            {
                // Faz o envio dos bytes
                udpClient.Send(byteData, byteData.Length);
            }
        }

        //
        //
        // ROTINAS RELACIONADAS A RECEPÇAO EM BACKGROUND MAS CHAMADA DE FORMA SINCRONA E RECEBE POR EVENT
        //
        //
        private BackgroundWorker bkgReceiveBackground;
        public void StartReceive()
        {
            // bkgReceiveBackground de recepçao que é chamado por uma rotina sincrona.
            bkgReceiveBackground = new BackgroundWorker();
            bkgReceiveBackground.WorkerReportsProgress = true;
            bkgReceiveBackground.WorkerSupportsCancellation = true;
            bkgReceiveBackground.DoWork += new DoWorkEventHandler(bgwReceiveBackground_DoWork);
            bkgReceiveBackground.ProgressChanged += new ProgressChangedEventHandler(bgwReceiveBackground_ProgressChanged);
            bkgReceiveBackground.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwReceiveBackground_RunWorkerCompleted);
            //Inicia operçao em background
            bkgReceiveBackground.RunWorkerAsync();

        }
        private void StopReceive()
        {
            if (bkgReceiveBackground.IsBusy)
            {
                bkgReceiveBackground.CancelAsync();
                //
                bkgReceiveBackground.Dispose();
            }
        }
        //Contem as mensagens recebidas do SicosApp
        string msgRecv = string.Empty;
        //
        byte[] bytesRecv = new byte[1024];

        /// <summary>
        /// RETORNA DADOS RECEBIDOS
        /// </summary>
        /// <returns></returns>
        public virtual string Read()
        {
            // Reserva o valor da mensagem
            string reserva = msgRecv;
            // Limpa a variavel publica da mensagem
            msgRecv = string.Empty;
            // Retorna valor reservado
            return reserva;
        }

        public virtual byte[] ReadBytes()
        {
            return bytesRecv;
        }


        public virtual string ReadBytes(char Separador)
        {
            StringBuilder ret = new StringBuilder();

            foreach (var item in bytesRecv)
            {
                ret.AppendFormat(string.Format("{0:X2}{1}", item, Separador));
            }          

            return ret.ToString();
        }
        

        





        /// <summary>
        /// GERA EVENTO DE RECEPÇAO PARA SER USADO NO CODIGO DO FORM
        /// </summary>
        public event DadosRecebidosEventHandler DataReceivedInBackGround;
        public void OnDataReceivedInBackGround(EventArgs e)
        {
            if (DataReceivedInBackGround != null)
            {
                DataReceivedInBackGround.Invoke(this, e);
            }
            //Rotina chamada sempre que recebe dados pela conexao TCP
            //DataReceivedInBackGround?.Invoke(this, e);
        }
        /// <summary>
        /// OPERAÇAO DE RECEPÇAO EM BACKGROUND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReceiveBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IPEndPoint ReceiveAllRemote = new IPEndPoint(IPAddress.Any, remotePort);
                // Recebe os bytes
                bytesRecv = udpClient.Receive(ref ReceiveAllRemote);
                // Converte os bytes em String formato ASCII
                msgRecv = Encoding.ASCII.GetString(bytesRecv);
            }
            catch (Exception)
            {
                msgRecv = string.Empty;
            }

            //bytesRecv = udpClient

        }
        private void bgwReceiveBackground_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Nao estou usando ainda.
            msgRecv += "ProgressChange";
        }
        private void bgwReceiveBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (connected)
            {
                //Chama uma rotina na tread principal para colocar na tela e tratar mensagem recebida
                OnDataReceivedInBackGround(new EventArgs());
                //Inicia operçao em background
                if (connected) bkgReceiveBackground.RunWorkerAsync();
                else bkgReceiveBackground.Dispose();
            }
        }













    }
}
