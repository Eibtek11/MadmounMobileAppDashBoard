using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addtableofserviceoffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbServicesOfferss",
                columns: table => new
                {
                    ServicesOffersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OfferSyntax = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServiceOfferCost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServiceOfferDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrRepId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    SrReqId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    SrOffId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServicesRequiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbServicesOfferss", x => x.ServicesOffersId);
                    table.ForeignKey(
                        name: "FK_TbServicesOffers_TbServicesRequired",
                        column: x => x.ServicesRequiredId,
                        principalTable: "TbServicesRequired",
                        principalColumn: "ServicesRequiredId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbServicesOfferss_ServicesRequiredId",
                table: "TbServicesOfferss",
                column: "ServicesRequiredId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbServicesOfferss");
        }
    }
}
