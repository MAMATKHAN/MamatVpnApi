using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MamatVPN.DAL.Entites
{
    public class LocationEntityV1
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string ImageName { get; set; }
    }
}
