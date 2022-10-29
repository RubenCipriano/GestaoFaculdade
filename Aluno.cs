using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class Aluno
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime Data_Nascimento { get; set; } = DateTime.Now;
        public ICollection<Notas> Notas { get; set; }
        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}
