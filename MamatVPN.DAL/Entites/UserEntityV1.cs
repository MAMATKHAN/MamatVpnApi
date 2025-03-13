using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamatVPN.DAL.Entites
{
    public class UserEntityV1
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
