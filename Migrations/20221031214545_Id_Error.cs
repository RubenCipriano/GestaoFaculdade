using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class Id_Error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_Alunos_AlunosId",
                table: "AlunoDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_Disciplinas_DisciplinasId",
                table: "AlunoDisciplina");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Professores",
                newName: "ProfessorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notas",
                newName: "NotasId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Disciplinas",
                newName: "DisciplinaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cursos",
                newName: "CursoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alunos",
                newName: "AlunoId");

            migrationBuilder.RenameColumn(
                name: "DisciplinasId",
                table: "AlunoDisciplina",
                newName: "DisciplinasDisciplinaId");

            migrationBuilder.RenameColumn(
                name: "AlunosId",
                table: "AlunoDisciplina",
                newName: "AlunosAlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoDisciplina_DisciplinasId",
                table: "AlunoDisciplina",
                newName: "IX_AlunoDisciplina_DisciplinasDisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_Alunos_AlunosAlunoId",
                table: "AlunoDisciplina",
                column: "AlunosAlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_Disciplinas_DisciplinasDisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinasDisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_Alunos_AlunosAlunoId",
                table: "AlunoDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_Disciplinas_DisciplinasDisciplinaId",
                table: "AlunoDisciplina");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Professores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NotasId",
                table: "Notas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DisciplinaId",
                table: "Disciplinas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Cursos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Alunos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DisciplinasDisciplinaId",
                table: "AlunoDisciplina",
                newName: "DisciplinasId");

            migrationBuilder.RenameColumn(
                name: "AlunosAlunoId",
                table: "AlunoDisciplina",
                newName: "AlunosId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoDisciplina_DisciplinasDisciplinaId",
                table: "AlunoDisciplina",
                newName: "IX_AlunoDisciplina_DisciplinasId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_Alunos_AlunosId",
                table: "AlunoDisciplina",
                column: "AlunosId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_Disciplinas_DisciplinasId",
                table: "AlunoDisciplina",
                column: "DisciplinasId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
