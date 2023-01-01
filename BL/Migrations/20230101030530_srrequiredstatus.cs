using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class srrequiredstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TbServicesRequired",
                type: "nvarchar(max)",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TbServicesRequired");
        }
    }
}
