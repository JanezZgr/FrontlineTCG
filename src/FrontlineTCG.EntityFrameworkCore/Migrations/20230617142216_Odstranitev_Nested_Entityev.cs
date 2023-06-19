using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontlineTCG.Migrations
{
    /// <inheritdoc />
    public partial class OdstranitevNestedEntityev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCards_AppCardAbilities_Ability1Id",
                table: "AppCards");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUnitCards_AppCardAbilities_Ability2Id",
                table: "AppUnitCards");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUnitCards_AppCards_CardId",
                table: "AppUnitCards");

            migrationBuilder.DropIndex(
                name: "IX_AppCards_Ability1Id",
                table: "AppCards");

            migrationBuilder.DropColumn(
                name: "Ability1Id",
                table: "AppCards");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "AppUnitCards",
                newName: "Card");

            migrationBuilder.RenameColumn(
                name: "Ability2Id",
                table: "AppUnitCards",
                newName: "Ability2");

            migrationBuilder.RenameIndex(
                name: "IX_AppUnitCards_CardId",
                table: "AppUnitCards",
                newName: "IX_AppUnitCards_Card");

            migrationBuilder.RenameIndex(
                name: "IX_AppUnitCards_Ability2Id",
                table: "AppUnitCards",
                newName: "IX_AppUnitCards_Ability2");

            migrationBuilder.AddColumn<int>(
                name: "Ability1",
                table: "AppCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppCards_Ability1",
                table: "AppCards",
                column: "Ability1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnitCards_AppCards_Card",
                table: "AppUnitCards",
                column: "Card",
                principalTable: "AppCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropForeignKey(
                name: "FK_AppUnitCards_AppCards_Card",
                table: "AppUnitCards");

            migrationBuilder.DropIndex(
                name: "IX_AppCards_Ability1",
                table: "AppCards");

            migrationBuilder.DropColumn(
                name: "Ability1",
                table: "AppCards");

            migrationBuilder.RenameColumn(
                name: "Card",
                table: "AppUnitCards",
                newName: "CardId");

            migrationBuilder.RenameColumn(
                name: "Ability2",
                table: "AppUnitCards",
                newName: "Ability2Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppUnitCards_Card",
                table: "AppUnitCards",
                newName: "IX_AppUnitCards_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUnitCards_Ability2",
                table: "AppUnitCards",
                newName: "IX_AppUnitCards_Ability2Id");

            migrationBuilder.AddColumn<int>(
                name: "Ability1Id",
                table: "AppCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCards_Ability1Id",
                table: "AppCards",
                column: "Ability1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCards_AppCardAbilities_Ability1Id",
                table: "AppCards",
                column: "Ability1Id",
                principalTable: "AppCardAbilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnitCards_AppCardAbilities_Ability2Id",
                table: "AppUnitCards",
                column: "Ability2Id",
                principalTable: "AppCardAbilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnitCards_AppCards_CardId",
                table: "AppUnitCards",
                column: "CardId",
                principalTable: "AppCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
