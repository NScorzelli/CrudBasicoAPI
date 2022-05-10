using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }
        // CRUD = CREATE

        [HttpPost]
        public IActionResult AdicionaFilmes([FromBody] Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { Id = filme.Id }, filme);
        }

        // CRUD = READ

        [HttpGet]
        public IActionResult ListaFilmes()
        {
            return  Ok(_context.Filmes);
        }

        // CRUD = READ 

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            foreach (Filme filme in _context.Filmes)
            {
                if (filme.Id == id)
                {
                    return Ok(filme);
                }
            }
            return NotFound();
        }

        // CRUD = GETFILME

        [HttpPut("{id}")]
        public IActionResult EditaFilme(int id, [FromBody] Filme filmeNovo)
        {
            foreach (Filme filme in _context.Filmes)
            {
                if (filme.Id == id)
                {
                    filme.Titulo = filmeNovo.Titulo;
                    filme.Diretor = filmeNovo.Diretor;
                    filme.Genero = filmeNovo.Genero;
                    filme.Duracao = filmeNovo.Duracao;

                    _context.SaveChanges();
                    return NoContent();
                }
            }
            return NotFound();
        }

        // CRUD = REMOVE FILME

        [HttpDelete("{id}")]
        public IActionResult RemoveFilme(int id)
        {
            foreach (Filme filme in _context.Filmes)
            {
                if (filme.Id == id)
                {
                    _context.Filmes.Remove(filme);
                    _context.SaveChanges();
                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
