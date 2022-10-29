using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class Notas
    {
        public int Id { get; set; }
        
        public Aluno Aluno { get; set; }

        public Disciplina Disciplina { get; set; }

        public int Nota { get; set; }
    }
}
