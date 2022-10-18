using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class AdsAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisementss",
                columns: table => new
                {
                    AdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AdvertisementName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdvertisementDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdvertisementImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisementss", x => x.AdvertisementId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisementss");
        }
    }
}
