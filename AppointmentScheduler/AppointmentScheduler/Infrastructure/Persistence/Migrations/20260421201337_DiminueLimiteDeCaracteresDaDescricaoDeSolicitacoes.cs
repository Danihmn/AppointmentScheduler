using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentScheduler.Migrations
{
    /// <inheritdoc />
    public partial class DiminueLimiteDeCaracteresDaDescricaoDeSolicitacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_DesiredDate",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_Status_Priority_DesiredDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DesiredDate",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Medium");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Medium",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);

            migrationBuilder.AddColumn<DateTime>(
                name: "DesiredDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DesiredDate",
                table: "Requests",
                column: "DesiredDate");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Status_Priority_DesiredDate",
                table: "Requests",
                columns: new[] { "Status", "Priority", "DesiredDate" });
        }
    }
}
