using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class final1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIMCards_Modems_ModemId",
                table: "SIMCards");

            migrationBuilder.AddForeignKey(
                name: "FK_SIMCards_Modems_ModemId",
                table: "SIMCards",
                column: "ModemId",
                principalTable: "Modems",
                principalColumn: "ModemId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIMCards_Modems_ModemId",
                table: "SIMCards");

            migrationBuilder.AddForeignKey(
                name: "FK_SIMCards_Modems_ModemId",
                table: "SIMCards",
                column: "ModemId",
                principalTable: "Modems",
                principalColumn: "ModemId");
        }
    }
}
