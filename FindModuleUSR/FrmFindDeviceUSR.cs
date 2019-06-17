using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpArpListFinder;
using UdpLibrary;
using UsrProtocol;

namespace FindModuleUSR
{
    public partial class FrmFindDeviceUSR : Form
    {
        //
        FrmClientUDP frmClientUDP;
        FrmServerUDP frmServerUDP;
        // Cliente UDP para conexão com o Módulo
        ClientUDP UDP = new ClientUDP();
        // Lista de equipamentos
        List<ArpEntity> listArp = new List<ArpEntity>();
        //
        string IPLocal;


        public FrmFindDeviceUSR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Busca todos os equipamentos na rede (LAN). Ex.: Computadores, Celular, etc e coloca na listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_AllDevices_Click(object sender, EventArgs e)
        {
            Search_AllDevices();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSearch_TCP232_Click(object sender, EventArgs e)
        {
            Search_TCP232();
        }


        private void btnClientUDP_Click(object sender, EventArgs e)
        {
            frmClientUDP = new FrmClientUDP();
            //frmClientUDP.ShowInTaskbar = false;

            frmClientUDP.Show();
        }

        private void btnServerUDP_Click(object sender, EventArgs e)
        {
            frmServerUDP = new FrmServerUDP();
            //frmServerUDP.ShowInTaskbar = false;

            frmServerUDP.Show();
        }

        private async void Search_TCP232()
        {
            // Classe usada para listar o ARP (Todos os IP's registrados no gateway)
            ArpHelper arp = new ArpHelper();

            // Gera a lista ARP com IPs, MACs e Types dos Equipamentos Registrados na Rede.
            listArp = arp.GetArpResult();
            //
            byte[] searchCommand = { 0xFF, 0x01, 0x01, 0x02 };
            //
            byte[] basicCommmand = { 0x55, 0xC6 };

            //
            lstListDevices.Items.Clear();
            // Roda a lista ARP enviando o comando de "Search" na porta 1901.
            foreach (var device in listArp)
            {
                lstListDevices.Items.Add(GetListViewItem(device));

                // Conecta via UDP ao Device
                UDP.Connect(device.Ip, 1901, 1901);
                //
                UDP.DataReceivedInBackGround += UDP_DataReceivedInBackGround;
                // Envia um comando de busca, caso o device responda corretamente, então trata-se de um módulo USR-TCP232
                UDP.Send(searchCommand);
                //
                await Task.Delay(800);
                //
                UDP.DataReceivedInBackGround -= UDP_DataReceivedInBackGround;
                //
                UDP.Disconnect();
                //
                await Task.Delay(50);
            }
        }

        /// <summary>
        /// Busca todo e qualquer equipamento da lista ARP na LAN.
        /// </summary>
        private void Search_AllDevices()
        {
            // Classe usada para listar o ARP (Todos os IP's registrados no gateway)
            ArpHelper arp = new ArpHelper();
            // Gera a lista ARP com IPs, MACs e Types dos Equipamentos Registrados na Rede.
            listArp = arp.GetArpResult();
            //
            lstListDevices.Items.Clear();
            //
            foreach (var device in listArp)
            {
                lstListDevices.Items.Add(GetListViewItem(device));
            }
        }

        /// <summary>
        /// Recepção UPD. Recebe resposta do comando enviado para localizar um TCP232.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void UDP_DataReceivedInBackGround(object source, EventArgs e)
        {
            byte[] ret = UDP.ReadBytes();


            string xx = Search.GetStrigReturn(ret);


            //
            txtOperationLog.AppendText(string.Format("\r\n{0}", xx));


        }

        /// <summary>
        /// Insere um ArpEntity na lista.
        /// </summary>
        /// <param name="ArpEntity"></param>
        /// <returns></returns>
        public static ListViewItem GetListViewItem(ArpEntity ArpEntity)
        {
            ListViewItem listViewItem = new ListViewItem();

            // Preeche o Item principal
            listViewItem.Text = string.Format("{0}", ArpEntity.Ip);

            //Instancia o array de subitens 
            ListViewItem.ListViewSubItem[] subitems = new ListViewItem.ListViewSubItem[5];
            subitems[0] = new ListViewItem.ListViewSubItem();
            subitems[0].Text = ArpEntity.Type;
            subitems[1] = new ListViewItem.ListViewSubItem();
            subitems[1].Text = ArpEntity.MacAddress;
            subitems[2] = new ListViewItem.ListViewSubItem();
            subitems[2].Text = string.Empty;
            //Adiciona os subitens no item
            listViewItem.SubItems.AddRange(subitems);

            return listViewItem;
        }


    }
}
