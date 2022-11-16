using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class serviceFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbServicesFinished",
                columns: table => new
                {
                    ServiceFinishedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ServiceApprovedId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 450, nullable: true),
                    ServiceSyntax = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    ContractPdf = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SrApprovedDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbServicesFinished", x => x.ServiceFinishedId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbServicesFinished");
        }
    }
}
