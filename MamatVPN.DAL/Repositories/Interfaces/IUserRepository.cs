using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamatVPN.DAL.Entites;

namespace MamatVPN.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntityV1> Get(long userId, CancellationToken token);
        public Task<long> Create(UserEntityV1 entity, CancellationToken token);
        public Task Update(UserEntityV1 entity, CancellationToken token);
        public Task Delete(long userId, CancellationToken token);
    }
}
