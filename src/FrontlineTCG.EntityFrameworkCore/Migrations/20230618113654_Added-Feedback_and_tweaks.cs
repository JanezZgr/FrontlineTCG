using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontlineTCG.Migrations
{
    /// <inheritdoc />
    public partial class AddedFeedbackandtweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCards_AppCardAbilities_Ability1",
                table: "AppCards");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUnitCards_AppCardAbilities_Ability2",
                table: "AppUnitCards");

            migrationBuilder.AlterColumn<int>(
                name: "Ability1",
                table: "AppCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "ActivationRange",
                table: "AppCardAbilities",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AppCardFeedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserPosted = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Card = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BalanceScore = table.Column<byte>(type: "tinyint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCardFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCardFeedbacks_AppCards_Card",
                        column: x => x.Card,
                        principalTable: "AppCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCardFeedbacks_Card",
                table: "AppCardFeedbacks",
                column: "Card");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCards_AppCardAbilities_Ability1",
                table: "AppCards",
                column: "Ability1",
                principalTable: "AppCardAbilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnitCards_AppCardAbilities_Ability2",
                table: "AppUnitCards",
                column: "Ability2",
                principalTable: "AppCardAbilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCards_AppCardAbilities_Ability1",
                table: "AppCards");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUnitCards_AppCardAbilities_Ability2",
                table: "AppUnitCards");

            migrationBuilder.DropTable(
                name: "AppCardFeedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "Ability1",
                table: "AppCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivationRange",
                table: "AppCardAbilities",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCards_AppCardAbilities_Ability1",
                table: "AppCards",
                column: "Ability1",
                principalTable: "AppCardAbilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnitCards_AppCardAbilities_Ability2",
                table: "AppUnitCards",
                column: "Ability2",
                principalTable: "AppCardAbilities",
                principalColumn: "Id");
        }
    }
}
