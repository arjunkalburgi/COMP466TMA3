using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace part4.Migrations.ComputerCartItems
{
    public partial class ComputerCartItemsContextTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cartcomps",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CPUid = table.Column<Guid>(nullable: false),
                    Displayid = table.Column<Guid>(nullable: false),
                    HDid = table.Column<Guid>(nullable: false),
                    OSid = table.Column<Guid>(nullable: false),
                    RAMid = table.Column<Guid>(nullable: false),
                    SoundCardid = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 700, nullable: false),
                    image = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartcomps", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartcomps");
        }
    }
}
