using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentScheduler.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunaDeRoleEmSecretarias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Secretaries",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Secretaries");
        }
    }
}
