using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace My.Project.adk.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ecole",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecole", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EcoleID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Niveau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneeScolaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classe_Ecole_EcoleID",
                        column: x => x.EcoleID,
                        principalTable: "Ecole",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eleve",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClasseID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    DateNaissaince = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleve", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Eleve_Classe_ClasseID",
                        column: x => x.ClasseID,
                        principalTable: "Classe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classe_EcoleID",
                table: "Classe",
                column: "EcoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Eleve_ClasseID",
                table: "Eleve",
                column: "ClasseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eleve");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Ecole");
        }
    }
}
