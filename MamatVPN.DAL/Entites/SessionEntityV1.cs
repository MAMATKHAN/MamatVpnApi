using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamatVPN.DAL.Entites
{
    public class SessionEntityV1
    {
        public long Id { get; set; }
        public long ServerId { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset EndedOn { get; set; }
        public DateTimeOffset Duration { get; set; }
        public bool IsActive { get; set; }
    }
}
