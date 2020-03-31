using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCSP.MyAirport.EF.Migrations
{
    public partial class changeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VolId",
                table: "Vols",
                newName: "ID_VOL");

            migrationBuilder.RenameColumn(
                name: "BagageId",
                table: "Bagages",
                newName: "ID_BAGAGE");

            migrationBuilder.AlterColumn<string>(
                name: "Pkg",
                table: "Vols",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Pax",
                table: "Vols",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Lig",
                table: "Vols",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imm",
                table: "Vols",
                type: "char(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dhc",
                table: "Vols",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Des",
                table: "Vols",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cie",
                table: "Vols",
                type: "char(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sta",
                table: "Bagages",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Ssur",
                table: "Bagages",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Prioritaire",
                table: "Bagages",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Escale",
                table: "Bagages",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Bagages",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodeIata",
                table: "Bagages",
                type: "char(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Classe",
                table: "Bagages",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_VOL",
                table: "Vols",
                newName: "VolId");

            migrationBuilder.RenameColumn(
                name: "ID_BAGAGE",
                table: "Bagages",
                newName: "BagageId");

            migrationBuilder.AlterColumn<string>(
                name: "Pkg",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Pax",
                table: "Vols",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lig",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Imm",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dhc",
                table: "Vols",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Des",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cie",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Sta",
                table: "Bagages",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ssur",
                table: "Bagages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Prioritaire",
                table: "Bagages",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Escale",
                table: "Bagages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Bagages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodeIata",
                table: "Bagages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(12)");

            migrationBuilder.AlterColumn<string>(
                name: "Classe",
                table: "Bagages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);
        }
    }
}
