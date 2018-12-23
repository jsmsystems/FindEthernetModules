using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UdpLibrary;

namespace FindModuleUSR
{
    public partial class FrmFindModuleUSR : Form
    {
        ClientUDP UDP = new ClientUDP();

        public FrmFindModuleUSR()
        {
            InitializeComponent();
            //"$J48,99,00,FF,*46";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            int RemotePort = 0;

            if (int.TryParse(txtRemotePort.Text, out RemotePort))
            {
                // Conecta
                UDP.Connect(txtIP.Text, RemotePort, 65000);
                // Inicia recepção
                // UDP.MsgReceived += UDP_MsgReceived;
                //

            }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            UDP.Send("$J48,99,00,FF,*46");
        }
    }
}
