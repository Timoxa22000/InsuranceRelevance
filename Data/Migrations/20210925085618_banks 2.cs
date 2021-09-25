using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceRelevance.Data.Migrations
{
    public partial class banks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeCyclesIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTimeOffset>(nullable: false),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeCyclesIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractsBanks",
                columns: table => new
                {
                    ContarctId = table.Column<Guid>(nullable: false),
                    NumberContract = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    CompleteDate = table.Column<DateTimeOffset>(nullable: true),
                    CompletePlanDate = table.Column<DateTimeOffset>(nullable: true),
                    ContractAmount = table.Column<decimal>(nullable: true),
                    CompanyBankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsBanks", x => x.ContarctId);
                    table.ForeignKey(
                        name: "FK_ContractsBanks_CompanyBanks_CompanyBankId",
                        column: x => x.CompanyBankId,
                        principalTable: "CompanyBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceServices",
                columns: table => new
                {
                    InsuranceServiceId = table.Column<Guid>(nullable: false),
                    ServiceNumber = table.Column<string>(nullable: true),
                    InsuranceSum = table.Column<decimal>(nullable: false),
                    InsuranceRate = table.Column<decimal>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: false),
                    CompanyInsuranceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceServices", x => x.InsuranceServiceId);
                    table.ForeignKey(
                        name: "FK_InsuranceServices_CompanyInsurances_CompanyInsuranceId",
                        column: x => x.CompanyInsuranceId,
                        principalTable: "CompanyInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractsBanks_CompanyBankId",
                table: "ContractsBanks",
                column: "CompanyBankId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceServices_CompanyInsuranceId",
                table: "InsuranceServices",
                column: "CompanyInsuranceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractsBanks");

            migrationBuilder.DropTable(
                name: "InsuranceServices");

            migrationBuilder.DropTable(
                name: "LifeCyclesIS");

            migrationBuilder.DropTable(
                name: "CompanyBanks");

            migrationBuilder.DropTable(
                name: "CompanyInsurances");
        }
    }
}
