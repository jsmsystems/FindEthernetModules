using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;//Comunicação UDP
using System.Net.Sockets;//Comunicação UDP
using System.ComponentModel;//BackgroundWorker

namespace jsm
{
    public class udpControl
    {
        /*********************************************************
         * CONEXÃO ETHERNET (UDP CLIENT)
         *********************************************************/
        //Variaveis usadas na UDP Client 
        private UdpClient udpClient = new UdpClient();//Inicia Client UDP na Porta Específica
        private IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);//Pega IP do destinatario (ou seja, para o Modulo da USR)
        public BackgroundWorker backWorkRecv = new BackgroundWorker();//Recepção
        public BackgroundWorker backWorkEnv = new BackgroundWorker();//Envio

        private string lastSend;//Contem a ultima mensagem envida
        public string LastMessage
        {
            get { return lastSend; }
            //set { lastSend = value; }
        }

        
        
        DoWorkEventArgs e = new DoWorkEventArgs(null);

        //IP do Modulo ques e quer conectar
        private IPAddress ipDestino;
        public string IpDestino
        {
            get { return ipDestino.ToString(); }
            set { ipDestino = IPAddress.Parse(value); }//converte IP para uso interno
        }
        //Porta do Modulo que se quer conectar. Mesmo em IP diferente não podemos usar a mesma porta para todos.
        private int portaDestino;
        public string PortaDestino
        {
            get { return portaDestino.ToString(); }
            //set { portaDestino = Convert.ToInt32(value); }
        }
        private string msgReceive;
        public string MsgReceive
        {
            get { return msgReceive; }
            //não tem set neste caso! A string é preenchida dentro da classe apenas.
        }
        //Retorna true se esta conectado
        private bool isOpen = false;
        public bool IsOpen
        {
            get { return isOpen; }
        }
        private void InitializeBackgroundWorker()
        {

            //BackGraund de Recepção
            backWorkRecv.DoWork += new DoWorkEventHandler(backWorkRecv_DoWork);
            backWorkRecv.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorkRecv_RunWorkerCompleted);
            //Permite o cancelamento da Thread
            backWorkRecv.WorkerSupportsCancellation = true;
            //BackGraund informa o progresso da operação
            backWorkRecv.WorkerReportsProgress = true;

