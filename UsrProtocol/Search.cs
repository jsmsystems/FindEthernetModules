using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsrProtocol
{
    public static class Search
    {


        public static byte[] CommandSend()
        {
            byte[] send = { 0xFF, 0x01, 0x01, 0x02 };

            return send;

        }

        public static string GetStrigReturn(byte[] SearchReturn)
        {
            StringBuilder buildReturn = new StringBuilder();


            buildReturn.AppendFormat("TAG_STATUS: {0}", SearchReturn[0]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Packet_length: {0}", SearchReturn[1]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("CMD_DISCOVER_TARGET: {0}", SearchReturn[2]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Board_type: {0}", SearchReturn[3]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Board_ID: {0}", SearchReturn[4]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Client_IP_address: {0}.{1}.{2}.{3}", SearchReturn[5], SearchReturn[6], SearchReturn[7], SearchReturn[8]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("MAC_address: {0:x2} {1:x2} {2:x2} {3:x2} {4:x2} {5:x2}", SearchReturn[9], SearchReturn[10], SearchReturn[11], SearchReturn[12], SearchReturn[13], SearchReturn[14]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Firemware_version: {0:X2} {1:X2} {2:X2} {3:X2}", SearchReturn[15], SearchReturn[16], SearchReturn[17], SearchReturn[18]);
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Application_title: {0}", Encoding.ASCII.GetString(SearchReturn, 19, 16));
            buildReturn.AppendLine();
            buildReturn.AppendFormat("Checksum: {0:X2}", SearchReturn[35]);

            return buildReturn.ToString();
        } 




    }
}
