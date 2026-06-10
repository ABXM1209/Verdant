using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elements",
                table: "Ancestries");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activated = table.Column<bool>(type: "boolean", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AncestryId",
                table: "Players",
                column: "AncestryId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatureId",
                table: "Players",
                column: "CreatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ProfessionId",
                table: "Players",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementalAffinities_creatureId",
                table: "ElementalAffinities",
                column: "creatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTechniques_CreatureId",
                table: "CreatureTechniques",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTechniques_TechniqueId",
                table: "CreatureTechniques",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureProficiencies_CreatureId",
                table: "CreatureProficiencies",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureProficiencies_ProficiencyId",
                table: "CreatureProficiencies",
                column: "ProficiencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureProficiencies_Creatures_CreatureId",
                table: "CreatureProficiencies",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureProficiencies_Proficiencies_ProficiencyId",
                table: "CreatureProficiencies",
                column: "ProficiencyId",
                principalTable: "Proficiencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureTechniques_Creatures_CreatureId",
                table: "CreatureTechniques",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureTechniques_Techniques_TechniqueId",
                table: "CreatureTechniques",
                column: "TechniqueId",
                principalTable: "Techniques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementalAffinities_Creatures_creatureId",
                table: "ElementalAffinities",
                column: "creatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Ancestries_AncestryId",
                table: "Players",
                column: "AncestryId",
                principalTable: "Ancestries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Creatures_CreatureId",
                table: "Players",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Professions_ProfessionId",
                table: "Players",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatureProficiencies_Creatures_CreatureId",
                table: "CreatureProficiencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureProficiencies_Proficiencies_ProficiencyId",
                table: "CreatureProficiencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureTechniques_Creatures_CreatureId",
                table: "CreatureTechniques");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureTechniques_Techniques_TechniqueId",
                table: "CreatureTechniques");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementalAffinities_Creatures_creatureId",
                table: "ElementalAffinities");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Ancestries_AncestryId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Creatures_CreatureId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Professions_ProfessionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Players_AncestryId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CreatureId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ProfessionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_ElementalAffinities_creatureId",
                table: "ElementalAffinities");

            migrationBuilder.DropIndex(
                name: "IX_CreatureTechniques_CreatureId",
                table: "CreatureTechniques");

            migrationBuilder.DropIndex(
                name: "IX_CreatureTechniques_TechniqueId",
                table: "CreatureTechniques");

            migrationBuilder.DropIndex(
                name: "IX_CreatureProficiencies_CreatureId",
                table: "CreatureProficiencies");

            migrationBuilder.DropIndex(
                name: "IX_CreatureProficiencies_ProficiencyId",
                table: "CreatureProficiencies");

            migrationBuilder.AddColumn<string[]>(
                name: "Elements",
                table: "Ancestries",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }
    }
}
