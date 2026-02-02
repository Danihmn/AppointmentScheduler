using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentScheduler.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Appointments_ResultingAppointmentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ResultingAppointmentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResultingAppointmentId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Date",
                table: "Appointments",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RequestId",
                table: "Appointments",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Requests_RequestId",
                table: "Appointments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Requests_RequestId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Date",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_RequestId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "ResultingAppointmentId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ResultingAppointmentId",
                table: "Requests",
                column: "ResultingAppointmentId",
                unique: true,
                filter: "[ResultingAppointmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Appointments_ResultingAppointmentId",
                table: "Requests",
                column: "ResultingAppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
