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
            Create.Table("Locations")
                .WithColumn("Id").AsInt64().PrimaryKey("loactions_pk").Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Image").AsBinary()
                .WithColumn("ImageName");

            Create.Table("Servers")
                .WithColumn("Id").AsInt64().PrimaryKey("servers_pk").Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("IpAddress").AsString().NotNullable()
                .WithColumn("LocationId").AsInt64().ForeignKey("servers_locations_fk", "Locations", "Id").NotNullable();

            Create.Table("Users")
                .WithColumn("Id").AsInt64().PrimaryKey("users_pk").Identity()
                .WithColumn("Login").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("CreatedOn").AsDateTimeOffset().NotNullable()
                .WithColumn("ModifiedOn").AsDateTimeOffset()
                .WithColumn("CreatedBy").AsInt64().ForeignKey("users_created_by_fk", "Users", "Id").NotNullable()
                .WithColumn("ModifiedBy").AsInt64().ForeignKey("users_modified_by_fk", "Users", "Id");

            Create.Table("Sessions")
                .WithColumn("Id").AsInt64().PrimaryKey("sessions_pk").Identity()
                .WithColumn("ServerId").AsInt64().ForeignKey("sessions_servers_fk", "Servers", "Id").NotNullable()
                .WithColumn("UserId").AsInt64().ForeignKey("sessions_users_fk", "Users", "Id").NotNullable()
                .WithColumn("StartedOn").AsDateTimeOffset().NotNullable()
                .WithColumn("EndedOn").AsDateTimeOffset()
                .WithColumn("Duration").AsTime()
                .WithColumn("IsActive").AsBoolean().NotNullable();

            Create.Table("Admins")
                .WithColumn("Id").AsInt64().PrimaryKey("admins_pk").Identity()
                .WithColumn("UserId").AsInt16().ForeignKey("admins_users_fk", "Users", "Id").NotNullable()
                .WithColumn("CreatedOn").AsDateTimeOffset().NotNullable()
                .WithColumn("CreatedBy").AsInt16().ForeignKey("admins_created_by", "Users", "Id").NotNullable();
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
