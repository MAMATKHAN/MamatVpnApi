using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamatVPN.DAL.Options
{
    public class DbConnectionOption
    {
        public required string SqlLiteConnectionString { get; init; } = string.Empty;
    }
}
