using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MamatVPN.DAL.Options;

namespace MamatVPN.DAL.Infrastructure
{
    public static class Sqlite
    {
        public static void AddMigrations(IServiceCollection services)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb.AddSQLite()
                    .WithGlobalConnectionString(s =>
                    {
                        var cfg = s.GetRequiredService<IOptions<DbConnectionOptions>>();
                        return cfg.Value.SqlLiteConnectionString;
                    }).ScanIn(typeof(Sqlite).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}
