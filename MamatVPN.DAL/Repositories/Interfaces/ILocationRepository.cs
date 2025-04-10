using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamatVPN.DAL.Entites;

namespace MamatVPN.DAL.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<LocationEntityV1> Get(long locationId, CancellationToken token);
        Task<LocationEntityV1> GetByServerId(long serverId, CancellationToken token);
        Task<long> Create(LocationEntityV1 entity, CancellationToken token);
        Task Update(LocationEntityV1 entity, CancellationToken token);
        Task Delete(long locationId, CancellationToken token);
    }
}
