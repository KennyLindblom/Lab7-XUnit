using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb7_XUnit.Migrations
{
    /// <inheritdoc />
    public partial class classnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalculatorLogs",
                table: "CalculatorLogs");

            migrationBuilder.RenameTable(
                name: "CalculatorLogs",
                newName: "CalculationLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalculationLog",
                table: "CalculationLog",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalculationLog",
                table: "CalculationLog");

            migrationBuilder.RenameTable(
                name: "CalculationLog",
                newName: "CalculatorLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalculatorLogs",
                table: "CalculatorLogs",
                column: "Id");
        }
    }
}
