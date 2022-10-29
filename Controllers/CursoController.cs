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
    public class CursoController : ControllerBase
    {
        private readonly DataContext _context;

        public CursoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> GetCursos()
        {
            return Ok(await _context.Cursos.Include(curso => curso.Disciplinas).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<EntityEntry<string>>> CreateCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            if (_context.SaveChanges() == 1)
                return Ok("O Curso foi inserido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntityEntry<string>>> Delete(int id)
        {
            var foundObject = this._context.Disciplinas.Find(id);
            this._context.Remove(foundObject);

            if (_context.SaveChanges() == 1)
                return Ok("A Disciplina foi removido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }
    }
}
