using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace MamatVPN.DAL.Migratioons
{
    [Migration(1, TransactionBehavior.None)]
    public class InitSchema : Migration
    {
        public override void Up()
        {
            Create.Table("locations")
                .WithColumn("id").AsInt64().PrimaryKey("loactions_pk").Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("image").AsBinary()
                .WithColumn("image_name");

            Create.Table("servers")
                .WithColumn("id").AsInt64().PrimaryKey("servers_pk").Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("ip_address").AsString().NotNullable()
                .WithColumn("location_id").AsInt64().ForeignKey("servers_locations_fk", "location", "id").NotNullable();

            Create.Table("users")
                .WithColumn("id").AsInt64().PrimaryKey("users_pk").Identity()
                .WithColumn("login").AsString().NotNullable()
                .WithColumn("password").AsString().NotNullable()
                .WithColumn("created_on").AsDateTimeOffset().NotNullable()
                .WithColumn("modified_on").AsDateTimeOffset()
                .WithColumn("created_by").AsInt64().ForeignKey("users_created_by_fk", "users", "id").NotNullable()
                .WithColumn("modified_by").AsInt64().ForeignKey("users_modified_by_fk", "users", "id");

            Create.Table("sessions")
                .WithColumn("id").AsInt64().PrimaryKey("sessions_pk").Identity()
                .WithColumn("server_id").AsInt64().ForeignKey("sessions_servers_fk", "servers", "id").NotNullable()
                .WithColumn("user_id").AsInt64().ForeignKey("sessions_users_fk", "users", "id").NotNullable()
                .WithColumn("started_on").AsDateTimeOffset().NotNullable()
                .WithColumn("ended_on").AsDateTimeOffset()
                .WithColumn("duration").AsTime()
                .WithColumn("is_active").AsBoolean().NotNullable();

            Create.Table("admins")
                .WithColumn("id").AsInt64().PrimaryKey("admins_pk").Identity()
                .WithColumn("user_id").AsInt16().ForeignKey("admins_users_fk", "users", "id").NotNullable()
                .WithColumn("created_on").AsDateTimeOffset().NotNullable()
                .WithColumn("created_by").AsInt16().ForeignKey("admins_created_by", "users", "id").NotNullable();
        }

        public override void Down()
        {
            Delete.Table("locations");
            Delete.Table("servers");
            Delete.Table("users");
            Delete.Table("sessions");
            Delete.Table("admins");
        }
    }
}
