using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModemTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems");

            migrationBuilder.AlterColumn<int>(
                name: "SimCardID",
                table: "Modems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems",
                column: "SimCardID",
                unique: true,
                filter: "[SimCardID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems");

            migrationBuilder.AlterColumn<int>(
                name: "SimCardID",
                table: "Modems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modems_SimCardID",
                table: "Modems",
                column: "SimCardID",
                unique: true);
        }
    }
}
