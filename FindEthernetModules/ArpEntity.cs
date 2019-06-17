using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpArpListFinder
{
    /// <summary>
    /// Objeto que representa um equipamento
    /// </summary>
    public class ArpEntity
    {
        public string Ip { get; set; }

        public string MacAddress { get; set; }

        public string Type { get; set; }
    }
}
