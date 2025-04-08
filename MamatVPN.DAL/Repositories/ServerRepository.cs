using MamatVPN.DAL.Entites;
using MamatVPN.DAL.Options;
using MamatVPN.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Dapper;

namespace MamatVPN.DAL.Repositories
{
    public class ServerRepository : SqliteRepository, IServerRepository
    {
        public ServerRepository(IOptions<DbConnectionOptions> options) : base(options.Value) { }

        public async Task<long> Add(ServerEntityV1 server, CancellationToken token)
        {
            const string sql = @"
insert into Servers(Name, IpAddress, LocationId)
       values(@Name, @IpAddress, @LocationId)
returning id;
";

            await using var connection = await GetConnectionAsync();
            var cmd = new CommandDefinition(sql, server, cancellationToken: token);
            var id = await connection.QuerySingleAsync<long>(cmd);

            return id;
        }

        public async Task Delete(long serverId, CancellationToken token)
        {
            const string sql = @"
delete from Servers
 where Id = @Id;
";
            await using var connection = await GetConnectionAsync();
            var cmd = new CommandDefinition(sql, new {Id = serverId}, cancellationToken: token);

            await connection.ExecuteAsync(cmd);
        }

        public async Task<ServerEntityV1> Get(long serverId, CancellationToken token)
        {
            const string sql = @"
select Id
       ,Name
       ,IpAddress
       ,LocationId
  from Servers
 where Id = @Id;
";

            await using var connection = await GetConnectionAsync();
            var cmd = new CommandDefinition(sql, new { Id = serverId }, cancellationToken: token);

            return await connection.QuerySingleAsync<ServerEntityV1>(cmd);
        }

        public async Task<ServerEntityV1[]> GetAll(CancellationToken token)
        {
            const string sql = @"
select Id
       ,Name
       ,IpAddress
       ,LocationId
  from Servers;
";

            await using var connection = await GetConnectionAsync();
            var cmd = new CommandDefinition(sql, cancellationToken: token);

            return (await connection.QueryAsync<ServerEntityV1>(cmd)).ToArray();
        }

        public async Task Update(ServerEntityV1 server, CancellationToken token)
        {
            const string sql = @"
update Servers
   set Name = @Name
       IpAddress = @IpAddress
       LocationId = @LocationId
 where Id = @Id;
";
            await using var connection = await GetConnectionAsync();
            var cmd = new CommandDefinition(sql, server, cancellationToken: token);

            await connection.ExecuteAsync(cmd);
        }
    }
}
