using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceRelevance.Data.Migrations
{
    public partial class IS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceServiceId",
                table: "LifeCyclesIS",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LifeCyclesIS_InsuranceServiceId",
                table: "LifeCyclesIS",
                column: "InsuranceServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_LifeCyclesIS_InsuranceServices_InsuranceServiceId",
                table: "LifeCyclesIS",
                column: "InsuranceServiceId",
                principalTable: "InsuranceServices",
                principalColumn: "InsuranceServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LifeCyclesIS_InsuranceServices_InsuranceServiceId",
                table: "LifeCyclesIS");

            migrationBuilder.DropIndex(
                name: "IX_LifeCyclesIS_InsuranceServiceId",
                table: "LifeCyclesIS");

            migrationBuilder.DropColumn(
                name: "InsuranceServiceId",
                table: "LifeCyclesIS");
        }
    }
}
