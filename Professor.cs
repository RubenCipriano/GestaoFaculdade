using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class Professor
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; } = DateTime.Now;

        public int salario { get; set; } = 0;
    }
}
