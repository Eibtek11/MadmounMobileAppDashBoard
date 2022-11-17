using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class servicenameandserviceimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceImage",
                table: "TbServicesRequired",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "TbServicesRequired",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceImage",
                table: "TbServicesRequired");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "TbServicesRequired");
        }
    }
}
