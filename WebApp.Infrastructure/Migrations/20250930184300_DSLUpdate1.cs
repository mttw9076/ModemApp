using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DSLUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSLs_AspNetUsers_CreatedById",
                table: "DSLs");

            migrationBuilder.DropIndex(
                name: "IX_DSLs_CreatedById",
                table: "DSLs");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DSLs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "DSLs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DSLs_CreatedByUserId",
                table: "DSLs",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DSLs_AspNetUsers_CreatedByUserId",
                table: "DSLs",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSLs_AspNetUsers_CreatedByUserId",
                table: "DSLs");

            migrationBuilder.DropIndex(
                name: "IX_DSLs_CreatedByUserId",
                table: "DSLs");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DSLs");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DSLs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
