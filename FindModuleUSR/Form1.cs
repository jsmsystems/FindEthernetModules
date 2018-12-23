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

namespace FindModuleUSR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //"$J48,99,00,FF,*46";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.20"), Convert.ToInt32(txtPorta.Text)); // endpoint where server is listening
            udpClient.Connect(endPoint);


            byte[] data = { 0xFF, 0x01, 0x01, 0x02 }; //FF 01 01 02


            //string Comando = txtComando.Text;//.Split(' ');


            // send data
            udpClient.Send(data, data.Length);


            txtReport.AppendText("\r\nSend: ");
            foreach (var item in data)
            {
                txtReport.AppendText(item.ToString("X2") + " ");
            }



            //udpClient.Send(data, data.Length);


            // then receive data
            //var receivedData = await client.ReceiveAsync();   //.Receive(ref ep);


            /*byte[]*/ data = udpClient.Receive(ref endPoint);//Recebe UDP e coloca na variavel data  
            string msgReceive = Encoding.ASCII.GetString(data);//Escreve o que foi lido





            txtReport.AppendText(string.Format("\r\nreceive data from {0}: {1}", endPoint.ToString(), msgReceive));


        }
    }
}
