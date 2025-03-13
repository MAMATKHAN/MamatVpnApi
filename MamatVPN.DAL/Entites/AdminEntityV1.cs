using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamatVPN.DAL.Entites
{
    public class AdminEntityV1
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
