using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addtosrrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SrReqName",
                table: "TbServicesRequired",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrReqName",
                table: "TbServicesRequired");
        }
    }
}
