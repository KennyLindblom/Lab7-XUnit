using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb7_XUnit.Migrations
{
    /// <inheritdoc />
    public partial class AddResultColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "CalculationLog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "CalculationLog");
        }
    }
}
