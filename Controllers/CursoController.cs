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
                return Ok(curso);
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntityEntry<string>>> Delete(int id)
        {
            var foundObject = this._context.Cursos.Find(id);
            this._context.Remove(foundObject);

            if (_context.SaveChanges() == 1)
                return Ok("O Curso foi removido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EntityEntry<Curso>>> Edit(int id, Curso updatedObject)
        {
            var foundObject = this._context.Cursos
                .Include(include => include.Disciplinas)
                .FirstOrDefault(s => s.Id == id);

            foundObject.Nome = updatedObject.Nome;

            if (updatedObject.Disciplinas != null) foundObject.Disciplinas = updatedObject.Disciplinas;

            if (_context.SaveChanges() == 1)
                return Ok(foundObject);
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }
    }
}
