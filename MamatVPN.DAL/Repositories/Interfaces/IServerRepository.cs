using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamatVPN.DAL.Entites;

namespace MamatVPN.DAL.Repositories.Interfaces
{
    public interface IServerRepository
    {
        Task<long> Add(ServerEntityV1 server, CancellationToken token);
        Task<ServerEntityV1> Get(long serverId, CancellationToken token);
        Task<ServerEntityV1[]> GetAll(CancellationToken token);
        Task Update(ServerEntityV1 server, CancellationToken token);
        Task Delete(long serverId, CancellationToken token);
    }
}
