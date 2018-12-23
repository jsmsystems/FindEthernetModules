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

    //Este é o arquivo de classe novo. 08/03/2018

    public class ServerTCP
    {
        //Chama construto da classe que fornce o server
        protected TcpListener tcpListener;
        /// <summary>
        /// Esta classe com o mesmo nome da classe permite que ao criar uma instancia da classe isso seja feito atribuindo valores da porta e cria instancia do TcpListener
        /// Controladores porta 60500
        /// SicosApp porta 60100
        /// </summary>
        /// <param name="setPort"></param>
        public ServerTCP(int setPort)
        {
            //Seta variavel com o numero da porta que será do Host
            port = setPort;
        }
        /// <summary>
        /// Cria instancia do TcpListener com a porta informada. Não criar diretamente.
        /// </summary>
        private void tcpListenerCreateInstance()
        {
            //destroi instancia caso já exista
            if (tcpListener != null) tcpListener = null;
            //Cria instancia
            tcpListener = new TcpListener(IPAddress.Any, port);
        }


        /// <summary>
        /// Informa se há clientes pendentes de conexão no servidor.
        /// </summary>
        public bool Pending { get { return tcpListener.Pending(); } }

        //Port só pode ser settado internamente através de uma funçao.
        //Porta Controladores 60500
        //Porta SicosApp 60100
        //Inicia com uma porta padrão para evitar erros
        private int port = 60500;
        /// <summary>
        /// Porta do Servidor (Host) ao qual os clientes devem se conmectar.
        /// </summary>
        public int Port { get { return port; } }

        
        private bool started;
        /// <summary>
        /// Informa se o servidor já foi iniciado.
        /// </summary>
        public bool Started  { get { return started; } }

        
        //Lista publica de clientes aceitos. Classe JSM.
        public List<ClientTCP> clientList = new List<ClientTCP>();


        /// <summary>
        /// INICIA SERVIDOR COM A PORTA JÁ DEFINIDA NA INSTANCIAÇÃO DA CLASSE SERVERTCP
        /// </summary>
        /// <returns></returns>
        public virtual async Task Start()
        {
            //
            tcpListener = new TcpListener(IPAddress.Any, port);
            //Inicia operação servidor
            tcpListener.Start();
            //Aguarda 5 segundos para permitir tempo há dos clientes localizarem o Servidor recem iniciado
            await Task.Delay(5000);
            //
            started = true;
        }
        /// <summary>
        /// INICIA O SERVIDOR TCP/IP NO IP E PORTA JÁ DEFINIDOS NAS VARIAVEIS DA CLASSE
        /// </summary>
        /// <param name="Port">Padrão: 60500</param>
        public virtual async Task Start(int _portHost)
        {
            //
            port = _portHost;
            //
            await Start();
        }


        /// <summary>
        /// ENCERRA O SERVIDOR TCP CRIADO COM A FUNÇÃO START()
        /// </summary>
        public void Stop()
        {
            //Limpa lista de clientes
            ClearClientList();
            //Paraliza o Servidor. Obs: não fecha os clientes.
            tcpListener.Stop();
            //Flha indica que servidor não esta iniciado.
            started = false;
        }

        /// <summary>
        /// DESCONECTA TODOS OS CLIENTES E LIMPA A LISTA
        /// </summary>
        private void ClearClientList()
        {
            //Varre toda a lista em busca de clientes conectados e faz a desconexao.
            foreach (var client in clientList)
            {
                //Fecha o stream de conexão
                client.networkStream.Close();
                //Desconecta o client
                if (client.Connected) client.Disconnect();
                

            }
            //Limpa lista
            clientList.Clear();
        }

        /// <summary>
        /// ACEITADOR GENÉRICO DE CLIENTES PENDENTES. ACEITA UM CLIENTE E O RETORNA CASO EXISTA. USO PRIVADO.
        /// </summary>
        /// <param name="_server"></param>
        /// <returns>Retona o TcpClient conectado ou nulo se não conectou.</returns>
        private async Task<TcpClient> AcceptClient(TcpListener _server)
        {
            //Client genérico
            TcpClient client = new TcpClient();
            //Verifica se Servidor existe e Clientes Pendentes
            if (_server != null && _server.Pending())
            {
                //Aceita qualquer cliente
                client = await _server.AcceptTcpClientAsync();
                //Aguarda até 5segundos para estabelecer a conexão
                for (int i = 0; i < 50 && !client.Connected; i++) await Task.Delay(100);
            }
            //Confirma se conectou e reorna o client
            if (client.Connected) return client;
            //Se nao conectou retorna nulo
            else return null;

        }

        /// <summary>
        /// Aceito todos os clientes pendentes e coloco na Lista de clients.
        /// Os clientes aceitos preechem a lista "clientList"
        /// </summary>
        /// <returns></returns>
        public async Task AddAllPendingClients()
        {
            //Cliente generico da classe JSM
            ClientTCP newClientTCP;
            //Passa todos os Pendentes em busca do IP solicitado
            while (tcpListener.Pending())
            {
                //Cria instancia de um cliente genérico
                newClientTCP = new ClientTCP();
                //Cria instacia da classe 
                newClientTCP.TCP = new TcpClient();
                //Aceita cliente pendente
                newClientTCP.TCP = await AcceptClient(tcpListener);
                //Verifica se conectou
                if (newClientTCP.Connected)
                {
                    //Adiciona o "Túnel de conexão" para receber dados
                    newClientTCP.networkStream = newClientTCP.TCP.GetStream();
                    //Inicia recepçao em background
                    newClientTCP.StartReceive();
                    //Executa uma leitura para limpar buffer.
                    //newClientTCP.Read();
                    //Cria instancia do gerador de eventos de reçepçao.
                    //newClientTCP.DataReceivedInBackGround += NewClientTCP_DataReceivedInBackGround;
                    //Adiciona na lista de Clientes
                    clientList.Add(newClientTCP);
                    //
                }
                //Destroi a instancia para ser recriada para outro client
                newClientTCP = null;
            }

        }



        /// <summary>
        /// Busca e remove os clientes listados que não estiverem conectados.
        /// </summary>
        /// <param name="RemovedClients"></param>
        public void RemoveAllDisconnectedClients(out List<string> RemovedClients)
        {
            RemovedClients = new List<string>();

            for (int i = 0; i < clientList.Count; i++)
            {
                try
                {
                    if (!clientList[i].Connected)
                    {
                        //Log.print(txtLogSicosAppConector, Log.tipo.Controlador, string.Format("\r\nCliente[{0}] :{1} - removido.", i, ServerTCP.clientList[i].IP));
                        RemovedClients.Add(string.Format("Cliente[{0}] :{1} - removido.", i, clientList[i].IP));
                        //Cliente removido.
                        clientList.RemoveAt(i);
                        //Garante o reinicio da busca para evitar de pular algum cliente após uma remoção e reorganização da fila.
                        i = 0;
                    }
                }
                catch (Exception ex)
                {
                    //Se o objeto já tiver sido descartado
                    RemovedClients.Add(string.Format("\r\nLimpeza: Cliente[{0}] - removido. {1}", i, ex.Message));
                    //Cliente removido.
                    clientList.RemoveAt(i);
                    //Garante o reinicio da busca para evitar de pular algum cliente após uma remoção e reorganização da fila.
                    i = 0;
                }
            }
        }


        public void RemoveDisconnectedClient()
        {

        }







    }

}
