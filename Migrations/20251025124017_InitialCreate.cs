using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isgasoir.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filieres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qte = table.Column<double>(type: "float", nullable: false),
                    Pu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "semestrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiliereId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semestrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_semestrees_filieres_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "filieres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coiff = table.Column<double>(type: "float", nullable: false),
                    SemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modules_semestrees_SemId",
                        column: x => x.SemId,
                        principalTable: "semestrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chapitres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duree = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapitres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chapitres_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleStudant",
                columns: table => new
                {
                    ModulesId = table.Column<long>(type: "bigint", nullable: false),
                    StudantsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStudant", x => new { x.ModulesId, x.StudantsId });
                    table.ForeignKey(
                        name: "FK_ModuleStudant_modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleStudant_studants_StudantsId",
                        column: x => x.StudantsId,
                        principalTable: "studants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapitreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activities_chapitres_ChapitreId",
                        column: x => x.ChapitreId,
                        principalTable: "chapitres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activities_ChapitreId",
                table: "activities",
                column: "ChapitreId");

            migrationBuilder.CreateIndex(
                name: "IX_chapitres_ModuleId",
                table: "chapitres",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_modules_SemId",
                table: "modules",
                column: "SemId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudant_StudantsId",
                table: "ModuleStudant",
                column: "StudantsId");

            migrationBuilder.CreateIndex(
                name: "IX_semestrees_FiliereId",
                table: "semestrees",
                column: "FiliereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activities");

            migrationBuilder.DropTable(
                name: "ModuleStudant");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "chapitres");

            migrationBuilder.DropTable(
                name: "studants");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "semestrees");

            migrationBuilder.DropTable(
                name: "filieres");
        }
    }
}
