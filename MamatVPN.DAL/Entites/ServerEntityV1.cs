using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamatVPN.DAL.Entites
{
    public class ServerEntityV1
    {
        public long Id { get; set; }
        public long LocationId { get; set; }
        public string Name { get; set; }
        public string IpAdress { get; set; }
    }
}
