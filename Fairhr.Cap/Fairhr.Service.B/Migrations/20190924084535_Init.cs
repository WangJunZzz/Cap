using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fairhr.Service.B.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    OrderId = table.Column<string>(maxLength: 64, nullable: true),
                    stauts = table.Column<int>(type: "int(2)", nullable: false, defaultValue: 0),
                    Money = table.Column<string>(maxLength: 32, nullable: true),
                    CrateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayInfo");
        }
    }
}
