using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsrProtocol
{
    public class SendCommandModel
    {
        private string function;
        private byte head;
        private byte lenght;
        private byte command;
        private byte[] mac;// 6 bytes
        private byte[] user_Password;// 12 bytes
        private byte[] parameter;// multibytes
        private byte check;

        ///// <summary>
        ///// Comando completo, usado no BasicSettings e configuraçoes pela entrada Serial COM.
        ///// </summary>
        ///// <param name="Function"></param>
        ///// <param name="Head"></param>
        ///// <param name="Lenght"></param>
        ///// <param name="Command"></param>
        ///// <param name="Mac"></param>
        ///// <param name="User_Password"></param>
        ///// <param name="Parameter"></param>
        ///// <param name="Check"></param>
        //public SendCommandModel(string Function, byte Head, byte Lenght, byte Command, byte[] Mac, byte[] User_Password, byte[] Parameter, byte Check)
        //{
        //    function = Function;
        //    head = Head;
        //    lenght = Lenght;
        //    command = Command;
        //    mac = Mac;
        //    user_Password = User_Password;
        //    parameter = Parameter;
        //    check = Check;
        //}

        ///// <summary>
        ///// Comando Search, não é necessário envias MAC, User/Password e Parametros.
        ///// </summary>
        ///// <param name="Function"></param>
        ///// <param name="Head"></param>
        ///// <param name="Lenght"></param>
        ///// <param name="Command"></param>
        ///// <param name="Check"></param>
        //public SendCommandModel(string Function, byte Head, byte Lenght, byte Command, byte Check)
        //{
        //    function = Function;
        //    head = Head;
        //    lenght = Lenght;
        //    command = Command;
        //    check = Check;
        //}

        ///// <summary>
        ///// Comandos de ação direta, Reset, Read e Store.
        ///// </summary>
        ///// <param name="Function"></param>
        ///// <param name="Head"></param>
        ///// <param name="Lenght"></param>
        ///// <param name="Command"></param>
        ///// <param name="Mac"></param>
        ///// <param name="User_Password"></param>
        ///// <param name="Check"></param>
        //public SendCommandModel(string Function, byte Head, byte Lenght, byte Command, byte[] Mac, byte[] User_Password, byte Check)
        //{
        //    function = Function;
        //    head = Head;
        //    lenght = Lenght;
        //    command = Command;
        //    mac = Mac;
        //    user_Password = User_Password;
        //    check = Check;
        //}


        //public byte[] Search()
        //{
        //    function = "Search";
        //    head = 0xFF;
        //    lenght = 0x01;
        //    command = 0x01;
        //    check = 0x02;


        //}



        //public virtual byte[] Build()
        //{

        //}









        public string Function
        {
            get { return function; }
            set { function = value; }
        }

        public byte Head
        {
            get { return head; }
            set { head = value; }
        }

        public byte Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public byte Command
        {
            get { return command; }
            set { command = value; }
        }

        public byte[] Mac
        {
            get { return mac; }
            set { mac = value; }
        }

        public byte[] User_Password
        {
            get { return user_Password; }
            set { user_Password = value; }
        }

        public byte[] Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        public byte Check
        {
            get { return check; }
            set { check = value; }
        }


    }
}
