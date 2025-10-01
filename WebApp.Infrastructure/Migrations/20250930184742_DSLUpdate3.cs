using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DSLUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "DSLs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "DSLs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "DSLs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DSLs_ModifiedByUserId",
                table: "DSLs",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DSLs_AspNetUsers_ModifiedByUserId",
                table: "DSLs",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSLs_AspNetUsers_ModifiedByUserId",
                table: "DSLs");

            migrationBuilder.DropIndex(
                name: "IX_DSLs_ModifiedByUserId",
                table: "DSLs");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "DSLs");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "DSLs");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "DSLs");
        }
    }
}
