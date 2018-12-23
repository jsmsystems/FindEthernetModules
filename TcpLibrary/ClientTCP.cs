using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.ComponentModel;

namespace JSM.TcpLibrary
{


    //Usada na recepçao assincrona chamada por rotina que nao precisa aguardar!!!
    public delegate void DadosRecebidosEventHandler(object source, EventArgs e);

    public class ClientTCP
    {

        public TcpClient TCP { get; set; }
        public CancellationTokenSource cancellationTokenSource { get; set; }
        public NetworkStream networkStream { get; set; }
        //IP do Client
        public IPAddress IP
        {
            get { return ((IPEndPoint)TCP.Client.RemoteEndPoint).Address; }
        }
        //Retorna se o cliente esta conectado ao servidor ou não
        public bool Connected
        {
            get { return TCP!=null? TCP.Connected : false; }
        }
        //Endereço MAC no caso de ser um Controlador
        public int MAC { get; set; }
        //O Cliente será confirmado se responder a pergunta do servidor.
        public bool Confirmed { get; set; }
        //Recepçao iniciada
        public bool ReceiveStarted { get; set; }
        //Controle de Fila iniciado
        public bool QueueManagerStarted { get; set; }



        /// <summary>
        /// EVENTO USADO PARA INFORMAR QUANDO A CONEXÃO FOI EFETIVADA AO USAR A RETINA "Connect".
        /// </summary>
        public event EventHandler ConnectedEvent;
        private void OnConnectedEvent(EventArgs e)
        {
            ConnectedEvent?.Invoke(this, e);
        }

        //
        //
        // ROTINAS RELACIONADAS A CONEXÃO E DESCONEXÃO
        //
        //
        public async Task Connect(string hostIP, int port)
        {

            //Cria instacia da classe 
            TCP = new TcpClient();
            //Inicia tentativa de conexão asincrona
            await TCP.ConnectAsync(hostIP, port);
            //Se a conexão foi bem sucedida inicia a recepçao.
            if (Connected)
            {
                // Gera evento informando que conectou.
                OnConnectedEvent(new EventArgs());
                // Inicia recepção
                StartReceive();
            }
            else
            {
                //Se não vai iniciar a recepçao, entao é melhor desconectar.
                TCP.Close();
                //
                //TCP = null;
            }
            //}
            //catch (SocketException)
            //{
            //    //Tentativa de conexao falhou, Servidor esta desligado
            //    return false;
            //}
            //catch (ObjectDisposedException)
            //{
            //    //Objeto descartado, desconexão feita de forma errada.
            //    return false;
            //}
        }


        /// <summary>
        /// EVENTO USADO PARA INFORMAR QUANDO A CONEXÃO FOI EFETIVADA AO USAR A RETINA "Connect".
        /// </summary>
        public event EventHandler DisconnectEvent;
        private void OnDisconnectEvent(EventArgs e)
        {
            DisconnectEvent?.Invoke(this, e);
        }

        // Desconecta cliente TCP
        public bool Disconnect()
        {
            //
            StopReceive();
            //Fecha cliente
            TCP.Close();

            if (!TCP.Connected)
            {
                // Chama evento informando que foi desconectado!
                OnDisconnectEvent(new EventArgs());
                // Desconectado com sucesso
                return true;
            }
            else
            {
                // Desconexão falhou.
                return false;
            }
        }
        //
        //
        // ROTINAS RELACIONADAS AO ENVIO
        //
        //
        public virtual string Send(string text)
        {
            int tamBuff = 1024;
            byte[] bytesSend = new byte[tamBuff];
            try
            {
                if (Connected)
                {
                    //Converte a mensagem em Bytes
                    bytesSend = Encoding.ASCII.GetBytes(text);
                    //Envia através do túnel de stream do TCP
                    networkStream.Write(bytesSend, 0, bytesSend.Length);
                    //Retorna texto enviado para uso em rotinas de log.
                    return text;
                }
            }
            catch
            {
                //Se houve falha, faz a desconexão
                Disconnect();
            }
            //Retorna vario pois não enviou nada.
            return string.Empty;
        }


        public virtual bool Send(string text, out string txtReturn)
        {
             
            int tamBuff = 1024;
            byte[] bytesSend = new byte[tamBuff];
            try
            {
                if (Connected)
                {
                    //Converte a mensagem em Bytes
                    bytesSend = Encoding.ASCII.GetBytes(text);
                    //Envia através do túnel de stream do TCP
                    networkStream.Write(bytesSend, 0, bytesSend.Length);
                    //Retorna texto enviado para uso em rotinas de log.
                    txtReturn = text;
                    return true;
                }
            }
            catch
            {
                //Se houve falha, faz a desconexão
                Disconnect();
            }
            //Retorna vario pois não enviou nada.
            txtReturn = string.Empty;
            return false;
        }


        //
        //
        // ROTINAS RELACIONADAS A RECEPÇAO EM BACKGROUND MAS CHAMADA DE FORMA SINCRONA E RECEBE POR EVENT
        //
        //
        private BackgroundWorker bkgReceiveBackground;
        public void StartReceive()
        {
            //Cria fluxo de conexão (stream)           
            networkStream = TCP.GetStream();
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
            //Fecha stream do client
            if (TCP.Connected) TCP.GetStream().Close();
            //Fecha canal
            networkStream.Close();
        }
        //Contem as mensagens recebidas do SicosApp
        string msgRecv = string.Empty;
        int count = 0;
        /// <summary>
        /// RETORNA DADOS RECEBIDOS
        /// </summary>
        /// <returns></returns>
        public virtual string Read()
        {
            //Reserva o valor da mensagem
            string reserva = msgRecv;
            //limpa a variavel publica da mensagem
            msgRecv = string.Empty;
            //retorna valor reservado
            return reserva;
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
            int tamBuff = 1024;
            byte[] bytesRecv = new byte[tamBuff];

            
            try
            {

                if (Connected)
                {
                    //Recebe os dados do Cliente em Bytes
                    count = networkStream.Read(bytesRecv, 0, bytesRecv.Length);
                    //Decodifica os bytes em careteres ASCII
                    msgRecv = Encoding.ASCII.GetString(bytesRecv, 0, count);
                }
            }
            catch (IOException)
            {
                //Quando ocorre é pq o servidor foi fechado e portanto devo fechar o cliente
                count = 0;
            }

        }
        private void bgwReceiveBackground_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Nao estou usando ainda.
            msgRecv += "ProgressChange";
        }
        private void bgwReceiveBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (count != 0)
            {
                //Chama uma rotina na tread principal para colocar na tela e tratar mensagem recebida
                OnDataReceivedInBackGround(new EventArgs());
                //Inicia operçao em background
                if (Connected) bkgReceiveBackground.RunWorkerAsync();
                else bkgReceiveBackground.Dispose();
             
            }
            else
            {
                //Conexao foi interrompida

            }
        }
    }











    public class tcpClientTools
    {

        /// <summary>
        /// Retorna um string com o valor do IP do DNS resolvido
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public IPAddress GetDnsResolve(string hostname = "127.0.0.1")
        {
            //Resolvo o IP do DNS fornecido
            IPAddress[] ips = Dns.GetHostAddresses(hostname);
            //Retorno string do tipo 192.168.1.53 do IP do DNS informado
            return ips[0];

        }
    }








}
