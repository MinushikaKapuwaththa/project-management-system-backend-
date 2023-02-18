using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectmanagementsystembackend.Migrations
{
    /// <inheritdoc />
    public partial class _18022023updatemanytomanytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    AssId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AssigmentId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignment_assignment_AssigmentId",
                        column: x => x.AssigmentId,
                        principalTable: "assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignment_employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReqDocument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqDocument", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReqirmentReqDoucment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqirmentId = table.Column<int>(type: "int", nullable: false),
                    ReqDoucmentId = table.Column<int>(type: "int", nullable: false),
                    ReqDoucumentID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqirmentReqDoucment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReqirmentReqDoucment_ReqDocument_ReqDoucumentID",
                        column: x => x.ReqDoucumentID,
                        principalTable: "ReqDocument",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReqirmentReqDoucment_requirments_ReqirmentId",
                        column: x => x.ReqirmentId,
                        principalTable: "requirments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignment_AssigmentId",
                table: "EmployeeAssignment",
                column: "AssigmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignment_EmployeeID",
                table: "EmployeeAssignment",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ReqirmentReqDoucment_ReqDoucumentID",
                table: "ReqirmentReqDoucment",
                column: "ReqDoucumentID");

            migrationBuilder.CreateIndex(
                name: "IX_ReqirmentReqDoucment_ReqirmentId",
                table: "ReqirmentReqDoucment",
                column: "ReqirmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAssignment");

            migrationBuilder.DropTable(
                name: "ReqirmentReqDoucment");

            migrationBuilder.DropTable(
                name: "ReqDocument");
        }
    }
}
