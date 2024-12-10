using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeAddtionalImgFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
