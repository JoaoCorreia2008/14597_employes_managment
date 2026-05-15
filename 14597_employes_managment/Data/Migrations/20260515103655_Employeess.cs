using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14597_employes_managment.Data.Migrations
{
    /// <inheritdoc />
    public partial class Employeess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Function",
                table: "Employees");
        }
    }
}
