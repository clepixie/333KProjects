using Microsoft.EntityFrameworkCore.Migrations;

namespace Team1_FinalProject.Migrations
{
    public partial class Setup19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FixPrice",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixPrice",
                table: "Tickets");
        }
    }
}
