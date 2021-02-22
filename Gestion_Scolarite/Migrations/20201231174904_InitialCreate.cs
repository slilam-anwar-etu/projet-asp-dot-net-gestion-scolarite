using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Scolarite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_User_ID",
                        column: x => x.ID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DepartementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enseignant_Departement_DepartementID",
                        column: x => x.DepartementID,
                        principalTable: "Departement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseignant_User_ID",
                        column: x => x.ID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnseignantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Filiere_Enseignant_EnseignantID",
                        column: x => x.EnseignantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Niveau",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiliereID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveau", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Niveau_Filiere_FiliereID",
                        column: x => x.FiliereID,
                        principalTable: "Filiere",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NiveauID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Etudiant_Niveau_NiveauID",
                        column: x => x.NiveauID,
                        principalTable: "Niveau",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etudiant_User_ID",
                        column: x => x.ID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnseignantID = table.Column<int>(type: "int", nullable: false),
                    NiveauID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Module_Enseignant_EnseignantID",
                        column: x => x.EnseignantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Module_Niveau_NiveauID",
                        column: x => x.NiveauID,
                        principalTable: "Niveau",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnseignantID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    VolumeHoraire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matiere_Enseignant_EnseignantID",
                        column: x => x.EnseignantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matiere_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatiereID = table.Column<int>(type: "int", nullable: false),
                    EtudiantID = table.Column<int>(type: "int", nullable: false),
                    Note_Initiale = table.Column<int>(type: "int", nullable: true),
                    Note_Finale = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Matiere_MatiereID",
                        column: x => x.MatiereID,
                        principalTable: "Matiere",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatiereID = table.Column<int>(type: "int", nullable: false),
                    Date_Seance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heures = table.Column<int>(type: "int", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seance_Matiere_MatiereID",
                        column: x => x.MatiereID,
                        principalTable: "Matiere",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeanceID = table.Column<int>(type: "int", nullable: false),
                    EtudiantID = table.Column<int>(type: "int", nullable: false),
                    Absence_Justifie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    justification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fichier = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Absence_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absence_Seance_SeanceID",
                        column: x => x.SeanceID,
                        principalTable: "Seance",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_EtudiantID",
                table: "Absence",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_SeanceID",
                table: "Absence",
                column: "SeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_DepartementID",
                table: "Enseignant",
                column: "DepartementID");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_NiveauID",
                table: "Etudiant",
                column: "NiveauID");

            migrationBuilder.CreateIndex(
                name: "IX_Filiere_EnseignantID",
                table: "Filiere",
                column: "EnseignantID");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_EnseignantID",
                table: "Matiere",
                column: "EnseignantID");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_ModuleID",
                table: "Matiere",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_EnseignantID",
                table: "Module",
                column: "EnseignantID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_NiveauID",
                table: "Module",
                column: "NiveauID");

            migrationBuilder.CreateIndex(
                name: "IX_Niveau_FiliereID",
                table: "Niveau",
                column: "FiliereID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_EtudiantID",
                table: "Note",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_MatiereID",
                table: "Note",
                column: "MatiereID");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_MatiereID",
                table: "Seance",
                column: "MatiereID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Niveau");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
