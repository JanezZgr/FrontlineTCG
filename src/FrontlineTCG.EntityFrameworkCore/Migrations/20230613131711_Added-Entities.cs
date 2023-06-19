using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontlineTCG.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCardAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivationCount = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivationRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCardAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostMaterial = table.Column<int>(type: "int", nullable: false),
                    CostManpower = table.Column<int>(type: "int", nullable: false),
                    Ability1Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCards_AppCardAbilities_Ability1Id",
                        column: x => x.Ability1Id,
                        principalTable: "AppCardAbilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUnitCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DmgUnarmored = table.Column<int>(type: "int", nullable: false),
                    DmgArmored = table.Column<int>(type: "int", nullable: false),
                    DmgStructure = table.Column<int>(type: "int", nullable: false),
                    DmgAir = table.Column<int>(type: "int", nullable: false),
                    Ability2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUnitCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUnitCards_AppCardAbilities_Ability2Id",
                        column: x => x.Ability2Id,
                        principalTable: "AppCardAbilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUnitCards_AppCards_CardId",
                        column: x => x.CardId,
                        principalTable: "AppCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCards_Ability1Id",
                table: "AppCards",
                column: "Ability1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnitCards_Ability2Id",
                table: "AppUnitCards",
                column: "Ability2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnitCards_CardId",
                table: "AppUnitCards",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUnitCards");

            migrationBuilder.DropTable(
                name: "AppCards");

            migrationBuilder.DropTable(
                name: "AppCardAbilities");
        }
    }
}
