using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SchemaChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ancestries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lifespan = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Elements = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'[]'::jsonb"),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ancestries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatureType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Str = table.Column<int>(type: "integer", nullable: false),
                    Agi = table.Column<int>(type: "integer", nullable: false),
                    Dur = table.Column<int>(type: "integer", nullable: false),
                    Spi = table.Column<int>(type: "integer", nullable: false),
                    HpMax = table.Column<int>(type: "integer", nullable: false),
                    SpMax = table.Column<int>(type: "integer", nullable: false),
                    HpCurrent = table.Column<int>(type: "integer", nullable: false),
                    SpCurrent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    WeightClassEnum = table.Column<int>(type: "integer", nullable: false),
                    TypeEnum = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StarterAttribute = table.Column<int>(type: "integer", nullable: false),
                    StarterMastery = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryEnum = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RequiredSkill = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AncestralTraits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AncestryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AncestralTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AncestralTraits_Ancestries_AncestryId",
                        column: x => x.AncestryId,
                        principalTable: "Ancestries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementalAffinities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    AffinityRoll = table.Column<int>(type: "integer", nullable: false),
                    Elements = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementalAffinities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementalAffinities_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureProficiencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProficiencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureProficiencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureProficiencies_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureProficiencies_Proficiencies_ProficiencyId",
                        column: x => x.ProficiencyId,
                        principalTable: "Proficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTechniques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechniqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTechniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureTechniques_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTechniques_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    AncestryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Ancestries_AncestryId",
                        column: x => x.AncestryId,
                        principalTable: "Ancestries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentTier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerProfessions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerProfessions_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AncestralTraits_AncestryId",
                table: "AncestralTraits",
                column: "AncestryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureProficiencies_CreatureId",
                table: "CreatureProficiencies",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureProficiencies_ProficiencyId",
                table: "CreatureProficiencies",
                column: "ProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTechniques_CreatureId",
                table: "CreatureTechniques",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTechniques_TechniqueId",
                table: "CreatureTechniques",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementalAffinities_CreatureId",
                table: "ElementalAffinities",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfessions_PlayerId",
                table: "PlayerProfessions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfessions_ProfessionId",
                table: "PlayerProfessions",
                column: "ProfessionId");

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
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AncestralTraits");

            migrationBuilder.DropTable(
                name: "CreatureProficiencies");

            migrationBuilder.DropTable(
                name: "CreatureTechniques");

            migrationBuilder.DropTable(
                name: "ElementalAffinities");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PlayerProfessions");

            migrationBuilder.DropTable(
                name: "Proficiencies");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Ancestries");

            migrationBuilder.DropTable(
                name: "Creatures");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
