using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontlineTCG.Migrations
{
    /// <inheritdoc />
    public partial class AddedCardIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HP",
                table: "AppUnitCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Icon",
                table: "AppCards",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HP",
                table: "AppUnitCards");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "AppCards");
        }
    }
}
