using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectmanagementsystembackend.Migrations
{
    /// <inheritdoc />
    public partial class _18022023updatemanytomanytables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReqDoucmentId",
                table: "ReqirmentReqDoucment");

            migrationBuilder.DropColumn(
                name: "AssId",
                table: "EmployeeAssignment");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "EmployeeAssignment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReqDoucmentId",
                table: "ReqirmentReqDoucment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssId",
                table: "EmployeeAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "EmployeeAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
