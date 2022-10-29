using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class Disciplina_Curso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Cursos_CursoId",
                table: "Disciplinas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Cursos_CursoId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Disciplinas");

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursosId = table.Column<int>(type: "int", nullable: false),
                    DisciplinasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursosId, x.DisciplinasId });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinasId",
                table: "CursoDisciplina",
                column: "DisciplinasId");
        }
    }
}
