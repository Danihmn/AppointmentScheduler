using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentScheduler.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunasDeAutenticacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Secretaries",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Secretaries",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Secretaries_Username",
                table: "Secretaries",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Secretaries_Username",
                table: "Secretaries");

            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Secretaries");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Secretaries");
        }
    }
}
