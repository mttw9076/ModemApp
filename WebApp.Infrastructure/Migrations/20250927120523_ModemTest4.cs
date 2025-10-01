using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModemTest4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modems_ModemSimCardDetails_ModemSimCardDetailsSimCardId",
                table: "Modems");

            migrationBuilder.DropForeignKey(
                name: "FK_Modems_ModemSimCardDetails_SimCardID",
                table: "Modems");

            migrationBuilder.DropIndex(
                name: "IX_Modems_ModemSimCardDetailsSimCardId",
                table: "Modems");

            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "ModemSimCardDetailsSimCardId",
                table: "Modems");

            migrationBuilder.RenameColumn(
                name: "SimCardID",
                table: "Modems",
                newName: "SimCardId");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceType",
                table: "Modems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modems_SimCardId",
                table: "Modems",
                column: "SimCardId",
                unique: true,
                filter: "[SimCardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Modems_ModemSimCardDetails_SimCardId",
                table: "Modems",
                column: "SimCardId",
                principalTable: "ModemSimCardDetails",
                principalColumn: "SimCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modems_ModemSimCardDetails_SimCardId",
                table: "Modems");

            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardId",
                table: "Modems");

            migrationBuilder.RenameColumn(
                name: "SimCardId",
                table: "Modems",
                newName: "SimCardID");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceType",
                table: "Modems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ModemSimCardDetailsSimCardId",
                table: "Modems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modems_ModemSimCardDetailsSimCardId",
                table: "Modems",
                column: "ModemSimCardDetailsSimCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems",
                column: "SimCardID",
                unique: true,
                filter: "[SimCardID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Modems_ModemSimCardDetails_ModemSimCardDetailsSimCardId",
                table: "Modems",
                column: "ModemSimCardDetailsSimCardId",
                principalTable: "ModemSimCardDetails",
                principalColumn: "SimCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modems_ModemSimCardDetails_SimCardID",
                table: "Modems",
                column: "SimCardID",
                principalTable: "ModemSimCardDetails",
                principalColumn: "SimCardId");
        }
    }
}