            ////BackGraund de Envio
            ////backWorkEnv.DoWork += new DoWorkEventHandler(backWorkEnv_DoWork);
            ////backWorkEnv.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorkEnv_RunWorkerCompleted);
            ////Permite o cancelamento da Thread
            //backWorkEnv.WorkerSupportsCancellation = true;
            ////BackGraund informa o progresso da operação
            //backWorkEnv.WorkerReportsProgress = true;


        }
        /*************
         * Faz a conexão da Porta UDP selecionada!
         * Utiliza os dados nas variaveis "portaDestino" e "ipDestino".
         **************/
        public string connect(string ip, string porta)
        {

            try
            {
                //Carrega o ipDestino no formato correto
                //ipDestino = IPAddress.Parse(ip);
                ipDestino = Dns.GetHostAddresses(ip)[0];//mudei pra essa forma para acitar DNS
            }
            catch (FormatException ex)
            {
                //retorna falha no formato da string do ip
                return "Erro no formato da string do IP.\r\n" +ex.Message;
            }
            try
            {
                //Carrega Porta de Destino no formato correto
                portaDestino = Convert.ToInt32(porta);
            }
            catch (FormatException ex)
            {
                //retorna falha no formato da string do ip
                return "Erro no formato da string da Porta.\r\n" + ex.Message;
            }
            try
            {
                udpClient = new UdpClient(portaDestino);//Inicia Client UDP na Porta Específica
            }
            catch (SocketException ex)
            {//Avisa sobre erro quando conecta 2x na mesma porta, mesmo que o IP seja diferente ignorar este erro!
                return "Erro ao tentar conectar.\r\n" + ex.Message;
            }
            //Esvazia a string de recepção
            msgReceive = string.Empty;


            //Conecta de fato!
            udpClient.Connect(ipDestino, portaDestino);


            //Inicializa rotinas do background
            InitializeBackgroundWorker();
            //Inicializa recepção no backgraund
            backWorkRecv.RunWorkerAsync();
            //carrega flag para indicar que esta conectado
            isOpen = true;
            //retorna informando sucesso na conexão
            return "true";
        }
        /*************
        //Faz a desconexao da Porta UDP selecionada
        **************/
        public string close()
        {

            try
            {
                //udpClient.DropMulticastGroup(IPAddress.Any);
                //Fecha conexão
                udpClient.Close();
                //udpClient = null;


                //Cancela Thread Recevive
                backWorkRecv.CancelAsync();
                backWorkRecv.DoWork -= new DoWorkEventHandler(backWorkRecv_DoWork);
                backWorkRecv.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(backWorkRecv_RunWorkerCompleted);
                backWorkRecv.Dispose();

                //Cancela Thread Envio 
                //backWorkEnv.CancelAsync();
                //backWorkEnv.DoWork -= new DoWorkEventHandler(backWorkEnv_DoWork);
                //backWorkEnv.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(backWorkRecv_RunWorkerCompleted);
                //backWorkRecv.Dispose();
                
                
                //Informa ao programa que a conexão foi fechada
                isOpen = false;
            }
            catch (Exception ex)
            {
                return "Falha ao fechar conexão UDP Client.\r\nDetalhes:" + ex.Message;
            }
            //Retorna sucesso em fechar a conexão
            return "true";
        }
        /*************
         * Faz o envio de dados pela porta UDP aberta
         * Utiliza os dados nas variaveis "portaDestino" e "ipDestino".
        **************/
        public void send(string msgSend)
        {//FAZ O ENVIO DE UMA MSG UDP
            if (isOpen)
            {
                ////Faz o envio de fato pelo UDP
                //backWorkEnv.RunWorkerAsync(msgSend);//usava este antes


                try
                {
                    //Faz o envio de fato pelo UDP
                    udpClient.SendAsync(Encoding.ASCII.GetBytes(msgSend), msgSend.Length);
                }
                catch (Exception ex)
                {
                    throw new Exception("Falha ao enviar!\r\nDetalhes:" + ex.ToString());
                }

                
                

                //Registra a ultima mensagem enviada
                lastSend = msgSend;

            }
            else
            {
                throw new Exception("Client UDP não esta conectado. Favor conectar!");
            }
        }

        /*************
         * FAZ A RECEPÇÃO EM SEGUNDO PLANO
        **************/
        private void backWorkRecv_DoWork(object sender, DoWorkEventArgs e)
        {//Faz a recepção UDP
            if (isOpen)
            {
                try
                {
                    byte[] data = udpClient.Receive(ref endPoint);//Recebe UDP e coloca na variavel data  
                    msgReceive = Encoding.ASCII.GetString(data);//Escreve o que foi lido
                }
                catch (Exception)
                {//Gera muitas excessoes aqui, mas não tem sido um problema, entao nao faço nada!
                    //throw new Exception("Não foi possivel receber os dados.\r\nDetalhes:" + ex.Message);
                }
                //catch (System.Net.Sockets.SocketException ex)
                //{
                //    //Essa excessão ocorre sempre que desconecto, mas não parece afetar o desempenho
                //    throw new Exception("Uma operação de bloqueio foi interrompida por uma chamada a WSACancelBlockingCall.\r\nDetalhes:" + ex.Message);
                //}

            }
        }
        /*************
         * VEM AQUI PARA FINALIZAR UMA RECEPÇÃO QUANDO RECEBE ALGUMA COISA
         * Deve ser criado o Metodo conforme exemplo abaixo e colocado na inicilização do form:
         * conexaoUDP.MsgReceived += conexaoUDP_MsgReceived;
        **************/
        //Evento de recepção de mensagem
        public event EventHandler MsgReceived;
        //Rotina para ativar o evento 
        protected virtual void OnMsgReceived(EventArgs e)
        {
            MsgReceived?.Invoke(this, e);
        }
        private void backWorkRecv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {//Realiza o que recebeu em BackGraund, ou seja, dados recebidos na UDP

            //Chama o evento 
            OnMsgReceived(new EventArgs());


            //while (backWorkRecv.IsBusy) ;


            if (!backWorkRecv.IsBusy && isOpen)
            {
                backWorkRecv.RunWorkerAsync();//roda novamente para recebeer as proximas msg
            }

        }
        public void TestaEvent(string MsgReceive_TextAdd)
        {
            OnMsgReceived(new EventArgs());
            msgReceive += MsgReceive_TextAdd;
        }
    }
}
