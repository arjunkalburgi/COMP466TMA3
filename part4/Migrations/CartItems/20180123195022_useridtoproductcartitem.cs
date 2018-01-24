using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace part4.Migrations.CartItems
{
    public partial class useridtoproductcartitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "userid",
                table: "cartitems",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userid",
                table: "cartitems");
        }
    }
}
