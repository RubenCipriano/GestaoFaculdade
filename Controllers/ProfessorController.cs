using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Professor>>> GetProfessor()
        {
            return Ok(await _context.Professores.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<EntityEntry<Professor>>> CreateProfessor(Professor professor)
        {
            _context.Professores.Add(professor);
            if (_context.SaveChanges() == 1)
                return Ok(professor);
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntityEntry<string>>> Delete(int id)
        {
            var foundObject = this._context.Professores.Find(id);
            this._context.Remove(foundObject);

            if (_context.SaveChanges() == 1)
                return Ok("O Professor foi removido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EntityEntry<Professor>>> Edit(int id, Professor updatedObject)
        {
            var foundObject = this._context.Professores.Find(id);

            foundObject.nome = updatedObject.nome;

            foundObject.salario = updatedObject.salario;

            if (foundObject.data_nascimento != null) foundObject.data_nascimento = updatedObject.data_nascimento;

            if (_context.SaveChanges() == 1)
                return Ok(foundObject);
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }
    }
}
