using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DSLUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DSLs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DSLs_CreatedById",
                table: "DSLs",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DSLs_AspNetUsers_CreatedById",
                table: "DSLs",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSLs_AspNetUsers_CreatedById",
                table: "DSLs");

            migrationBuilder.DropIndex(
                name: "IX_DSLs_CreatedById",
                table: "DSLs");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DSLs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DSLs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DSLs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "DSLs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "DSLs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
