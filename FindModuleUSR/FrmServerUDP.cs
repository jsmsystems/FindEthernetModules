using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UdpLibrary;

namespace FindModuleUSR
{
    public partial class FrmServerUDP : Form
    {
        ServerUDP serverUDP = new ServerUDP();

        public FrmServerUDP()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            byte[] msgSend = { 0xFF, 0x01, 0x01, 0x02 };

            txtReport.AppendText(ServerUDP.SendUdp(1901, "192.168.1.255", 1901, msgSend));
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            txtReport.AppendText(ServerUDP.ReceiveUdp(1901));
        }
    }
}
