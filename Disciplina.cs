using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class Disciplina
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Professor Professor { get; set; }

        public ICollection<Aluno> Alunos { get; set; }

        public Curso Curso { get; set; }

        public ICollection<Notas> Notas { get; set; }

        public double getNota()
        {
            if (this.Notas != null)
                return this.Notas.ToList().FindAll((nota) => nota.Disciplina.Id == this.Id).Average((nota) => nota.Nota);
            else
                return 0;
        }
    }
}
