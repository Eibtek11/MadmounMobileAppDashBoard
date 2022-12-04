using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class rayadah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RyadahOrNot",
                table: "TbServicesRequired",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "RyadahOrNot",
                table: "TbServicesRequired");
        }
    }
}
