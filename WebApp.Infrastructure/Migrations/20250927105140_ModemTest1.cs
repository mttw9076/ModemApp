using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModemTest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "Modems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Modems",
                newName: "ModemId");

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "ModemSimCardDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SimCardID",
                table: "Modems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Modems_ModemSimCardDetails_ModemSimCardDetailsSimCardId",
                table: "Modems",
                column: "ModemSimCardDetailsSimCardId",
                principalTable: "ModemSimCardDetails",
                principalColumn: "SimCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modems_ModemSimCardDetails_ModemSimCardDetailsSimCardId",
                table: "Modems");

            migrationBuilder.DropIndex(
                name: "IX_Modems_ModemSimCardDetailsSimCardId",
                table: "Modems");

            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "ModemSimCardDetails");

            migrationBuilder.DropColumn(
                name: "ModemSimCardDetailsSimCardId",
                table: "Modems");

            migrationBuilder.RenameColumn(
                name: "ModemId",
                table: "Modems",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "SimCardID",
                table: "Modems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "Modems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems",
                column: "SimCardID");
        }
    }
}
