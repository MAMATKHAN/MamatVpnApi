using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamatVPN.DAL.Entites;

namespace MamatVPN.DAL.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<AdminEntityV1> Get(long adminId, CancellationToken token);
        Task<AdminEntityV1?> GetByUserId(long userId, CancellationToken token);
        Task<long> Create(AdminEntityV1 entity, CancellationToken token);
        Task Update (AdminEntityV1 entity, CancellationToken token);
        Task Delete (long adminId, CancellationToken token);
    }
}
