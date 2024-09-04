using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tryToAvoidTriggersProblemWithSave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Carts",
                newName: "LastUpdate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Carts",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "Carts",
                newName: "LastUpdated");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Carts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
