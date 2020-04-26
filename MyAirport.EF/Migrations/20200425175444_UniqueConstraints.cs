using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCSP.MyAirport.EF.Migrations
{
    public partial class UniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dhc",
                table: "Vols",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vols_Cie_Lig_Dhc",
                table: "Vols",
                columns: new[] { "Cie", "Lig", "Dhc" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bagages_CodeIata_DateCreation",
                table: "Bagages",
                columns: new[] { "CodeIata", "DateCreation" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vols_Cie_Lig_Dhc",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Bagages_CodeIata_DateCreation",
                table: "Bagages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dhc",
                table: "Vols",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
