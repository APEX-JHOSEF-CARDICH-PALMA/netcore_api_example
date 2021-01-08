using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_api_example.Migrations
{
    public partial class addOwnerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "gestores_bd",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "owner",
                table: "gestores_bd");
        }
    }
}
