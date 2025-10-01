using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeviceUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SIMCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "SIMCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "SIMCards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Modems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Modems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Modems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Modems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Modems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Modems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIMCards_CreatedByUserId",
                table: "SIMCards",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modems_CreatedByUserId",
                table: "Modems",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modems_ModifiedByUserId",
                table: "Modems",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modems_AspNetUsers_CreatedByUserId",
                table: "Modems",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modems_AspNetUsers_ModifiedByUserId",
                table: "Modems",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SIMCards_AspNetUsers_CreatedByUserId",
                table: "SIMCards",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modems_AspNetUsers_CreatedByUserId",
                table: "Modems");

            migrationBuilder.DropForeignKey(
                name: "FK_Modems_AspNetUsers_ModifiedByUserId",
                table: "Modems");

            migrationBuilder.DropForeignKey(
                name: "FK_SIMCards_AspNetUsers_CreatedByUserId",
                table: "SIMCards");

            migrationBuilder.DropIndex(
                name: "IX_SIMCards_CreatedByUserId",
                table: "SIMCards");

            migrationBuilder.DropIndex(
                name: "IX_Modems_CreatedByUserId",
                table: "Modems");

            migrationBuilder.DropIndex(
                name: "IX_Modems_ModifiedByUserId",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SIMCards");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SIMCards");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "SIMCards");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Modems");
        }
    }
}
