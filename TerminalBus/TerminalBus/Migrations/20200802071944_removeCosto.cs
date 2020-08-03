using Microsoft.EntityFrameworkCore.Migrations;

namespace TerminalBus.Migrations
{
    public partial class removeCosto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "Viajes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Costo",
                table: "Viajes");
        }
    }
}
