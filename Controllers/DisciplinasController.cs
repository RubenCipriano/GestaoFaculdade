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
    public class DisciplinasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisciplinasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Disciplina>>> GetAlunos()
        {
            List<Disciplina> disciplinas = await _context.Disciplinas
                .Include(disciplina => disciplina.Alunos)
                .Include(dsciplina => dsciplina.Notas)
                .Include(disciplina => disciplina.Professor)
                .Include(disciplina => disciplina.Curso)
                .ToListAsync();
            return Ok(disciplinas);
        }

        [HttpPost]
        public async Task<ActionResult<EntityEntry<Disciplina>>> CreateAluno(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            if (_context.SaveChanges() == 1)
                return Ok("A Disciplina foi inserido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntityEntry<Disciplina>>> Delete(int id)
        {
            var foundObject = this._context.Disciplinas.Find(id);
            this._context.Remove(foundObject);

            if (_context.SaveChanges() == 1)
                return Ok("A Disciplina foi removido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EntityEntry<Professor>>> Edit(int id, Disciplina updatedObject)
        {
            var foundObject = this._context.Disciplinas.Find(id);
            foundObject = updatedObject;

            this._context.Entry(foundObject).CurrentValues.SetValues(updatedObject);

            if (_context.SaveChanges() == 1)
                return Ok("A Disciplina foi editada com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
            return Ok(foundObject);
        }
    }
}
