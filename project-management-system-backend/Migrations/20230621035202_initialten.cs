using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectmanagementsystembackend.Migrations
{
    /// <inheritdoc />
    public partial class initialten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Documents",
                newName: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Documents",
                newName: "ClientName");
        }
    }
}
