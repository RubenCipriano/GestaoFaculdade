using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Data
{
    public class DataContext: DbContext

    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options){ }

        public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Professor> Professores => Set<Professor>();

        public DbSet<Disciplina> Disciplinas => Set<Disciplina>();

        public DbSet<Notas> Notas => Set<Notas>();

        public DbSet<Curso> Cursos => Set<Curso>();
    }
}
