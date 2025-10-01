using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestModemito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modems_ModemSimCardDetails_SimCardId",
                table: "Modems");

            migrationBuilder.DropTable(
                name: "ModemSimCardDetails");

            migrationBuilder.DropIndex(
                name: "IX_Modems_SimCardId",
                table: "Modems");

            migrationBuilder.DropColumn(
                name: "ShopID",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "SimCardId",
                table: "Modems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shops",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "shopNumber",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SIMCards",
                columns: table => new
                {
                    SIMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USIM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PUK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Op = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIMCards", x => x.SIMId);
                    table.ForeignKey(
                        name: "FK_SIMCards_Modems_ModemId",
                        column: x => x.ModemId,
                        principalTable: "Modems",
                        principalColumn: "ModemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIMCards_ModemId",
                table: "SIMCards",
                column: "ModemId",
                unique: true,
                filter: "[ModemId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIMCards");

            migrationBuilder.DropColumn(
                name: "shopNumber",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Shops",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ShopID",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SimCardId",
                table: "Modems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModemSimCardDetails",
                columns: table => new
                {
                    SimCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Op = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PUK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USIM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModemSimCardDetails", x => x.SimCardId);
                });

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
    }
}
