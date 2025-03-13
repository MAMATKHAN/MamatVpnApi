using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamatVPN.DAL.Entites;

namespace MamatVPN.DAL.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<SessionEntityV1> Get(long sessionId, CancellationToken token);
        Task<SessionEntityV1[]> GetAll(CancellationToken token);
        Task<long> Create(SessionEntityV1 entity, CancellationToken token);
        Task Update(SessionEntityV1 entity, CancellationToken token);
        Task Delete(long sessionId, CancellationToken token);
    }
}
