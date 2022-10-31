using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI
{
    public class Notas
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Aluno Aluno { get; set; }

        public Disciplina Disciplina { get; set; }

        public int Nota { get; set; }
    }
}
