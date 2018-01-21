using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace part4.Migrations.Computer
{
    public partial class ComputersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 700, nullable: false),
                    image = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "computeritems",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CPUid = table.Column<Guid>(nullable: true),
                    Displayid = table.Column<Guid>(nullable: true),
                    HDid = table.Column<Guid>(nullable: true),
                    OSid = table.Column<Guid>(nullable: true),
                    RAMid = table.Column<Guid>(nullable: true),
                    SoundCardid = table.Column<Guid>(nullable: true),
                    description = table.Column<string>(maxLength: 700, nullable: false),
                    image = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computeritems", x => x.id);
                    table.ForeignKey(
                        name: "FK_computeritems_products_CPUid",
                        column: x => x.CPUid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_computeritems_products_Displayid",
                        column: x => x.Displayid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_computeritems_products_HDid",
                        column: x => x.HDid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_computeritems_products_OSid",
                        column: x => x.OSid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_computeritems_products_RAMid",
                        column: x => x.RAMid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_computeritems_products_SoundCardid",
                        column: x => x.SoundCardid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_computeritems_CPUid",
                table: "computeritems",
                column: "CPUid");

            migrationBuilder.CreateIndex(
                name: "IX_computeritems_Displayid",
                table: "computeritems",
                column: "Displayid");

            migrationBuilder.CreateIndex(
                name: "IX_computeritems_HDid",
                table: "computeritems",
                column: "HDid");

            migrationBuilder.CreateIndex(
                name: "IX_computeritems_OSid",
                table: "computeritems",
                column: "OSid");

            migrationBuilder.CreateIndex(
                name: "IX_computeritems_RAMid",
                table: "computeritems",
                column: "RAMid");

            migrationBuilder.CreateIndex(
                name: "IX_computeritems_SoundCardid",
                table: "computeritems",
                column: "SoundCardid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computeritems");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
