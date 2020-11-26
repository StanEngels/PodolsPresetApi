using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PresetApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EffectType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Presets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    accountId = table.Column<int>(nullable: false),
                    presetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EffectsToPresets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PresetIdid = table.Column<int>(nullable: true),
                    EffectIdid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectsToPresets", x => x.id);
                    table.ForeignKey(
                        name: "FK_EffectsToPresets_Effects_EffectIdid",
                        column: x => x.EffectIdid,
                        principalTable: "Effects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EffectsToPresets_Presets_PresetIdid",
                        column: x => x.PresetIdid,
                        principalTable: "Presets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EffectsToPresets_EffectIdid",
                table: "EffectsToPresets",
                column: "EffectIdid");

            migrationBuilder.CreateIndex(
                name: "IX_EffectsToPresets_PresetIdid",
                table: "EffectsToPresets",
                column: "PresetIdid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EffectsToPresets");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "Presets");
        }
    }
}
