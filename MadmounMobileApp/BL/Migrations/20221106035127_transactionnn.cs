using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class transactionnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ServicesRequiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServicesOffersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceApprovedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceSyntax = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    SrRepId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    SrReqId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    SrOffId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ServiceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceCategoryName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ServiceApprovedMilstoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceApprovedMilstoneDesc = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContractPdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrApprovedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTransactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbTransactions");
        }
    }
}
