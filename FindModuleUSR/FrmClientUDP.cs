using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UdpLibrary;

namespace FindModuleUSR
{
    public partial class FrmClientUDP : Form
    {
        ClientUDP UDP = new ClientUDP();


        byte[] username = { 0x61, 0x64, 0x6D, 0x69, 0x6E, 0x00 };
        byte[] password = { 0x61, 0x64, 0x6D, 0x69, 0x6E, 0x00 };
        byte[] ucUserMAC = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };


        public FrmClientUDP()
        {
            InitializeComponent();
            //"$J48,99,00,FF,*46";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!UDP.Connected)
            {
                Conectar();  
            }
            else
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Faz a conexão com o Server UDP
        /// </summary>
        private void Conectar()
        {
            int RemotePort = 0;
            int LocalPort = 0;

            if (int.TryParse(txtRemotePort.Text, out RemotePort) && int.TryParse(txtLocalPort.Text, out LocalPort))
            {
                // Conectar em BroadCast
                if (rdBroadCast.Checked)
                {
                    UDP.Connect(IPAddress.Broadcast, RemotePort, LocalPort);
                }
                else if (rdAny.Checked)
                {
                    UDP.Connect(IPAddress.Any, RemotePort, LocalPort);
                }
                // Conecta a um IP Remoto Especificado.
                else
                {
                    UDP.Connect(txtIP.Text, RemotePort, LocalPort);
                }
                //
                UDP.DataReceivedInBackGround += UDP_DataReceivedInBackGround;
                //
                btnConnect.Text = "Disconnect";
                btnSend.Enabled = true;
            }
        }

        private void Desconectar()
        {
            // Efetivamente desconecta
            UDP.Disconnect();
            // Finaliza a rotina de eventos de recepção
            UDP.DataReceivedInBackGround -= UDP_DataReceivedInBackGround;
            //
            btnConnect.Text = "Connect";
            btnSend.Enabled = false;
        }



        private void UDP_DataReceivedInBackGround(object source, EventArgs e)
        {
            if (chkHex.Checked)
            {
                byte[] recv = UDP.ReadBytes();
                txtReport.AppendText("\r\nReceived:");

                foreach (var item in recv)
                {
                    txtReport.AppendText(string.Format(" {0:X2}", item));
                }               
            }
            else
            {
                txtReport.AppendText(string.Format("\r\nReceived: {0}", UDP.Read()));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (UDP.Connected)
            {
                // Envia os dados como um array de bytes, devem ser separados por espaço
                if (chkHex.Checked)
                {
                    //
                    string[] bytesASCII = txtComando.Text.Split(' ');
                    //
                    byte result;
                    List<byte> listBytes = new List<byte>();
                    // Cria a lista de bytes para enviar.
                    foreach (var item in bytesASCII)
                    {
                        //
                        if (byte.TryParse(item, NumberStyles.HexNumber, null, out result))
                        {
                            listBytes.Add(result);
                        }
                    }

                    // Mostra o que foi enviado.
                    txtReport.AppendText("\r\nByte:");
                    foreach (var item in listBytes)
                    {
                        txtReport.AppendText(string.Format(" {0:X2}", item));
                    }

                    UDP.Send(listBytes.ToArray());

                }
                // Envia como string em formato ASCII
                else
                {
                    //
                    txtReport.AppendText(string.Format("\r\nString: {0}", txtComando.Text));
                    //
                    UDP.Send(txtComando.Text);
                }

            }
            else
            {
                // Aviso de conectar!
            }

            
        }

        private void rdIPDestino_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = rdIPDestino.Checked;
        }
    }
}
