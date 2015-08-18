using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace PhonePAMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column(type: "INTEGER", nullable: false),
                    //    .Annotation("Sqlite:Autoincrement", true),
                    Blocked = table.Column(type: "INTEGER", nullable: false),
                    Message = table.Column(type: "TEXT", nullable: true),
                    Name = table.Column(type: "TEXT", nullable: true),
                    Number = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Contact");
        }
    }
}
