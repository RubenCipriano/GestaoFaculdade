﻿using Microsoft.AspNetCore.Http;
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
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> GetAlunos()
        {
            List<Aluno> alunos = await _context.Alunos.Include(aluno => aluno.Notas).Include(aluno => aluno.Disciplinas).ToListAsync();
            return Ok(alunos);
        }

        [HttpPost]
        public async Task<ActionResult<EntityEntry<string>>> CreateAluno(Aluno aluno)
        {
            Console.Write(aluno.Data_Nascimento);
            _context.Alunos.Add(aluno);
            if (_context.SaveChanges() == 1)
                return Ok("O Aluno foi inserido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntityEntry<string>>> Delete(int id)
        {
            var foundObject = this._context.Alunos.Find(id);
            this._context.Remove(foundObject);

            if (_context.SaveChanges() == 1)
                return Ok("O Aluno foi removido com sucesso!");
            else
                return BadRequest("Algo inexperado aconteceu, tente novamente mais tarde!");
        }
    }
}
