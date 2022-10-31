using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI
{
    public class Disciplina
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public Professor Professor { get; set; }

        public ICollection<Aluno> Alunos { get; set; }

        public Curso Curso { get; set; }

        public ICollection<Notas> Notas { get; set; }
    }
}
