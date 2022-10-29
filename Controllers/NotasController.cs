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
    public class NotasController : ControllerBase
    {
        private readonly DataContext _context;

        public NotasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Notas>>> GetNotas()
        {
            var notas = await this._context.Notas.Include(notas => notas.Aluno).Include(notas => notas.Disciplina).ToListAsync();
            return Ok(notas);
        }

        [HttpPost]
        public async Task<ActionResult<EntityEntry<string>>> CreateNota(Notas notas)
        {
            _context.Notas.Add(notas);
            if (_context.SaveChanges() == 1)
                return Ok("A Nota foi inserida com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntityEntry<string>>> Delete(int id)
        {
            var foundObject = this._context.Notas.Find(id);
            this._context.Remove(foundObject);

            if (_context.SaveChanges() == 1)
                return Ok("A Nota foi removido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }
    }
}
