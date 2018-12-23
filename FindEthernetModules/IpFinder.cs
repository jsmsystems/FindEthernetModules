using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace FindEthernetModules
{
    public class IpFinder
    {
        public string FindIpAddressByMacAddress(string macAddress, string currentIpAddress)
        {
            Parallel.ForEach(GetListOfSubnetIps(currentIpAddress), delegate (string s)
            {
                DeviceScanner.IsHostAccessible(s);
            });

            var arpEntities = new ArpHelper().GetArpResult();
            var ip = arpEntities.FirstOrDefault(
                a => string.Equals(
                    a.MacAddress,
                    macAddress,
                    StringComparison.CurrentCultureIgnoreCase))?.Ip;

            return ip;
        }

        /// <summary>
        /// Gera uma lista com todos os IP da faixa de IP fornecida.
        /// </summary>
        /// <param name="currentIp"></param>
        /// <returns></returns>
        private List<string> GetListOfSubnetIps(string currentIp)
        {
            var a = currentIp.Split('.');
            var lst = new List<string>();

            for (int i = 1; i <= 255; i++)
            {
                lst.Add($"{a[0]}.{a[1]}.{a[2]}.{i}");
            }

            lst.Remove(currentIp);

            return lst;
        }

        /// <summary>
        /// Retona o IP local
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            string nome = Dns.GetHostName();

            IPAddress[] ip = Dns.GetHostAddresses(nome);

            return ip[1].ToString();
        }
    }








}
