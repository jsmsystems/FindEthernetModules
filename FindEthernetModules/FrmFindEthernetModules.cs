using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpArpListFinder
{
    public partial class FrmFindEthernetModules : Form
    {

        // Lista de equipamentos
        List<ArpEntity> listArp = new List<ArpEntity>();
        //
        string IPLocal;

        public FrmFindEthernetModules()
        {
            InitializeComponent();
            // Carrega variavel com o IP da maquina onde este programa for executado.
            IPLocal = IpFinder.GetLocalIP();
            //
            this.Text = string.Format("Find Ethernet Modules - IP Local: {0}", IPLocal);

        }

        /// <summary>
        /// Printa na tela a lista ARP. Semelhante à 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArpList_Click(object sender, EventArgs e)
        {
            // Classe usada para listar o ARP (Todos os IP's registrados no gateway)
            ArpHelper arp = new ArpHelper();
            
            // Gera a lista ARP.
            listArp = arp.GetArpResult();
            //
            txtResult.Clear();
            //
            txtResult.AppendText(string.Format("Lista de Equipamentos Encontrados:\r\n"));
            //
            foreach (var item in listArp)
            {
                // Exibe os dados do equipamento
                txtResult.AppendText(string.Format("\r\nIP: {0},   MAC: {1},    Type: {2}", item.Ip, item.MacAddress, item.Type));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Se o campo não é nulo
            if (!string.IsNullOrEmpty(txtMacAddress.Text))
            {
                if (MessageBox.Show("Este processo pode demorar alguns minutos. Continuar?") == DialogResult.OK)
                {
                    IpFinder ip = new IpFinder();


                    // Busca o IP do equipamento que tem o MAC informado, dentro da faixa de IP do IP informado.
                    string IPLocalizado = ip.FindIpAddressByMacAddress(txtMacAddress.Text, IPLocal);

                    // Busca em toda a faixa de IP da rede o MAC informado.
                    txtResult.AppendText(string.Format("\r\nMAC Adress: \"{0}\" => IP: {1} ", txtMacAddress.Text, IPLocalizado));

                }
            }
            else
            {
                MessageBox.Show("Informe antes o MAC Adress que será pesquisado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
