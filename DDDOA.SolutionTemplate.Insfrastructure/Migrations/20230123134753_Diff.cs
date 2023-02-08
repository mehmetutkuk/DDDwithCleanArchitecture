using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDOA.SolutionTemplate.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Diff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Forecast",
                table: "Forecast");

            migrationBuilder.RenameTable(
                name: "Forecast",
                newName: "Forecasts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forecasts",
                table: "Forecasts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Forecasts",
                table: "Forecasts");

            migrationBuilder.RenameTable(
                name: "Forecasts",
                newName: "Forecast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forecast",
                table: "Forecast",
                column: "Id");
        }
    }
}
