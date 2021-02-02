using Microsoft.EntityFrameworkCore.Migrations;

namespace TruckerMicroservice.Migrations
{
    public partial class MODIFIED_FREIGHT_REGISTER_TABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreightId",
                table: "FREIGHT_REGISTER",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreightId",
                table: "FREIGHT_REGISTER");
        }
    }
}
